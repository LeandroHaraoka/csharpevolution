using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsharpEvolution.WeeklyChallenges.Weekly01.Calculus;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Home
{
    public class Menu
    {
        private readonly IEnumerable<Type> _features;

        public Menu()
        {
            _features = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces()
                        .Contains(typeof(IFeature)) && !mytype.IsInterface);
        }

        public void Show()
        {
            var featuresNames = _features.Select(x => x.Name).ToList();

            Console.WriteLine("\nThis calculator has the below features.");
            Console.WriteLine("========================================");
            featuresNames.ForEach(
                (name) => Console.WriteLine($"- {name}"));
            Console.WriteLine("========================================\n");
        }

        public IFeature SelectFeature()
        {
            var featureType = null as Type;

            while (featureType is null)
            {
                Console.WriteLine("Please type the desired feature.");

                var chosenFeature = Console.ReadLine();

                featureType = _features
                    .FirstOrDefault(type => type.Name.ToLower() == chosenFeature.ToLower());
            }

            Console.WriteLine($"The feature {featureType.Name} was selected!\n");
            
            var feature = (IFeature)Activator.CreateInstance(featureType);

            return feature;
        } 
    }
}
