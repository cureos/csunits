using System;
#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#else

#endif

namespace Cureos.Measurables
{
    public struct Measurable<U> : IMeasurable<U> where U : IUnit
    {
        #region INSTANCE MEMBERS

        private readonly System.Double mAmount;

        #endregion

        #region CONSTRUCTORS

        public Measurable(System.Double iAmount)
        {
            mAmount = iAmount;
        }

        #endregion

        #region Implementation of IMeasurable<out U>

        public System.Double Amount
        {
            get { return mAmount; }
        }

        public U Unit
        {
            get { return UnitReflection.GetUnitInstance<U>(); }
        }

        public IMeasurable<V> ConvertTo<V>() where V : IUnit
        {
            V toUnit = UnitReflection.GetUnitInstance<V>();
            if (Unit.Dimension.Equals(toUnit.Dimension))
            {
                return new Measurable<V>(toUnit.FromBase(Unit.ToBase(mAmount)));
            }
            throw new InvalidOperationException("Unit dimensions are not equal");
        }

        #endregion

        #region METHODS

        public override string ToString()
        {
            return string.Format("{0} {1}", mAmount, Unit);
        }

        #endregion
    }
}