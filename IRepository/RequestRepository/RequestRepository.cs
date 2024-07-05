using IndustrialContoroler.Models;
using Microsoft.AspNetCore.Mvc;
namespace IndustrialContoroler.IRepository.RequestRepository
{
    public class RequestRepository<T> : IRequestRepository<T> where T : class
    {
        private readonly IndustrialContorolerDatabaseContext _context;
        public RequestRepository(IndustrialContorolerDatabaseContext context)
        {
            _context = context;
        }



        public T Add(T request)
        {
            try
            {
                var SqlCommand = _context.Add(request);
                var RowCount = _context.SaveChanges();
                return request;
            }
            catch (Exception)
            {
                return default;
            }
        }

        //get all data
        public List<T> GetAll()
        {
            var res = _context.Set<T>().ToList();
            return res;
        }

       

      
    }
}
