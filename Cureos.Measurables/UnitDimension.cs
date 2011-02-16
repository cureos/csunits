using System;

namespace Cureos.Measurables
{
    public sealed class UnitDimension : Tuple<int, int, int, int, int, int, int>
    {
        #region CONSTRUCTORS

        public UnitDimension(int iLengthExponent, int iMassExponent, int iTimeExponent, int iElectricCurrentExponent, int iTemperatureExponent,
            int iLuminousIntensityExponent, int iSubstanceAmountExponent)
            : base(iLengthExponent, iMassExponent, iTimeExponent, iElectricCurrentExponent,
            iTemperatureExponent, iLuminousIntensityExponent, iSubstanceAmountExponent)
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

        public int SubstanceAmountExponent { get { return Item7; } }

        #endregion

        #region OPERATORS

        public static UnitDimension operator+(UnitDimension iLhs, UnitDimension iRhs)
        {
            return new UnitDimension(iLhs.Item1 + iRhs.Item1, iLhs.Item2 + iRhs.Item2, iLhs.Item3 + iRhs.Item3,
                iLhs.Item4 + iRhs.Item4, iLhs.Item5 + iRhs.Item5, iLhs.Item6 + iRhs.Item6, iLhs.Item7 + iRhs.Item7);
        }

        public static UnitDimension operator -(UnitDimension iLhs, UnitDimension iRhs)
        {
            return new UnitDimension(iLhs.Item1 - iRhs.Item1, iLhs.Item2 - iRhs.Item2, iLhs.Item3 - iRhs.Item3,
                iLhs.Item4 - iRhs.Item4, iLhs.Item5 - iRhs.Item5, iLhs.Item6 - iRhs.Item6, iLhs.Item7 - iRhs.Item7);
        }

        #endregion
    }
}