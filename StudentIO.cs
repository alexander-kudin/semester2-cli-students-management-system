using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
namespace COMP1202_S20_Assg2_AleksandrYamato
{
    public class StudentIO
    {
        static string fileName = "DataFile.txt"; // TXT file name
        static string fullPath = Path.GetFullPath(fileName); // path to the TXT file
        static List<string> TXTLines = File.ReadAllLines(fullPath).ToList(); // list of lines from the TXT file

        public static void HardCodeStudents()
        {
            TXTLines.Add($"10000:Aleksandr:Kudin:T127:6473332211:4.0:2001-09-01");
            TXTLines.Add($"10001:Yamato:Masuda:T127:6471112233:4.0:2001-03-09");
            File.WriteAllLines(fullPath, TXTLines); // rewriting all students data with the new student added
        }

        public static void StudentList()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA      Phone           Birthday           ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------           ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < Search (1) >         < Sort By (2) >         < Add Student (3) >                          ");
            Console.WriteLine("                              < Student Erase (4) >         < Student Info (5) >                               ");
            Console.WriteLine("                                                 < Quit (0) >                                                  ");
            Console.WriteLine();          
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    StudentList();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    SearchStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SortBy();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    AddStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    EraseStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 5)
                {
                    DisplayStudentInfo();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is now avaliable at that time");
     
                    continue;
                }
            }
        }

        public static void SortBy()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < First Name (1) >              < Last Name (2) >             < GPA (3) >                   ");
            Console.WriteLine("                                     < Back (4) >                < Quit (0) >                                  ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    SortBy();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    FirstNameSort();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    LastNameSort();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    GPASort();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    StudentList();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");

                    continue;
                }
            }
        }



        public static void FirstNameSort()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Students = Students.OrderBy(x => x.FirstName).ToList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name^        Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < Reverse (1) >         < Sort By (2) >         < Add Student (3) >                         ");
            Console.WriteLine("                              < Student Erase (4) >        < Quit (0) >                                         ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    FirstNameSort();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    FirstNameSortReverse();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SortBy();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    AddStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    EraseStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");

                    continue;
                }
            }
        }

        public static void FirstNameSortReverse()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Students = Students.OrderByDescending(x => x.FirstName).ToList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name^        Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < Reverse (1) >         < Sort By (2) >         < Add Student (3) >                         ");
            Console.WriteLine("                              < Student Erase (4) >        < Quit (0) >                                         ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    FirstNameSort();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    FirstNameSort();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SortBy();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    AddStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    EraseStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");

                    continue;
                }
            }
        }

        public static void LastNameSort()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Students = Students.OrderBy(x => x.LastName).ToList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name^         Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < Reverse (1) >         < Sort By (2) >         < Add Student (3) >                         ");
            Console.WriteLine("                              < Student Erase (4) >        < Quit (0) >                                         ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    LastNameSort();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    LastNameSortReverse();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SortBy();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    AddStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    EraseStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");

                    continue;
                }
            }
        }

        public static void LastNameSortReverse()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Students = Students.OrderByDescending(x => x.LastName).ToList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name^         Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < Reverse (1) >         < Sort By (2) >         < Add Student (3) >                         ");
            Console.WriteLine("                              < Student Erase (4) >        < Quit (0) >                                         ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    LastNameSortReverse();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    LastNameSort();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SortBy();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    AddStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    EraseStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");

                    continue;
                }
            }
        }

        public static void GPASort()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Students = Students.OrderBy(x => x.GPA).ToList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA^     Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < Reverse (1) >         < Sort By (2) >         < Add Student (3) >                         ");
            Console.WriteLine("                              < Student Erase (4) >        < Quit (0) >                                         ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    GPASort();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    GPASortReverse();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SortBy();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    AddStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    EraseStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is now avaliable at that time");

                    continue;
                }
            }
        }

        public static void GPASortReverse()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Students = Students.OrderByDescending(x => x.GPA).ToList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA^     Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < Reverse (1) >         < Sort By (2) >         < Add Student (3) >                         ");
            Console.WriteLine("                              < Student Erase (4) >        < Quit (0) >                                         ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    GPASortReverse();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    GPASort();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SortBy();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    AddStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    EraseStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");

                    continue;
                }
            }
        }

        public static void DisplayStudentInfo()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA      Phone           Birthday           ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------           ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {

                Console.Write("Enter Student ID of student you want to look at (0 to go BACK): ");
                string IDToEdit = Console.ReadLine();
                if (!Int32.TryParse(IDToEdit, out int IsInt)) // checking whether the number is entered or not
                {
                    DisplayStudentInfo();
                    continue;
                }
                if (Convert.ToInt32(IDToEdit) == 0)
                {
                    StudentList();
                }
                for (int i = 0; i < Students.Count; i++)
                {

                    if (Students[i].StudentID == Convert.ToInt32(IDToEdit))
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("╔════════════ Student Info ════════════╗");
                            Console.WriteLine();
                            Console.WriteLine($"  Name: {Students[i].FirstName} {Students[i].LastName}                 ");
                            Console.WriteLine($"  Student ID: {Students[i].StudentID}                  ");
                            Console.WriteLine($"  Major: {Students[i].Major}                            ");
                            Console.WriteLine($"  GPA: {Students[i].GPA}                               ");
                            Console.WriteLine($"  Phone: {Students[i].Phone}                    ");
                            Console.WriteLine($"  Birth: {Students[i].Birthday.ToString("MMMM dd, yyyy")}     ");
                            Console.WriteLine();
                            Console.WriteLine("  < Students List (1) >   < Edit (2) >  ");
                            Console.WriteLine();
                            Console.WriteLine("╚══════════════════════════════════════╝");
                            // action manager
                            Console.Write("Action: ");
                            string action = Console.ReadLine();
                            if (!Int32.TryParse(action, out int isInt)) // checking whether the number is entered or not
                            {
                                continue;
                            }
                            else if (Convert.ToInt32(action) == 1)
                            {
                                StudentList();
                                break;
                            }
                            else if (Convert.ToInt32(action) == 2)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("sorry... the function is not avaliable at that time");

                                continue;
                            }
                        }

                        int LineIndex = i;
                        Console.Clear();
                        Console.WriteLine("╔════════════ Student Info ════════════╗");
                        Console.WriteLine();
                        Console.WriteLine($"  Name: {Students[i].FirstName} {Students[i].LastName}                 ");
                        Console.WriteLine($"  Student ID: {Students[i].StudentID}                  ");
                        Console.WriteLine($"  Major: {Students[i].Major}                            ");
                        Console.WriteLine($"  GPA: {Students[i].GPA}                               ");
                        Console.WriteLine($"  Phone: {Students[i].Phone}                    ");
                        Console.WriteLine($"  Birth: {Students[i].Birthday.ToString("MMMM dd, yyyy")}     ");
                        Console.WriteLine();
                        Console.WriteLine("╚══════════════════════════════════════╝");
                        Console.WriteLine("╔════════════ Editing Student ════════════╗");
                        Console.WriteLine();
                        Console.Write("  First Name (Press Enter to skip): ");
                        string FirstName = Console.ReadLine();
                        if (string.IsNullOrEmpty(FirstName)) // checking whether the value is entered or not
                        {
                            Console.WriteLine("Skiped!");
                            FirstName = Students[i].FirstName;
                        }
                        Console.Clear();
                        Console.WriteLine("╔════════════ Student Info ════════════╗");
                        Console.WriteLine();
                        Console.WriteLine($"  Name: {FirstName} {Students[i].LastName}          ");
                        Console.WriteLine($"  Student ID: {Students[i].StudentID}                  ");
                        Console.WriteLine($"  Major: {Students[i].Major}                            ");
                        Console.WriteLine($"  GPA: {Students[i].GPA}                               ");
                        Console.WriteLine($"  Phone: {Students[i].Phone}                    ");
                        Console.WriteLine($"  Birth: {Students[i].Birthday.ToString("MMMM dd, yyyy")}     ");
                        Console.WriteLine();
                        Console.WriteLine("╚══════════════════════════════════════╝");
                        Console.WriteLine("╔════════════ Editing Student ════════════╗");
                        Console.WriteLine();
                        Console.Write("  Last Name (Press Enter to skip): ");
                        string LastName = Console.ReadLine();
                        if (string.IsNullOrEmpty(LastName)) // checking whether the value is entered or not
                        {
                            Console.WriteLine("Skiped!");
                            LastName = Students[i].LastName;
                        }

                        Console.Clear();
                        Console.WriteLine("╔════════════ Student Info ════════════╗");
                        Console.WriteLine();
                        Console.WriteLine($"  Name: {FirstName} {LastName}          ");
                        Console.WriteLine($"  Student ID: {Students[i].StudentID}                  ");
                        Console.WriteLine($"  Major: {Students[i].Major}                            ");
                        Console.WriteLine($"  GPA: {Students[i].GPA}                               ");
                        Console.WriteLine($"  Phone: {Students[i].Phone}                    ");
                        Console.WriteLine($"  Birth: {Students[i].Birthday.ToString("MMMM dd, yyyy")}     ");
                        Console.WriteLine();
                        Console.WriteLine("╚══════════════════════════════════════╝");
                        Console.WriteLine("╔════════════ Editing Student ════════════╗");
                        Console.WriteLine();
                        Console.Write("  Major (Press Enter to skip): ");
                        string Major = Console.ReadLine();
                        if (string.IsNullOrEmpty(Major)) // checking whether the value is entered or not
                        {
                            Console.WriteLine("Skiped!");
                            Major = Students[i].Major;
                        }

                        Console.Clear();
                        Console.WriteLine("╔════════════ Student Info ════════════╗");
                        Console.WriteLine();
                        Console.WriteLine($"  Name: {FirstName} {LastName}          ");
                        Console.WriteLine($"  Student ID: {Students[i].StudentID}                  ");
                        Console.WriteLine($"  Major: {Major}                            ");
                        Console.WriteLine($"  GPA: {Students[i].GPA}                               ");
                        Console.WriteLine($"  Phone: {Students[i].Phone}                    ");
                        Console.WriteLine($"  Birth: {Students[i].Birthday.ToString("MMMM dd, yyyy")}     ");
                        Console.WriteLine();
                        Console.WriteLine("╚══════════════════════════════════════╝");
                        Console.WriteLine("╔════════════ Editing Student ════════════╗");
                        Console.WriteLine();
                        string Phone;
                        while (true)
                        {
                            Console.Write("  Phone (Press Enter to skip) :");
                            Phone = Console.ReadLine();
                            if (string.IsNullOrEmpty(Phone)) // checking whether the value is entered or not
                            {
                                Console.WriteLine("Skiped!");
                                Phone = Convert.ToString(Students[i].Phone);
                                break;
                            }
                            if (!Int64.TryParse(Phone, out long isInt)) // checking whether the number is entered or not
                            {
                                Console.WriteLine("  Invalid value! The number must be entered:  ");
                                continue;
                            }
                            else if (Phone.Length != 10)
                            {
                                Console.WriteLine("  Invalid value! The phone number must contain 10 digits:  ");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("╔════════════ Student Info ════════════╗");
                        Console.WriteLine();
                        Console.WriteLine($"  Name: {FirstName} {LastName}          ");
                        Console.WriteLine($"  Student ID: {Students[i].StudentID}                  ");
                        Console.WriteLine($"  Major: {Major}                            ");
                        Console.WriteLine($"  GPA: {Students[i].GPA}                               ");
                        Console.WriteLine($"  Phone: {Phone}                    ");
                        Console.WriteLine($"  Birth: {Students[i].Birthday.ToString("MMMM dd, yyyy")}     ");
                        Console.WriteLine();
                        Console.WriteLine("╚══════════════════════════════════════╝");
                        Console.WriteLine("╔════════════ Editing Student ════════════╗");
                        Console.WriteLine();
                        string GPA;
                        while (true)
                        {
                            Console.Write("  GPA (Press Enter to skip): ");
                            GPA = Console.ReadLine();
                            if (string.IsNullOrEmpty(GPA)) // checking whether the value is entered or not
                            {
                                Console.WriteLine("Skiped!");
                                GPA = Convert.ToString(Students[i].GPA);
                                break;
                            }
                            if (!Double.TryParse(GPA, out double IsDouble)) // checking whether the number is entered or not
                            {
                                Console.WriteLine("  Invalid value! The number must be entered:  ");
                                continue;
                            }
                            else if (Convert.ToDouble(GPA) > 4.00 || Convert.ToDouble(GPA) < 0)
                            {
                                Console.WriteLine("  Invalid value! The number must be between 0 and 4:  ");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("╔════════════ Student Info ════════════╗");
                        Console.WriteLine();
                        Console.WriteLine($"  Name: {FirstName} {LastName}          ");
                        Console.WriteLine($"  Student ID: {Students[i].StudentID}                  ");
                        Console.WriteLine($"  Major: {Major}                            ");
                        Console.WriteLine($"  GPA: {GPA}                               ");
                        Console.WriteLine($"  Phone: {Phone}                    ");
                        Console.WriteLine($"  Birth: {Students[i].Birthday.ToString("MMMM dd, yyyy")}     ");
                        Console.WriteLine();
                        Console.WriteLine("╚══════════════════════════════════════╝");
                        Console.WriteLine("╔════════════ Editing New Student ════════════╗");
                        Console.WriteLine();
                        Console.WriteLine("  Birthday (MM/dd/yyyy): ");
                        string dateFormat;
                        while (true)
                        {
                            dateFormat = Console.ReadLine();
                            if (string.IsNullOrEmpty(dateFormat)) // checking whether the value is entered or not
                            {
                                Console.WriteLine("Skiped!");
                                dateFormat = Convert.ToString(Students[i].Birthday.ToString("MM/dd/yyyy"));
                                break;
                            }
                            if (!DateTime.TryParse(dateFormat, out DateTime Birthday))
                            {
                                Console.WriteLine("You have entered an incorrect value. The format is (MM/dd/yyyy):");
                                continue;
                            }
                            else
                            {
                                dateFormat = Birthday.ToString("MM/dd/yyyy");
                                break;
                            }
                        }

                        TXTLines.Add($"{Students[i].StudentID}:{FirstName}:{LastName}:{Major}:{Phone}:{GPA}:{dateFormat}");
                        File.WriteAllLines(fullPath, TXTLines); // rewriting all students data with the new student added
                        TXTLines.RemoveAt(LineIndex);
                        File.WriteAllLines(fullPath, TXTLines);
                       // Console.WriteLine($"Student with the ID of {IDToEdit} has been removed from the list!");
                        Console.Write("Press any button to see student list");
                        Console.ReadKey();
                        StudentList();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, the student with the giving ID does not exist...");
                    }

                }
                StudentList();
                break;
            }
        }

        public static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("╔════════════ Adding New Student ════════════╗");
            Console.WriteLine();
            Console.WriteLine("  First Name:");
            string FirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(FirstName)) // checking whether the value is entered or not
            {
                Console.WriteLine("Name can't be empty! Input student name once more:");
                FirstName = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("╔════════════ Adding New Student ════════════╗");
            Console.WriteLine();
            Console.WriteLine("  Last Name:");
            string LastName = Console.ReadLine();
            while (string.IsNullOrEmpty(LastName)) // checking whether the value is entered or not
            {
                Console.WriteLine("Name can't be empty! Input student name once more:");
                LastName = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("╔════════════ Adding New Student ════════════╗");
            Console.WriteLine();
            Console.WriteLine("  Major:");
            string Major = Console.ReadLine();
            while (string.IsNullOrEmpty(Major)) // checking whether the value is entered or not
            {
                Console.WriteLine("Major can't be empty! Input student major once more:");
                Major = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("╔════════════ Adding New Student ════════════╗");
            Console.WriteLine();
            string Phone;
            while (true)
            {
                Console.WriteLine("  Phone:");
                Phone = Console.ReadLine();
                if (!Int64.TryParse(Phone, out long isInt)) // checking whether the number is entered or not
                {
                    Console.WriteLine("  Invalid value! The number must be entered:  ");
                    continue;
                }
                else if (Phone.Length != 10)
                {
                    Console.WriteLine("  Invalid value! The phone number must contain 10 digits:  ");
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("╔════════════ Adding New Student ════════════╗");
            Console.WriteLine();
            Console.WriteLine("  GPA:");
            string GPA;
            while (true)
            {
                GPA = Console.ReadLine();
                if (!Double.TryParse(GPA, out double IsDouble)) // checking whether the number is entered or not
                {
                    Console.WriteLine("  Invalid value! The number must be entered:  ");
                    continue;
                }
                else if (Convert.ToDouble(GPA) > 4.00 || Convert.ToDouble(GPA) < 0)
                {
                    Console.WriteLine("  Invalid value! The number must be between 0 and 4:  ");
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("╔════════════ Adding New Student ════════════╗");
            Console.WriteLine();
            Console.WriteLine("  Birthday (MM/dd/yyyy): ");
            string dateFormat;
            while (true)
            {
                dateFormat = Console.ReadLine();
                if (DateTime.TryParse(dateFormat, out DateTime Birthday))
                {
                    dateFormat = Birthday.ToString("MM/dd/yyyy");
                    break;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value. The format is (MM/dd/yyyy):");
                }
            }

            List<Student> Students = ListManager.SyncStudentList();
            TXTLines.Add($"{Student.IDGenerator}:{FirstName}:{LastName}:{Major}:{Phone}:{GPA}:{dateFormat}");
            Student.IDGenerator++;
            File.WriteAllLines(fullPath, TXTLines); // rewriting all students data with the new student added
            Console.Clear();
            Message.NewStudent();
            while (true)
            {
                Console.WriteLine("Action:");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    Console.Clear();
                    Message.NewStudent();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    StudentList();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    AddStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");
                    continue;
                }
            }

        }

        // really annoying function to build but too late figured out it's not a requirement. (we leave it for you, professor)
        public static void EraseStudent()
        {
            List<Student> Students = ListManager.SyncStudentList();

            while (true)
            {
                Console.Write("ID of Student to Erase: ");
                string IDToRemove = Console.ReadLine();
                if (!Int32.TryParse(IDToRemove, out int IsInt)) // checking whether the number is entered or not
                {
                    EraseStudent();
                    continue;
                }
                for (int i = 0; i < Students.Count; i++)
                {
                  
                    if (Students[i].StudentID == Convert.ToInt32(IDToRemove))
                    {
                        int LineIndex = i;
                        TXTLines.RemoveAt(LineIndex);
                        File.WriteAllLines(fullPath, TXTLines);
                        Console.WriteLine($"Student with the ID of {IDToRemove} has been removed from the list!");
                        Console.Write("Press any button to refresh student list");
                        Console.ReadKey();
                        StudentList();
                    }

                }
                Console.WriteLine("Sorry, the student with the giving ID does now exist...");
                Console.Write("Press any button to refresh student list");
                Console.ReadKey();
                StudentList();
                break;
            }
        }


        public static void SearchStudent()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                   < Student ID (1) >              < Major (2) >             < GPA (3) >                   ");
            Console.WriteLine("                                     < Back (4) >                < Quit (0) >                                  ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    SearchStudent();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    SearchStudentID();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SearchStudentMajor();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    SearchStudentGPA();
                    break;
                }
                else if (Convert.ToInt32(action) == 4)
                {
                    StudentList();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");

                    continue;
                }
            }
        }

        public static void SearchStudentID()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Write("Enter Student ID: ");
            string StudentIDScope = Console.ReadLine();
            int matchAmount = 0;
            while (true)
            {
                if (!Int32.TryParse(StudentIDScope, out int IsInt)) // checking whether the number is entered or not
                {
                    SearchStudentID();
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                if (student.StudentID == Convert.ToInt32(StudentIDScope))
                {
                    matchAmount++;
                    Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
                }
            }
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine($"{matchAmount} result(s) have been found!");
            Console.WriteLine($"Press any button to see student list.");
            Console.ReadKey();
            StudentList();
        }

        public static void SearchStudentMajor()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Write("Enter Student Major: ");
            string StudentMajorScope = Console.ReadLine();
            int matchAmount = 0;
            while (string.IsNullOrEmpty(StudentMajorScope)) // checking whether the value is entered or not
            {
                Console.WriteLine("Enter Student Major: ");
                StudentMajorScope = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID^    First Name         Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                if (student.Major == StudentMajorScope)
                {
                    matchAmount++;
                    Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
                }
            }
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine($"{matchAmount} result(s) have been found!");
            Console.WriteLine($"Press any button to see student list.");
            Console.ReadKey();
            StudentList();
        }

        public static void SearchStudentGPA()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
            }
            Console.WriteLine();
            Console.WriteLine("                                   < Higher (1) >                < Lower (2) >                                  ");
            Console.WriteLine("                                     < Back (3) >                < Quit (0) >                                  ");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                // action manager
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if (!Int32.TryParse(action, out int IsInt)) // checking whether the number is entered or not
                {
                    SearchStudent();
                    continue;
                }
                else if (Convert.ToInt32(action) == 1)
                {
                    SearchStudentGPAHigher();
                    break;
                }
                else if (Convert.ToInt32(action) == 2)
                {
                    SearchStudentGPALower();
                    break;
                }
                else if (Convert.ToInt32(action) == 3)
                {
                    SearchStudent();
                    break;
                }
                else if (Convert.ToInt32(action) == 0)
                {
                    Console.WriteLine("bye...");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("sorry... the function is not avaliable at that time");

                    continue;
                }
            }
        }

        public static void SearchStudentGPAHigher()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Write("Enter GPA: ");
            string GPAScope = Console.ReadLine();
            int matchAmount = 0;
            while (true)
            {
                if (!Double.TryParse(GPAScope, out double IsDouble)) // checking whether the number is entered or not
                {
                    SearchStudentGPAHigher();
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                if (student.GPA >= Convert.ToDouble(GPAScope))
                {
                    matchAmount++;
                    Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
                }
            }
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine($"{matchAmount} result(s) have been found!");
            Console.WriteLine($"Press any button to see student list.");
            Console.ReadKey();
            StudentList();
        }

        public static void SearchStudentGPALower()
        {
            List<Student> Students = ListManager.SyncStudentList();
            Console.Write("Enter GPA: ");
            string GPAScope = Console.ReadLine();
            int matchAmount = 0;
            while (true)
            {
                if (!Double.TryParse(GPAScope, out double IsDouble)) // checking whether the number is entered or not
                {
                    SearchStudentGPALower();
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════ Students List ════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("   Student ID     First Name         Last Name          Major      GPA      Phone           Birthday    ");
            Console.WriteLine("   ----------     ----------         ---------          -----      ---      -----           --------    ");
            foreach (var student in Students)
            {
                if (student.GPA <= Convert.ToDouble(GPAScope))
                {
                    matchAmount++;
                    Console.WriteLine(String.Format("   {0,-14} {1,-18} {2,-18} {3,-10} {4,-8:0.00} {5,-15} {6,-15}", student.StudentID, student.FirstName, student.LastName, student.Major, student.GPA, student.Phone, student.Birthday.ToString("MMMM dd, yyyy")));
                }
            }
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine($"{matchAmount} result(s) have been found!");
            Console.WriteLine($"Press any button to see student list.");
            Console.ReadKey();
            StudentList();
        }

    }
}
