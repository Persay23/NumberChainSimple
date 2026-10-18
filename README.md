# NumberChainSimple

A small C# console app. It reads numbers from a text file and finds the longest chain of them.
A number can be followed by another number when the **last 2 digits** of the first one are equal to
the **first 2 digits** of the second one. The chain is then glued into one big number.

## Example

Input file:

```
123456 567890 345612 999999
```

Chain: `345612 -> 123456 -> 567890` (12 = 12, 56 = 56). `999999` connects to nothing.

Gluing: keep the first number whole, and from every next number drop its first 2 digits
(they repeat the last 2 digits of the number before it):

```
345612 + 3456 + 7890 = 34561234567890
```

## Files

| File | What it does |
| --- | --- |
| `FileReader.cs` | Reads the numbers from a text file |
| `NumberSplitter.cs` | Splits a number into first 2 digits, middle and last 2 digits |
| `ChainFinder.cs` | Compares the digits, finds the longest chain and glues it |
| `Program.cs` | Connects everything and prints the result |

## Input file

- A plain text file (.txt).
- Numbers are separated by spaces, tabs, new lines, commas or semicolons.
- Only numbers with digits (0-9) and at least 4 digits are used. Anything else is skipped.

## How to run

You need the .NET SDK 8 or newer: https://dotnet.microsoft.com/download

From the project folder:

```
dotnet run -c Release -- "path\to\numbers.txt"
```

Or run without a path, and the program will ask for it:

```
dotnet run -c Release
```

## Note

The program tries every possible chain, so it always finds the longest one, but it can be slow.
For about 150 numbers it takes around a minute or more. Running with `-c Release` makes it faster.
