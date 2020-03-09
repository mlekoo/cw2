using System;
using System.Collections.Generic;
using System.IO;

namespace cw2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = "dane.csv";
            List<Student> studentList = new List<Student>();

            try
            {
                var lines = File.ReadLines(path);
                foreach (var line in lines)
                {

                    var data = line.Split(",");
                    Student student = new Student();
                    student.Imie = data[0];
                    student.Nazwisko = data[1];
                    student.Kierunek = data[2];
                    student.TrybStudiow = data[3];
                    student.NumerIndeksu = data[4];
                    student.DataRozpoczecia = DateTime.Parse(data[5]).ToShortDateString();
                    student.Email = data[6];
                    student.ImieMatki = data[7];
                    student.ImieOjca = data[8];
                    studentList.Add(student);


                }

                HashSet<Student> studentHash = new HashSet<Student>(new OwnComparer());
                foreach (var student in studentList)
                {
                    if (string.IsNullOrEmpty(student.Imie))
                    {
                        if (string.IsNullOrEmpty(student.Nazwisko))
                        {
                            if (string.IsNullOrEmpty(student.Kierunek))
                            {
                                if (string.IsNullOrEmpty(student.TrybStudiow))
                                {
                                    if (string.IsNullOrEmpty(student.NumerIndeksu))
                                    {
                                        if (string.IsNullOrEmpty(student.DataRozpoczecia))
                                        {
                                            if (string.IsNullOrEmpty(student.Email))
                                            {
                                                if (string.IsNullOrEmpty(student.ImieMatki))
                                                {
                                                    if (string.IsNullOrEmpty(student.ImieOjca))
                                                    {
                                                        if (!studentHash.Add(student))
                                                        {
                                                            log(student + " błąd");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine(student);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna", e);
                log("Podana ścieżka jest niepoprawna " + e);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Plik " + path + " nie istnieje", e);
                log("Plik " + path + " nie istnieje " + e);
            }

            Console.Write(studentList);


            var today = DateTime.UtcNow;

        }

        public static void log(string text)
        {
            using (StreamWriter sw = new StreamWriter("log.txt",true))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }

        }
    }
}



