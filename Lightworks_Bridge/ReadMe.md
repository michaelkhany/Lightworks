# Lightworks Bridge

Lightworks Bridge is a Csharp utility designed to translate complex C# code into a sequence of simpler command objects, maintaining the execution order. It's ideal for developers who need to process C# source code for scripting, interpretation, or any context where a high-level code needs to be translated into a more manageable form.

## Features

- Load command mappings from a JSON file.
- Translate Csharp source code into a sequential list of Command objects.
- Ensure the execution order is preserved in translation.

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 6.0 SDK or newer
- Newtonsoft.Json library

### Usage
Prepare JSON mapping files in the `Dictionary` directory. Each file should contain mappings in the following format:
```
[
  {
    "CSharpCommand": "command_string",
    "SimpleCommand": "simplified_command",
    "Parameters": ["param1", "param2"]
  }
  // ... additional mappings
]
```

Utilize the `lw_bridge` class in your application to load command mappings and translate source code:
```
lw_bridge bridge = new lw_bridge();
bridge.LoadCommandMappings("path/to/Dictionary");
List<Command> commands = bridge.Translate("C# source code here...");
```

Process the commands list as needed for your application.

## Versions

### lw_bridge_02310

In this release, we're introducing a host of robust features designed to improve the translation of C# code:

- Simplified JSON mapping structure for ease of command definitions.
- Enhanced parsing capabilities to accurately interpret C# constructs and convert them into discrete commands.
- Improved error handling and messaging to provide clear feedback on translation mismatches and unsupported syntax.
- Extended command set support allowing for more complex C# statements to be broken down into executable commands.
- New tokenization process to better handle a variety of C# expressions and control structures.
- Optimizations for faster translation times and reduced memory footprint.
- Initial support for method calls and arithmetic operations within the source code translation process.
- Streamlined initialization of the translation engine to facilitate integration into existing projects.

Remember to update your JSON mappings to leverage these new features and enjoy an even more powerful and flexible translation experience.

