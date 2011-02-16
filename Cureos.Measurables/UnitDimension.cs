// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

namespace Cureos.Measurables
{
	
#if NOTNET4
	public class Tuple<T1, T2, T3, T4, T5, T6, T7>
	{
		public Tuple(T1 i1, T2 i2, T3 i3, T4 i4, T5 i5, T6 i6, T7 i7)
		{
			Item1 = i1;
			Item2 = i2;
			Item3 = i3;
			Item4 = i4;
			Item5 = i5;
			Item6 = i6;
			Item7 = i7;
		}
		
		public T1 Item1 { get; private set; }
		public T2 Item2 { get; private set; }
		public T3 Item3 { get; private set; }
		public T4 Item4 { get; private set; }
		public T5 Item5 { get; private set; }
		public T6 Item6 { get; private set; }
		public T7 Item7 { get; private set; }
		
		public override bool Equals (object obj)
		{
			var tupleObj = obj as Tuple<T1, T2, T3, T4, T5, T6, T7>;
			return tupleObj != null ? Item1.Equals(tupleObj.Item1) && Item2.Equals(tupleObj.Item2) &&
				Item3.Equals(tupleObj.Item3) && Item4.Equals(tupleObj.Item4) && Item5.Equals(tupleObj.Item5) &&
					Item6.Equals(tupleObj.Item6) && Item7.Equals(tupleObj.Item7) : false;
		}
		
		public override int GetHashCode ()
		{
			return Item1.GetHashCode() + Item2.GetHashCode() + Item3.GetHashCode() + Item4.GetHashCode() +
				Item5.GetHashCode() + Item6.GetHashCode() + Item7.GetHashCode();
		}
	}
#endif
	
    /// <summary>
    /// Representation of the unit dimension in terms of SI base units
    /// </summary>
    public sealed class UnitDimension : Tuple<int, int, int, int, int, int, int>
    {
        #region CONSTRUCTORS

        /// <summary>
        /// Initializes an instance of a unit dimension
        /// </summary>
        /// <param name="iLengthExponent">Length exponent</param>
        /// <param name="iMassExponent">Mass exponent</param>
        /// <param name="iTimeExponent">Time exponent</param>
        /// <param name="iElectricCurrentExponent">Electric current exponent</param>
        /// <param name="iTemperatureExponent">Temperature exponent</param>
        /// <param name="iLuminousIntensityExponent">Luminous intensity exponent</param>
        /// <param name="iSubstanceAmountExponent">Substance amount exponent</param>
        internal UnitDimension(int iLengthExponent, int iMassExponent, int iTimeExponent, int iElectricCurrentExponent, int iTemperatureExponent,
            int iLuminousIntensityExponent, int iSubstanceAmountExponent)
            : base(iLengthExponent, iMassExponent, iTimeExponent, iElectricCurrentExponent,
            iTemperatureExponent, iLuminousIntensityExponent, iSubstanceAmountExponent)
        {
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the length (m) exponent
        /// </summary>
        internal int LengthExponent { get { return Item1; } }

        /// <summary>
        /// Gets the mass (kg) exponent
        /// </summary>
        internal int MassExponent { get { return Item2; } }

        /// <summary>
        /// Gets the time (s) exponent
        /// </summary>
        internal int TimeExponent { get { return Item3; } }

        /// <summary>
        /// Gets the electric current (A) exponent
        /// </summary>
        internal int ElectricCurrentExponent { get { return Item4; } }

        /// <summary>
        /// Gets the temperature (K) exponent
        /// </summary>
        internal int TemperatureExponent { get { return Item5; } }

        /// <summary>
        /// Gets the luminous intensity (Cd) exponent
        /// </summary>
        internal int LuminousIntensityExponent { get { return Item6; } }

        /// <summary>
        /// Gets the substance amount (mol) exponent
        /// </summary>
        internal int SubstanceAmountExponent { get { return Item7; } }

        #endregion

        #region OPERATORS

        /// <summary>
        /// Add two unit dimension objects (used in unit multiplication)
        /// </summary>
        /// <param name="iLhs">First unit dimension object</param>
        /// <param name="iRhs">Second unit dimension object</param>
        /// <returns>New unit dimension object, with each exponent being the sum of the two input object exponents</returns>
        public static UnitDimension operator+(UnitDimension iLhs, UnitDimension iRhs)
        {
            return new UnitDimension(iLhs.Item1 + iRhs.Item1, iLhs.Item2 + iRhs.Item2, iLhs.Item3 + iRhs.Item3,
                iLhs.Item4 + iRhs.Item4, iLhs.Item5 + iRhs.Item5, iLhs.Item6 + iRhs.Item6, iLhs.Item7 + iRhs.Item7);
        }

        /// <summary>
        /// Subtract two unit dimension objects (used in unit division)
        /// </summary>
        /// <param name="iLhs">First unit dimension object</param>
        /// <param name="iRhs">Second unit dimension object</param>
        /// <returns>New unit dimension object, with each exponent being the difference of the two input object exponents</returns>
        public static UnitDimension operator -(UnitDimension iLhs, UnitDimension iRhs)
        {
            return new UnitDimension(iLhs.Item1 - iRhs.Item1, iLhs.Item2 - iRhs.Item2, iLhs.Item3 - iRhs.Item3,
                iLhs.Item4 - iRhs.Item4, iLhs.Item5 - iRhs.Item5, iLhs.Item6 - iRhs.Item6, iLhs.Item7 - iRhs.Item7);
        }

        #endregion
    }
}