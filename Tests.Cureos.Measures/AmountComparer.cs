// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections;
using NUnit.Framework;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Tests.Cureos.Measures
{
    public class AmountComparer : IComparer
    {
        public static readonly AmountComparer Instance;

        private static readonly AmountType smkEqualityTolerance;

        #region CONSTRUCTORS

        static AmountComparer()
        {
            smkEqualityTolerance = AmountConverter.ToAmountType(1.0e-6);
            Instance = new AmountComparer();
        }

        #endregion
        
        #region Implementation of IComparer

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// Value 
        ///                     Condition 
        ///                     Less than zero 
        ///                 <paramref name="x"/> is less than <paramref name="y"/>. 
        ///                     Zero 
        ///                 <paramref name="x"/> equals <paramref name="y"/>. 
        ///                     Greater than zero 
        ///                 <paramref name="x"/> is greater than <paramref name="y"/>. 
        /// </returns>
        /// <param name="x">The first object to compare. 
        ///                 </param><param name="y">The second object to compare. 
        ///                 </param><exception cref="T:System.ArgumentException">Neither <paramref name="x"/> nor <paramref name="y"/> implements the <see cref="T:System.IComparable"/> interface.
        ///                     -or- 
        ///                 <paramref name="x"/> and <paramref name="y"/> are of different types and neither one can handle comparisons with the other. 
        ///                 </exception><filterpriority>2</filterpriority>
        public int Compare(object x, object y)
        {
            Assert.IsInstanceOf(typeof(AmountType), x);
            Assert.IsInstanceOf(typeof(AmountType), y);

            AmountType diff = (AmountType)x - (AmountType)y;
            return diff < -smkEqualityTolerance ? -1 : diff < smkEqualityTolerance ? 0 : 1;
        }

        #endregion
    }
}