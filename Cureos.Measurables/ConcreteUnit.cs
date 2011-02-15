using System;
#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#else

#endif

namespace Cureos.Measurables
{
    public class ConcreteUnit : IUnit
    {
        #region INSTANCE VARIABLES

        private readonly string mSymbol;
        private readonly System.Double mToBaseFactor;
        private readonly System.Double mFromBaseFactor;

        #endregion
        
        #region CONSTRUCTORS

        /// <summary>
        /// Reference unit constructor for multiplicative unit conversion, conversion factor unity
        /// </summary>
        /// <param name="iSymbol">Unit symbol</param>
        /// <param name="iDimension">Unit dimensions in terms of SI base units</param>
        protected ConcreteUnit(string iSymbol, UnitDimension iDimension)
        {
            mSymbol = iSymbol;
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
        protected ConcreteUnit(UnitPrefix iPrefix, string iPrefixlessSymbol, UnitDimension iDimension)
        {
            mSymbol = iPrefix.GetUnitSymbol(iPrefixlessSymbol);
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
        protected ConcreteUnit(string iSymbol, IUnit iReferenceUnit)
        {
            mSymbol = iSymbol;
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
        protected ConcreteUnit(UnitPrefix iPrefix, string iPrefixlessSymbol, IUnit iReferenceUnit)
        {
            mSymbol = iPrefix.GetUnitSymbol(iPrefixlessSymbol);
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
        protected ConcreteUnit(string iSymbol, IUnit iReferenceUnit, System.Double iToBaseFactor)
        {
            mSymbol = iSymbol;
            ReferenceUnit = iReferenceUnit;
            Dimension = iReferenceUnit.Dimension;
            mToBaseFactor = iToBaseFactor;
            mFromBaseFactor = 1.0 / iToBaseFactor;
            InitializeMultiplicativeConverters();
        }

        #endregion
        
        #region Implementation of IUnit<double>

        public IUnit ReferenceUnit { get; private set; }

        public UnitDimension Dimension { get; private set; }

        public Func<double, double> ToBase { get; private set; }

        public Func<double, double> FromBase { get; private set; }

        #endregion

        #region METHODS

        public override string ToString()
        {
            return mSymbol;
        }

        private void InitializeMultiplicativeConverters()
        {
            ToBase = a => mToBaseFactor * a;
            FromBase = a => mFromBaseFactor * a;
        }

        #endregion
    }
}