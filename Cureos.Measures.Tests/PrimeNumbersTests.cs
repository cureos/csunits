/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

namespace Cureos.Measures
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class PrimeNumbersTests
    {
        #region Fields

        private PrimeNumbers _instance;

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void Setup()
        {
            _instance = new PrimeNumbers();
        }

        [TearDown]
        public void Teardown()
        {
            _instance = null;
        }

        #endregion

        #region Unit tests

        [Test]
        public void TakeWhile_CollectionUpToValue50_MatchesPrimeNumberListTo50()
        {
            var expected = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
            var actual = _instance.TakeWhile(x => x < 50).ToArray();
            CollectionAssert.AreEquivalent(expected, actual);
            Assert.AreEqual(expected.Length, actual.Count());
            Assert.IsTrue(actual.SequenceEqual(expected), "{0}", actual);
        }

        [Test]
        public void OddInts_FirstValue_Equals3()
        {
            var expected = 3;
            var actual = PrimeNumbers.OddInts().First();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Timing")]
        public void ElementAt_Get100000thElement_TimeOperation()
        {
            var expected = 1299709;
            var start = DateTime.Now;
            var actual = _instance.ElementAt(99999);
            var stop = DateTime.Now;
            var duration = (stop - start).Ticks / 10000;
            Console.WriteLine("Timing {0} ms", duration);
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
