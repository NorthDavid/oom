using System;

namespace Task3
{
    public interface Tonaufnahme
    {
        decimal Price { get; set; }
        string Title { get; }
        int Year { get; set; }
        decimal getLength(string Format);
        void setLength(string Format, decimal Time);
    }
    public class MusicTitle : Tonaufnahme
    {
        private decimal m_prize;
        private string m_title;
        private string m_interpret;
        private int m_year;
        private decimal m_length;

        public string Title => m_title;
        public string Interpret => m_interpret;

        public decimal Price
        {
            get { return m_prize; }
            set { if (value > 0) m_prize = value; }
        }
        public int Year
        {
            get { return m_year; }
            set { if (value > 0) m_year = value; }
        }
        public void setLength(string Format, decimal Time)
        {
            switch (Format)
            {
                case "s":
                    if (Time > 0) m_length = Time; break;
                case "m":
                    if (Time > 0) m_length = Time * 60; break;
                default:
                    throw new ArgumentException("Format must be \"s\" or \"m\"!");
            }      
        }
        public decimal getLength(string Format)
        {
            switch (Format)
            {
                case "s":
                    return m_length;
                case "m":
                    return m_length / 60;
                default:
                    throw new ArgumentException("Format must be \"s\" or \"m\"!");
            }
        }



        public MusicTitle(string newInterpret, string newTitle, int newYear, decimal newLength, string Format, decimal newPrize)
        {
            m_interpret = newInterpret;
            m_title = newTitle;
            this.m_prize = newPrize;
            this.m_year = newYear;
            setLength(Format, newLength);
        }
    }
    public class Podcast : Tonaufnahme
    {
        private decimal m_prize;
        private string m_title;
        private string m_publisher;
        private int m_year;
        private decimal m_length;

        public string Title => m_title;
        public string Publisher => m_publisher;

        public decimal Price
        {
            get { return m_prize; }
            set { if (value > 0) m_prize = value; }
        }
        public int Year
        {
            get { return m_year; }
            set { if (value > 0) m_year = value; }
        }
        public void setLength(string Format, decimal Time)
        {
            switch (Format)
            {
                case "s":
                    if (Time > 0) m_length = Time; break;
                case "m":
                    if (Time > 0) m_length = Time * 60; break;
                default:
                    throw new ArgumentException("Format must be \"s\" or \"m\"!");
            }
        }
        public decimal getLength(string Format)
        {
            switch (Format)
            {
                case "s":
                    return m_length;
                case "m":
                    return m_length / 60;
                default:
                    throw new ArgumentException("Format must be \"s\" or \"m\"!");
            }
        }



        public Podcast(string newPublisher, string newTitle, int newYear, decimal newLength, string Format, decimal newPrize)
        {
            m_publisher = newPublisher;
            m_title = newTitle;
            this.m_prize = newPrize;
            this.m_year = newYear;
            setLength(Format, newLength);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tonaufnahme a = new MusicTitle("test_Interpret", "test_Title", 2000, 179, "s", 3.99m);
            Tonaufnahme b = new Podcast("test_Publisher", "test_Title", 1999, 90, "m", 6.99m);

            Console.WriteLine($"Title: {a.Title} & {b.Title}");
            Console.WriteLine($"Length: {Math.Round(b.getLength("s"),0)}sec & {Math.Round(b.getLength("m"),2)}min");
            Console.WriteLine($"Length: {Math.Round(a.getLength("s"), 0)}sec & {Math.Round(a.getLength("m"), 2)}min");
        }
    }
}
