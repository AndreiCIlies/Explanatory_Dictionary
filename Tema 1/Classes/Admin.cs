using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tema_1.Classes
{
    public class Admin
    {
        public String username { get; set; }
        public String password { get; set; }

        public Admin(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public void AddWordInDictionary(Word word)
        {

        }

        public void EditWordInDictionary(Word word)
        {

        }

        public void DeleteWordFromDictionary(Word word)
        {

        }
    }
}
