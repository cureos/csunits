// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections;
using System.Linq;
using Cureos.Measures.Extensions;
using NUnit.Framework;

namespace Tests.Cureos.Measures.Extensions
{
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
            var actual = _instance.TakeWhile(x => x < 50);
            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        #endregion
    }
}
