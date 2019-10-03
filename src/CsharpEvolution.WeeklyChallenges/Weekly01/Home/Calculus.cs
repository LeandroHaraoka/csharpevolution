using CsharpEvolution.WeeklyChallenges.Weekly01.Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Home
{

    public class Calculus : ICalculatorFeature
    {
        private readonly IEnumerable<Type> _operations;

        public Calculus()
        {
            _operations = 
                System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces()
                        .Contains(typeof(ICalculusOperation)));
        }

        public void Show()
        {
            var operationsNames = _operations.Select(x => x.Name).ToList();

            Console.WriteLine("The calculus feature has the below operations.");
            Console.WriteLine("========================================");
            operationsNames.ForEach(
                (name) => Console.WriteLine($"- {name}"));
            Console.WriteLine($"- Exit");
            Console.WriteLine("========================================\n");
        }

        public void Execute()
        {
            var hasInitialValue = false;
            var accumulatedValue = 0.0;

            while (!hasInitialValue)
            {
                Console.WriteLine("Please insert the initial value.");
                hasInitialValue = double.TryParse(Console.ReadLine(), out accumulatedValue);
            }

            var chosenOperationType = null as Type;
            while (chosenOperationType is null)
            {
                while (chosenOperationType is null)
                {
                    Console.WriteLine("Please insert the desired calculus operation.");

                    var chosenOperation = Console.ReadLine();

                    if (chosenOperation.ToLower() == "exit")
                        return;

                    chosenOperationType = _operations
                    .DefaultIfEmpty(null)
                    .FirstOrDefault(type => type.Name.ToLower() == chosenOperation.ToLower());
                }

                var operation = (ICalculusOperation)Activator.CreateInstance(chosenOperationType);

                InitializeOperation(operation, accumulatedValue);

                accumulatedValue = operation.Calculate();

                Console.WriteLine($"Result: {accumulatedValue}.\n");

                chosenOperationType = null as Type;
            }
        }

        private void InitializeOperation(ICalculusOperation operationType,
            double firstNumber)
        {
            //TODO: Quando existirem operações com mais de 2 parâmetros, tornar este método mais flexível.           
            bool hasAllParameters = false;
            operationType.FirstNumber = firstNumber;

            while (!hasAllParameters)
            {
                Console.WriteLine("Please insert the second parameter.");
                hasAllParameters = double.TryParse(Console.ReadLine(), out var secondNumber);
                operationType.SecondNumber = secondNumber;
            }
        }
    }
}
