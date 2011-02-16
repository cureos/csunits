namespace Cureos.Measurables.Dimensions
{
    internal static class Length
    {
        #region FIELDS

        internal static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Length()
        {
            Dimension = new UnitDimension(1, 0, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}