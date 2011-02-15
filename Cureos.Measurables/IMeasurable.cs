namespace Cureos.Measurables
{
    public interface IMeasurable<T, out U> where U : IUnit<T>
    {
        T Amount { get; }

        U Unit { get; }

        IMeasurable<T, V> ConvertTo<V>() where V : IUnit<T>;
    }
}