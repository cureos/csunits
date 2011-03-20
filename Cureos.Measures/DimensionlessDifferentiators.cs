// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;
using Cureos.Measures.Extensions;

namespace Cureos.Measures
{
    /// <summary>
    /// Identifiers to differentiate between unrelated dimensionless quantities
    /// Each quantity should be assigned a prime number, to ensure that one dimensionless
    /// quantity does not accidentally switch into an unrelated dimensionless quantity through multiplication.
    /// </summary>
    /// <remarks>
    /// When adding a new field, unrelated to the other dimensionless quantities, assign its value by 
    /// calling the <see cref="GetNextPrime"/> method.
    /// The solid angle quantity steradian can be regarded as the square of the plane angle quantity
    /// radian, and therefore its identifier is set to the square of the radian.
    /// </remarks>
    public static class DimensionlessDifferentiators
    {
        #region FIELDS

        private static readonly IEnumerator<int> _primesEnumerator = new PrimeNumbers().GetEnumerator();

        public static readonly int Radian = GetNextPrime();
        public static readonly int Steradian = Radian * Radian;
        public static readonly int Pi = GetNextPrime();
        public static readonly int RelativeDensity = GetNextPrime();
        public static readonly int RefractiveIndex = GetNextPrime();
        public static readonly int RelativePermeability = GetNextPrime();
        public static readonly int RelativeBiologicalEffectiveness = GetNextPrime();

        #endregion

        #region PRIVATE SUPPORT METHODS

        private static int GetNextPrime()
        {
            if (_primesEnumerator.MoveNext()) return _primesEnumerator.Current;
            throw new InvalidOperationException("Reached the end of the Int32 prime number collection");
        }

        #endregion
    }
}