using SampleLog.NET8.Models;

namespace SampleLog.NET8.Repositories
{
    public interface IHistoryRepository
    {
        void Save(History history);
        void Delete(History history);
        History Find(int id);
    }
}
