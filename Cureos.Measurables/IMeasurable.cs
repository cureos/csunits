namespace Cureos.Measurables
{
    public interface IMeasurable<T, out U> where U : IUnit<T>
    {
        T Amount { get; }

        U Unit { get; }

        IMeasurable<T, V> ConvertTo<V>(V iToUnit) where V : IUnit<T>;
    }
}