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
    public class GenericUnit : IUnit
    {
        #region INSTANCE VARIABLES

        private readonly AmountType mToBaseFactor;
        private readonly AmountType mFromBaseFactor;

        #endregion
        
        #region CONSTRUCTORS

        /// <summary>
        /// Reference unit constructor for multiplicative unit conversion, conversion factor unity
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iDimension">Unit dimensions in terms of SI base units</param>
        protected GenericUnit(string iSymbol, UnitDimension iDimension)
        {
            Symbol = iSymbol;
            ReferenceUnit = this;
            Dimension = iDimension;
            mToBaseFactor = mFromBaseFactor = 1.0;
            InitializeMultiplicativeConverters();
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
            mToBaseFactor = iPrefix.GetValue();
            mFromBaseFactor = iPrefix.GetInvertedValue();
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Reference unit constructor for multiplicative unit conversion, conversion factor unity
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        protected GenericUnit(string iSymbol, IUnit iReferenceUnit)
        {
            Symbol = iSymbol;
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mToBaseFactor = mFromBaseFactor = 1.0;
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Initializes a unit instance which uses multiplicative conversion
        /// </summary>
        /// <param name="iPrefix">Unit prefix</param>
        /// <param name="iPrefixlessSymbol">Unit symbol excluding prefix</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        protected GenericUnit(UnitPrefix iPrefix, string iPrefixlessSymbol, IUnit iReferenceUnit)
        {
            Symbol = iPrefix.GetUnitSymbol(iPrefixlessSymbol);
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mToBaseFactor = iPrefix.GetValue();
            mFromBaseFactor = iPrefix.GetInvertedValue();
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Initializes a unit instance which uses multiplicative conversion
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        /// <param name="iToBaseFactor">Multiplicative factor for temporary unit conversion to base</param>
        protected GenericUnit(string iSymbol, IUnit iReferenceUnit, AmountType iToBaseFactor)
        {
            Symbol = iSymbol;
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mToBaseFactor = iToBaseFactor;
            mFromBaseFactor = 1.0 / iToBaseFactor;
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Initializes a unit instance which uses a generic unit conversion
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        /// <param name="iToBase">Function converting this unit to base</param>
        /// <param name="iFromBase">Function converting from base to this unit</param>
        protected GenericUnit(string iSymbol, IUnit iReferenceUnit, Func<AmountType, AmountType> iToBase,
            Func<AmountType, AmountType> iFromBase)
        {
            Symbol = iSymbol;
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mToBaseFactor = mFromBaseFactor = 0.0;
            ToBase = iToBase;
            FromBase = iFromBase;
        }

        #endregion
        
        #region Implementation of IUnit<double>

        public string Symbol { get; private set; }

        public IUnit ReferenceUnit { get; private set; }

        public UnitDimension Dimension { get; private set; }

        public Func<AmountType, AmountType> ToBase { get; private set; }

        public Func<AmountType, AmountType> FromBase { get; private set; }

        #endregion

        #region METHODS

        public override string ToString()
        {
            return Symbol;
        }

        internal static GenericUnit Multiply(IUnit iLhsUnit, IUnit iRhsUnit)
        {
            return new GenericUnit(String.Empty, iLhsUnit.Dimension + iRhsUnit.Dimension);
        }

        internal static GenericUnit Divide(IUnit iLhsUnit, IUnit iRhsUnit)
        {
            return new GenericUnit(String.Empty, iLhsUnit.Dimension - iRhsUnit.Dimension);
        }

        private void InitializeMultiplicativeConverters()
        {
            ToBase = a => mToBaseFactor * a;
            FromBase = a => mFromBaseFactor * a;
        }

        #endregion
    }
}