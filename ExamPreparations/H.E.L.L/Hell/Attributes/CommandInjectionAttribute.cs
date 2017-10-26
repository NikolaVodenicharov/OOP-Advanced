namespace Hell.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class CommandInjectionAttribute : Attribute
    {
    }
}
