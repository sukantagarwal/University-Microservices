namespace MicroPack.Types
{
    public interface IIdentifiable<out TKey>
    {
        TKey Id { get; }
    }
}