// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Reflection;

namespace Cureos.Measurables
{
    public static class UnitReflection
    {
        public static U GetUnitInstance<U>() where U  : IUnit
        {
            FieldInfo f = typeof(U).GetField("Instance");
            if (f == null) throw new InvalidOperationException("Specified IUnit type does not contain static field Instance");
            return (U) f.GetValue(null);
        }
    }
}