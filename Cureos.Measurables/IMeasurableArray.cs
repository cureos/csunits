namespace Cureos.Measurables
{
    public interface IMeasurableArray<out T>
    {
        #region PROPERTIES

        T[] Amounts { get; }

        #endregion
    }
}