namespace Cureos.Measurables.Dimensions
{
    public static class Mass
    {
        #region FIELDS

        public static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static Mass()
        {
            Dimension = new UnitDimension(0, 1, 0, 0, 0, 0, 0);
        }

        #endregion
    }
}