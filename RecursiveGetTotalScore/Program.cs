using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Practical_2_Q_5
{
    /// <summary>
    /// C# Create a program that count/calculate mazimum/average score/result from A text file “data.txt”.
    /// and total number of pass score and total score using recursive method.
    /// Author: Faryaz
    /// </summary>

    class Tester
    {
        static void Main(string[] args)
        {
            ScoreApp app = new ScoreApp("data.txt");
            WriteLine(new String('-', 50));
            app.PrintAll();
            WriteLine(new String('-', 50));
            WriteLine("Max score: " + app.GetMaxScore());
            WriteLine("Average score: " + app.GetAverageScore());
            WriteLine("Number of pass scores: " + app.CountPassScore());
            WriteLine("Total score (recursion): " +
            RecursiveGetTotalScore(app.Students));
        }
        static double RecursiveGetTotalScore(List<Student> list)
        {

            if (list == null || list.Count == 0)
            {
                return 0;
            }
            else
            {
                double ScorefstElm = list[0].Score;
                List<Student> Midlist = list.GetRange(1, list.Count - 1);
                double total = ScorefstElm + RecursiveGetTotalScore(Midlist);
                return total;


            }
        }
    }
    class ScoreApp
    {
        public List<Student> Students { get; set; }
        public ScoreApp(string filename)
        {
            Students = new List<Student>();
            ReadStudentData(filename);
        }
        public void ReadStudentData(string filename)
        {
            //fill the code
            Students = new List<Student>();
            using (StreamReader StrIn = new StreamReader(filename))
            {
                while (StrIn.EndOfStream == false)
                {
                    string line = StrIn.ReadLine();
                    string[] item = line.Split(',');
                    string id = item[0];
                    double scr = double.Parse(item[1]);
                    Student s = new Student(id, scr);
                    Students.Add(s);
                }
            }
        }

        public void PrintAll()
        {
            foreach (Student s in Students)
            {
                WriteLine($"{s.ID}: {s.Score}");
            }
        }
        public double GetMaxScore()
        {
            double max = double.MinValue;
            foreach (Student s in Students)
            {
                if (max < s.Score)
                {
                    max = s.Score;
                }
            }
            return max;

        }


        public double GetAverageScore()
        {

            double total = 0;
            foreach (Student s in Students)
            {
                total += s.Score;
            }
            double avg = 0;
            if (Students.Count > 0)
            {
                avg = total / Students.Count;
            }
            return avg;
        }
        public int CountPassScore()
        {
            int count = 0;
            foreach (Student s in Students)
            {
                if (s.Score == 50 || s.Score > 50)
                {
                    count++;
                }
            }
            return count;
        }
    }
    class Student
    {
        public string ID { get; set; }
        public double Score { get; set; }
        public Student(string id, double scr)
        {
            ID = id;
            Score = scr;
        }


    }
}