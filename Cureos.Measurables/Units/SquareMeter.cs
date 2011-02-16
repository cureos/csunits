using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Units
{
    public sealed class SquareMeter : GenericUnit
    {
        #region FIELDS

        public static readonly SquareMeter Instance;

        #endregion

        #region CONSTRUCTORS

        static SquareMeter()
        {
            Instance = new SquareMeter();
        }

        private SquareMeter()
            : base("m²", Area.Dimension)
        {

        }

        #endregion
    }
}