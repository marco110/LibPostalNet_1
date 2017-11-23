using LibPostalNet;
using System;

namespace LibPostalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "781 Franklin Ave Crown Heights Brooklyn NYC NY 11216 USA";
            LibPostal.Setup();
            LibPostal.SetupParser();
            LibPostal.SetupLanguageClassifier();

            // Parser Tests
            var parserOptions = LibPostal.GetAddressParserDefaultOptions();
            var response = LibPostal.ParseAddress(address, parserOptions);

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

            LibPostal.AddressParserResponseDestroy(response);

            // Expansion Tests
            var expansionOptions = LibPostal.GetDefaultOptions();
            var expansion = LibPostal.ExpandAddress(address, expansionOptions);

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

            LibPostal.ExpansionArrayDestroy(expansion);

            // Teardown (only called once at the end of your program)
            LibPostal.Teardown();
            LibPostal.TeardownParser();
            LibPostal.TeardownLanguageClassifier();
        }
    }
}
