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
            get { return UnitReflection.GetUnitInstance<U>(); }
        }

        public IMeasurable<double, V> ConvertTo<V>() where V : IUnit<double>
        {
            V toUnit = UnitReflection.GetUnitInstance<V>();
            if (Unit.Dimension.Equals(toUnit.Dimension))
            {
                return new Measurable<V>(toUnit.FromBase(Unit.ToBase(mAmount)));
            }
            throw new InvalidOperationException("Unit dimensions are not equal");
        }

        #endregion

        #region PROPERTIES

        #endregion
        
        #region METHODS

        public override string ToString()
        {
            return string.Format("{0} {1}", mAmount, Unit);
        }

        #endregion
    }
}