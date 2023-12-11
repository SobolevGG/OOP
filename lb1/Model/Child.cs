namespace Model
{
    /// <summary>
    /// Class Child.
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
        /// Школа, которую ребенок исправно посещает.
        /// </summary>
        private string _school;

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
        public string School
        {
            get => _school;

            // Школа должна быть у всех детей
            set => _school = CheckValue(value);
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
            string motherStatus = "Отсутствует";
            string fatherStatus = "No father";

            if (Mother != null)
            {
                motherStatus = $"Mother`s name is {Mother.Name}," +
                    $"surname is {Mother.Surname}";
            }

            if (Father != null)
            {
                fatherStatus = $"Father`s name is {Father.Name}," +
                    $"surname is {Father.Surname}";
            }

            string schoolStatus = "not studing";
            if (!string.IsNullOrEmpty(School))
            {
                schoolStatus = $"Study in {School}";
            }

            if (Mother == null && Father == null)
            {
                return Gender == Gender.Female
                    ? $"{GetInfo()} \n{schoolStatus}" +
                        $"\nUnfortunately, she is an orphan"
                    : $"{GetInfo()} \n{schoolStatus}" +
                        $"\nUnfortunately, he is an orphan";
            }
            else
            {
                return $"{GetInfo()}\n" +
                    $"{fatherStatus},\n" +
                    $"{motherStatus},\n" +
                    $"{schoolStatus}";
            }
        }

        /// <summary>
        /// Child's constructor.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="surname">Surname.</param>
        /// <param name="age">Age.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="mother">Mother.</param>
        /// <param name="father">Father.</param>
        /// <param name="school">School.</param>
        public Child(string name, string surname, int age, Gender gender,
            Adult mother, Adult father, string school)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            School = school;
        }

        /// <summary>
        /// Entering a random child.
        /// </summary>
        /// <returns>Random person.</returns>
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

            // string[] schools = new string[]
            // {
            //     "Школа №1","Школа №2","Школа №3","Школа 4",
            //     "Школа №5","Школа №6","Школа №7","Школа 8",
            //     "Школа №9","Школа №10","Школа №11","Школа 12",
            //     "Школа №13","Школа №14","Школа №15","Школа 16"
            // };

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

            string school = kindergartens[random.Next(kindergartens.Length)];

            Adult mother = GetRandomParent(1);
            Adult father = GetRandomParent(0);

            return new Child(name, surname, age, gender,
                            mother, father, school);
        }

        /// <summary>
        /// Create random parent for random child.
        /// </summary>
        /// <param name="numberParent"> 0 is Male, 1 is Female.</param>
        /// <returns>Random Parent.</returns>
        /// <exception cref="ArgumentException">Incorrect input.</exception>
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
        /// Special method for class child.
        /// </summary>
        /// <returns>Name of ship model.</returns>
        public string GetShipCollection()
        {
            string[] shipModels = new string[]
            {
                "Black Pearl", "Flying Dutchman", "Queen Anne's Revenge",
                "HMS Interceptor", "Empress", "Hai Peng", "Jolly Mon",
                "Dying Gull", "Wicked Wench", "Misty Lady"
            };
            var random = new Random();
            string model = shipModels[random.Next(shipModels.Length)];
            return model;
        }

        /// <summary>
        /// Child without parameters.
        /// </summary>
        public Child()
        {
        }
    }
}
