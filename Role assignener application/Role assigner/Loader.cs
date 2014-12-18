using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_assigner
{
    class Loader
    {
        public System.Windows.Forms.ComboBox addRoles(System.Windows.Forms.ComboBox box)
        {
            box.Items.Add("bar");
            box.Items.Add("gate");
            box.Items.Add("shop");
            box.Items.Add("artist");

            return box;
        }




    }
}
