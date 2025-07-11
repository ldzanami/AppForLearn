namespace AppForLearn
{
    public interface IDatabaseDeleteQuerier
    {
        Task DeleteAll();
        Task DeleteRangeToId(int startId,  int endId);
        Task DeleteToId(int id);
        Task DeleteArrayToId(int[] ids);
    }
}
