using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrance_application
{
    class EnterClient
    {
        private string serial;
        private decimal money;
        private string username;
        private int status;

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
        public Int32 Status
        {
            get { return status; }
            set { status = value; }
        }

        public EnterClient(string RFIDnr)
        {
            //db function
            this.Username = "gestel";
            this.Serial = RFIDnr;
            this.Money = 0;
            this.Status = 1;
        }

        public void ChangeStatus(int change)
        {
            this.Status = change;
        }

        public Int32 Entering(string ID)
        {
            //db function
            //if (this.Serial == ID)
                return Status;
            //else
                //return -1;
        }
 

    }
}
