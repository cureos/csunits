#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measurables
{
    public interface IMeasurableArray
    {
        #region PROPERTIES

        AmountType[] Amounts { get; }

        #endregion
    }
}