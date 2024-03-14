using System;

namespace Lista2
{
    

    public class L2z1
    {
        HashSet<Liczby> Kolekcja = new HashSet<Liczby>();

        public L2z1(int size, int min = -100, int max = 100)
        {
            var rnd = new Random();
            var randomNumbers = Enumerable.Range(min, max).OrderBy(x => rnd.Next()).Take(size).ToList();

            foreach (int i in randomNumbers)
            {
                this.Kolekcja.Add(new Liczby(i));
            }

            DisplaySet();
            
        }

        private void DisplaySet()
        {
            Console.WriteLine(" Liczba | Wartosc_Bezwzgledna | Parzysta");
            foreach (Liczby i in  Kolekcja) 
            {
                Object[] temp = i.GetValues();
                Console.WriteLine(" {0,6} | {1,19} | {2,8}", temp[0], temp[1], temp[2]);
            }
        }
    }
    public class Liczby {
        int wartosc, 
            wartoscBezwzgledna;
        bool czyParzysta;

        public Liczby(int var) {
            this.wartosc = var;
            this.wartoscBezwzgledna = Math.Abs(var);
            this.czyParzysta = (var % 2 == 0) ? true : false;
        }

        public Object[] GetValues()
        {
            return new Object[] { this.wartosc, this.wartoscBezwzgledna, this.czyParzysta};
        }
        
    }
}