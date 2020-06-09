using System;
using System.Collections;

namespace laba6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Human[] human = new Human[12];
            //StudentBSUIR[] students = new StudentBSUIR [10];
            ArrayList students = new ArrayList  ();
            for (int i = 0; i < 12; i++)
                if (i % 6 == 0)
                    human[i] = new Human("Max", "Chmurau");
                else if (i % 6 == 1)
                    human[i] = new StudentBSUIR("Pavel", "Clybic");
                else if (i % 6 == 2)
                    human[i] = new AIStudent("Berejnov", "Danila");
                else if (i % 6 == 3)
                    human[i] = new IiTPStudent("Igar", "Karpenko");
                else if (i % 6 == 4)
                    human[i] = new ASOIStudent("I", "I");
                else if (i % 6 == 5)
                    human[i] = new StudentBSU("Egor", "Cuzovkov");
            foreach (Human i in human)
                i.GetInfo();
            foreach (Human i in human)
                if (i is StudentBSUIR stud)
                    students.Add(stud);
            students.Sort();
            foreach (IStudent i in students)
                i.CheckStudentData();
            foreach (StudentBSUIR i in students)
                i.GetInfo();
        }
    }
}
