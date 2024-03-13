using System;

public class L1
{
    public static void Start() {
        Console.WriteLine("Podaj Nr Zadania");
        int cho = int.Parse(Console.ReadLine());

        switch (cho)
        {
            case 1:
                Console.WriteLine("Input number");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(num + " Is " + (isPrimaryNumber(num) ? "Primary" : "Not Primary") + " Number");
                L1.Start();
                break;
            case 2:
                Console.WriteLine("Input string");
                string txt = Console.ReadLine();
                Console.WriteLine(txt + "Is " + (isPolindrome(txt) ? "Polindrome" : "Not Polindrome"));
                L1.Start();
                break;
            case 3:
                Console.WriteLine("Input number");
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine(num2 + "Is" + (isTriangleNumber(num2) ? "Triangle" : "Not Triangle") + "Number");
                L1.Start();
                break;
            case 4:
                Console.WriteLine("Input a: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Input b: ");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Input c: ");
                int c = int.Parse(Console.ReadLine());
                Console.WriteLine($"Roots of function {0}x^2+{1}x+{2}=0",a,b,c);
                Console.WriteLine(" of are " + SquareRoots(a, b, c));
                L1.Start();
                break;
            case 5:
                Console.WriteLine("Input n: ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("Input K: ");
                int k = int.Parse(Console.ReadLine());
                Console.WriteLine(SquareRoot(n,k));
                L1.Start();
                break;
            case 6:
                break;
            default: 
                L1.Start();
                break;
        }
    }

    private static bool isPrimaryNumber(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }

    private static bool isPolindrome(string txt)
    {
        char[] cArray = txt.ToCharArray();
        Array.Reverse(cArray);
        string revStr = new string(cArray);

        if (txt == revStr) return true;
        else return false;
    }

    private static bool isTriangleNumber(int num)
    {
        int temp = 0;
        for (int i = 0; i <= num; i++)
        {
            temp += i;

            if (temp == num) return true;
            else if (temp > num) break;
            else continue;
        }
        return false;
    }

    private static Tuple<double, double> SquareRoots(int a, int b, int c)
    {
        int delta = (b * b) - 4 * (a * c);

        if (delta > 0)
        {
            double x1 = (-b) + Math.Sqrt(delta);
            double x2 = (-b) - Math.Sqrt(delta);
            x1 /= (2 * a);
            x2 /= (2 * a);
            x1 = Math.Round(x1, 2);
            x2 = Math.Round(x2, 2);
            return Tuple.Create(x1, x2);
        }
        else if (delta == 0)
        {
            double x0 = Math.Round(-b / (2.0 * a), 2);
            return Tuple.Create(x0, x0);
        }
        else
        {
            return Tuple.Create(0.0 / 2.0, 0.0 / 2.0);
        }
    }

    private static double SquareRoot(int n, int K)
    {
        return Math.Pow(K, 1.0 / n);
    }
}