using System;
using System.Text.RegularExpressions;
class Program
{
    public static void Main(string[] args)
    {
        /*The randomly generated answer should be four (4) digits in length, with each digit between the numbers 1 and 6*/
        Console.WriteLine("***********MASTERMIND*************");
        string code = "";
        int attempt = 0;
        Random random = new Random();
        for (int i = 0; i < 4; i++){
          code = code + random.Next(1, 6); 
        }
        Console.WriteLine(code);
        while (true) {
            int num = 0;
            String pin = "";
            while (pin.Length != 4 || !(Regex.IsMatch(pin, @"^[0-9]+$")))
            {
                Console.WriteLine("Attempt # " + (attempt + 1) + ": Enter your 4 digit Number:");
                pin = Console.ReadLine();
                if (pin.Length != 4 || !(Regex.IsMatch(pin, @"^[0-9]+$"))) { Console.WriteLine("Invalid!"); }
            }
            /*Print all plus signs first, all minus signs second, and nothing for     incorrect digits. */
            String plus = "";
            String minus = "";
            String empty = "";
            for (int i = 0; i < 4; i++){
                if (pin[i] == code[i]) {
                    num++;
                    // Console.Write("+");
                    plus = plus + "+";
                }
                else{
                    if (code.Contains(Char.ToString(pin[i]))){
                        //Console.Write("-");
                        minus = minus + "-";
                    }
                    else{//Console.Write(" ");
                        empty = empty + " ";
                    }
                }
            }
            Console.WriteLine(plus + minus + empty);
            if (num == 4) { Console.WriteLine("****Correct!****"); }
            Console.WriteLine(plus.Length + " (+)in correct position ");
            Console.WriteLine(minus.Length + " (-) in wrong position ");
            Console.WriteLine(empty.Length + "  wrong digit ");
            attempt = attempt + 1;
            Console.WriteLine("");
            if (attempt != 10 && num == 4) { break; }
            if (attempt == 10 && num != 4)
            {
                Console.WriteLine("****You Lost!****");
                Console.WriteLine("The code is :" + code);
            }
        }
    }
}
