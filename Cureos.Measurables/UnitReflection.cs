// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Reflection;

namespace Cureos.Measurables
{
    /// <summary>
    /// Support methods for obtaining type information of unit classes
    /// </summary>
    public static class UnitReflection
    {
        /// <summary>
        /// Gets a single instance of the specified unit type
        /// </summary>
        /// <typeparam name="U">Unit type for which a class instance is requested</typeparam>
        /// <returns>One instance of the specified unit type</returns>
        /// <exception cref="InvalidOperationException">is thrown if the specified unit class does not contain a static field denoted Instance</exception>
        public static U GetUnitInstance<U>() where U  : IUnit
        {
            FieldInfo f = typeof(U).GetField("Instance");
            if (f == null) throw new InvalidOperationException("Specified IUnit type does not contain static field Instance");
            return (U) f.GetValue(null);
        }
    }
}