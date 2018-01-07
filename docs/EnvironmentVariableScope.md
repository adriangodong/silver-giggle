# EnvironmentVariableScope

Creates a virtual scope where environment variable values modification can be restored. When execution goes out of scope, registered environment variable values are reverted. This class simplifies testing a code block that reads data from environment variable.

## Examples

The following example demonstrates creation of a scope, modification to the environment variable, and restoration of the original values when the scope is destroyed.

```csharp
System.Environment.SetEnvironmentVariable("VARIABLE_A", "Initial value");

using (var scope = new SilverGiggle.EnvironmentVariableScope("VARIABLE_A", "VARIABLE_B"))
{
    System.Environment.SetEnvironmentVariable("VARIABLE_A", "New value");
    System.Console.WriteLine(System.Environment.GetEnvironmentVariable("VARIABLE_A")); // Prints "New value"
}

System.Console.WriteLine(System.Environment.GetEnvironmentVariable("VARIABLE_A")); // Prints "Initial value"
```

## Constructors

| Name | Description |
|------|-------------|
| `EnvironmentVariableScope(string[])` | Initializes a new instance of EnvironmentVariableScope. Creates a copy of environment variable values from keys provided from the input parameters.

## Properties

| Name | Description |
|------|-------------|
| `OriginalValues` | Gets the dictionary containing stored environment variable key and original values.

## Methods

| Name | Description |
|------|-------------|
| `UpdateEnvironmentVariable(string, string)` | Creates a copy of the environment variable value and then set the new value. When called more than once, only the value from the first call is stored/restored.
