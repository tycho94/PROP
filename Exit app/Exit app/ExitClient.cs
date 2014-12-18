using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exit_app
{
    class ExitClient
    {
        private string serial;
        private decimal money;
        private string username;

        public String Serial
        {
            get { return serial; }
            private set { serial = value; }
        }
        public Decimal Money
        {
            get { return money; }
            set { money = value; }
        }
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        public ExitClient(string RFIDnr)
        {
            //db function
            this.Username = "gestel";
            this.Serial = RFIDnr;
            this.Money = 100;
        }
    }
}
