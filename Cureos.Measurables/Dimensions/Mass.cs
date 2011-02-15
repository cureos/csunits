using System;

namespace Cureos.Measurables.Dimensions
{
    public static class Mass
    {
        #region FIELDS

        public static readonly UnitDimensions Dimensions;

        #endregion

        #region CONSTRUCTORS

        static Mass()
        {
            Dimensions = new UnitDimensions(0, 1, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}