namespace AppForLearn
{
    public interface IDatabasePatchQuerier<T, M>
    {
        Task<T> FindItemsFromDB(int[] ids);
        Task SaveDBChanges();
        Task<M> FindItemFromDB(int id);
        Task ReplaceItemInDB(M item);
    }
}
