namespace Cureos.Measurables.Double.Units
{
    public sealed class CentiGray : ConcreteUnit
    {
        #region FIELDS

        public static readonly CentiGray Instance;

        #endregion

        #region CONSTRUCTORS

        static CentiGray()
        {
            Instance = new CentiGray();
        }

        private CentiGray()
            : base(UnitPrefix.Centi, "Gy", Gray.Instance)
        {

        }

        #endregion
    }
}