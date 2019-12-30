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
            var serverProxyType = module.Types.Single(x => x.Name == typeName);
            var serverProxyCtor = serverProxyType.GetConstructors().Single(x => x.HasParameters);

            var baseServiceRemotableTypeViaCtorParams = ((GenericInstanceType) serverProxyCtor.Parameters.Single().ParameterType)
                .GenericArguments[1].DeclaringType;
            PrintDetails(baseServiceRemotableTypeViaCtorParams);

            var baseServiceRemotableTypeViaClassConstraint = serverProxyType.GenericParameters.Single().Constraints.Single().ConstraintType;
            PrintDetails(baseServiceRemotableTypeViaClassConstraint);

            PrintDetails(baseServiceRemotableTypeViaCtorParams);
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
