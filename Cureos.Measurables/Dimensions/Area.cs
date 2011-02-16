namespace Cureos.Measurables.Dimensions
{
    internal static class Area
    {
        #region FIELDS

        internal static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Area()
        {
            Dimension = new UnitDimension(2, 0, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}