namespace Cureos.Measurables.Units
{
    public sealed class CentiMeter : GenericUnit
    {
        #region FIELDS

        public static readonly CentiMeter Instance;

        #endregion

        #region CONSTRUCTORS

        static CentiMeter()
        {
            Instance = new CentiMeter();
        }

        private CentiMeter()
            : base(UnitPrefix.Centi, "m", Meter.Instance)
        {
        }

        #endregion
    }
}