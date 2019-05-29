# Framework Streamliner
Make usage of .NET Framework more efficient and effective by:
- providing extensions so that common .NET Framework methods can be called with fluent method syntax
- creating extend classes for static classes
- providing common cross-cutting concerns

For example for string null or empty testing we have to write code 
```cs
string.IsNullOrEmpty(someVar);
```
with this library we can write
```cs
someVar.IsNullOrEmpty();
```
which is much more readable.

## Getting Started
Clone the repository.

Open and build the ```FrameworkStreamliner.sln``` solution with Visual Studio 2017+ and .NET Core 2.2 SDK.

## License
Copyright (c) POSLOVNA PREDNOST d.o.o.. All rights reserved.

Licensed under the [MS-RSL](LICENSE.txt) license.