#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Tests.Cureos.Measurables
{
    public static class AmountHelper
    {
        #region FIELDS

        public const AmountType EqualityTolerance = 1.0e-7;

        #endregion
    }
}