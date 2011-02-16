using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Units
{
    public sealed class Meter : GenericUnit
    {
        #region FIELDS

        public static readonly Meter Instance;

        #endregion

        #region CONSTRUCTORS

        static Meter()
        {
            Instance = new Meter();
        }

        private Meter()
            : base("m", Length.Dimension)
        {

        }

        #endregion
    }
}