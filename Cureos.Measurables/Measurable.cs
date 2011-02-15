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
    public struct Measurable<U> : IMeasurable<U>, IComparable<Measurable<U>>, IEquatable<Measurable<U>> where U : IUnit
    {
        #region INSTANCE MEMBERS

        private readonly AmountType mAmount;

        #endregion

        #region CONSTRUCTORS

        public Measurable(AmountType iAmount)
        {
            mAmount = iAmount;
        }

        #endregion

        #region Implementation of IMeasurable<out U>

        public AmountType Amount
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

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Measurable<U> other)
        {
            return mAmount.Equals(other.mAmount);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            return (obj is Measurable<U>) ? Equals((Measurable<U>)obj) : false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return mAmount.GetHashCode();
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Measurable<U> other)
        {
            return mAmount.CompareTo(other.mAmount);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", mAmount, Unit).Trim();
        }

        #endregion
    }
}