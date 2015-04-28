// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    using System;

    /// <summary>
    /// Implementation of the linear accelerator absorbed dose rate quantity
    /// </summary>
    public struct LinearAcceleratorAbsorbedDoseRate : IQuantity<LinearAcceleratorAbsorbedDoseRate>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ 2) * (QuantityDimension.Time ^ 2) *
            (QuantityDimension.LinearAcceleratorMeterset ^ -1);

        public static readonly Unit<LinearAcceleratorAbsorbedDoseRate> GrayPerMonitorUnit = new Unit<LinearAcceleratorAbsorbedDoseRate>("Gy MU\u207b¹");
        public static readonly Unit<LinearAcceleratorAbsorbedDoseRate> CentiGrayPerMonitorUnit = new Unit<LinearAcceleratorAbsorbedDoseRate>(UnitPrefix.Centi);

        #endregion

        #region Implementation of IQuantity<LinearAcceleratorAbsorbedDoseRate>

        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return _dimension; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        IUnit IQuantity.StandardUnit
        {
            get { return StandardUnit; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        public IUnit<LinearAcceleratorAbsorbedDoseRate> StandardUnit
        {
            get { return GrayPerMonitorUnit; }
        }

        public bool Equals(IQuantity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            return other is LinearAcceleratorAbsorbedDoseRate;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return GetType().Name;
        }

        #endregion
    }
}
