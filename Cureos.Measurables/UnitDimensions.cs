using System;

namespace Cureos.Measurables
{
    public sealed class UnitDimensions : Tuple<int, int, int, int, int, int, int>
    {
        #region CONSTRUCTORS

        public UnitDimensions(int iLengthExponent, int iMassExponent, int iTimeExponent, int iElectricCurrentExponent, int iTemperatureExponent,
            int iLuminousIntensityExponent, int iPlaneAngleExponent)
            : base(iLengthExponent, iMassExponent, iTimeExponent, iElectricCurrentExponent,
            iTemperatureExponent, iLuminousIntensityExponent, iPlaneAngleExponent)
        {
        }

        #endregion

        #region PROPERTIES

        public int LengthExponent { get { return Item1; } }

        public int MassExponent { get { return Item2; } }

        public int TimeExponent { get { return Item3; } }

        public int ElectrincCurrentExponent { get { return Item4; } }

        public int TemperatureExponent { get { return Item5; } }

        public int LuminousIntensityExponent { get { return Item6; } }

        public int PlaneAngleExponent { get { return Item7; } }

        #endregion
    }
}