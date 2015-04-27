// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measures.Quantities;

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
    /// Representation of a triplet of measures, given in the standard units of the respective quantities
    /// </summary>
    /// <typeparam name="Q1">Quantity type of the first measure</typeparam>
    /// <typeparam name="Q2">Quantity type of the second measure</typeparam>
    /// <typeparam name="Q3">Quantity type of the third measure</typeparam>
    public struct MeasureTriplet<Q1, Q2, Q3> : IMeasureTriplet<Q1, Q2, Q3>
        where Q1 : struct, IQuantity<Q1>
        where Q2 : struct, IQuantity<Q2>
        where Q3 : struct, IQuantity<Q3>
    {
        #region MEMBER VARIABLES

        private readonly Measure<Q1> mX;
        private readonly Measure<Q2> mY;
        private readonly Measure<Q3> mZ;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a triplet of standard measures
        /// </summary>
        /// <param name="iMeasureTriplet">Triplet of measures in arbitrary unit</param>
        public MeasureTriplet(IMeasureTriplet<Q1, Q2, Q3> iMeasureTriplet)
            : this(iMeasureTriplet.X, iMeasureTriplet.Y, iMeasureTriplet.Z)
        {
        }

        /// <summary>
        /// Initializes a triplet of standard measures from three standard measure objects
        /// </summary>
        /// <param name="iX">First measure object</param>
        /// <param name="iY">Second measure object</param>
        /// <param name="iZ">Third measure object</param>
        public MeasureTriplet(Measure<Q1> iX, Measure<Q2> iY, Measure<Q3> iZ)
        {
            mX = iX;
            mY = iY;
            mZ = iZ;
        }

        /// <summary>
        /// Initializes a triplet of standard measures
        /// </summary>
        /// <param name="iMeasure1">First measure object</param>
        /// <param name="iMeasure2">Second measure object</param>
        /// <param name="iMeasure3">Third measure object</param>
        public MeasureTriplet(IMeasure<Q1> iMeasure1, IMeasure<Q2> iMeasure2, IMeasure<Q3> iMeasure3)
        {
            mX = new Measure<Q1>(iMeasure1);
            mY = new Measure<Q2>(iMeasure2);
            mZ = new Measure<Q3>(iMeasure3);
        }

        /// <summary>
        /// Initializes a triplet of standard measures from a triplet of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        /// <param name="iAmount3">Amount in standard units of the third measure object</param>
        public MeasureTriplet(double iAmount1, double iAmount2, double iAmount3)
        {
            mX = new Measure<Q1>(iAmount1);
            mY = new Measure<Q2>(iAmount2);
            mZ = new Measure<Q3>(iAmount3);
        }

        /// <summary>
        /// Initializes a triplet of standard measures from a triplet of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        /// <param name="iAmount3">Amount in standard units of the third measure object</param>
        public MeasureTriplet(float iAmount1, float iAmount2, float iAmount3)
        {
            mX = new Measure<Q1>(iAmount1);
            mY = new Measure<Q2>(iAmount2);
            mZ = new Measure<Q3>(iAmount3);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        /// <param name="iAmount3">Amount in standard units of the third measure object</param>
        public MeasureTriplet(decimal iAmount1, decimal iAmount2, decimal iAmount3)
        {
            mX = new Measure<Q1>(iAmount1);
            mY = new Measure<Q2>(iAmount2);
            mZ = new Measure<Q3>(iAmount3);
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the first measure in the measure triplet
        /// </summary>
        public Measure<Q1> X
        {
            get { return mX; }
        }

        /// <summary>
        /// Gets the second measure in the measure triplet
        /// </summary>
        public Measure<Q2> Y
        {
            get { return mY; }
        }

        /// <summary>
        /// Gets the third measure in the measure triplet
        /// </summary>
        public Measure<Q3> Z
        {
            get { return mZ; }
        }

        #endregion

        #region Implementation of IMeasure<Q1,Q2,Q3>

        /// <summary>
        /// Gets the first measure in the measure triplet
        /// </summary>
        IMeasure<Q1> IMeasureTriplet<Q1, Q2, Q3>.X
        {
            get { return mX; }
        }

        /// <summary>
        /// Gets the second measure in the measure triplet
        /// </summary>
        IMeasure<Q2> IMeasureTriplet<Q1, Q2, Q3>.Y
        {
            get { return mY; }
        }

        /// <summary>
        /// Gets the third measure in the measure triplet
        /// </summary>
        IMeasure<Q3> IMeasureTriplet<Q1, Q2, Q3>.Z
        {
            get { return mZ; }
        }

        #endregion

        #region OPERATORS

        /// <summary>
        /// Adds two measure triplets
        /// </summary>
        /// <param name="iLhs">First measure triplet</param>
        /// <param name="iRhs">Second measure triplet</param>
        /// <returns>Sum of the specified measure triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator +(MeasureTriplet<Q1, Q2, Q3> iLhs, MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX + iRhs.mX, iLhs.mY + iRhs.mY, iLhs.mZ + iRhs.mZ);
        }

        /// <summary>
        /// Adds two measure triplets
        /// </summary>
        /// <param name="iLhs">First measure triplet</param>
        /// <param name="iRhs">Second measure triplet</param>
        /// <returns>Sum of the specified measure triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator +(MeasureTriplet<Q1, Q2, Q3> iLhs, IMeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX.Amount + iRhs.X.StandardAmount,
                                                          iLhs.mY.Amount + iRhs.Y.StandardAmount,
                                                          iLhs.mZ.Amount + iRhs.Z.StandardAmount);
        }

        /// <summary>
        /// Subtracts two measure triplets
        /// </summary>
        /// <param name="iLhs">First measure triplet</param>
        /// <param name="iRhs">Second measure triplet</param>
        /// <returns>Difference of the specified measure triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator -(MeasureTriplet<Q1, Q2, Q3> iLhs, MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX - iRhs.mX, iLhs.mY - iRhs.mY, iLhs.mZ - iRhs.mZ);
        }

        /// <summary>
        /// Subtracts two measure triplets
        /// </summary>
        /// <param name="iLhs">First measure triplet</param>
        /// <param name="iRhs">Second measure triplet</param>
        /// <returns>Difference of the specified measure triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator -(MeasureTriplet<Q1, Q2, Q3> iLhs, IMeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX.Amount - iRhs.X.StandardAmount,
                                                          iLhs.mY.Amount - iRhs.Y.StandardAmount,
                                                          iLhs.mZ.Amount - iRhs.Z.StandardAmount);
        }

        /// <summary>
        /// Apply multiplicative factor on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Multiplicative factor</param>
        /// <param name="iRhs">Measure triplet</param>
        /// <returns>Product of the measure triplet and the multiplicative factor</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(AmountType iLhs, MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs * iRhs.mX.Amount, iLhs * iRhs.mY.Amount, iLhs * iRhs.mZ.Amount);
        }

        /// <summary>
        /// Apply multiplicative factor on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Multiplicative factor</param>
        /// <param name="iRhs">Measure triplet</param>
        /// <returns>Product of the measure triplet and the multiplicative factor</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(Measure<Number> iLhs, MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.Amount * iRhs.mX.Amount, iLhs.Amount * iRhs.mY.Amount, iLhs.Amount * iRhs.mZ.Amount);
        }

        /// <summary>
        /// Apply multiplicative factor on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Multiplicative factor</param>
        /// <returns>Product of the measure triplet and the multiplicative factor</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(MeasureTriplet<Q1, Q2, Q3> iLhs, AmountType iRhs)
        {
            return iRhs * iLhs;
        }

        /// <summary>
        /// Apply multiplicative factor on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Multiplicative factor</param>
        /// <returns>Product of the measure triplet and the multiplicative factor</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(MeasureTriplet<Q1, Q2, Q3> iLhs, Measure<Number> iRhs)
        {
            return iRhs * iLhs;
        }

        /// <summary>
        /// Multiplies one measure triplet with a number triplet
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Number triplet</param>
        /// <returns>Product of the measure and number triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(MeasureTriplet<Q1, Q2, Q3> iLhs, MeasureTriplet<Number, Number, Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX.Amount * iRhs.mX.Amount,
                                                          iLhs.mY.Amount * iRhs.mY.Amount,
                                                          iLhs.mZ.Amount * iRhs.mZ.Amount);
        }

        /// <summary>
        /// Multiplies one measure triplet with a number triplet
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Number triplet</param>
        /// <returns>Product of the measure and number triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(MeasureTriplet<Q1, Q2, Q3> iLhs, IMeasureTriplet<Number, Number, Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX.Amount * iRhs.X.StandardAmount,
                                                          iLhs.mY.Amount * iRhs.Y.StandardAmount,
                                                          iLhs.mZ.Amount * iRhs.Z.StandardAmount);
        }

        /// <summary>
        /// Apply scalar denominator on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Scalar denominator</param>
        /// <returns>Quotient of the measure triplet and the scalar denominator</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator /(MeasureTriplet<Q1, Q2, Q3> iLhs, AmountType iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX.Amount / iRhs, iLhs.mY.Amount / iRhs, iLhs.mZ.Amount / iRhs);
        }

        /// <summary>
        /// Apply scalar denominator on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Scalar denominator</param>
        /// <returns>Quotient of the measure triplet and the scalar denominator</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator /(MeasureTriplet<Q1, Q2, Q3> iLhs, Measure<Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX.Amount / iRhs.Amount, iLhs.mY.Amount / iRhs.Amount,
                                                          iLhs.mZ.Amount / iRhs.Amount);
        }

        /// <summary>
        /// Divides one measure triplet with a number triplet
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Number triplet</param>
        /// <returns>Quotient of the measure and number triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator /(MeasureTriplet<Q1, Q2, Q3> iLhs, MeasureTriplet<Number, Number, Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX.Amount / iRhs.mX.Amount,
                                                          iLhs.mY.Amount / iRhs.mY.Amount,
                                                          iLhs.mZ.Amount / iRhs.mZ.Amount);
        }

        /// <summary>
        /// Divides one measure triplet with a number triplet
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Number triplet</param>
        /// <returns>Quotient of the measure and number triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator /(MeasureTriplet<Q1, Q2, Q3> iLhs, IMeasureTriplet<Number, Number, Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.mX.Amount / iRhs.X.StandardAmount,
                                                          iLhs.mY.Amount / iRhs.Y.StandardAmount,
                                                          iLhs.mZ.Amount / iRhs.Z.StandardAmount);
        }

        /// <summary>
        /// Divides one measure triplet with another measure triplet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure triplet</param>
        /// <param name="iRhs">Denominator measure triplet</param>
        /// <returns>Quotient of the measure triplets as a number triplet</returns>
        public static MeasureTriplet<Number, Number, Number> operator /(MeasureTriplet<Q1, Q2, Q3> iLhs, MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Number, Number, Number>(iLhs.mX / iRhs.mX, iLhs.mY / iRhs.mY, iLhs.mZ / iRhs.mZ);
        }

        /// <summary>
        /// Divides one measure triplet with another measure triplet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure triplet</param>
        /// <param name="iRhs">Denominator measure triplet</param>
        /// <returns>Quotient of the measure triplets as a number triplet</returns>
        public static MeasureTriplet<Number, Number, Number> operator /(MeasureTriplet<Q1, Q2, Q3> iLhs, IMeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Number, Number, Number>(iLhs.mX.Amount / iRhs.X.StandardAmount,
                                                                      iLhs.mY.Amount / iRhs.Y.StandardAmount,
                                                                      iLhs.mZ.Amount / iRhs.Z.StandardAmount);
        }

        #endregion
    }

    /// <summary>
    /// Utility class for operations on StandardMeasureTriplet objects
    /// </summary>
    public static class MeasureTriplet
    {
        /// <summary>
        /// Compare two nullable standard measure triplets containing a single quantity for approximate equivalence
        /// </summary>
        /// <typeparam name="Q">Struct type implementing the IQuantity{Q} interface</typeparam>
        /// <param name="iLhs">First nullable standard measure triplet subject to comparison</param>
        /// <param name="iRhs">Second nullable standard measure triplet subject to comparison</param>
        /// <param name="iTol">Tolerance of the difference between the two measures</param>
        /// <returns>true if both objects have values and the difference is less than the specified tolerance, false otherwise</returns>
        public static bool AreEqual<Q>(MeasureTriplet<Q, Q, Q>? iLhs, 
            MeasureTriplet<Q, Q, Q>? iRhs, Measure<Q> iTol) where Q : struct, IQuantity<Q>
        {
            return iLhs.HasValue && iRhs.HasValue && iLhs.Value.X.Equals(iRhs.Value.X, iTol) &&
                iLhs.Value.Y.Equals(iRhs.Value.Y, iTol) && iLhs.Value.Z.Equals(iRhs.Value.Z, iTol);
        }

        /// <summary>
        /// Compare two standard measure triplets containing a single quantity for approximate equivalence
        /// </summary>
        /// <typeparam name="Q">Struct type implementing the IQuantity{Q} interface</typeparam>
        /// <param name="iLhs">First standard measure triplet subject to comparison</param>
        /// <param name="iRhs">Second standard measure triplet subject to comparison</param>
        /// <param name="iTol">Tolerance of the difference between the two measures</param>
        /// <returns>true if the difference between each coordinate is less than the specified tolerance, false otherwise</returns>
        public static bool AreEqual<Q>(MeasureTriplet<Q, Q, Q> iLhs,
            MeasureTriplet<Q, Q, Q> iRhs, Measure<Q> iTol) where Q : struct, IQuantity<Q>
        {
            return iLhs.X.Equals(iRhs.X, iTol) && iLhs.Y.Equals(iRhs.Y, iTol) && iLhs.Z.Equals(iRhs.Z, iTol);
        }
    }
}