using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Double.Units
{
    public sealed class KiloGram : ConcreteUnit
    {
        #region FIELDS

        public static readonly KiloGram Unit;

        #endregion

        #region CONSTRUCTORS

        static KiloGram()
        {
            Unit = new KiloGram();
        }

        private KiloGram() : base(UnitPrefix.Kilo, "g", Mass.Dimensions)
        {
            
        }

        #endregion
    }
}