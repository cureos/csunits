namespace Cureos.Measurables.Dimensions
{
    internal static class Mass
    {
        #region FIELDS

        internal static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Mass()
        {
            Dimension = new UnitDimension(0, 1, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}