using CsharpEvolution.WeeklyChallenges.Weekly01.Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Home
{

    public class Calculus : ICalculatorFeature
    {
        public void Show()
        {
            var operations = GetCalculusOperations();

            var operationsNames = operations.Select(x => x.Name).ToList();

            Console.WriteLine("The calculus feature has the below operations.");
            Console.WriteLine("========================================");
            operationsNames.ForEach(
                (name) => Console.WriteLine($"- {name}"));
            Console.WriteLine($"- Exit");
            Console.WriteLine("========================================\n");
        }

        public void Execute()
        {
            var mathOperationTypes = GetCalculusOperations();

            var chosenOperationType = null as Type;

            var hasInitialValue = false;

            var accumulatedValue = 0.0;

            while (!hasInitialValue)
            {
                Console.WriteLine("Please insert the initial value.");
                hasInitialValue = double.TryParse(Console.ReadLine(), out accumulatedValue);
            }

            while (chosenOperationType is null)
            {
                Console.WriteLine("Please insert the desired calculus operation.");

                var chosenOperation = Console.ReadLine();

                if (chosenOperation.ToLower() == "exit")
                    return;

                chosenOperationType = mathOperationTypes
                .DefaultIfEmpty(null)
                .FirstOrDefault(type => type.Name.ToLower() == chosenOperation.ToLower());

                var operation = (ICalculusOperation)Activator.CreateInstance(chosenOperationType);

                operation.FirstNumber = accumulatedValue;

                GetOperationParameters(operation);

                accumulatedValue = operation.Calculate();

                Console.WriteLine($"Result: {accumulatedValue}.\n");

                chosenOperationType = null as Type;
            }
        }

        private IEnumerable<Type> GetCalculusOperations()
        {
            var operations =
                System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces().Contains(typeof(ICalculusOperation)));

            return operations;
        }

        private void GetOperationParameters(ICalculusOperation operationType)
        {
            //TODO: Quando existirem operações com mais de 2 parâmetros, tornar este método mais flexível.           
            bool hasAllParameters = false;
            double secondParameter = 0.0;
            
            while (!hasAllParameters)
            {
                Console.WriteLine("Please insert the second parameter.");
                hasAllParameters = double.TryParse(Console.ReadLine(), out secondParameter);
            }

            operationType.SecondNumber = secondParameter;
        }
    }
}
