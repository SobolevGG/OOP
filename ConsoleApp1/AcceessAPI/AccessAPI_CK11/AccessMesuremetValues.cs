using AcceessAPI.AccessAPI_CK11;
using AcceessAPI.Object;
using Newtonsoft.Json;
using NLog;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using static AcceessAPI.AccessAPI_CK11.AccessMesuremetValues;


namespace AcceessAPI.AccessAPI_CK11
{
    /// <summary>
    /// Класс для получения значений измерений через API СК-11
    /// по одному UID за определенный промежуток времени.
    /// </summary>
    public class AccessMesuremetValues
    {
        /// <summary>
        /// Лог
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// UID измерения.
        /// </summary>
        private string[] _uids;

        /// <summary>
        /// Тип измерения (например numeric)
        /// </summary>
        private string _typeMeasure;

        /// <summary>
        /// Время начала сбора измерений.
        /// По умолчанию - за 2 дня до текущего времени.
        /// </summary>
        private DateTime _dateStamp;// = DateTime.Now.Subtract(new TimeSpan(0, 0, 0, 20));

        /// <summary>
        /// Время конца сбора измерений.
        /// По умолчанию - последнее измерение.
        /// </summary>
        private DateTime _dateEnd; // = DateTime.Now;

        /// <summary>
        /// Экземпляр класса ListMeasurementValues, содержащий
        /// информаицию о собранных измерениях за период.
        /// </summary>
        private ListMeasurementValues _listMeasurementValues = null;

        /// <summary>
        /// Экземпляр класса ListMeasurementValuesExtend, содержащий
        /// информаицию о собранных измерениях за период.
        /// </summary>
        private ListMeasurementValuesExtend _listMeasurementValuesExtend = null;

        /// <summary>
        /// Параметры для запросов адресов и токена с API.
        /// Включает в себя имя домена и версию подключения (например "2.1")
        /// </summary>
        private SettingAccessAPI _settingAPI;

        /// <summary>
        /// Параметры для запросов значений измерений с API.
        /// Включает в себя имя домена и версию подключения (например "2.1")
        /// </summary>
        private SettingMeasurementAPI _settingMeasurementAPI;

        /// <summary>
        /// UID измерения.
        /// </summary>
        public string[] UIDs
        {
            get { return _uids; }
            set { _uids = value; }
        }

        /// <summary>
        /// Тип измерения (например numeric)
        /// </summary>
        public string TypeMeasure
        {
            get { return _typeMeasure; }
            set { _typeMeasure = value; }
        }

        /// <summary>
        /// Время конца сбора измерений.
        /// </summary>
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }

        /// <summary>
        /// Время начала сбора измерений.
        /// По умолчанию - за 2 дня до текущего времени
        /// </summary>
        public DateTime DateStamp
        {
            get { return _dateStamp; }
            set { _dateStamp = value; }
        }

        /// <summary>
        /// Параметры для запросов адресов и токена с API. 
        /// Включает в себя имя домена и версию подключения (например "2.1")
        /// </summary>
        public SettingAccessAPI SettingAPI
        {
            get { return _settingAPI; }
            set { _settingAPI = value; }
        }

        /// <summary>
        /// Параметры для запросов значений измерений с API. 
        /// Включает в себя имя домена и версию подключения (например "2.1")
        /// </summary>
        public SettingMeasurementAPI SettingMeasureAPI
        {
            get { return _settingMeasurementAPI; }
            set { _settingMeasurementAPI = value; }
        }

        /// <summary>
        /// Токен для доступа к измерениям.
        /// </summary>
        public Token Token
        {
            get { return new AccessRequestToken(SettingAPI).Token; }
        }

        /// <summary>
        /// Экземпляр класса ListMeasurementValues, содержащий
        /// информаицию о собранных измерениях за период.
        /// </summary>
        public ListMeasurementValues ListMeasurementValues
        {
            get { return GetMeasurementValuesArray().Result; }
            set { _listMeasurementValues = GetMeasurementValuesArray().Result; }
        }


        /// <summary>
        /// Экземпляр класса ListMeasurementValues, содержащий
        /// информацию о собранных измерениях за период.
        /// </summary>
        public ListMeasurementValuesExtend ListMeasurementValuesExtend
        {
            get { return GetMeasurementValuesArrayInRange("2024-01-10T00:00:00Z", "2024-01-10T23:00:00Z").Result; }
            set { _listMeasurementValuesExtend = GetMeasurementValuesArrayInRange("2024-01-10T00:00:00Z", "2024-01-10T23:00:00Z").Result; }
        }

        /// <summary>
        /// Конуструктор класса
        /// </summary>
        /// <param name="uid">UID измерения.</param>
        /// <param name="dateStamp">Время начала сбора измерений.</param>
        /// <param name="dateEnd">Время конца сбора измерений.</param>
        /// <param name="settingAccessAPI">Параметры для запроса измерений по API. 
        /// Включает в себя имя домена и версию подключения (например "2.1").</param>
        /// <param name="typeMeasure">Тип измерения (например numeric).</param>
        public AccessMesuremetValues(string[] uid, DateTime dateStamp, DateTime dateEnd,
                                     SettingMeasurementAPI settingAccessAPI, string typeMeasure)
        {
            UIDs = uid;
            DateStamp = dateStamp;
            DateEnd = dateEnd;
            SettingMeasureAPI = settingAccessAPI;
            TypeMeasure = typeMeasure;
        }

        /// <summary>
        /// Конуструктор класса
        /// </summary>
        /// <param name="uids">UID измерений.</param>
        public AccessMesuremetValues(string[] uids, SettingAccessAPI settingAccessAPI, SettingMeasurementAPI settingMeasurement, string typeMeasure)
        {
            UIDs = uids;
            SettingAPI = settingAccessAPI;
            SettingMeasureAPI = settingMeasurement;
            TypeMeasure = typeMeasure;
        }

        /// <summary>
        /// Получение списка значений измерений
        /// </summary>
        /// <returns>Перечень измерений</returns>
        public async Task<ListMeasurementValues> GetMeasurementValues()
        {
            //Формирование url адресса для получения значений измерения.
            string url = $"https://{SettingMeasureAPI.NameDomen}/api/public/measurement-values/" +
                         $"v{SettingMeasureAPI.Version}/{TypeMeasure}/{UIDs[0]}/data/" +
                         $"in-interval?fromTimeStamp={DateTimeConverter(DateStamp)}" +
                         $"&toTimeStamp={DateTimeConverter(DateEnd)}";
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(url);

            //Создание клиента для запроса списка значений измерения.
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token.AccessToken);

            //Создание GET сообщения для запроса списка значений измерения.
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json;charset=UTF-8"));
            request.RequestUri = new Uri(url.ToString(), UriKind.RelativeOrAbsolute);

            if (logger.IsInfoEnabled) logger.Info($"Запрос значений измерения за период: C ({DateStamp}) по ({DateEnd}) ");
            if (logger.IsInfoEnabled) logger.Trace($"Параметры запроса измерений:" +
                                                  $"\n\tUID - ({UIDs})\n\tUrl запроса - {url}");

            //Отправка запроса на получение списка значений измерения.
            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            var statusCode = (int)response.StatusCode;
            //Содержимое ответа
            string responseContent = await response.Content.ReadAsStringAsync();


            if (statusCode == 200)
            {
                if (responseContent == null)
                {
                    throw new CK11APIException("Неожиданный пустой ответ.", statusCode, responseContent, null);
                }
                else
                {
                    //Дессириализация содержимого в класс ListMeasurementValues
                    ListMeasurementValues measurements = JsonConvert.DeserializeObject<ListMeasurementValues>(responseContent);
                    if (logger.IsTraceEnabled) logger.Info("Измерения успешно получены. Кол-во измерений: " + measurements.ListMeasurement.Count());
                    return measurements;
                }
            }
            else
            {
                CK11Exception exception = new CK11Exception();
                exception.ErrorStatusCode(statusCode, responseContent, CancellationToken.None);
                return null!;
            }
        }

        /// <summary>
        /// Получение списка значений измерений
        /// </summary>
        /// <returns>Перечень измерений</returns>
        public async Task<ListMeasurementValues> GetMeasurementValuesArray()
        {
            //Формирование url адресса для получения значений измерения.
            string url = $"https://{SettingMeasureAPI.NameDomen}/api/public/measurement-values/" +
                         $"v{SettingMeasureAPI.Version}/{TypeMeasure}/data/" +
                         $"get-snapshot";
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(url);

            //Создание клиента для запроса списка значений измерения.
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token.AccessToken);

            //Создание GET сообщения для запроса списка значений измерения.
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json;charset=UTF-8"));
            request.RequestUri = new Uri(url.ToString(), UriKind.RelativeOrAbsolute);

            // if (logger.IsInfoEnabled) logger.Info($"Запрос значений измерения за период: C ({DateStamp}) по ({DateEnd}) ");
            // if (logger.IsInfoEnabled) logger.Trace($"Параметры запроса измерений:" +
            //                                      $"\n\tUID - ({UIDs})\n\tUrl запроса - {url}");

            
            string content = "{\"uids\": " + ArrayToString(UIDs) + "\"timeStamp\": \"2024-01-10T00:00:00Z\",\"timeStamp2\": \"2024-01-10T23:00:00Z\",\"qualityCodesFilter\": \"all\"}";

            //Отправка запроса на получение списка значений измерения.
            HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            var statusCode = (int)response.StatusCode;
            //Содержимое ответа
            string responseContent = await response.Content.ReadAsStringAsync();


            if (statusCode == 200)
            {
                if (responseContent == null)
                {
                    throw new CK11APIException("Неожиданный пустой ответ.", statusCode, responseContent, null);
                }
                else
                {
                    //Дессириализация содержимого в класс ListMeasurementValues
                    ListMeasurementValues measurements = JsonConvert.DeserializeObject<ListMeasurementValues>(responseContent);
                    if (logger.IsTraceEnabled) logger.Info("Измерения успешно получены. Кол-во измерений: " + measurements.ListMeasurement.Count());
                    return measurements;
                }
            }
            else
            {
                CK11Exception exception = new CK11Exception();
                exception.ErrorStatusCode(statusCode, responseContent, CancellationToken.None);
                return null!;
            }
        }

        /// <summary>
        /// Получение списка значений измерений
        /// </summary>
        /// <returns>Перечень измерений</returns>
        public async Task<ListMeasurementValuesExtend> GetMeasurementValuesArrayInRange(string dataTimeFrom, string dataTimeTo)
        {
            //Формирование url адресса для получения значений измерения.
            string url = $"https://{SettingMeasureAPI.NameDomen}/api/public/measurement-values/" +
                         $"v{SettingMeasureAPI.Version}/{TypeMeasure}/data/" +
                         $"get-table";
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(url);

            //Создание клиента для запроса списка значений измерения.
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token.AccessToken);

            //Создание GET сообщения для запроса списка значений измерения.
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json;charset=UTF-8"));
            request.RequestUri = new Uri(url.ToString(), UriKind.RelativeOrAbsolute);

            if (logger.IsInfoEnabled) logger.Info($"Запрос значений измерения за период: C ({DateStamp}) по ({DateEnd}) ");
            if (logger.IsInfoEnabled) logger.Trace($"Параметры запроса измерений:" +
                                                  $"\n\tUID - ({UIDs})\n\tUrl запроса - {url}");

            string content = "{\"uids\": " + 
                   ArrayToString(UIDs) + 
                   "\"fromTimeStamp\": " + 
                   $"\"{dataTimeFrom}\", " +
                   "\"toTimeStamp\": " + 
                   $"\"{dataTimeTo}\", " +
                   "\"stepUnits\": \"seconds\", " +
                   "\"stepValue\": 3600}";

            //Отправка запроса на получение списка значений измерения.
            HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            var statusCode = (int)response.StatusCode;
            //Содержимое ответа
            string responseContent = await response.Content.ReadAsStringAsync();


            if (statusCode == 200)
            {
                if (responseContent == null)
                {
                    throw new CK11APIException("Неожиданный пустой ответ.", statusCode, responseContent, null);
                }
                else
                {
                    //Дессириализация содержимого в класс ListMeasurementValues
                    ListMeasurementValuesExtend measurements = JsonConvert.DeserializeObject<ListMeasurementValuesExtend>(responseContent);
                    if (logger.IsTraceEnabled) logger.Info("Измерения успешно получены. Кол-во измерений: " + measurements.ListMeasurement.Count());
                    return measurements;
                }
            }
            else
            {
                CK11Exception exception = new CK11Exception();
                exception.ErrorStatusCode(statusCode, responseContent, CancellationToken.None);
                return null!;
            }
        }

        /// <summary>
        ///     Метод для создания строки
        ///     формата StringContent из массива.
        /// </summary>
        /// <param name="strings">Массив.</param>
        /// <returns>Строка.</returns>
        public static string ArrayToString(string[] strings) 
        {
            StringBuilder sb = new StringBuilder("[");
            foreach (string s in strings) 
            {
                sb.Append("\"" + s + "\", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("],");
            return sb.ToString();
        }

        /// <summary>
        /// Метод конвертирующий время в формат, необходимый для запроса к API ("yyyy-MM-ddTHH:mm:ss.000Z")
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string DateTimeConverter(DateTime dateTime)
        {
            return dateTime.Subtract(new TimeSpan(0, 3, 0, 0)).ToString("yyyy-MM-ddTHH:mm:ss.000Z");
        }
    }
}
