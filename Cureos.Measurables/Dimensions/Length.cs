using System;

namespace Cureos.Measurables.Dimensions
{
    public static class Length
    {
        #region FIELDS

        public static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Length()
        {
            Dimension = new UnitDimension(1, 0, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}