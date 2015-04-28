// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    using System;

    /// <summary>
    /// Implementation of the specific quantity
    /// </summary>
    public struct LinearAcceleratorMeterset : IQuantity<LinearAcceleratorMeterset>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = QuantityDimension.LinearAcceleratorMeterset;

        public static readonly ConstantConverterUnit<LinearAcceleratorMeterset> MonitorUnit = new ConstantConverterUnit<LinearAcceleratorMeterset>("MU");

        #endregion

        #region Implementation of IQuantity<LinearAcceleratorMeterset>

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
        public IUnit<LinearAcceleratorMeterset> StandardUnit
        {
            get { return MonitorUnit; }
        }

        public bool Equals(IQuantity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            return other is LinearAcceleratorMeterset;
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
