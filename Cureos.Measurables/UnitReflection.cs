using System.Reflection;

namespace Cureos.Measurables
{
    public static class UnitReflection
    {
        public static U GetUnitInstance<T, U>() where U  : IUnit<T>
        {
            return (U) typeof (U).GetField("Unit").GetValue(null);
        }
    }
}