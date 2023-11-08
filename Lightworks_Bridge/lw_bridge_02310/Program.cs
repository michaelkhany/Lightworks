using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        lw_bridge bridge = new lw_bridge();

        // Load command mappings from the Dictionary directory
        bridge.LoadCommandMappings(@"..\..\..\Dictionary"); // Adjust as needed

        // Example source code to translate
        string sourceCode = @"
            Box box = new Box();
            var i = x + box.GetX(Origin.Center) * (y + 5.0f);
            if (i > box.GetY(Origin.Center) + 10.0f)
                i = 0;
        ";

        // Translate the C# code into the sequence of simpler commands
        List<Command> commands = bridge.Translate(sourceCode);

        // Output the translated commands
        foreach (var command in commands)
        {
            Console.WriteLine($"Instruction: {command.Instruction}");
            if (command.Arguments != null && command.Arguments.Count > 0)
            {
                Console.WriteLine("Arguments:");
                foreach (var arg in command.Arguments)
                {
                    Console.WriteLine($" - {arg}");
                }
            }
        }
    }
}
