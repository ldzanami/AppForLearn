
namespace AppForLearn
{
    public interface IDatabaseGetQuerier<T>
    {
        T SelectAllFromDataBase();
        T SelectArrayToIdFromDatabase(int[] ids);
        T SelectAllSortedToCostDescFromDatabase();
        T SelectAllSortedToCostFromDatabase();
        T SelectAllSortedToIdDescFromDatabase();
        T SelectAllSortedToIdFromDatabase();
        T SelectAllSortedToNameDescFromDatabase();
        T SelectAllSortedToNameFromDatabase();
        T SelectCostFromDatabase(float cost);
        T SelectIdFromDatabase(int id);
        T SelectNameFromDatabase(string name);
        T SelectRangeToCostDescFromDatabase(float startCost, float endCost);
        T SelectRangeToCostFromDatabase(float startCost, float endCost);
        T SelectRangeToIdDescFromDatabase(int startId, int endId);
        T SelectRangeToIdFromDatabase(int startId, int endId);
    }
}