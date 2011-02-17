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
    /// <summary>
    /// Extension methods associated with <see cref="UnitPrefix"/> enumeration
    /// </summary>
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

        /// <summary>
        /// Get unit symbol prepended with the specified unit prefix
        /// </summary>
        /// <param name="iPrefix">This unit prefix</param>
        /// <param name="iPrefixlessSymbol">Prefix-less unit symbol</param>
        /// <returns>Resulting unit symbol with this prefix prepended</returns>
        public static string GetUnitSymbol(this UnitPrefix iPrefix, string iPrefixlessSymbol)
        {
            return String.Format("{0}{1}", Symbols[iPrefix], iPrefixlessSymbol);
        }

        /// <summary>
        /// Gets the value associated with this unit prefix
        /// </summary>
        /// <param name="iPrefix">This unit prefix</param>
        /// <returns>Value associated with this unit prefix</returns>
        public static AmountType GetValue(this UnitPrefix iPrefix)
        {
            return (AmountType)Math.Pow(10.0, (double)iPrefix);
        }

        #endregion
    }
}