using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Units
{
    public sealed class Gray : GenericUnit
    {
        #region FIELDS

        public static readonly Gray Instance;

        #endregion

        #region CONSTRUCTORS

        static Gray()
        {
            Instance = new Gray();
        }

        private Gray()
            : base("Gy", AbsorbedDose.Dimension)
        {

        }

        #endregion
    }
}