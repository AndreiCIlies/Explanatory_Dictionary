using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Tema_1.Classes
{
    public class Admin
    {
        public String username { get; set; }
        public String password { get; set; }

        public Admin()
        {

        }

        public Admin(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public void AddWordInDictionary(Word word)
        {
            try
            {
                string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";

                if (File.ReadAllText(filePath).Contains(word.word))
                {
                    MessageBox.Show($"The word '{word.word}' already exists in the dictionary.", "Duplicate Word", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(word.word);
                    writer.WriteLine(word.description);
                    writer.WriteLine(word.image);
                    writer.WriteLine(word.category);
                }

                Console.WriteLine($"Word '{word.word}' added to the dictionary.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while adding the word: " + e.Message);
            }
        }

        public void EditWordInDictionary(Word word)
        {
            try
            {
                string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";

                if (!File.ReadAllText(filePath).Contains(word.word))
                {
                    MessageBox.Show($"The word '{word.word}' does not exist in the dictionary.", "Non-existent Word", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 4)
                {
                    if (lines[i] == word.word)
                    {
                        lines[i] = word.word;
                        lines[i + 1] = word.description;
                        lines[i + 2] = word.image;
                        lines[i + 3] = word.category;
                        break;
                    }
                }

                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Word '{word.word}' edited in the dictionary.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while editing the word: " + e.Message);
            }
        }

        public void DeleteWordFromDictionary(Word word)
        {
            try
            {
                string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";

                if (!File.ReadAllText(filePath).Contains(word.word))
                {
                    MessageBox.Show($"The word '{word.word}' does not exist in the dictionary.", "Non-existent Word", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);
                List<string> newLines = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == word.word)
                    {
                        i += 3;
                    }
                    else
                    {
                        newLines.Add(lines[i]);
                    }
                }

                File.WriteAllLines(filePath, newLines);
                Console.WriteLine($"Word '{word.word}' deleted from the dictionary.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while deleting the word: " + e.Message);
            }
        }
    }
}
