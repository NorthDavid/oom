﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace Task4
{
    public interface Tonaufnahme
    {
        decimal Price { get; set; }
        string Title { get; }
        int Year { get; set; }
        Length Duration { get; set; }
    }
    public class MusicTitle : Tonaufnahme
    {
        private decimal m_prize;
        private string m_title;
        private string m_interpret;
        private int m_year;
        private Length m_duration;

        public string Title => m_title;
        public string Interpret => m_interpret;
        public Length Duration
        {
            get { return m_duration; }
            set
            {
                if (value.Duration > 0 && (string.Compare(value.Unit, "s") == 0 || string.Compare(value.Unit, "m") == 0))
                    m_duration = value;
                else
                    throw new ArgumentException("Unit must be \"s\" or \"m\" and value must be greater than 0!");
            }
        }
        public decimal Price
        {
            get { return m_prize; }
            set
            {
                if (value > 0)
                    m_prize = value;
                else
                    throw new ArgumentException("Value for price must be greater than 0!");
            }
        }
        public int Year
        {
            get { return m_year; }
            set
            {
                if (value > 0)
                    m_year = value;
                else
                    throw new ArgumentException("Value for year must be greater than 0!");
            }
        }

        public MusicTitle(string newInterpret, string newTitle, int newYear, decimal newLength, string Format, decimal newPrize)
            : this(newInterpret, newTitle, newYear, new Length(newLength, Format), newPrize)
        {

        }

        [JsonConstructor]
        public MusicTitle(string Interpret, string Title, int newYear, Length duration, decimal newPrize)
        {
            this.m_interpret = Interpret;
            this.m_title = Title;
            this.m_prize = newPrize;
            this.m_year = newYear;
            this.m_duration = duration;
            
        }
    }
    public class Podcast : Tonaufnahme
    {
        private decimal m_prize;
        private string m_title;
        private string m_publisher;
        private int m_year;
        private Length m_duration;

        public string Title => m_title;
        public string Publisher => m_publisher;
        public Length Duration
        {
            get { return m_duration; }
            set
            {
                if (value.Duration > 0 && (string.Compare(value.Unit,"s") == 0 || string.Compare(value.Unit, "m") == 0))
                    m_duration = value;
                else
                    throw new ArgumentException("Unit must be \"s\" or \"m\" and value must be greater than 0!");
            }
        }
        public decimal Price
        {
            get { return m_prize; }
            set
            {
                if (value > 0)
                    m_prize = value;
                else
                    throw new ArgumentException("Value for price must be greater than 0!");
            }
        }
        public int Year
        {
            get { return m_year; }
            set
            {
                if (value > 0)
                    m_year = value;
                else
                    throw new ArgumentException("Value for year must be greater than 0!");
            }
        }

        public Podcast(string newPublisher, string newTitle, int newYear, decimal newLength, string Format, decimal newPrize)
            : this(newPublisher, newTitle,newYear, new Length(newLength,Format), newPrize)
        {

        }

        [JsonConstructor]
        public Podcast(string Publisher, string Title, int newYear, Length duration, decimal newPrize)
        {
            this.m_publisher = Publisher;
            this.m_title = Title;
            this.m_prize = newPrize;
            this.m_year = newYear;
            this.m_duration = duration;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Tonaufnahme[2];
            a[0] = new MusicTitle("test_Interpret", "test_Title", 2000, 179.2m, "s", 3.99m);
            a[1] = new Podcast("test_Publisher", "test_Title", 1999, new Length(32,"m"), 6.99m);

            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

            string s = JsonConvert.SerializeObject(a, settings);
            File.WriteAllText("export.json", s);

            var textFromFile = File.ReadAllText("export.json");
            var e = JsonConvert.DeserializeObject<Tonaufnahme[]>(textFromFile, settings);



            Console.WriteLine("String before Export:");
            Console.WriteLine(s);
            Console.WriteLine("\n\nString after Import:");
            Console.WriteLine(textFromFile);

            Console.WriteLine("\n\nCompare Titles:");
            Console.Write($"a: {a[0].Title} & {a[1].Title}");
            Console.WriteLine($"   e: {e[0].Title} & {e[1].Title}");

            Console.WriteLine("\n\nCompare Durations:");
            Console.Write($"a: {Math.Round(a[0].Duration.Duration, 1)}{a[0].Duration.Unit}");
            Console.WriteLine($"   a: {Math.Round(a[1].Duration.Duration, 1)}{a[1].Duration.Unit}");
            Console.Write($"e: {Math.Round(e[0].Duration.Duration, 1)}{e[0].Duration.Unit}");
            Console.WriteLine($"   e: {Math.Round(e[1].Duration.Duration, 1)}{e[1].Duration.Unit}");

            Console.WriteLine("\n\n\n\n");




            var b = new Podcast[4];
            b[0] = new Podcast("Publisher_B1", "Title_B1", 2999, new Length(12, "s"), 10);
            b[1] = new Podcast("Publisher_B2", "Title_B2", 2999, new Length(12, "s"), 1);
            b[2] = new Podcast("Publisher_B3", "Title_B3", 2999, new Length(12, "s"), -12);
            b[3] = new Podcast("Publisher_B4", "Title_B4", 2999, new Length(12, "s"), 1);

            //Task6
            var test = new Subject<Podcast>();
            test
                .Where(x => x.Price > 0)
                .Subscribe(x =>
                    {
                        Console.WriteLine($"received Podcast: {x.Title}");
                    });

            foreach (Podcast pod in b) test.OnNext(pod);
            Console.WriteLine("\n\n\n\n");


            //Task7
            var random = new Random();
            var sw = new Stopwatch(); sw.Start();
            var tasks = new List<Task<Podcast>>();
            foreach (var pod in b)
            {
               var task = Task.Run(() =>
                {
                    Console.WriteLine($"T1: Start {pod.Title}");
                    Task.Delay(TimeSpan.FromSeconds(1.0 + random.Next(2))).Wait();
                    Console.WriteLine($"T1: End {pod.Title}");
                    return pod;
                });

                tasks.Add(task);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Start();

            var tasks2 = new List<Task<Podcast>>();
            foreach (var task in tasks)
            {
                tasks2.Add(task.ContinueWith(t => 
                {
                    Console.WriteLine($"T2: {t.Result.Title}");
                    return t.Result;
                }));
            }

            Console.WriteLine(sw.Elapsed);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine(sw.Elapsed);
        }
    }
}
