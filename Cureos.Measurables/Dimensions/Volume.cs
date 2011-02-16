namespace Cureos.Measurables.Dimensions
{
    public static class Volume
    {
        #region FIELDS

        public static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Volume()
        {
            Dimension = new UnitDimension(3, 0, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}