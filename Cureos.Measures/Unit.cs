// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
    public sealed class Unit<Q> : IUnit<Q> where Q : struct, IQuantity<Q>
    {
        #region CONSTRUCTORS

        public Unit(string iSymbol) :
            this(iSymbol, a => a, a => a)
        {
        }

        public Unit(string iSymbol, AmountType iToReferenceFactor) :
            this(iSymbol, a => a * iToReferenceFactor, a => a / iToReferenceFactor)
        {
        }

        public Unit(string iSymbol, Func<AmountType, AmountType> iAmountToReferenceUnitConverter,
            Func<AmountType, AmountType> iAmountFromReferenceUnitConverter)
        {
            Symbol = iSymbol;
            AmountToReferenceUnitConverter = iAmountToReferenceUnitConverter;
            AmountFromReferenceUnitConverter = iAmountFromReferenceUnitConverter;
        }

        #endregion
        
        #region Implementation of IUnit<Q>

        public IQuantity<Q> ReferencedQuantity
        {
            get { return default(Q); }
        }

        public string Symbol { get; private set; }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter { get; private set; }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter { get; private set; }

        #endregion
    }
}