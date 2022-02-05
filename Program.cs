
// Student name: Aleksandr Kudin (101258693)
// Student name: Yamato Masuda (101280981)
// Institution: George Brown College
// Professor: Albert Danison
// Date: August 11, 2020
// CRN-80801-201903
using System;
using System.IO;

namespace COMP1202_S20_Assg2_AleksandrYamato
{
    class Program
    {
        static void Main(string[] args)
        {
            Message.Greetings();
            Console.ReadKey();
            // Create a new file     
            using (StreamWriter sw = File.CreateText("DataFile.txt"))
            {

            }
            StudentIO.HardCodeStudents(); // calling the method to hardcore 2 students to start with (can be turned off)
            StudentIO.StudentList(); // calling the method to display student list
            Console.ReadKey();

        }
    }
}
