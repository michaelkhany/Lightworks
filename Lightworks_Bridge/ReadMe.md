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
