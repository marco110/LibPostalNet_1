using LibPostalNet;
using System;

namespace LibPostalConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string address = "781 Franklin Ave Crown Heights Brooklyn NYC NY 11216 USA";

            Console.WriteLine("Loading LibPostal...");
            LibPostal libPostal = LibPostal.GetInstance();
            libPostal.LoadParser();
            libPostal.LoadLanguageClassifier();
            libPostal.PrintFeatures = true;
            Console.WriteLine("Loaded.");

            // Parser Tests
            var parserOptions = libPostal.GetAddressParserDefaultOptions();
            using (var response = libPostal.ParseAddress(address, parserOptions))
            {
                foreach (var x in response.Results)
                {
                    Console.WriteLine("{0}: {1}", x.Key, x.Value);
                }
                Console.WriteLine();

                Console.WriteLine("JSON:");
                Console.WriteLine(response.ToJSON());
                Console.WriteLine();

                Console.WriteLine("XML:");
                Console.WriteLine(response.ToXML());
                Console.WriteLine();
            }

            // Expansion Tests
            var expansionOptions = libPostal.GetAddressExpansionDefaultOptions();
            using (var expansion = libPostal.ExpandAddress(address, expansionOptions))
            {
                foreach (var x in expansion.Expansions)
                {
                    Console.WriteLine("{0}", x);
                }
                Console.WriteLine();

                Console.WriteLine("JSON:");
                Console.WriteLine(expansion.ToJSON());
                Console.WriteLine();

                Console.WriteLine("XML:");
                Console.WriteLine(expansion.ToXML());
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
