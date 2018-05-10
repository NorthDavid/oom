using System;

namespace Task2
{
    class MusicTitle
    {
        private decimal m_prize;
        private string m_title;
        private string m_interpret;

        public string Title => m_title;
        public string Interpret => m_interpret;

        public decimal Price
        {
            get { return m_prize; }
            set { if (value > 0) m_prize = value; }
        }

        public MusicTitle(string newInterpret, string newTitle, decimal newPrize)
        {
            m_interpret = newInterpret;
            m_title = newTitle;
            this.m_prize = newPrize;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicTitle a = new MusicTitle("testInterpet", "testTitle", 400);

            Console.WriteLine($"Music Title = {a.Title}");
            Console.WriteLine($"Music Interpret = {a.Interpret}");
            Console.WriteLine($"Music Price = {a.Price}");
            Console.WriteLine($"Music new Price = {a.Price = 500}");

        }
    }
}
