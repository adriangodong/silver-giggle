# RandomValue

Wraps a Random object and exposes methods that returns random values of primitive/common types. All methods are thread safe.

## Examples

To use, create a new instance of RandomValue and call its methods.

```csharp
System.Console.WriteLine(SilverGiggle.RandomValue.NextInt32()); // Prints random integer
```

## Static Properties

| Name | Description |
|------|-------------|
| `Random { get; set; }` | Gets or sets the wrapped Random instance.

## Static Methods

| Name | Description |
|------|-------------|
| `NextGuid()` | Returns a random Guid.
| `NextString()` | Returns a random Guid serialized to string.
| `NextInt32()` | Returns a non-negative random integer.
| `NextInt32(Int32)` | Returns a non-negative random integer that is less than the specified maximum.
| `NextInt32(Int32, Int32)` | Returns a random integer that is within a specified range.
| `NextDouble()` | Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
| `NextInt64()` | Returns a random non-negative long integer.
| `NextBoolean()` | Returns a random boolean.
| `NextDateTimeOffset()` | Returns a random DateTimeOffset with UTC timezone.
