#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measurables
{
    public interface IMeasurable<out U> where U : IUnit
    {
        AmountType Amount { get; }

        U Unit { get; }

        IMeasurable<V> InUnit<V>() where V : IUnit;
    }
}