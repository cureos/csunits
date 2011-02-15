using System;
using System.Reflection;

namespace Cureos.Measurables
{
    public static class UnitReflection
    {
        public static U GetUnitInstance<U>() where U  : IUnit
        {
            FieldInfo f = typeof(U).GetField("Instance");
            if (f == null) throw new InvalidOperationException("Specified IUnit type does not contain static field Instance");
            return (U) f.GetValue(null);
        }
    }
}