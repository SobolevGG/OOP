namespace Model
{
    /// <summary>
    /// Класс Child.
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        private const int _minAge = 0;

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        private const int _maxAge = 17;

        /// <summary>
        /// Переопределение базового метода мин. возраста.
        /// </summary>
        protected override int MinAge { get; } = _minAge;

        /// <summary>
        /// Переопределение базового метода макс. возраста.
        /// </summary>
        protected override int MaxAge { get; } = _maxAge;

        /// <summary>
        /// Мать ребенка.
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Отец ребенка.
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Учреждение, которое посещает ребенок.
        /// </summary>
        private string _institute;

        /// <summary>
        /// Метод для обращения к полям матери.
        /// </summary>
        public Adult Mother
        {
            get => _mother;

            set
            {
                CheckParentGender(value, Gender.Female);

                // Допускается пустой ввод
                _mother = value;
            }
        }

        /// <summary>
        /// Метод для обращения к полям отца.
        /// </summary>
        public Adult Father
        {
            get => _father;

            set
            {
                CheckParentGender(value, Gender.Male);

                // Допускается пустой ввод
                _father = value;
            }
        }

        /// <summary>
        /// Метод для обращения к полям школы.
        /// </summary>
        public string Institute
        {
            get => _institute;

            // Школа должна быть у всех детей
            set => _institute = CheckValue(value);
        }

        /// <summary>
        /// Метод проверки корректности полов родителей.
        /// </summary>
        /// <param name="parent">Партнёр.</param>
        /// <param name="gender">Пол.</param>
        /// <exception cref="ArgumentException">Некорректный ввод.</exception>
        private void CheckParentGender(Adult parent, Gender gender)
        {
            if (parent != null && parent.Gender != gender)
            {
                throw new ArgumentException("Быть такого не может, " +
                    "должно быть, Вы ошиблись при вводе!");
            }
        }

        /// <summary>
        /// Метод проверки возраста.
        /// </summary>
        /// <param name="age"></param>
        /// <returns>Возраст.</returns>
        /// <exception cref="IndexOutOfRangeException">Исключение
        /// по нарушающему диапазон возрасту.</exception>
        protected override int CheckAge(int age)
        {
            // Передать значение переменной _age,
            // однако, прежде провести проверку:
            // значение входит в НЕправильный диапазон?
            return MinAge > age || age > MaxAge
                    // Если да, то кинуть исключение
                    ? throw new IndexOutOfRangeException("Возраст " +
                        $"должен быть в диапазоне " +
                        $"от {MinAge} до {MaxAge} лет!")
                    // Если нет, то продолжить присваивание
                    : age;
        }

        /// <summary>
        /// Метод вывода информации о ребёнке.
        /// </summary>
        /// <returns>Информация о ребёнке.</returns>
        public override string GetInfoBase()
        {
            string instituteStatus = "";
            if (!string.IsNullOrEmpty(Institute))
            {
                if (Age >= 7)
                {
                    instituteStatus = $"    Учебное заведение: {Institute}";
                }
                else if (Age < 7)
                {
                    string group = "";
                    switch (Age)
                    {
                        case < 2:
                            group = "первая младшая группа";
                            break;
                        case <= 2 and <= 3:
                            group = "вторая младшая группа";
                            break;
                        case <= 4 and <= 5:
                            group = "средняя группа";
                            break;
                        case > 5 and <= 6:
                            group = "старшая группа";
                            break;
                        default:
                            break;
                    }

                    instituteStatus = $"    Учреждение дошкольного " +
                        $"образования \"{Institute}\" ({group})";
                }
            }

            // Информация о родителях
            string parents = "информация отсутствует";
            // Оба родителя имеются
            if (Mother != null && Father != null)
            {
                parents = $"мать - {Mother.Surname} {Mother.Name}, " +
                $"отец - {Father.Surname} {Father.Name}";
            }
            // Имеется хотя бы 1 родитель
            else if (Mother != null || Father != null)
            {
                // Имеется мать
                if (Mother != null && Father == null)
                {
                    parents = $"мать - {Mother.Surname} {Mother.Name}, " +
                        $"воспитывающийся без отца";
                }
                // Имеется отец
                else if (Mother == null && Father != null)
                {
                    parents = $"отец - {Father.Surname} {Father.Name}, " +
                        $"воспитывающийся без матери";
                }
            }
            // Родителей нет
            else if (Mother == null || Father == null)
            {
                parents = "воспитывается без родителей";
            }

            return $"{GetInfo()}" +
                $"{instituteStatus}, " +
                $"\n    Информация о родителях: {parents}\n";
        }

        /// <summary>
        /// Конструктор для ребёнка.
        /// </summary>
        /// <param name="name">Имя ребёнка.</param>
        /// <param name="surname">Фамилия ребёнка.</param>
        /// <param name="age">Возраст ребёнка.</param>
        /// <param name="gender">Пол ребёнка.</param>
        /// <param name="mother">Мать ребёнка.</param>
        /// <param name="father">Отец ребёнка.</param>
        /// <param name="institute">Образовательное учреждение.</param>
        public Child(string name, string surname, int age, Gender gender,
            Adult mother, Adult father, string institute)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            Institute = institute;
        }

        /// <summary>
        /// Метод генерирования детей.
        /// </summary>
        /// <returns>Ребенок.</returns>
        public static Child GetRandomPerson()
        {
            string[] maleNames =
            {
                "Александр", "Владимир", "Григорий", "Максим",
                "Артем", "Егор", "Иван", "Илья"
            };

            string[] femaleNames =
            {
                "Светлана", "Татьяна","Ульяна", "Фаина",
                "Христина", "Цветана", "Эвелина", "Анастасия"
            };

            string[] surnames =
            {
                "Живаго",
                "Шапиро",
                "Грабчак",
                "Дей",
                "Штольберг"
            };

            string[] kindergartens = new string[]
            {
                "Радуга", "Солнышко","Весёлые карапузы","Ласточка",
                "Дружные малыши","Звёздочка","Улыбка","Мишутка",
                "Теремок","Сказка","Весёлый мир","Зайчонок",
                "Смешарики","Волшебный лес","Колобок","Спутничок"
            };

            string[] schools = new string[10];

            for (int i = 1; i <= schools.Length; i++)
            {
                schools[i - 1] = $"Школа №{i}";
            }

            var random = new Random();
            string name = string.Empty;
            var gender = (Gender)random.Next(0, 2);
            switch (gender)
            {
                case Gender.Male:
                    name = maleNames[random.Next(maleNames.Length)];
                    break;
                case Gender.Female:
                    name = femaleNames[random.Next(femaleNames.Length)];
                    break;
                case Gender.Default:
                    break;
                default:
                    break;
            }

            string surname = surnames[random.Next(surnames.Length)];
            int age = random.Next(_minAge, _maxAge);

            // Случайным образом выбирается школа
            string institute = schools[random.Next(schools.Length)];

            // Условимся, что дети идут в школу с 7 лет
            if (age < 7)
            {
                institute = kindergartens[random.Next(kindergartens.Length)];
            }

            Adult mother = GetRandomParent(1);
            Adult father = GetRandomParent(0);

            return new Child(name, surname, age, gender,
                            mother, father, institute);
        }

        /// <summary>
        /// Метод создания родителей для ребёнка.
        /// </summary>
        /// <param name="numberParent"> 0 - мальчик, 1 - девочка.</param>
        /// <returns>Случайный родитель.</returns>
        /// <exception cref="ArgumentException">Некорректный ввод.</exception>
        private static Adult GetRandomParent(int numberParent)
        {
            var random = new Random();
            var parentStatus = random.Next(1, 3);

            // Если выпала 1, то партнёра нет
            if (parentStatus == 1)
            {
                return null;
            }

            // В ином случае будет партнёр
            else
            {
                switch (numberParent)
                {
                    // Если был передан 0, то партнёр - мужчина
                    case 0:
                        return (Adult)Adult.GetRandomPerson(Gender.Male);

                    // Если была передана 1, то партнёр - женщина
                    case 1:
                        return (Adult)Adult.GetRandomPerson(Gender.Female);

                    // Если передали неожидаемое значение
                    default:
                        throw new ArgumentException
                            ("Введите, пожалуйста, число 1 или 2");
                }
            }
        }

        /// <summary>
        /// Метод генерации успеваемости в школе.
        /// </summary>
        /// <returns>Успеваемость в школе.</returns>
        public string GetSchoolProgress()
        {
            string[] schoolProgress = { "\"даже лучше, чем у сына " +
                    "маминой подруги\"", "отлично", "хорошо", "удовлетворительно" };
            Random random = new Random();
            return schoolProgress[random.Next(schoolProgress.Length)];
        }

        /// <summary>
        /// Метод генерации карманных расходов
        /// исходя из успеваемости.
        /// </summary>
        /// <returns>Карманные расходы.</returns>
        public string GetPocketExpenses(string schoolProgress)
        {
            int pocketExpenses = 0;
            Random random = new Random();
            switch (schoolProgress)
            {
                case "\"даже лучше, чем у сына " +
                    "маминой подруги\"":
                    pocketExpenses = random.Next(10, 21) * 100;
                    break;
                case "отлично":
                    pocketExpenses = random.Next(10, 16) * 100;
                    break;
                case "хорошо":
                    pocketExpenses = random.Next(5, 11) * 100;
                    break;
                case "удовлетворительно":
                    pocketExpenses = random.Next(1, 5) * 100;
                    break;
                default:
                    break;
            }
            return $"{pocketExpenses} рублей";
        }

        /// <summary>
        /// Ребёнок.
        /// </summary>
        public Child()
        {
        }
    }
}
