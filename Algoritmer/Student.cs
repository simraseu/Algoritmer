using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer
{
    public class Student
    {
        public string FullName { get; set; }
        public int GroupNumber { get; set; }

        //Constructor: 
        public Student(string fullName, int groupNumber)
        {
            FullName = fullName;
            GroupNumber = groupNumber;
        }
    }
}


