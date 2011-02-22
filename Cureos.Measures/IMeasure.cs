// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
	public interface IMeasure
	{
        AmountType Amount
        {
            get;
        }

        Unit Unit
        {
            get;
        }

        Quantity Quantity
        {
            get;
        }
		
		AmountType GetAmount(Unit iUnit);
		
		IMeasure ConvertTo(Unit iUnit);
	}
}

