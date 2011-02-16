namespace Cureos.Measurables.Units
{
    public sealed class Liter : GenericUnit
    {
        #region FIELDS

        public static readonly Liter Instance;

        #endregion

        #region CONSTRUCTORS

        static Liter()
        {
            Instance = new Liter();
        }

        private Liter()
            : base("l", CubicMeter.Instance, 0.001)
        {
        }

        #endregion
    }
}