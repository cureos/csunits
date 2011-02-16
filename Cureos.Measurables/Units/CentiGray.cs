namespace Cureos.Measurables.Units
{
    public sealed class CentiGray : GenericUnit
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