namespace AppForLearn
{
    public interface IDatabaseDeleteQuerier
    {
        Task<bool> DeleteAll();
        Task<bool> DeleteRangeToId(int startId,  int endId);
        Task<bool> DeleteToId(int id);
        Task<bool> DeleteArrayToId(int[] ids);
    }
}
