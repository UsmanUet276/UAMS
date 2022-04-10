using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    internal class student
    {
        public student(string name , int age , float fscMarks , float ecatMarks)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
        }
        public string name;
        public int age;
        public int fees;
        public int creditHours;
        public float fscMarks;
        public float ecatMarks;
        public double merit;
        public bool isAdmitted;
        public bool cheakMax;
        public bool isRegistered;
        public degreeProgram selectedInDegree;
        public List<degreeProgram> prefrences = new List<degreeProgram>();
        public List<subject> registeredSubjects = new List<subject>();

        public void calculateMerit()
        {
            merit = (fscMarks / 11 * 0.6) + (ecatMarks / 4 * 0.4);
        }
    }
}
