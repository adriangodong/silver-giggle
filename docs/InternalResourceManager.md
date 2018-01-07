# InternalResourceManager

Creates a helper class to read embedded resource content.

## Examples

The following example demonstrates reading an embedded resource string content.

Project structure:

```
\Test.cs
\Resources\Marker.cs -- Contains empty class named Aaa.Resources.Marker
\Resources\Embed.json -- Embedded content containing a JSON string to read
```

`Test.cs`:

```csharp
var manager = new InternalResourceManager(typeof(Aaa.Resources.Marker));
var content = manager.GetString("Embed.json"); // No need to provide Aaa.Resources namespace
```

## Constructors

| Name | Description |
|------|-------------|
| `InternalResourceManager(Type)` | Initializes a new instance of InternalResourceManager. All requested resource identifiers will be prepended with namespace of provided marker class.

## Properties

| Name | Description |
|------|-------------|
| `Assembly` | Gets the assembly of the marker class.
| `ResourceNamespace` | Gets the resource namespace inferred from the namespace of the marker class.

## Methods

| Name | Description |
|------|-------------|
| `GetString(string)` | Returns the string content of the requested embedded resource.
