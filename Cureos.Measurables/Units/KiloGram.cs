using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Units
{
    public sealed class KiloGram : GenericUnit
    {
        #region FIELDS

        public static readonly KiloGram Instance;

        #endregion

        #region CONSTRUCTORS

        static KiloGram()
        {
            Instance = new KiloGram();
        }

        private KiloGram() : base(UnitPrefix.Kilo, "g", Mass.Dimension)
        {
            
        }

        #endregion
    }
}