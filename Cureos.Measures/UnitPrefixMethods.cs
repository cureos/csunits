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

namespace Cureos.Measures
{
	public static class UnitPrefixMethods
	{
    	#region STATIC MEMBER VARIABLES

    	private static readonly Dictionary<UnitPrefix, string> smkPrefixSymbolsMap;
    	
    	#endregion

    	#region CONSTRUCTORS
    	
    	static UnitPrefixMethods()
    	{
    		smkPrefixSymbolsMap = new Dictionary<UnitPrefix, string>()
    		{
    			{UnitPrefix.Yotta, "Y"},
    			{UnitPrefix.Zetta, "Z"},
    			{UnitPrefix.Exa, "E"},
    			{UnitPrefix.Peta, "P"},
    			{UnitPrefix.Tera, "T"},
    			{UnitPrefix.Giga, "G"},
    			{UnitPrefix.Mega, "M"},
    			{UnitPrefix.Kilo, "k"},
    			{UnitPrefix.Hecto, "h"},
    			{UnitPrefix.Deka, "da"},
    			{UnitPrefix.Deci, "d"},
    			{UnitPrefix.Centi, "c"},
    			{UnitPrefix.Milli, "m"},
    			{UnitPrefix.Micro, "µ"},
    			{UnitPrefix.Nano, "n"},
    			{UnitPrefix.Pico, "p"},
    			{UnitPrefix.Femto, "f"},
    			{UnitPrefix.Atto, "a"},
    			{UnitPrefix.Zepto, "z"},
    			{UnitPrefix.Yocto, "y"}
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
