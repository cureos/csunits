using System;

namespace Cureos.Measurables
{
    public interface IUnit
    {
        #region PROPERTIES

        IUnit ReferenceUnit { get; }

        UnitDimension Dimension { get; }

        #endregion
    }

    /// <summary>
    /// Common interface for physical units
    /// </summary>
    public interface IUnit<T> : IUnit
    {
        #region PROPERTIES

        Func<T, T> ToBase { get; }

        Func<T, T> FromBase { get; }

        #endregion
    }
}
