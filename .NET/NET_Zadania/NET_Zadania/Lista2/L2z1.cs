using System;

namespace Lista2
{
    

    public class L2z1
    {
        HashSet<Liczby> Kolekcja = new HashSet<Liczby>();

        public L2z1(int size)
        {
            var rand = new Random();

            for (int i = 0; i < size; i++) { 
                Kolekcja.Add(new Liczby(rand.Next(-100,100))); 
            }

            DisplaySet();
            
            Console.WriteLine("Hell");
        }

        private void DisplaySet()
        {
            foreach (Liczby i in  Kolekcja) 
            {
                Object[] temp = i.GetValues();
                Console.WriteLine(" {0} {1} {2}", temp[0], temp[1], temp[2]);
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