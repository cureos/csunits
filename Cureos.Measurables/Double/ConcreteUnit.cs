using System;

namespace Cureos.Measurables.Double
{
    public class ConcreteUnit : IUnit<double>
    {
        #region MEMBER VARIABLES

        private readonly double mToBaseFactor;
        private readonly double mFromBaseFactor;

        #endregion
        
        #region CONSTRUCTORS

        /// <summary>
        /// Reference unit constructor for multiplicative unit conversion, conversion factor unity
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iDimensions">Unit dimensions in terms of SI base units</param>
        public ConcreteUnit(string iSymbol, UnitDimensions iDimensions)
        {
            Symbol = iSymbol;
            ReferenceUnit = this;
            Dimensions = iDimensions;
            mToBaseFactor = mFromBaseFactor = 1.0;
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Reference unit constructor supporting multiplicative unit conversion
        /// </summary>
        /// <param name="iPrefix">Unit prefix</param>
        /// <param name="iPrefixlessSymbol">Unit symbol excluding prefix</param>
        /// <param name="iDimensions">Unit dimensions in terms of SI base units</param>
        public ConcreteUnit(UnitPrefix iPrefix, string iPrefixlessSymbol, UnitDimensions iDimensions)
        {
            Symbol = iPrefix.GetUnitSymbol(iPrefixlessSymbol);
            ReferenceUnit = this;
            Dimensions = iDimensions;
            mToBaseFactor = iPrefix.GetValue();
            mFromBaseFactor = iPrefix.GetInvertedValue();
            InitializeMultiplicativeConverters();
        }

        /// <summary>
        /// Initializes a unit instance which uses multiplicative conversion
        /// </summary>
        /// <param name="iPrefix">Unit prefix</param>
        /// <param name="iPrefixlessSymbol">Unit symbol excluding prefix</param>
        /// <param name="iReferenceUnit">Reference unit</param>
        public ConcreteUnit(UnitPrefix iPrefix, string iPrefixlessSymbol, IUnit<double> iReferenceUnit)
        {
            Symbol = iPrefix.GetUnitSymbol(iPrefixlessSymbol);
            ReferenceUnit = iReferenceUnit;
            Dimensions = iReferenceUnit.Dimensions;
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
        public ConcreteUnit(string iSymbol, IUnit<double> iReferenceUnit, double iToBaseFactor)
        {
            Symbol = iSymbol;
            ReferenceUnit = iReferenceUnit;
            Dimensions = iReferenceUnit.Dimensions;
            mToBaseFactor = iToBaseFactor;
            mFromBaseFactor = 1.0 / iToBaseFactor;
            InitializeMultiplicativeConverters();
        }

        #endregion
        
        #region Implementation of IUnit<double>

        public string Symbol { get; private set; }

        public IUnit<double> ReferenceUnit { get; private set; }

        public UnitDimensions Dimensions { get; private set; }

        public Func<double, double> ToBase { get; private set; }

        public Func<double, double> FromBase { get; private set; }

        #endregion

        #region METHODS

        private void InitializeMultiplicativeConverters()
        {
            ToBase = a => mToBaseFactor * a;
            FromBase = a => mFromBaseFactor * a;
        }

        #endregion
    }
}