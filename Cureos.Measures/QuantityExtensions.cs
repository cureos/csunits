// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;

namespace Cureos.Measures
{
    public static class QuantityExtensions
    {
        #region STATIC MEMBERS

        private static Dictionary<Quantity, QuantityDetails> smDetailsMap;

        #endregion

        #region CONSTRUCTORS

        static QuantityExtensions()
        {
            smDetailsMap = new Dictionary<Quantity, QuantityDetails>
                               {
                                   {Quantity.Length, new QuantityDetails(new UnitDimensions(1, 0, 0, 0, 0, 0, 0))},
                                   {Quantity.Area, new QuantityDetails(new UnitDimensions(2, 0, 0, 0, 0, 0, 0))},
                                   {Quantity.Volume, new QuantityDetails(new UnitDimensions(3, 0, 0, 0, 0, 0, 0))},
                                   {Quantity.Mass, new QuantityDetails(new UnitDimensions(0, 1, 0, 0, 0, 0, 0))},
                                   {Quantity.Time, new QuantityDetails(new UnitDimensions(0, 0, 1, 0, 0, 0, 0))},
                                   {Quantity.Temperature, new QuantityDetails(new UnitDimensions(0, 0, 0, 0, 1, 0, 0))},
                                   {Quantity.AbsorbedDose, new QuantityDetails(new UnitDimensions(2, 0, -2, 0, 0, 0, 0))}
                               };
        }

        #endregion

        #region EXTENSION METHODS

        public static void SetReferenceUnit(this Quantity iQuantity, Unit iReferenceUnit)
        {
            smDetailsMap[iQuantity].ReferenceUnit = iReferenceUnit;
        }

        #endregion
        
        #region INNER SUPPORT CLASSES

        private sealed class QuantityDetails
        {
            #region MEMBER VARIABLES

            private Unit mReferenceUnit;

            #endregion
            
            #region CONSTRUCTORS

            internal QuantityDetails(UnitDimensions iUnitDimensions)
            {
                Dimensions = iUnitDimensions;
                mReferenceUnit = Unit.None;
            }

            #endregion

            #region AUTO-IMPLEMENTED PROPERTIES

            internal UnitDimensions Dimensions { get; private set; }

            #endregion

            #region PROPERTIES

            internal Unit ReferenceUnit
            {
                get
                {
                    return mReferenceUnit;
                }
                set
                {
                    if (mReferenceUnit != Unit.None) throw new InvalidOperationException("Attempt to set already defined ReferenceUnit");
                    mReferenceUnit = value;
                }
            }

            #endregion
        }

        /// <summary>
        /// Representation of the unit dimension in terms of SI base units
        /// </summary>
        private sealed class UnitDimensions
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
            internal UnitDimensions(int iLengthExponent, int iMassExponent, int iTimeExponent, int iElectricCurrentExponent, int iTemperatureExponent,
                int iLuminousIntensityExponent, int iSubstanceAmountExponent)
            {
                LengthExponent = iLengthExponent;
                MassExponent = iMassExponent;
                TimeExponent = iTimeExponent;
                ElectricCurrentExponent = iElectricCurrentExponent;
                TemperatureExponent = iTemperatureExponent;
                LuminousIntensityExponent = iLuminousIntensityExponent;
                SubstanceAmountExponent = iSubstanceAmountExponent;
            }

            #endregion

            #region AUTO-IMPLEMENTED PROPERTIES

            /// <summary>
            /// Gets the length (m) exponent
            /// </summary>
            internal int LengthExponent { get; set; }

            /// <summary>
            /// Gets the mass (kg) exponent
            /// </summary>
            internal int MassExponent { get; set; }

            /// <summary>
            /// Gets the time (s) exponent
            /// </summary>
            internal int TimeExponent { get; set; }

            /// <summary>
            /// Gets the electric current (A) exponent
            /// </summary>
            internal int ElectricCurrentExponent { get; set; }

            /// <summary>
            /// Gets the temperature (K) exponent
            /// </summary>
            internal int TemperatureExponent { get; set; }

            /// <summary>
            /// Gets the luminous intensity (Cd) exponent
            /// </summary>
            internal int LuminousIntensityExponent { get; set; }

            /// <summary>
            /// Gets the substance amount (mol) exponent
            /// </summary>
            internal int SubstanceAmountExponent { get; set; }

            #endregion

            #region METHODS

            internal bool Equals(UnitDimensions other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other.LengthExponent == LengthExponent && other.MassExponent == MassExponent &&
                       other.TimeExponent == TimeExponent && other.ElectricCurrentExponent == ElectricCurrentExponent &&
                       other.TemperatureExponent == TemperatureExponent &&
                       other.LuminousIntensityExponent == LuminousIntensityExponent &&
                       other.SubstanceAmountExponent == SubstanceAmountExponent;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as UnitDimensions);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int result = LengthExponent;
                    result = (result * 397) ^ MassExponent;
                    result = (result * 397) ^ TimeExponent;
                    result = (result * 397) ^ ElectricCurrentExponent;
                    result = (result * 397) ^ TemperatureExponent;
                    result = (result * 397) ^ LuminousIntensityExponent;
                    result = (result * 397) ^ SubstanceAmountExponent;
                    return result;
                }
            }

            #endregion
            /*
            #region OPERATORS

            /// <summary>
            /// Add two unit dimension objects (used in unit multiplication)
            /// </summary>
            /// <param name="iLhs">First unit dimension object</param>
            /// <param name="iRhs">Second unit dimension object</param>
            /// <returns>New unit dimension object, with each exponent being the sum of the two input object exponents</returns>
            public static UnitDimension operator +(UnitDimension iLhs, UnitDimension iRhs)
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
 */
        }
        #endregion
    }
}