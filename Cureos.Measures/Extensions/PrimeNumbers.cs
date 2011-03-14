// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cureos.Measures.Extensions
{
    /// <summary>
    /// Support class for generating a (nearly) unbounded collection of primes.
    /// Adapted from an implementation by Clinton Sheppard, published at
    /// http://handcraftsman.wordpress.com/2010/09/02/ienumerable-of-prime-numbers-in-csharp/.
    /// </summary>
    public sealed class PrimeNumbers : IEnumerable<int>
    {
        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<int> GetEnumerator()
        {
            yield return 2;

            var enumerator = OddInts().GetEnumerator();
            do
            {
                var x = enumerator.Current;
                var sqrt = Math.Sqrt(x);
                if (!OddInts().TakeWhile(y => y <= sqrt).Any(y => x % y == 0)) yield return x;
            } while (enumerator.MoveNext());
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region PRIVATE SUPPORT METHODS

        private static IEnumerable<int> OddInts()
        {
            int start = 1;
            while (start > 0)
            {
                unchecked
                {
                    yield return start += 2;
                }
            }
        }

        #endregion
    }
}