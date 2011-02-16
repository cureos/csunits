namespace Cureos.Measurables.Dimensions
{
    internal static class Temperature
    {
        #region FIELDS

        internal static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Temperature()
        {
            Dimension = new UnitDimension(0, 0, 0, 0, 1, 0, 0);
        }

        #endregion
    }
}