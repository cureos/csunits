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

namespace MonodroidUnitConverter
{
    using System.Globalization;
    using System.Linq;

    using Android.App;
    using Android.OS;
    using Android.Text;
    using Android.Widget;

    using Cureos.Measures;
    using Cureos.Measures.Collections;

    using Activity = Android.App.Activity;

    [Activity (Label = "Cureos Unit Converter", MainLauncher = true)]
    public class UnitConverterActivity : Activity
    {
        #region PRIVATE FIELDS

        private QuantityAdapter[] mQuantities;

        private Spinner mQuantitySpinner;
        private Spinner mFromUnitSpinner;
        private Spinner mToUnitSpinner;

        private EditText mFromAmountEditText;
        private EditText mToAmountEditText;

        #endregion

        #region OVERRIDDEN METHODS
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            InitializeFields();
        }

        #endregion

        #region PRIVATE METHODS

        private void InitializeFields()
        {
            mQuantities = QuantityCollection.Quantities.OrderBy(qa => qa.ToString()).ToArray();

            var adapter = new ArrayAdapter<QuantityAdapter>(this, Android.Resource.Layout.SimpleSpinnerItem, mQuantities);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            mQuantitySpinner = FindViewById<Spinner>(Resource.Id.QuantitySpinner);
            mQuantitySpinner.Adapter = adapter;
            mQuantitySpinner.ItemSelected += QuantitySpinner_ItemSelected;

            mFromAmountEditText = FindViewById<EditText>(Resource.Id.FromAmountEditText);
            mFromAmountEditText.TextChanged += FromAmountEditText_TextChanged;

            mFromUnitSpinner = FindViewById<Spinner>(Resource.Id.FromUnitSpinner);
            mFromUnitSpinner.ItemSelected += UnitSpinner_ItemSelected;

            mToAmountEditText = FindViewById<EditText>(Resource.Id.ToAmountEditText);

            mToUnitSpinner = FindViewById<Spinner>(Resource.Id.ToUnitSpinner);
            mToUnitSpinner.ItemSelected += UnitSpinner_ItemSelected;
        }

        private void QuantitySpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position > -1)
            {
                var selQty = mQuantities[e.Position];

                var adapter = new ArrayAdapter<IUnit>(this, Android.Resource.Layout.SimpleSpinnerItem,
                                                      selQty.Units.ToArray());
                adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

                mFromUnitSpinner.Adapter = adapter;
                mToUnitSpinner.Adapter = adapter;
            }
            else
            {
                mFromUnitSpinner.Adapter = null;
                mToUnitSpinner.Adapter = null;
            }
        }

        private void FromAmountEditText_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateToAmount();
        }

        private void UnitSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateToAmount();
        }

        private void UpdateToAmount()
        {
            var fromUnitPos = mFromUnitSpinner.SelectedItemPosition;
            var toUnitPos = mToUnitSpinner.SelectedItemPosition;

            double fromAmount;
            if (fromUnitPos > -1 && toUnitPos > -1 && 
                double.TryParse(mFromAmountEditText.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out fromAmount))
            {
                var quantity = mQuantities[mQuantitySpinner.SelectedItemPosition];
                var fromUnit = quantity.Units.ElementAt(fromUnitPos);
                var toUnit = quantity.Units.ElementAt(toUnitPos);

                mToAmountEditText.Text =
                    toUnit.ConvertStandardAmountToUnit(fromUnit.ConvertAmountToStandardUnit(fromAmount)).ToString(
                        CultureInfo.CurrentCulture);
            }
            else
            {
                mToAmountEditText.Text = string.Empty;
            }

        }

        #endregion
    }
}


