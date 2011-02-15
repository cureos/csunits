using System;

namespace Cureos.Measurables
{
    /// <summary>
    /// Common interface for physical units
    /// </summary>
    public interface IUnit<T>
    {
        #region PROPERTIES

        string Symbol { get; }

        IUnit<T> ReferenceUnit { get; }

        UnitDimensions Dimensions { get; }

        Func<T, T> ToBase { get; }

        Func<T, T> FromBase { get; }

        #endregion
    }
}
