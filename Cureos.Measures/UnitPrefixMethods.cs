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
    using System.Collections.Generic;

#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

    public static class UnitPrefixMethods
    {
        #region STATIC MEMBER VARIABLES

        private static readonly Dictionary<UnitPrefix, string> smkPrefixSymbolsMap;
        
        #endregion

        #region CONSTRUCTORS

        static UnitPrefixMethods()
        {
            smkPrefixSymbolsMap = new Dictionary<UnitPrefix, string>
                                      {
                                          { UnitPrefix.Yotta, "Y" },
                                          { UnitPrefix.Zetta, "Z" },
                                          { UnitPrefix.Exa, "E" },
                                          { UnitPrefix.Peta, "P" },
                                          { UnitPrefix.Tera, "T" },
                                          { UnitPrefix.Giga, "G" },
                                          { UnitPrefix.Mega, "M" },
                                          { UnitPrefix.Kilo, "k" },
                                          { UnitPrefix.Hecto, "h" },
                                          { UnitPrefix.Deka, "da" },
                                          { UnitPrefix.Deci, "d" },
                                          { UnitPrefix.Centi, "c" },
                                          { UnitPrefix.Milli, "m" },
                                          { UnitPrefix.Micro, "µ" },
                                          { UnitPrefix.Nano, "n" },
                                          { UnitPrefix.Pico, "p" },
                                          { UnitPrefix.Femto, "f" },
                                          { UnitPrefix.Atto, "a" },
                                          { UnitPrefix.Zepto, "z" },
                                          { UnitPrefix.Yocto, "y" }
                                      };
        }

        #endregion
        
        #region EXTENSION METHODS
        
        /// <summary>
        /// Gets printed symbol associated with unit prefix
        /// </summary>
        /// <param name="iPrefix">Requested unit prefix</param>
        /// <returns>Unit prefix symbol</returns>
        public static string GetSymbol(this UnitPrefix iPrefix)
        {
            return smkPrefixSymbolsMap[iPrefix];
        }
        
        /// <summary>
        /// Gets scaling factor associated with unit prefix
        /// </summary>
        /// <param name="iPrefix">Requested unit prefix</param>
        /// <returns>Unit prefix scaling factor</returns>
        public static AmountType GetFactor(this UnitPrefix iPrefix)
        {
#if DOUBLE
            return Math.Pow(10.0, (double)iPrefix);
#elif SINGLE
            return (float)Math.Pow(10.0, (double)iPrefix);
#elif DECIMAL
            return (decimal)Math.Pow(10.0, (double)iPrefix);
#endif
        }
        
        #endregion
    }
}
