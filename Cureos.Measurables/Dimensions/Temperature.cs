namespace Cureos.Measurables.Dimensions
{
    public static class Temperature
    {
        #region FIELDS

        public static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Temperature()
        {
            Dimension = new UnitDimension(0, 0, 0, 0, 1, 0, 0);
        }

        #endregion
    }
}