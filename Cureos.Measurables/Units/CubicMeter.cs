using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Units
{
    public sealed class CubicMeter : GenericUnit
    {
        #region FIELDS

        public static readonly CubicMeter Instance;

        #endregion

        #region CONSTRUCTORS

        static CubicMeter()
        {
            Instance = new CubicMeter();
        }

        private CubicMeter()
            : base("m³", Volume.Dimension)
        {

        }

        #endregion
    }
}