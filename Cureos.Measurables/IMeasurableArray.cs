#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measurables
{
    public interface IMeasurableArray<out U> where U : IUnit
    {
        #region PROPERTIES

        AmountType[] Amounts { get; }

        U Unit { get; }

        IMeasurableArray<V> InUnit<V>() where V : IUnit;

        #endregion
    }
}