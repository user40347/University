

class Program
{


    public class OneString
    {
        public OneString(OneString previousString)
        {

            this.FString = previousString.FString;

        }


        public OneString(string firstString)
        {
            this.FString = firstString;

        }

        public string FString { get; set; }

        public string FLSymbols()
        {
            if (FString != "")
            {
                return FString[0].ToString() + FString[FString.Length - 1].ToString();
            }
            return FString;

        }

        public override string ToString()
        {
            return FString;
        }
    }

    public class DoubleString : OneString
    {
        public string SecondString { get; set; }

        public DoubleString(string firstString, string secondString)
            : base(firstString)
        {

            SecondString = secondString;

        }

        public string SumStrings()
        {
            return FString + SecondString;
        }

        public string MergeStrings()
        {
            string res = "";
            if (FString.Length > SecondString.Length && FString != "")
            {
                for (int i = 0; i < FString.Length; i++)
                {
                    res += FString[i];
                    if (i < SecondString.Length)
                    {
                        res += SecondString;
                    }
                }
                return res;

            }
            else if (FString.Length < SecondString.Length && SecondString != "")
            {
                for (int i = 0; i < SecondString.Length; i++)
                {
                    res += FString[i];
                    if (i < SecondString.Length)
                    {
                        res += FString;
                    }
                }
                return res;
            }
            else
            {
                return res;
            }
        }


    }


    static void Main()
    {
        Console.WriteLine("Введите строку");
        OneString string1 = new OneString(Console.ReadLine());
        OneString string2 = new OneString(string1);

        Console.WriteLine("Строка 1: " + string1.ToString());
        Console.WriteLine("Строка 1: " + string2.ToString());
        Console.WriteLine("Строка 1 First and last symbols: " + string2.FLSymbols());

        Console.WriteLine("Введите строку");
        string fs = Console.ReadLine();
        Console.WriteLine("Введите вторую строку");
        string ss = Console.ReadLine();

        DoubleString string3 = new DoubleString(fs,ss);
        Console.WriteLine("Строка 2: "+string3);
        Console.WriteLine("Сумма строк 1 и 2: " + string3.SumStrings());
        Console.WriteLine("Смешивание строк 1 и 2: " + string3.SumStrings());


    }
}
