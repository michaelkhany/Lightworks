# Define a Python function to generate JSON sample files for the Dictionary directory

import json
import os

def generate_json_samples(directory, mappings):
    """
    Generate JSON sample files in the specified directory based on the provided command mappings.

    :param directory: Path to the directory where JSON files will be created.
    :param mappings: A list of dictionaries with command mappings.
    """
    # Create the directory if it does not exist
    if not os.path.exists(directory):
        os.makedirs(directory)

    # Generate JSON files for each command mapping
    for i, mapping in enumerate(mappings, start=1):
        file_path = os.path.join(directory, f'command_mapping_{i}.json')
        with open(file_path, 'w') as json_file:
            json.dump(mapping, json_file, indent=4)

# Enhanced sample command mappings based on the provided sample descriptions
sample_mappings = [
    {
        'CSharpCommand': 'new Box()',
        'SimpleCommand': 'CreateInstance',
        'Parameters': ['Box']
    },
    {
        'CSharpCommand': 'y + 5.0f',
        'SimpleCommand': 'Sum',
        'Parameters': ['y', '5.0']
    },
    {
        'CSharpCommand': 'box.GetX(Origin.Center)',
        'SimpleCommand': 'CallFunction',
        'Parameters': ['GetX', 'Origin.Center', 'Box']
    },
    {
        'CSharpCommand': 'Result Command 2 * Result Command 3',
        'SimpleCommand': 'Multiply',
        'Parameters': ['Result Command 2', 'Result Command 3']
    },
    {
        'CSharpCommand': 'Result Command 4 + x',
        'SimpleCommand': 'Sum',
        'Parameters': ['Result Command 4', 'x']
    },
    {
        'CSharpCommand': 'var i = Result Command 5',
        'SimpleCommand': 'DefineVariable',
        'Parameters': ['i', 'Result Command 5']
    },
    {
        'CSharpCommand': 'box.GetY(Origin.Center)',
        'SimpleCommand': 'CallFunction',
        'Parameters': ['GetY', 'Origin.Center', 'Box']
    },
    {
        'CSharpCommand': 'Result Command 7 + 10.0f',
        'SimpleCommand': 'Sum',
        'Parameters': ['Result Command 7', '10.0']
    },
    {
        'CSharpCommand': 'i > Result Command 8',
        'SimpleCommand': 'Condition',
        'Parameters': ['i', 'Result Command 8', 'Greater']
    },
    {
        'CSharpCommand': 'if',
        'SimpleCommand': 'IF',
        'Parameters': []
    },
    {
        'CSharpCommand': 'i = 0',
        'SimpleCommand': 'InitVariable',
        'Parameters': ['i', '0']
    }
]

# Call the function to generate JSON files
# The path where the JSON files will be saved (this will be a directory in the current working directory for this example)
dictionary_path = 'Dictionary'  # Adjust the path as needed for your environment

generate_json_samples(dictionary_path, sample_mappings)

# List the created files to verify
created_files = os.listdir(dictionary_path)
created_files_paths = [os.path.join(dictionary_path, file_name) for file_name in created_files]
created_files_paths

print(">>Done.")