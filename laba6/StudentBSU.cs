using System;
using System.Collections.Generic;
using System.Text;

namespace laba6
{
    class StudentBSU : Human, IStudent, IComparable
    {
        public string Specialty { get; set; }
        public string GroupNumber { get; set; }
        public string StudentNumber { get; set; }
        public string Curator { get; set; }
        public string Faculty { get; set; }
        public string Status { get; set; }
        public bool IsWinnerOlympiad { get; set; }
        protected ushort _yearOfEntering, _grade;
        public float AverageRating { get; protected set; }
        protected IStudent.CentralizeTesting _testing;
        public bool IsSetteled { get; set; }
        public bool IsBuget { get; set; }
        public string Allocation { get; set; }
        private List<DateTime> _dateExpelled;
        private List<DateTime> _dateReturn;
        private List<List<sbyte>> _sessionResult;
        public StudentBSU() : base() { }
        public StudentBSU(string name, string surname) : base(name, surname) { }

        public StudentBSU(string name, string surname, string nationality, Gender gender, int day, int month, int year) :
            base(name, surname, nationality, gender, day, month, year)
        { }

        public StudentBSU(string name, string surname, string nationality, Gender gender, int day, int month, int year,
            string faculty, string specialty, string status, string curator, string groupNumber, string studentNumber,
            ushort language, ushort mathematic, ushort physics, ushort sertificate, ushort yearOfEntering, ushort grade,
            bool isWinnerOlympiad, bool isSetteled, bool isBuget)
            : base(name, surname, nationality, gender, day, month, year)
        {
            Faculty = faculty;
            Specialty = specialty;
            Status = status;
            Curator = curator;
            if (groupNumber.Length == 6)
                GroupNumber = groupNumber;
            if (studentNumber.Length == 8)
                StudentNumber = studentNumber;
            if (language <= 100)
                _testing.language = language;
            if (mathematic <= 100)
                _testing.mathematic = mathematic;
            if (physics <= 100)
                _testing.physics = physics;
            if (sertificate <= 100)
                _testing.sertificate = sertificate;
            if (yearOfEntering <= DateTime.Now.Year && yearOfEntering >= 1964)
                _yearOfEntering = yearOfEntering;
            if (grade > 0 && grade < 5)
                _grade = grade;
            IsBuget = isBuget;
            IsSetteled = isSetteled;
            IsWinnerOlympiad = isWinnerOlympiad;
        }

        public int CompareTo(object o)
        {
            if (o is StudentBSU p)
                return this.Surname.CompareTo(p.Surname);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public ushort YearOfEntering
        {
            get
            {
                return _yearOfEntering;
            }

            set
            {
                if (value <= DateTime.Now.Year && value >= 1945)
                    _yearOfEntering = value;
                else
                    Console.WriteLine("Неверное значение");
            }
        }

        public ushort Grade
        {
            get
            {
                return _grade;
            }

            set
            {
                if (value > 0 && value < 6)
                    _grade = value;
                else
                    Console.WriteLine("Неверное значение");
            }
        }

        public (ushort, ushort, ushort, ushort) Testing
        {
            get
            {
                var value = (_testing.language, _testing.mathematic, _testing.physics, _testing.sertificate);
                return value;
            }

            set
            {
                if (value.Item1 >= 0 && value.Item1 <= 100 && value.Item2 >= 0 && value.Item2 <= 100 && value.Item3 >= 0 && value.Item3 <= 100 && value.Item4 >= 0 && value.Item4 <= 100)
                {
                    _testing.language = value.Item1;
                    _testing.mathematic = value.Item2;
                    _testing.physics = value.Item3;
                    _testing.sertificate = value.Item4;
                }
                else
                    Console.WriteLine("Неверное значение");
            }
        }

        public virtual void SetExpelled()
        {
            Console.WriteLine("Введите количиство отчислений у студента");
            sbyte value = Convert.ToSByte(Console.ReadLine());
            for (int i = 0; i < value; i++)
            {
                Console.WriteLine($"Введите дату {i + 1}-го отчисления");
                int day = 0, month = 0, year = 0;
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Введите день");
                    day = Convert.ToInt32(Console.ReadLine());
                    if (day > 32 || day < 0)
                    {
                        Console.WriteLine("Неверное значение");
                    }
                    else
                        check = false;
                }

                check = true;
                while (check)
                {
                    Console.WriteLine("Введите месяц");
                    day = Convert.ToInt32(Console.ReadLine());
                    if (day > 32 || day < 0)
                    {
                        Console.WriteLine("Неверное значение");
                    }
                    else
                        check = false;
                }

                check = true;
                while (check)
                {
                    Console.WriteLine("Введите год");
                    day = Convert.ToInt32(Console.ReadLine());
                    if (day > 32 || day < 0)
                    {
                        Console.WriteLine("Неверное значение");
                    }
                    else
                        check = false;
                }
                DateTime date = new DateTime(day, month, year);
                _dateExpelled.Add(date);
            }
            _dateExpelled.Sort();
        }

        public void GetExpelled()
        {
            foreach (DateTime i in _dateExpelled)
                Console.WriteLine(i.ToString());
        }

        public void SetReturn()
        {
            Console.WriteLine("Введите количиство восстановлений у студента");
            sbyte value = Convert.ToSByte(Console.ReadLine());
            for (int i = 0; i < value; i++)
            {
                Console.WriteLine($"Введите дату {i + 1}-го восстановления");
                int day = 0, month = 0, year = 0;
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Введите день");
                    day = Convert.ToInt32(Console.ReadLine());
                    if (day > 32 || day < 0)
                    {
                        Console.WriteLine("Неверное значение");
                    }
                    else
                        check = false;
                }

                check = true;
                while (check)
                {
                    Console.WriteLine("Введите месяц");
                    day = Convert.ToInt32(Console.ReadLine());
                    if (day > 32 || day < 0)
                    {
                        Console.WriteLine("Неверное значение");
                    }
                    else
                        check = false;
                }

                check = true;
                while (check)
                {
                    Console.WriteLine("Введите год");
                    day = Convert.ToInt32(Console.ReadLine());
                    if (day > 32 || day < 0)
                    {
                        Console.WriteLine("Неверное значение");
                    }
                    else
                        check = false;
                }
                DateTime date = new DateTime(day, month, year);
                _dateReturn.Add(date);
            }
            _dateReturn.Sort();
        }

        public void GetReturn()
        {
            foreach (DateTime i in _dateReturn)
                Console.WriteLine(i.ToString());
        }

        public void AddSession()
        {
            List<sbyte> value = new List<sbyte>();
            sbyte amount;
            Console.WriteLine("Введите количество оценок за сессию");
            amount = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("Введите оценки за сессию");
            for (int i = 0; i < amount; i++)
                value.Add(Convert.ToSByte(Console.ReadLine()));
            _sessionResult.Add(value);

            amount = 0;
            int amount2 = 0;
            foreach (List<sbyte> i in _sessionResult)
                foreach (sbyte j in i)
                {
                    amount2 += j;
                    amount++;
                }
            AverageRating = (amount != 0) ? (float)(amount2 / amount) : 0;
        }

        public sealed override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine(
     @$"        Статус: {Status}
        Факльтет: {Faculty}
        Специальность: {Specialty}
        Год зачисления:{YearOfEntering}
        Курс:{Grade}
        Номер группы: {GroupNumber}
        Номер студенческого: {StudentNumber}
        Средний балл: {AverageRating}
        Куратор: {Curator}");
        }

        public override void Death(int dayOfDeath, int monthOfDeath, int yearOfDeath)
        {
            base.Death(dayOfDeath, monthOfDeath, yearOfDeath);
            Status = "Dead";
            _dateExpelled.Add(_dateOfDeath);
        }

        public sealed override string this[int index]
        {
            get
            {
                return index switch
                {
                    9 => Convert.ToString(Faculty),
                    10 => Convert.ToString(Specialty),
                    11 => Convert.ToString(Status),
                    12 => GroupNumber,
                    13 => StudentNumber,
                    14 => Convert.ToString(_yearOfEntering),
                    15 => Convert.ToString(AverageRating),
                    16 => Convert.ToString(_grade),
                    _ => base[index]
                };
            }
        }

        public void SetStudentsData(string faculty, string specialty, string status, string curator, string groupNumber, string studentNumber,
            ushort language, ushort mathematic, ushort physics, ushort sertificate, ushort yearOfEntering, ushort grade,
            bool isWinnerOlympiad, bool isSetteled, bool isBuget)
        {
            Faculty = faculty;
            Specialty = specialty;
            Status = status;
            Curator = curator;
            if (groupNumber.Length == 6)
                GroupNumber = groupNumber;
            if (studentNumber.Length == 8)
                StudentNumber = studentNumber;
            if (language <= 100)
                _testing.language = language;
            if (mathematic <= 100)
                _testing.mathematic = mathematic;
            if (physics <= 100)
                _testing.physics = physics;
            if (sertificate <= 100)
                _testing.sertificate = sertificate;
            if (yearOfEntering <= DateTime.Now.Year && yearOfEntering >= 1964)
                _yearOfEntering = yearOfEntering;
            if (grade > 0 && grade < 5)
                _grade = grade;
            IsBuget = isBuget;
            IsSetteled = isSetteled;
            IsWinnerOlympiad = isWinnerOlympiad;
        }

        public virtual void CheckStudentData()
        {
            for (int i = 0; i < 17; i++)
                if (this[i] == null)
                    Console.WriteLine("Есть пустые значения");
            if (Status == "")
                Console.WriteLine("Статус неизвестен");
            if (Faculty == "")
                Console.WriteLine("Факультет неизвестен");
            if (IsWinnerOlympiad == true && !(IsSetteled == false || IsBuget == false))
                Console.WriteLine("Олимпиадник не на бюжете или без общежития");
            if (AverageRating < 4 && AverageRating != 0)
                Console.WriteLine("Рекомендую его отчислить");
        }
    }
}