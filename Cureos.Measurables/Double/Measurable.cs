using System;

namespace Cureos.Measurables.Double
{
    public struct Measurable<U> : IMeasurable<double, U> where U : IUnit<double>
    {
        #region INSTANCE MEMBERS

        private readonly double mAmount;

        #endregion

        #region CONSTRUCTORS

        public Measurable(double iAmount)
        {
            mAmount = iAmount;
        }

        #endregion

        #region Implementation of IMeasurable<double,out U>

        public double Amount
        {
            get { return mAmount; }
        }

        public U Unit
        {
            get { return UnitReflection.GetUnitInstance<double, U>(); }
        }

        public IMeasurable<double, V> ConvertTo<V>(V iToUnit) where V : IUnit<double>
        {
            if (Unit.Dimensions.Equals(iToUnit.Dimensions))
            {
                return new Measurable<V>(iToUnit.FromBase(Unit.ToBase(mAmount)));
            }
            throw new InvalidOperationException("Unit dimensions are not equal");
        }

        #endregion

        #region PROPERTIES

        #endregion
        
        #region METHODS

        public override string ToString()
        {
            return string.Format("{0} {1}", mAmount, Unit.Symbol);
        }

        #endregion
    }
}