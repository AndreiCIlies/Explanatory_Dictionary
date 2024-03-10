using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tema_1.Classes
{
    public class Word
    {
        public string word { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string category { get; set; }

        public Word(string word, string description, string image, string category)
        {
            this.word = word;
            this.description = description;
            this.image = image;
            this.category = category;
        }

        public Word(string word, string description, string category)
        {
            this.word = word;
            this.description = description;
            this.category = category;
        }
    }
}
