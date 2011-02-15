using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Double.Units
{
    public sealed class Gram : ConcreteUnit
    {
        #region FIELDS

        public static readonly Gram Unit;

        #endregion

        #region CONSTRUCTORS

        static Gram()
        {
            Unit = new Gram();
        }

        private Gram()
            : base("g", Mass.Dimensions)
        {

        }

        #endregion
    }
}