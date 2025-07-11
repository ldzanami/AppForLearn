namespace AppForLearn
{
    public interface IDatabasePostQuerier<T>
    {
        Task AddItem(T item);
        Task AddItems(T[] items);
    }
}
