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
                if (word.image.EndsWith(".jpg") == false)
                {
                    MessageBox.Show($"The image of the word '{word.word}' is not a .jpg file.", "Not .jpg Image", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";

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

                string[] lines = File.ReadAllLines(filePath);
                bool foundWord = false;

                for (int i = 0; i < lines.Length; i += 4)
                {
                    if (lines[i] == word.word)
                    {
                        foundWord = true;
                        break;
                    }
                }

                if (foundWord == false)
                {
                    MessageBox.Show($"The word '{word.word}' does not exist in the dictionary.", "Non-existent Word", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                for (int i = 0; i < lines.Length; i += 4)
                {
                    if (lines[i] == word.word)
                    {
                        if(word.description == lines[i + 1])
                        {
                            MessageBox.Show($"The description of the word '{word.word}' is the same as the old one.", "Same Description", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        if(word.image == lines[i + 2])
                        {
                            MessageBox.Show($"The image of the word '{word.word}' is the same as the old one.", "Same Image", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        if(word.category == lines[i + 3])
                        {
                            MessageBox.Show($"The category of the word '{word.word}' is the same as the old one.", "Same Category", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        if (word.image.EndsWith(".jpg") == false)
                        {
                            MessageBox.Show($"The image of the word '{word.word}' is not a .jpg file.", "Not .jpg Image", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
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

                string[] lines = File.ReadAllLines(filePath);
                bool foundWord = false;

                for(int i = 0; i < lines.Length; i += 4)
                {
                    if (lines[i] == word.word)
                    {
                        foundWord = true;
                        break;
                    }
                }

                if(foundWord == false)
                {
                    MessageBox.Show($"The word '{word.word}' does not exist in the dictionary.", "Non-existent Word", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

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
