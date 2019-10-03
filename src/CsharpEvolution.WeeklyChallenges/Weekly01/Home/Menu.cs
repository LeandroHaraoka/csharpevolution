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
            var features = GetFeaturesTypes();
        
            var featuresNames = features.Select(x => x.Name).ToList();

            Console.WriteLine("\nThis calculator has the below features.");
            Console.WriteLine("========================================");
            featuresNames.ForEach(
                (name) => Console.WriteLine($"- {name}"));
            Console.WriteLine("========================================\n");
        }

        public IFeature SelectFeature()
        {
            var featureType = null as Type;
            var features = GetFeaturesTypes();

            while (featureType is null)
            {
                Console.WriteLine("Please type the desired feature.");

                var chosenFeature = Console.ReadLine();

                featureType = features
                    .DefaultIfEmpty(null)
                    .FirstOrDefault(type => type.Name.ToLower() == chosenFeature.ToLower());
            }

            Console.WriteLine($"The feature {featureType.Name} was selected!\n");
            
            var feature = (IFeature)Activator.CreateInstance(featureType);

            return feature;
        } 

        private IEnumerable<Type> GetFeaturesTypes()
        {
            var features = 
                System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces().Contains(typeof(IFeature)) && !mytype.IsInterface);

            return features;
        }
    }
}
