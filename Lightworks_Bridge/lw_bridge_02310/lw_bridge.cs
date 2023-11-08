using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Command
{
    public string Instruction { get; set; }
    public List<object> Arguments { get; set; }

    // Constructor
    public Command(string instruction, List<object> arguments)
    {
        Instruction = instruction;
        Arguments = arguments;
    }
}

public class CommandMapping
{
    public string CSharpCommand { get; set; }
    public string SimpleCommand { get; set; }
    public List<string> Parameters { get; set; }
}

public class lw_bridge
{
    private Dictionary<string, CommandMapping> commandDictionary;

    public lw_bridge()
    {
        commandDictionary = new Dictionary<string, CommandMapping>();
    }

    public void LoadCommandMappings(string dictionaryPath)
    {
        try
        {
            var fullPath = Path.GetFullPath(dictionaryPath);
            var jsonFiles = Directory.GetFiles(fullPath, "*.json");
            foreach (var filePath in jsonFiles)
            {
                string json = File.ReadAllText(filePath);
                // Deserialize a single CommandMapping object instead of a list
                var mapping = JsonConvert.DeserializeObject<CommandMapping>(json);
                if (mapping != null)
                {
                    commandDictionary[mapping.CSharpCommand] = mapping;
                }
            }
        }
        catch (DirectoryNotFoundException dirEx)
        {
            Console.WriteLine("Directory not found: " + dirEx.Message);
        }
        catch (JsonSerializationException jsonEx)
        {
            Console.WriteLine("JSON Serialization Exception: " + jsonEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }


    public List<Command> Translate(string sourceCode)
    {
        List<Command> translatedCommands = new List<Command>();

        // Naive line-by-line parsing
        var lines = sourceCode.Split(new[] { '\n', ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmedLine))
            {
                continue; // Skip empty lines
            }

            // Attempt to match and extract a command from the line
            foreach (var pair in commandDictionary)
            {
                if (trimmedLine.Contains(pair.Key))
                {
                    var commandMapping = pair.Value;
                    // Extract arguments from the line based on the expected parameters
                    List<object> arguments = ExtractArguments(trimmedLine, commandMapping.Parameters);

                    // Create a new command with the extracted arguments
                    Command command = new Command(commandMapping.SimpleCommand, arguments);
                    translatedCommands.Add(command);

                    // We found a mapping and processed it, so we can break out of the loop
                    break;
                }
            }
        }

        return translatedCommands;
    }

    private List<object> ExtractArguments(string line, List<string> parameters)
    {
        // Implement logic to extract arguments based on the command parameters
        // This is a placeholder implementation and needs to be adjusted according to the actual command syntax
        List<object> arguments = new List<object>();
        foreach (var parameter in parameters)
        {
            if (line.Contains(parameter))
            {
                // Extract the argument value from the line
                // For the sake of this example, let's assume we just add the parameter as-is
                arguments.Add(parameter);
            }
        }
        return arguments;
    }

}

//// Example usage of the lw_bridge class
//public class Example
//{
//    public static void Main()
//    {
//        lw_bridge bridge = new lw_bridge();

//        // Load command mappings from the Dictionary directory
//        bridge.LoadCommandMappings(@"path\to\Dictionary");

//        // Here you would obtain the source code that you want to translate
//        string sourceCode = "new Box();\ni = 0;\nif (condition)\n{\n}";

//        // Translate the C# code into the sequence of simpler commands
//        List<Command> commands = bridge.Translate(sourceCode);

//        // Output the results
//        foreach (var command in commands)
//        {
//            Console.WriteLine($"Instruction: {command.Instruction}");
//            if (command.Arguments != null)
//            {
//                Console.WriteLine("Arguments:");
//                foreach (var arg in command.Arguments)
//                {
//                    Console.WriteLine($" - {arg}");
//                }
//            }
//        }
//    }
//}