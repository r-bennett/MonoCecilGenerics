- Build lib/ExampleLibs.sln
- Build ConsoleApp1.sln
- Run ConsoleApp1 (which uses Mono Cecil to read the assemblies built from ExampleLibs.sln and prints information about them)

Output is:
```
AssemblyWithNestedType.GenericType`1
IsGenericInstance: False
HasGenericParameters: False

AssemblyWithNestedType.GenericType`1<TTools>
IsGenericInstance: True
HasGenericParameters: False

AssemblyWithNestedType.GenericType`1
IsGenericInstance: False
HasGenericParameters: True
```
