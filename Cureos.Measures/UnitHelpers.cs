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
    using System.Linq;
    using System.Reflection;

    public static class UnitHelpers
    {
        internal static string CreateUnitDisplayName(IUnit unit)
        {
            var fieldInfo =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(type => type.IsInstanceOfType(unit.Quantity) && !type.IsInterface)
                    .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static))
                    .SingleOrDefault(info => ReferenceEquals(info.GetValue(null), unit));

            return fieldInfo == null
                       ? unit.Symbol
                       : String.Format(
                           "{0} | {1}",
                           fieldInfo.Name,
                           String.IsNullOrWhiteSpace(unit.Symbol) ? "<none>" : unit.Symbol);
        }
    }
}