using LinearEquations.Infrastructure.Shared.Interfaces;
using LinearEquations.Infrastructure.Shared.Processes;
using LinearEquations.Infrastructure.Shared.Processes.Client;
using LinearEquations.Infrastructure.Shared.Util;
using LinearEquations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearEquations
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("LINEAR EQUATIONS SOLVER");
            var userInput = Menu();
            var equation = CreateCoeffiecientsAndConstants(userInput);
            if (equation?.Count() > 1)
            {
                var linearEquationsSolverClient = new LinaearEquationsSolverClient();
                linearEquationsSolverClient.Execute(equation[0], equation[1]);
            }
            else
            {
                Console.WriteLine("Invalid Inputs");
            }
        }

        private static string[] Menu()
        {
            var strUserInput = "";
            var counter = 1;
            do
            {
                Console.WriteLine($"EQ# {counter} : ");
                Console.SetCursorPosition(9, counter);
                var input = Console.ReadLine();
                counter += 1;
                strUserInput += input + Environment.NewLine;
            } while (!strUserInput.ToUpper().Contains("END"));

            var userInput = strUserInput?.ToUpper().Split("END");
            return userInput;

        }

        public static List<string> CreateCoeffiecientsAndConstants(string[] userInput)
        {
            var equation = new List<string>();
            if (ValidateUserInput(userInput[0]))
            {
                var equations = userInput[0];

                var buffer = equations.Split(Environment.NewLine);
                var coefficients = "";
                var constants = "";
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(buffer[i])) continue;
                    constants += buffer[i].Split(" ").Last() + Environment.NewLine;
                    var coeffecientList = buffer[i].Split(" ").SkipLast(1);
                    coefficients += string.Join(" ", coeffecientList) + Environment.NewLine;
                }

                equation.Add(coefficients);
                equation.Add(constants);

            }
            return equation;
        }

        private static bool ValidateUserInput(string userInput)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Input can not be Empty");
                    return false;
                }

                userInput = userInput?.Replace(" ", "");
                userInput = userInput?.Replace(Environment.NewLine, "");
                userInput = userInput?.Replace("+", "").Replace("-", "").Replace(".", "");
                if (!Util.IsNumeric(userInput))
                {
                    Console.WriteLine("Equation Includes Non Numeric Values");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
                return false;
            }
        }
    }
}
