// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures
{
    /// <summary>
    /// Identifiers to differentiate between unrelated dimensionless quantities
    /// Each quantity should be assigned a prime number larger than 1, to ensure that one dimensionless
    /// quantity does not accidentally switch into an unrelated dimensionless quantity through multiplication.
    /// </summary>
    /// <remarks>The solid angle quantity steradian can be regarded as the square of the plane angle quantity
    /// radian, and therefore its identifier is set to the square of the radian.</remarks>
    public enum DimensionlessDifferentiators
    {
        Radian = 2,
        Pi = 3,
        Steradian = 4,
        RelativeDensity = 5,
        RefractiveIndex = 7
    }
}