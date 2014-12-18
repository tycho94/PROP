using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrance_application
{
    class Admin
    {
        private string password;

        public Admin()
        {
            this.password = "pass";
        }


        public Boolean CheckPass(string pass)
        {
            if (pass == this.password)
            {
                return true;
            }

            else
            return false;
        }


    }
}
