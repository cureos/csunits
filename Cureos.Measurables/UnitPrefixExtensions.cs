using System;
using System.Collections.Generic;

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

        public static double GetValue(this UnitPrefix iPrefix)
        {
            return Math.Pow(10.0, (double) iPrefix);
        }

        public static double GetInvertedValue(this UnitPrefix iPrefix)
        {
            return Math.Pow(10.0, -(double) iPrefix);
        }

        #endregion
    }
}