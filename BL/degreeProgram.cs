using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    internal class degreeProgram
    {
        public degreeProgram(string title)
        {
            this.title = title;
        }
        public degreeProgram(string title , string duration , List<subject> offeredSubjects , int seats)
        {
            this.title = title;
            this.duration = duration;
            this.offeredSubjects = offeredSubjects;
            this.seats = seats;
        }
        public string title;
        public string duration;
        public int seats;
        public List<subject> offeredSubjects = new List<subject>();
    }
}
