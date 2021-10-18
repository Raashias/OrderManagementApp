using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Training\EuroTraining\OrderManagementApp\Quiz\sample-quiz-file.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<questions> quiz = new List<questions>();

            while (sr.Peek() > 0)
            {
                questions quest = new questions();
                string line = sr.ReadLine();
                string[] text = line.Split('|');
                quest.question = text[0];
                int count = 0;
                foreach (string item in text)
                {
                    if (item.Contains("*"))
                    {
                        quest.answer = count;
                        break;
                    }
                    count++;
                }
                quest.option1 = text[1].Contains("*") ? text[1].Trim(new char[] { '*' }) : text[1];
                quest.option2 = text[2].Contains("*") ? text[2].Trim(new char[] { '*' }) : text[2];
                quest.option3 = text[3].Contains("*") ? text[3].Trim(new char[] { '*' }) : text[3];
                quest.option4 = text[4].Contains("*") ? text[4].Trim(new char[] { '*' }) : text[4];

                quiz.Add(quest);
            }
            sr.Close();
            fs.Close();

            Console.WriteLine("Let's start quiz!!!!");
            Console.WriteLine("Enter the correct option");
            int score = 0;
            foreach (questions item in quiz)
            {
                Console.WriteLine(item.question);
                Console.WriteLine("1." + item.option1);
                Console.WriteLine("2." + item.option2);
                Console.WriteLine("3." + item.option3);
                Console.WriteLine("4." + item.option4);
                int ans = Convert.ToInt32(Console.ReadLine());
                if (ans == item.answer)
                {
                    Console.WriteLine("Your answer is correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect Answer");
                }
            }
            Console.WriteLine("Your total score is:" + score);
            Console.Read();
        }
    }
}
    