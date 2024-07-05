namespace IndustrialContoroler.Models.Repositories.GenericRepositry
{
    public class ServicesRequest : IServiceREpositoryRequest<Request>
    {
        private readonly IndustrialContorolerDatabaseContext _context;

        public ServicesRequest(IndustrialContorolerDatabaseContext context)
        {
            _context = context;
        }
        public bool Delete(int Id)
        {
            try
            {
                var result = FindBy(Id);
                result.IsDeleted = true;
                _context.Requests.Update(result);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Request FindBy(int Id)
        {
            try
            {
                
                return _context.Requests.FirstOrDefault(x=>x.ReId == Id && x.IsDeleted.Equals(false));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Request FindBy(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetAll()
        {
            try
            {
                return _context.Requests.OrderBy(x => x.ReType).Where(x => x.IsDeleted.Equals(false)).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool RefernceToAdmin(Request model)
        {
            try
            {
                model.ReRequestState = 1;
                model.ReDate = DateTime.Now;
                model.IsRead = false;
                _context.Requests.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RefernceToTech(Request model)
        {

            try {      
                model.ReRequestState = 2;
                model.IsRead = false;
                    _context.Requests.Update(model);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        

        public bool Save(Request model)
        {
            try
            {
                var result = FindBy(model.ReId);
                if (result == null)
                {
                    
                    model.IsDeleted = false;
                    _context.Requests.Add(model);
                }
                else
                {
                    
                    result.ReApplicant = model.ReApplicant;
                    result.ReDate = model.ReDate;
                    result.ReSuemNo=model.ReSuemNo;
                    result.ReFormNo=model.ReFormNo;
                    result.ReType=model.ReType;
                    result.IsDeleted =false;
                   _context.Requests.Update(result);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
