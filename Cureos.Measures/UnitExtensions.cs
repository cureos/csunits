// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;
using System.Linq;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
    /// <summary>
    /// Helper class providing extension methods for the <see cref="Unit">Unit enumeration</see>
    /// </summary>
    public static class UnitExtensions
    {
        #region STATIC MEMBER VARIABLES

        private static readonly Dictionary<Unit, UnitDetails> smUnitDetailsMap;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes the unit details map, by specifying associated quantity, text symbol, reference unit status and
        /// amount conversion operators to and from reference unit
        /// </summary>
        static UnitExtensions()
        {
            smUnitDetailsMap = new UnitDetails[]
                                   {
                                       new UnitDetails(Unit.Meter, Quantity.Length, "m"),
                                       new UnitDetails(Unit.DeciMeter, Quantity.Length, "dm", (AmountType) 0.1),
                                       new UnitDetails(Unit.CentiMeter, Quantity.Length, "cm", (AmountType) 0.01),
                                       new UnitDetails(Unit.MilliMeter, Quantity.Length, "mm", (AmountType) 0.001),
                                       new UnitDetails(Unit.SquareMeter, Quantity.Area, "m²"), 
                                       new UnitDetails(Unit.SquareDeciMeter, Quantity.Area, "dm²", (AmountType)0.01), 
                                       new UnitDetails(Unit.SquareCentiMeter, Quantity.Area, "cm²", (AmountType)0.0001), 
                                       new UnitDetails(Unit.CubicMeter, Quantity.Volume, "m³"),
                                       new UnitDetails(Unit.Liter, Quantity.Volume, "l", (AmountType)0.001), 
                                       new UnitDetails(Unit.CubicDeciMeter, Quantity.Volume, "dm³", (AmountType)0.001), 
                                       new UnitDetails(Unit.CubicCentiMeter, Quantity.Volume, "cm³", (AmountType)0.000001), 
                                       new UnitDetails(Unit.KiloGram, Quantity.Mass, "kg"),
                                       new UnitDetails(Unit.Gram, Quantity.Mass, "g", (AmountType) 0.001),
                                       new UnitDetails(Unit.Second, Quantity.Time, "s"),
                                       new UnitDetails(Unit.Minute, Quantity.Time, "min", (AmountType)60.0),
                                       new UnitDetails(Unit.Hour, Quantity.Time, "h", (AmountType)3600.0),
                                       new UnitDetails(Unit.Day, Quantity.Time, "dy", (AmountType)86400.0),
                                       new UnitDetails(Unit.Week, Quantity.Time, "wk", (AmountType)604800.0),
                                       new UnitDetails(Unit.Kelvin, Quantity.Temperature, "K"),
                                       new UnitDetails(Unit.Celsius, Quantity.Temperature, "°C", a => a + (AmountType)273.15, a => a - (AmountType)273.15),
                                       new UnitDetails(Unit.Gray, Quantity.AbsorbedDose, "Gy"),
                                       new UnitDetails(Unit.CentiGray, Quantity.AbsorbedDose, "cGy", (AmountType)0.01) 
                                   }.ToDictionary(ud => ud.Unit);
        }

        #endregion

        #region EXTENSION METHODS

        /// <summary>
        /// Gets the quantity associated with the specified unit
        /// </summary>
        /// <param name="iUnit">Unit for which the associated quantity is requested</param>
        /// <returns>Quantity associated with the specified unit</returns>
        public static Quantity GetQuantity(this Unit iUnit)
        {
            return smUnitDetailsMap[iUnit].Quantity;
        }

        /// <summary>
        /// Gets the text symbol of the specified unit
        /// </summary>
        /// <param name="iUnit">Unit for which the text symbol is requested</param>
        /// <returns>Text symbol for the specified unit</returns>
        public static string GetSymbol(this Unit iUnit)
        {
            return smUnitDetailsMap[iUnit].Symbol;
        }

        /// <summary>
        /// Gets the amount of the <paramref name="iMeasure">specified measure</paramref> in the requested unit
        /// </summary>
        /// <param name="iToUnit">Unit to which the measured amount should be converted</param>
        /// <param name="iMeasure">Measure for which the amount should be converted into the requested unit</param>
        /// <returns>Measured amount converted into <paramref name="iToUnit">specified unit</paramref></returns>
        /// <exception cref="InvalidOperationException">is thrown if the quantity of the specified unit is different
        /// from the measured quantity</exception>
        public static AmountType GetAmount(this Unit iToUnit, IMeasure iMeasure)
        {
            if (iToUnit.GetQuantity() == iMeasure.MeasuredQuantity)
            {
                return smUnitDetailsMap[iToUnit].AmountFromReferenceUnitConverter(iMeasure.ReferenceUnitAmount);
            }
            throw new InvalidOperationException(
                String.Format("Associated quantity for unit {0} is not equal to measured quantity {1}",
                iToUnit, iMeasure.MeasuredQuantity));
        }

        public static AmountType GetReferenceUnitAmount(this Unit iFromUnit, AmountType iFromUnitAmount)
        {
            return smUnitDetailsMap[iFromUnit].AmountToReferenceUnitConverter(iFromUnitAmount);
        }

        #endregion

        #region INNER SUPPORT CLASSES

        /// <summary>
        /// Symbol and amount conversion details associated with a physical unit
        /// A unit defined as a reference unit by convention has amount converters to itself
        /// </summary>
        private sealed class UnitDetails
        {
            #region CONSTRUCTORS

            /// <summary>
            /// Reference unit details constructor
            /// </summary>
            /// <param name="iUnit">Unit instance</param>
            /// <param name="iQuantity">Quantity for which this unit is reference unit</param>
            /// <param name="iSymbol">Unit symbol</param>
            internal UnitDetails(Unit iUnit, Quantity iQuantity, string iSymbol)
            {
                Unit = iUnit;
                Quantity = iQuantity;
                Symbol = iSymbol;
                AmountToReferenceUnitConverter = AmountFromReferenceUnitConverter = a => a;
                iQuantity.SetReferenceUnit(iUnit);
            }

            /// <summary>
            /// Initializes a non-reference unit instance which uses multiplicative conversion vis-a-vis the reference unit
            /// </summary>
            /// <param name="iUnit">Unit instance</param>
            /// <param name="iQuantity">Physical quantity associated with this unit</param>
            /// <param name="iSymbol">Unit symbol</param>
            /// <param name="iAmountToReferenceUnitFactor">Multiplicative factor for amount conversion to reference unit</param>
            internal UnitDetails(Unit iUnit, Quantity iQuantity, string iSymbol, AmountType iAmountToReferenceUnitFactor)
            {
                Unit = iUnit;
                Quantity = iQuantity;
                Symbol = iSymbol;
                AmountToReferenceUnitConverter = a => a * iAmountToReferenceUnitFactor;
                AmountFromReferenceUnitConverter = a => a / iAmountToReferenceUnitFactor;
            }

            /// <summary>
            /// Initializes a unit instance which uses a generic unit conversion
            /// </summary>
            /// <param name="iUnit">Unit instance</param>
            /// <param name="iQuantity">Physical quantity associated with this unit</param>
            /// <param name="iSymbol">Unit symbol</param>
            /// <param name="iAmountToReferenceUnitConverter">Function converting amount in this unit to reference unit amount</param>
            /// <param name="iAmountFromReferenceUnitConverter">Function converting reference unit amount to amount in this unit</param>
            internal UnitDetails(Unit iUnit, Quantity iQuantity, string iSymbol,
                Func<AmountType, AmountType> iAmountToReferenceUnitConverter, 
                Func<AmountType, AmountType> iAmountFromReferenceUnitConverter)
            {
                Unit = iUnit;
                Quantity = iQuantity;
                Symbol = iSymbol;
                AmountToReferenceUnitConverter = iAmountToReferenceUnitConverter;
                AmountFromReferenceUnitConverter = iAmountFromReferenceUnitConverter;
            }

            #endregion

            #region AUTO-IMPLEMENTED PROPERTIES

            /// <summary>
            /// Gets the quantity associated with this unit
            /// </summary>
            internal Quantity Quantity { get; private set; }

            internal Unit Unit { get; private set; }

            /// <summary>
            /// Gets the unit symbol
            /// </summary>
            internal string Symbol { get; private set; }

            /// <summary>
            /// Gets the function used for converting an amount from this unit to the reference unit of the same dimension
            /// </summary>
            internal Func<AmountType, AmountType> AmountToReferenceUnitConverter { get; private set; }

            /// <summary>
            /// Gets the function used for converting an amount to this unit from the reference unit of the same dimension
            /// </summary>
            internal Func<AmountType, AmountType> AmountFromReferenceUnitConverter { get; private set; }

            #endregion
/*
            #region METHODS

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            /// </returns>
            /// <filterpriority>2</filterpriority>
            public override string ToString()
            {
                return Symbol;
            }

            /// <summary>
            /// Multiply two unit objects, yielding a new generic unit with the unit dimensions summed
            /// </summary>
            /// <param name="iLhsUnit">First unit object</param>
            /// <param name="iRhsUnit">Second unit object</param>
            /// <returns>Generic unit with unit dimensions equal to the sum of the multiplied units</returns>
            internal static UnitDetails Multiply(IUnit iLhsUnit, IUnit iRhsUnit)
            {
                return new UnitDetails(String.Empty, iLhsUnit.Dimension + iRhsUnit.Dimension);
            }

            /// <summary>
            /// Divide two unit objects, yielding a new generic unit with unit dimension equal to the difference of the 
            /// divided units' unit dimensions
            /// </summary>
            /// <param name="iLhsUnit">Numerator unit object</param>
            /// <param name="iRhsUnit">Denominator unit object</param>
            /// <returns>Generic unit with unit dimensions equal to the difference of the divided units</returns>
            internal static UnitDetails Divide(IUnit iLhsUnit, IUnit iRhsUnit)
            {
                return new UnitDetails(String.Empty, iLhsUnit.Dimension - iRhsUnit.Dimension);
            }

            #endregion
 */
        }

        #endregion
    }
}