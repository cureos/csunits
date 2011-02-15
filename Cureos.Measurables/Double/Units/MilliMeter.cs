namespace Cureos.Measurables.Double.Units
{
    public sealed class MilliMeter : ConcreteUnit
    {
        #region FIELDS

        public static readonly MilliMeter Instance;

        #endregion

        #region CONSTRUCTORS

        static MilliMeter()
        {
            Instance = new MilliMeter();
        }

        private MilliMeter()
            : base(UnitPrefix.Milli, "m", Meter.Instance)
        {
        }

        #endregion
    }
}