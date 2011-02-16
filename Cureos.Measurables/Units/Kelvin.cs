using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Units
{
    public sealed class Kelvin : GenericUnit
    {
        #region FIELDS

        public static readonly Kelvin Instance;

        #endregion

        #region CONSTRUCTORS

        static Kelvin()
        {
            Instance = new Kelvin();
        }

        private Kelvin()
            : base("K", Temperature.Dimension)
        {

        }

        #endregion
    }
}