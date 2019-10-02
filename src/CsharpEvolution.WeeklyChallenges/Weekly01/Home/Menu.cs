using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsharpEvolution.WeeklyChallenges.Weekly01.Calculus;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Home
{
    public class Menu
    {
        public void Show()
        {
            var features = 
                System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces().Contains(typeof(IFeature)));

            var featuresNames = features.Select(x => x.Name).ToList();

            var featureType = null as Type;

            while (featureType is null)
            {
                Console.WriteLine("Please type the desired feature.");

                featuresNames.ForEach(
                    (name) => Console.WriteLine(name));

                var chosenFeature = Console.ReadLine();

                featureType = features
                    .DefaultIfEmpty(null)
                    .FirstOrDefault(type => type.Name.ToLower() == chosenFeature.ToLower());
            }

            Console.WriteLine($"The feature {featureType.Name} was selected!");
            
            var feature = (IFeature)Activator.CreateInstance(featureType);

            feature.Execute();
        }
    }
}
