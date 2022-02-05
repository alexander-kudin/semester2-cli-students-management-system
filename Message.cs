using System;
namespace COMP1202_S20_Assg2_AleksandrYamato
{
    public class Message
    {
        public static void Greetings()
        {
            Console.WriteLine("╔════════════════════════════════════ Welcome ════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("Student: Aleksandr Kudin 101258693");
            Console.WriteLine("Student: Yamato Masuda 101280981");
            Console.WriteLine("CRN: 80801-201903");
            Console.WriteLine("Professor: Albert Danison");
            Console.WriteLine("Date: August 11, 2020");
            Console.WriteLine("Assignment 2 Students Database");
            Console.WriteLine();
            Console.WriteLine("Description:");
            Console.WriteLine();
            Console.WriteLine("The user will have an access to the database which contains examples ");
            Console.WriteLine("of the student data. The user will be able to store and manage");
            Console.WriteLine("students data. UI and UX interfaces are designed for better");
            Console.WriteLine("navigation throught the database.");
            Console.WriteLine();
            Console.WriteLine("Functions avaliability:");
            Console.WriteLine();
            Console.WriteLine("Function 1. Display students list");
            Console.WriteLine("Function 2. Filter student list ");
            Console.WriteLine("Function 3. Add new student data");
            Console.WriteLine("Function 4. Erase student data");
            Console.WriteLine("Function 5. Edit student data");
            Console.WriteLine("Function 6. Search for a student");
            Console.WriteLine();
            Console.WriteLine("Privacy:");
            Console.WriteLine();
            Console.WriteLine("After the application is terminated all the session information will be saved");
            Console.WriteLine("on the device is using. After creating a new session, the information from");
            Console.WriteLine("the previous session will be erased and new session data will be stored.");
            Console.WriteLine();
            Console.WriteLine("Academic Honesty:");
            Console.WriteLine();
            Console.WriteLine("Aleksandr and Yamato, we guarantee that this program is our origin work.");
            Console.WriteLine("Aleksandr and Yamato, we have not given other student(s) access to our program.");
            Console.WriteLine();
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════╝");
        }

        public static void NewStudent()
        {
            Console.WriteLine("╔════════════ Adding New Student ════════════╗");
            Console.WriteLine();
            Console.WriteLine("                  ★。＼｜／。★                  ");
            Console.WriteLine("         New Student has been added!          ");
            Console.WriteLine("                  ★。／｜＼。★                  ");
            Console.WriteLine();
            Console.WriteLine("  < Students List (1) >  < Add Student (2) >  ");
            Console.WriteLine("                 < Quit (0) >                 ");
            Console.WriteLine();
            Console.WriteLine("╚════════════════════════════════════════════╝");
        }

        public static void Farewell()
        {

        }


    }
}
