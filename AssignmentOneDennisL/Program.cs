using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentOneDennisL
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProg();
        }
        static void StartProg()
        {
            var numberList = new List<double>();
            string op1, op2, retry;
            double term1, term2, term3, sum;
            bool runProg = true;

            Console.Title = "Assignment One";

            while (runProg == true)
            {
                Console.Clear();
                Console.Write("Enter first operator: ");
                op1 = CheckUserInputForOperator();
                Console.Write("Enter second operator: ");
                op2 = CheckUserInputForOperator();
                Console.Write("Enter first term: ");
                term1 = CheckUserInputForTerm();
                Console.Write("Enter second term: ");
                term2 = CheckUserInputForTerm();
                Console.Write("Enter third term: ");
                term3 = CheckUserInputForTerm();

                sum = DoOperation(op1, term1, term2);
                sum = DoOperation(op2, sum, term3);
                numberList.Add(sum);
                Console.WriteLine("{0} {1} {2} {3} {4} = {5}", term1, op1, term2, op2, term3, sum);

                if (sum < 100)
                {
                    Console.WriteLine("Less then a hundred.");
                }
                else if (sum == 100)
                {
                    Console.WriteLine("Cool, now you have a hundred, clap clap");
                }
                else
                {
                    Console.WriteLine("More then a hundred.");
                }

                Console.WriteLine("Try again? y/n");
                retry = CheckUserInputForRetry();

                if (retry == "Y" || retry == "y")
                {
                    runProg = true;
                }
                else if (retry == "N" || retry == "n")
                {
                    runProg = false;
                }
            }
            sum = CalcEndSum(numberList);
            Console.WriteLine("Thank you for playing. The sum of all round is {0}. Counted using a for-loop. Bye", sum);
            Console.WriteLine("Thank you for playing. The sum of all round is {0}. Counted using Linq with .Sum(). Bye", numberList.Sum());
            Console.ReadKey();
        }
        static string CheckUserInputForOperator()
        {
            string userInput = "";
            bool wrongInput = true;
            while (wrongInput == true)
            {
                userInput = Console.ReadLine();
                if (userInput == "+" || userInput == "-" || userInput == "*" || userInput == "/")
                {
                    wrongInput = false;
                }
                else
                {
                    Console.Write("Wrong input! Enter a Operator: ");
                    wrongInput = true;
                }
            }
            return userInput;
        }
        static double CheckUserInputForTerm()
        {
            string userInput;
            bool wrongInput = true;
            double num = -1;
            while (wrongInput == true)
            {
                userInput = Console.ReadLine();
                if (double.TryParse(userInput, out num))
                {
                    wrongInput = false;
                }
                else
                {
                    Console.Write("Wrong input! Enter a Number: ");
                    wrongInput = true;
                }
            }
            return num;
        }
        static string CheckUserInputForRetry()
        {
            string userInput = "";
            bool wrongInput = true;
            while (wrongInput == true)
            {
                userInput = Console.ReadLine();
                if (userInput == "Y" || userInput == "y" || userInput == "N" || userInput == "n")
                {
                    wrongInput = false;
                }
                else
                {
                    Console.Write("Wrong input! Enter y/n: ");
                    wrongInput = true;
                }
            }
            return userInput;
        }
        static double DoOperation(string op, double a, double b)
        {
            double sum = 0;
            switch (op)
            {
                case "+":
                    sum = a + b;
                    break;
                case "-":
                    sum = a - b;
                    break;
                case "*":
                    sum = a * b;
                    break;
                case "/":
                    sum = a / b;
                    break;
            }
            return sum;
        }
        static double CalcEndSum(List<double> numberList)
        {
            double sum = 0;
            for (int i = 0; i < numberList.Count; i++)
            {
                sum += numberList[i];
            }
            return sum;
        }
    }
}
