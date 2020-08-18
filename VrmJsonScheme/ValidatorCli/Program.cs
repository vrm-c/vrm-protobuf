using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace VrmValidator
{

    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine($"validate: {arg}");
                VrmValidator.Validator.Validate(arg);
            }
        }

    }
}
