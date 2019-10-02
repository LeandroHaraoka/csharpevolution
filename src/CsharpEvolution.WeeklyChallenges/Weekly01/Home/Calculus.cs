using CsharpEvolution.WeeklyChallenges.Weekly01.Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Home
{

    public class Calculus : IFeature
    {
        public void Execute()
        {
            var mathOperationTypes = 
                System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces().Contains(typeof(IMathOperation)));

            var chosenOperationType = null as Type;

            while (chosenOperationType is null)
            {
                Console.WriteLine("Please insert the desired calculus operation.");

                var chosenOperation = Console.ReadLine();

                chosenOperationType = mathOperationTypes
                    .DefaultIfEmpty(null)
                    .FirstOrDefault(type => type.Name.ToLower() == chosenOperation.ToLower());
            }

           Console.WriteLine($"The operation {chosenOperationType.Name} was selected!");
            var operation = (IMathOperation)Activator.CreateInstance(chosenOperationType); 
        }
    }
}
