using System;

namespace Cureos.Measurables.Dimensions
{
    public static class Length
    {
        #region FIELDS

        public static readonly UnitDimensions Dimensions;

        #endregion

        #region CONSTRUCTORS

        static Length()
        {
            Dimensions = new UnitDimensions(1, 0, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}