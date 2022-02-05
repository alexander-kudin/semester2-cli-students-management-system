using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace COMP1202_S20_Assg2_AleksandrYamato
{
    public class ListManager
    {
        static string fileName = "DataFile.txt"; // TXT file name
        public static string fullPath = Path.GetFullPath(fileName); // path to the TXT file

        public static List<Student> SyncStudentList()
        {
            List<string> TXTLines = File.ReadAllLines(fullPath).ToList(); // list of lines from the TXT file 
            List<Student> StudentsList = new List<Student>(); // list of student objects
            foreach (string line in TXTLines) // iterating with each data line stored
            {
                string[] values = line.Split(':'); // data validation from the txt file
                Student newStudent = new Student(Convert.ToInt32(values[0]), values[1], values[2], values[3], Convert.ToInt64(values[4]), Convert.ToDouble(values[5]), Convert.ToDateTime(values[6])); // create new student object
                StudentsList.Add(newStudent); // add new student to the list
            }
            return StudentsList;
        }
    }
}
