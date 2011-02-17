// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measurables
{
    /// <summary>
    /// Base class for all physical units
    /// A unit defined as a reference unit by convention has amount converters to itself
    /// </summary>
    public class GenericUnit : IUnit
    {
        #region INSTANCE VARIABLES

        private readonly AmountType mAmountToReferenceUnitFactor;
        private readonly AmountType mAmountFromReferenceUnitFactor;

        #endregion
        
        #region CONSTRUCTORS

        /// <summary>
        /// Reference unit constructor without unit prefix
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iDimension">Unit dimensions in terms of SI base units</param>
        protected GenericUnit(string iSymbol, UnitDimension iDimension)
        {
            Symbol = iSymbol;
            ReferenceUnit = this;
            Dimension = iDimension;
            mAmountToReferenceUnitFactor = mAmountFromReferenceUnitFactor = (AmountType)1.0;
            AmountToReferenceUnitConverter = AmountFromReferenceUnitConverter = a => a;
        }

        /// <summary>
        /// Reference unit constructor supporting multiplicative unit conversion
        /// </summary>
        /// <param name="iPrefix">Unit prefix</param>
        /// <param name="iPrefixlessSymbol">Unit symbol excluding prefix</param>
        /// <param name="iDimension">Unit dimensions in terms of SI base units</param>
        protected GenericUnit(UnitPrefix iPrefix, string iPrefixlessSymbol, UnitDimension iDimension)
        {
            Symbol = iPrefix.GetUnitSymbol(iPrefixlessSymbol);
            ReferenceUnit = this;
            Dimension = iDimension;
            mAmountToReferenceUnitFactor = mAmountFromReferenceUnitFactor = (AmountType)1.0;
            AmountToReferenceUnitConverter = AmountFromReferenceUnitConverter = a => a;
        }

        /// <summary>
        /// Initializes a unit instance which uses multiplicative conversion
        /// </summary>
        /// <param name="iPrefix">Unit prefix, simultaneously used to identify amount conversion factor</param>
        /// <param name="iPrefixlessSymbol">Unit symbol excluding prefix</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        protected GenericUnit(UnitPrefix iPrefix, string iPrefixlessSymbol, IUnit iReferenceUnit)
        {
            Symbol = iPrefix.GetUnitSymbol(iPrefixlessSymbol);
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mAmountToReferenceUnitFactor = iPrefix.GetValue();
            mAmountFromReferenceUnitFactor = (AmountType)1.0 / mAmountToReferenceUnitFactor;
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Initializes a unit instance which uses multiplicative conversion
        /// </summary>
        /// <param name="iPrefix">Unit prefix</param>
        /// <param name="iPrefixlessSymbol">Unit symbol excluding prefix</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        /// <param name="iAmountToReferenceUnitFactor">Multiplicative factor for temporary amount conversion to reference unit</param>
        protected GenericUnit(UnitPrefix iPrefix, string iPrefixlessSymbol, IUnit iReferenceUnit,
            AmountType iAmountToReferenceUnitFactor)
        {
            Symbol = iPrefix.GetUnitSymbol(iPrefixlessSymbol);
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mAmountToReferenceUnitFactor = iAmountToReferenceUnitFactor;
            mAmountFromReferenceUnitFactor = (AmountType)1.0 / iAmountToReferenceUnitFactor;
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Initializes a unit instance which uses multiplicative conversion
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        /// <param name="iAmountToReferenceUnitFactor">Multiplicative factor for temporary unit conversion to base</param>
        protected GenericUnit(string iSymbol, IUnit iReferenceUnit, AmountType iAmountToReferenceUnitFactor)
        {
            Symbol = iSymbol;
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mAmountToReferenceUnitFactor = iAmountToReferenceUnitFactor;
            mAmountFromReferenceUnitFactor = (AmountType)1.0 / iAmountToReferenceUnitFactor;
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Initializes a unit instance which uses a generic unit conversion
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        /// <param name="iAmountToReferenceUnitConverter">Function converting this unit to base</param>
        /// <param name="iAmountFromReferenceUnitConverter">Function converting from base to this unit</param>
        protected GenericUnit(string iSymbol, IUnit iReferenceUnit, Func<AmountType, AmountType> iAmountToReferenceUnitConverter,
            Func<AmountType, AmountType> iAmountFromReferenceUnitConverter)
        {
            Symbol = iSymbol;
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mAmountToReferenceUnitFactor = mAmountFromReferenceUnitFactor = (AmountType)0.0;
            AmountToReferenceUnitConverter = iAmountToReferenceUnitConverter;
            AmountFromReferenceUnitConverter = iAmountFromReferenceUnitConverter;
        }

        #endregion
        
        #region Implementation of IUnit<double>

        /// <summary>
        /// Gets the unit symbol
        /// </summary>
        public string Symbol { get; private set; }

        /// <summary>
        /// Gets the reference unit
        /// </summary>
        public IUnit ReferenceUnit { get; private set; }

        /// <summary>
        /// Gets the unit dimension
        /// </summary>
        public UnitDimension Dimension { get; private set; }

        /// <summary>
        /// Gets the function used for converting an amount from this unit to the reference unit of the same dimension
        /// </summary>
        public Func<AmountType, AmountType> AmountToReferenceUnitConverter { get; private set; }

        /// <summary>
        /// Gets the function used for converting an amount to this unit from the reference unit of the same dimension
        /// </summary>
        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter { get; private set; }

        #endregion

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
        internal static GenericUnit Multiply(IUnit iLhsUnit, IUnit iRhsUnit)
        {
            return new GenericUnit(String.Empty, iLhsUnit.Dimension + iRhsUnit.Dimension);
        }

        /// <summary>
        /// Divide two unit objects, yielding a new generic unit with unit dimension equal to the difference of the 
        /// divided units' unit dimensions
        /// </summary>
        /// <param name="iLhsUnit">Numerator unit object</param>
        /// <param name="iRhsUnit">Denominator unit object</param>
        /// <returns>Generic unit with unit dimensions equal to the difference of the divided units</returns>
        internal static GenericUnit Divide(IUnit iLhsUnit, IUnit iRhsUnit)
        {
            return new GenericUnit(String.Empty, iLhsUnit.Dimension - iRhsUnit.Dimension);
        }

        /// <summary>
        /// Convenience method for creating amount converts based on defined multiplicative conversion factors
        /// </summary>
        private void InitializeMultiplicativeConverters()
        {
            AmountToReferenceUnitConverter = a => a * mAmountToReferenceUnitFactor;
            AmountFromReferenceUnitConverter = a => a * mAmountFromReferenceUnitFactor;
        }

        #endregion
    }
}