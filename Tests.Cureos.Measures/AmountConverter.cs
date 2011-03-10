// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;
using System.Linq;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Tests.Cureos.Measures
{
    internal static class AmountConverter
    {
        internal static AmountType ToAmountType(double iValue)
        {
            return (AmountType) iValue;
        }

        internal static IEnumerable<AmountType> ToAmountType(IEnumerable<double> iValues)
        {
            return iValues.Select(a => (AmountType)a);
        }

        internal static AmountType[] CastToArray(IEnumerable<AmountType> iAmounts)
        {
            return (AmountType[])iAmounts;
        }
    }
}