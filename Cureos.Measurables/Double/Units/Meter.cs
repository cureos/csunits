using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Double.Units
{
    public sealed class Meter : ConcreteUnit
    {
        #region FIELDS

        public static readonly Meter Unit;

        #endregion

        #region CONSTRUCTORS

        static Meter()
        {
            Unit = new Meter();
        }

        private Meter()
            : base("m", Length.Dimensions)
        {

        }

        #endregion
    }
}