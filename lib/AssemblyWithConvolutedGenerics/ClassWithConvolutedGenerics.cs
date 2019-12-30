using System;
using AssemblyWithNestedType;

namespace AssemblyWithConvolutedGenerics
{
    public class ClassWithConvolutedGenerics<TTools> where TTools : GenericType<TTools>
    {
        public ClassWithConvolutedGenerics(Func<string, GenericType<TTools>.NestedType, TTools> func) {}
    }
}
