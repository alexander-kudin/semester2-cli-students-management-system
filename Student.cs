using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
namespace COMP1202_S20_Assg2_AleksandrYamato
{
    public class Student
    {
        public static int IDGenerator = 10002;
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public long Phone { get; set; }
        public double GPA { get; set; }
        public DateTime Birthday { get; set; }


        public Student(int IDGenerator, string FirstName, string LastName, string Major, long Phone, double GPA, DateTime Birthday)
        {
            this.StudentID = IDGenerator;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Major = Major;
            this.Phone = Phone;
            this.GPA = GPA;
            this.Birthday = Birthday;
        }
    }
}
