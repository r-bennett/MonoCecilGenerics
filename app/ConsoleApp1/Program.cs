using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var dllPath = @"..\..\..\..\..\lib\AssemblyWithConvolutedGenerics\bin\Debug\netcoreapp2.1\AssemblyWithConvolutedGenerics.dll";
            var typeName = "ClassWithConvolutedGenerics`1";

            var module = ModuleDefinition.ReadModule(dllPath);
            var classWithConvolutedGenericsType = module.Types.Single(x => x.Name == typeName);
            var classWithConvolutedGenericsCtor = classWithConvolutedGenericsType.GetConstructors().Single(x => x.HasParameters);

            var genericTypeViaCtorParams = ((GenericInstanceType) classWithConvolutedGenericsCtor.Parameters.Single().ParameterType)
                .GenericArguments[1].DeclaringType;
            PrintDetails(genericTypeViaCtorParams);

            var genericTypeViaClassConstraint = classWithConvolutedGenericsType.GenericParameters.Single().Constraints.Single().ConstraintType;
            PrintDetails(genericTypeViaClassConstraint);

            PrintDetails(genericTypeViaCtorParams);
        }

        private static void PrintDetails(TypeReference type)
        {
            Console.WriteLine(type.FullName);
            Console.WriteLine($"IsGenericInstance: {type.IsGenericInstance}");
            Console.WriteLine($"HasGenericParameters: {type.HasGenericParameters}");
            Console.WriteLine();
        }
    }
}
