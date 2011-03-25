using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;

namespace SLMultiBinding
{
  /// <summary>
  /// Implements MultiBinding by creating a BindingSlave instance for each of the Bindings.
  /// PropertyChanged events for the BindingSlae.Value property are handled, and the IMultiValueConveter
  /// is used to compute the converted value.
  /// </summary>
  [ContentProperty("Bindings")]
  public class MultiBinding : Panel, INotifyPropertyChanged
  {
    /// <summary>
    /// Indicates whether the converted value property is currently being updated
    /// as a result of one of the BindingSlave.Value properties changing
    /// </summary>
    private bool _updatingConvertedValue;

    #region ConvertedValue dependency property

    public static readonly DependencyProperty ConvertedValueProperty =
        DependencyProperty.Register("ConvertedValue", typeof(object), typeof(MultiBinding),
            new PropertyMetadata(null, OnConvertedValuePropertyChanged));

    /// <summary>
    /// This dependency property is set to the resulting output of the
    /// associated Converter.
    /// </summary>
    public object ConvertedValue
    {
      get { return GetValue(ConvertedValueProperty); }
      set { SetValue(ConvertedValueProperty, value); }
    }

    private static void OnConvertedValuePropertyChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
    {
      MultiBinding relay = depObj as MultiBinding;
      Debug.Assert(relay != null);
      relay.OnConvertedValuePropertyChanged();
    }

    /// <summary>
    /// Handles propety changes for the ConvertedValue property
    /// </summary>
    private void OnConvertedValuePropertyChanged()
    {
      OnPropertyChanged("ConvertedValue");

      // if the value is being updated, but not due to one of the multibindings
      // then the target property has changed.
      if (!_updatingConvertedValue)
      {
        // convert back
        object[] convertedValues = Converter.ConvertBack(ConvertedValue, null,
          ConverterParameter, CultureInfo.InvariantCulture);

        // update all the binding slaves
        if (Children.Count == convertedValues.Length)
        {
          for (int index = 0; index < convertedValues.Length; index++)
          {
            ((BindingSlave)Children[index]).Value = convertedValues[index];
          }
        }
      }
    }

    #endregion

    #region CLR properties

    /// <summary>
    /// The BindingMode
    /// </summary>
    public BindingMode Mode { get; set; }

    /// <summary>
    /// The target property on the element which this MultiBinding is assocaited with.
    /// </summary>
    public string TargetProperty { get; set; }

    /// <summary>
    /// The Converter which is invoked to compute the result of the multiple bindings
    /// </summary>
    public IMultiValueConverter Converter { get; set; }

    /// <summary>
    /// The configuration parameter supplied to the converter
    /// </summary>
    public object ConverterParameter { get; set; }

    /// <summary>
    /// The bindings, the result of which are supplied to the converter.
    /// </summary>
    public BindingCollection Bindings { get; set; }

    #endregion

    public MultiBinding()
    {
      Bindings = new BindingCollection();
    }

    /// <summary>
    /// Invoked when any of the BindingSlave's Value property changes.
    /// </summary>
    private void SlavePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      UpdateConvertedValue();
    }

    /// <summary>
    /// Uses the Converter to update the ConvertedValue in order to reflect
    /// the current state of the bindings.
    /// </summary>
    private void UpdateConvertedValue()
    {
      List<object> values = new List<object>();
      foreach (BindingSlave slave in Children)
      {
        values.Add(slave.Value);
      }

      _updatingConvertedValue = true;
      ConvertedValue = Converter.Convert(values.ToArray(), typeof(object), ConverterParameter, CultureInfo.CurrentCulture);
      _updatingConvertedValue = false;
    }

    /// <summary>
    /// Creates a BindingSlave for each Binding and binds the Value
    /// accordingly.
    /// </summary>
    internal void Initialise(FrameworkElement targetElement)
    {
      Children.Clear();
      foreach (Binding binding in Bindings)
      {
        BindingSlave slave;

        // create a binding slave instance 
        if (!string.IsNullOrEmpty(binding.ElementName))
        {
          // create an element name binding slave, this slave will resolve the 
          // binding source reference and construct a suitable binding.
          slave = new ElementNameBindingSlave(targetElement, binding);
        }
        else
        {
          slave = new BindingSlave();
          slave.SetBinding(BindingSlave.ValueProperty, binding);
        }
        slave.PropertyChanged += SlavePropertyChanged;
        Children.Add(slave);
      }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }

    #endregion
  }

  /// <summary>
  /// A simple element with a single Value property, used as a 'slave'
  /// for a Binding.
  /// </summary>
  public class BindingSlave : FrameworkElement, INotifyPropertyChanged
  {
    #region Value

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(object), typeof(BindingSlave),
            new PropertyMetadata(null, OnValueChanged));

    public object Value
    {
      get { return GetValue(ValueProperty); }
      set { SetValue(ValueProperty, value); }
    }

    private static void OnValueChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
    {
      BindingSlave slave = depObj as BindingSlave;
      Debug.Assert(slave != null);
      slave.OnPropertyChanged("Value");
    }

    #endregion

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }

    #endregion

  }

  /// <summary>
  /// A binding slave that performs 'ElementName' binding.
  /// </summary>
  public class ElementNameBindingSlave : BindingSlave
  {
    private FrameworkElement _multiBindingTarget;

    /// <summary>
    /// The source element named in the ElementName binding
    /// </summary>
    private FrameworkElement _elementNameSource;

    private Binding _binding;

    public ElementNameBindingSlave(FrameworkElement target, Binding binding)
    {
      _multiBindingTarget = target;
      _binding = binding;

      // try to locate the named element
      ResolveElementNameBinding();

      _multiBindingTarget.LayoutUpdated += MultiBindingTarget_LayoutUpdated;
    }

    /// <summary>
    /// Try to locate the named element. If the element can be located, create the required
    /// binding.
    /// </summary>
    private void ResolveElementNameBinding()
    {
      _elementNameSource = _multiBindingTarget.FindName(_binding.ElementName) as FrameworkElement;
      if (_elementNameSource != null)
      {
        SetBinding(BindingSlave.ValueProperty, new Binding()
        {
          Source = _elementNameSource,
          Path = _binding.Path,
          Converter = _binding.Converter,
          ConverterParameter = _binding.ConverterParameter
        });
      }
    }

    private void MultiBindingTarget_LayoutUpdated(object sender, EventArgs e)
    {
      // try to locate the named element 
      ResolveElementNameBinding();
    }
  }

  internal delegate void BindingCollectionChangedCallback();

  public class BindingCollection : Collection<BindingBase>
  {
    // Fields
    private readonly BindingCollectionChangedCallback _collectionChangedCallback;


    protected override void ClearItems()
    {
      base.ClearItems();
      OnBindingCollectionChanged();
    }

    protected override void InsertItem(int index, BindingBase item)
    {
      if (item == null)
      {
        throw new ArgumentNullException("item");
      }
      ValidateItem(item);
      base.InsertItem(index, item);
      OnBindingCollectionChanged();
    }

    private void OnBindingCollectionChanged()
    {
      if (_collectionChangedCallback != null)
      {
        _collectionChangedCallback();
      }
    }

    protected override void RemoveItem(int index)
    {
      base.RemoveItem(index);
      OnBindingCollectionChanged();
    }

    protected override void SetItem(int index, BindingBase item)
    {
      if (item == null)
      {
        throw new ArgumentNullException("item");
      }
      ValidateItem(item);
      base.SetItem(index, item);
      OnBindingCollectionChanged();
    }

    private static void ValidateItem(BindingBase binding)
    {
      if (!(binding is Binding))
      {
        throw new NotSupportedException("BindingCollectionContainsNonBinding");
      }
    }
  }
}
