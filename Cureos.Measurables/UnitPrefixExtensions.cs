// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measurables
{
    public static class UnitPrefixExtensions
    {
        #region FIELDS

        private static readonly Dictionary<UnitPrefix, string> Symbols;

        #endregion

        #region CONSTRUCTORS

        static UnitPrefixExtensions()
        {
            Symbols = new Dictionary<UnitPrefix, string>
                          {
                              {UnitPrefix.Pico, "p"},
                              {UnitPrefix.Nano, "n"},
                              {UnitPrefix.Micro, "µ"},
                              {UnitPrefix.Milli, "m"},
                              {UnitPrefix.Centi, "c"},
                              {UnitPrefix.Deci, "d"},
                              {UnitPrefix.Hecto, "h"},
                              {UnitPrefix.Kilo, "k"},
                              {UnitPrefix.Mega, "M"},
                              {UnitPrefix.Giga, "G"},
                              {UnitPrefix.Tera, "T"}
                          };
        }

        #endregion

        #region EXTENSION METHODS

        public static string GetUnitSymbol(this UnitPrefix iPrefix, string iPrefixlessSymbol)
        {
            return String.Format("{0}{1}", Symbols[iPrefix], iPrefixlessSymbol);
        }

        public static AmountType GetValue(this UnitPrefix iPrefix)
        {
            return Math.Pow((AmountType)10.0, (AmountType)iPrefix);
        }

        #endregion
    }
}