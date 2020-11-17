using System;

namespace CacheableProperties
{
    /// <summary>
    /// Use this instead of 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class CacheableAttribute : Attribute
    {

    }

    public struct Container<T>
    {
        public Container(Func<T> ctor)
        {
            this.ctor = ctor;
            value = default;
            initted = false;
        }

        private T value;
        private bool initted;
        private readonly Func<T> ctor;
        public T GetValue()
        {
            if (!initted)
            {
                initted = true;
                value = ctor();
            }
            return value;
        }
    }
}
