using System;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measurables
{
    /// <summary>
    /// Common interface for physical units
    /// </summary>
    public interface IUnit
    {
        #region PROPERTIES

        string Symbol { get; }

        IUnit ReferenceUnit { get; }

        UnitDimension Dimension { get; }

        Func<AmountType, AmountType> ToBase { get; }

        Func<AmountType, AmountType> FromBase { get; }

        #endregion
    }
}
