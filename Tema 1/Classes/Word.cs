using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tema_1.Classes
{
    internal class Word
    {
        public String word { get; set; }
        public String description { get; set; }
        public Image image { get; set; }
        public String category { get; set; }

        public Word(String word, String description, Image image, String category)
        {
            this.word = word;
            this.description = description;
            this.image = image;
            this.category = category;
        }

        public Word(String word, String description, String category)
        {
            this.word = word;
            this.description = description;
            this.category = category;
        }
    }
}
