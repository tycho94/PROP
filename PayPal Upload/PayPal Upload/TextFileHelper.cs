using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace PayPal_Upload
{
    class TextFileHelper
    {
        private string filename;

        public TextFileHelper(string filename)
        {
            this.filename = filename;
        }

        public List<string> LoadFromFile()
        {
            FileStream fs = null;
            List<string> temp = new List<string>();

            try
            {
                string s;
                int i = 0;
                fs = new FileStream(filename, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (i < 4)
                        {
                            temp.Add(s);
                        }
                        if (i >= 4)
                        {
                            string[] numbers = s.Split(' ');
                            foreach (string a in numbers)
                            {
                                temp.Add(a);
                            }
                        }
                        i++;
                    }
                }

            }
            catch (IOException)
            {
            }
            finally
            {
                if (fs != null) fs.Close();
            }

            return temp;

        }


    }
}
