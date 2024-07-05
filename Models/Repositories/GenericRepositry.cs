using Microsoft.AspNetCore.Mvc;
namespace IndustrialContoroler.Models.Repositories
{
    public class GenericRepositry<T> : IRepository<T> where T : class
    {
        private readonly IndustrialContorolerDatabaseContext _context;
        public GenericRepositry(IndustrialContorolerDatabaseContext context)
        {
            this._context = context;
        }

        //Add data
        public T Add(T entity)
        {
            try
            {
                var SqlCommand = _context.Add(entity);
                var RowCount = _context.SaveChanges();
                return SqlCommand.Entity as T;
            }
            catch (Exception)
            {
                return default(T);
            }
        }


        //get all data
        public List<T> GetAll()
        {
            var res = _context.Set<T>().ToList();
            return res;
        }


        //delete from temp table without Is_Delete 
        public void DeleteTmp(int Id)
        {
            var BuId = _context.Temporaries.Find(Id);
            if (BuId != null)
            {
                var RowCount = _context.Temporaries.Remove(BuId);
                var saveCh = _context.SaveChanges();
            }

        }


        public List<T> GetAllFaData(Func<T, bool> predicate)
        {
            var allFaData = _context.Set<T>().Where(predicate).ToList();
            return allFaData;
        }


    }
}
