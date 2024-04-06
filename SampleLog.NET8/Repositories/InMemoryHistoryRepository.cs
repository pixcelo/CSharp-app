using SampleLog.NET8.Models;

namespace SampleLog.NET8.Repositories
{
    public class InMemoryHistoryRepository : IHistoryRepository
    {
        public Dictionary<int, History> Store { get; } = new Dictionary<int, History>();

        public History Find(int id)
        {
            var target = Store.Values
                .FirstOrDefault(history => id.Equals(history.ID));

            if (target != null)
            {                
                return Clone(target);
            }
            else
            {
                return null;
            }
        }

        public void Save(History history)
        {
            history.ID = Store.Count + 1;
            Store[history.ID] = Clone(history);
        }

        public void Delete(History history)
        {
            Store[history.ID] = null;
        }
        
        private History Clone(History history)
        {
            var model = new History()
            { 
                ID = history.ID,
                Operation = history.Operation,
                Result = history.Result
            };
            
            return model;
        }
    }
}
