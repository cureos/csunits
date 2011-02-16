namespace Cureos.Measurables.Dimensions
{
    internal static class Volume
    {
        #region FIELDS

        internal static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Volume()
        {
            Dimension = new UnitDimension(3, 0, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}