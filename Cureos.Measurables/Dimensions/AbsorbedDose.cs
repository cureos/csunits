namespace Cureos.Measurables.Dimensions
{
    public static class AbsorbedDose
    {
        #region FIELDS

        public static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static AbsorbedDose()
        {
            Dimension = new UnitDimension(2, 0, -2, 0, 0, 0, 0);
        }

        #endregion
    }
}