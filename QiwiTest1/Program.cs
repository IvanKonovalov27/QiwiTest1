// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Reflection.Emit;
using System.Text;

while (true) 
{ 
    Console.WriteLine("Please enter sum: ");
    string input = Console.ReadLine();
    string result = new QiwiTest1.DecimalParser().Convert(input);
    Console.WriteLine(result);
    Console.WriteLine("Another one? (Ctrl+C to stop)");
}
