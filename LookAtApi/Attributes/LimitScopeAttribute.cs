using System;

namespace LookAtApi.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class LimitScopeAttribute : System.Attribute
    {
        public LimitScopeAttribute(Type type)
        {
            LimitingType = type;
        }

        public Type LimitingType { get; }
    }
}