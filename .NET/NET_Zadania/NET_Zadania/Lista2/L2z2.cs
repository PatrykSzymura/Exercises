using System;


namespace Lista2
{ 

	public class L2z2
	{
		public L2z2()
		{
            String bin = "010010";

            Console.WriteLine(ConvertHex(bin));
            Console.WriteLine(ConvertOct(bin));
            Console.WriteLine(ConvertDec(bin));
            Console.WriteLine(ConvertPen(bin));
        }

        public static string ConvertHex(string strBinary)
        {
            string strHex = Convert.ToInt32(strBinary, 2).ToString("X");
            return strHex;
        }

        public static string ConvertOct(string strBinary)
        {
            int convertnumber = Convert.ToInt32(strBinary, 2);
            return Convert.ToString(convertnumber, 8);
        }

        public static string ConvertDec(string strBinary)
        {
            return Convert.ToInt32(strBinary, 2).ToString();
        }

        public static string ConvertPen(string value)
        {
            int var = Convert.ToInt32(value,2);
            string result = string.Empty;
            char[] baseChars = {'0','1','2','3','4'};
            int Base = Convert.ToInt32("101", 2);

            do
            {
                result = baseChars[var % Base] + result;
                var = var / Base;
            }
            while (var > 0);

            return result;
        }
    }
}
