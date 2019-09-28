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

            Console.WriteLine("Please insert the desired math operation.");
            var chosenOperation = Console.ReadLine();

            var chosenOperationType = mathOperationTypes
                .FirstOrDefault(type => type.Name.ToLower() == chosenOperation.ToLower());

            var operation = (IMathOperation)Activator.CreateInstance(chosenOperationType);
        }
    }
}
