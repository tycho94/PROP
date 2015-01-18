using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_assigner
{
    class Employee
    {
        private int empNr;
        private string name;
        private int age;
        private string role;

        public Int32 EmpNr
        {
            get { return empNr; }
            set { empNr = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public Int32 Age
        {
            get { return age; }
            set { age = value; }
        }
        public String Role
        {
            get { return role; }
            set { role = value; }
        }

        public Employee(int nr, string empname, int empage, string assignedrole)
        {
            this.EmpNr = nr;
            this.Name = empname;
            this.Age = empage;
            this.Role = assignedrole;
        }
        public void AssignRole()
        {
            

        }


    }
}
