using IndustrialContoroler.Models;

namespace IndustrialContoroler.RepositryReuest.generateRepositery
{
    public class generatRequestRepositry : IrepositryRequestcs<Request>
    {
        private readonly IndustrialContorolerDatabaseContext _context;
        public generatRequestRepositry(IndustrialContorolerDatabaseContext context)
        {
            this._context = context;
        }
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Request FindBy(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Request model)
        {
            try
            {
                var SqlCommand = _context.Add(model);
                var RowCount = _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
