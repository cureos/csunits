namespace Cureos.Measurables.Units
{
    public sealed class Celsius : GenericUnit
    {
        #region FIELDS

        public static readonly Celsius Instance;

        #endregion

        #region CONSTRUCTORS

        static Celsius()
        {
            Instance = new Celsius();
        }

        private Celsius()
            : base("°C", Kelvin.Instance, t => t + 273.15, t => t - 273.15)
        {

        }

        #endregion
    }
}