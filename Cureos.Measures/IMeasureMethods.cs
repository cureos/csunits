// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures
{
    /// <summary>
    /// Support methods applicable to IMeasure objects
    /// </summary>
    public static class IMeasureMethods
    {
        public static bool ProductIs<Q, Q1, Q2>(IMeasure<Q1> iFirst, int iFirstExponent, IMeasure<Q2> iSecond,
                                                  int iSecondExponent)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            return QuantityDimensionIs<Q>((default(Q1).Dimension ^ iFirstExponent)*
                                          (default(Q2).Dimension ^ iSecondExponent));
        }

        private static bool QuantityDimensionIs<Q>(QuantityDimension iActualDimension) where Q : struct, IQuantity<Q>
        {
            return default(Q).Dimension.Equals(iActualDimension);
        }
    }
}