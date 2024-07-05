
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models.Repositories.GenericRepositry
{
    public class ServiceGenericLogRequest : IServicesRepositoryLogRequeist<RequestTraffic>
    {
        private readonly IndustrialContorolerDatabaseContext _context;

        public ServiceGenericLogRequest(IndustrialContorolerDatabaseContext context)
        {

            _context = context;
        }
        public bool Delete(int Id, string UserId)
        {
            try
            {
                var RequestTraffic = new RequestTraffic
                {
                   
                   UserId = UserId,
                   Action =Helper.Delete,
                   Date = DateTime.Now,
                   ReId = Id,
                   
                };
                _context.RequestTraffics.Add(RequestTraffic);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        

        public bool DeleteLog(int Id)
        {
            try
            {
                var result = FindBy(Id);
                if (!result.Equals(null))
                {
                    result.IsDeleted = true;
                    _context.RequestTraffics.Update(result);
                    _context.SaveChanges();
                    return true; 
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public RequestTraffic FindBy(int Id)
        {
            try
            {
                return _context.RequestTraffics.Include(x =>x.Re).FirstOrDefault(x => x.RtId.Equals(Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<RequestTraffic> GetAll()
        {
            return _context.RequestTraffics.Include(x => x.Re).OrderByDescending(x => x.Date).Where(x => x.IsDeleted ==false).ToList();
        }

        public bool ReferenceReToAdmin(int Id, string UserId)
        {
            try
            {
                var RequestTraffic = new RequestTraffic
                {


                    UserId = UserId,
                    Action = Helper.referenceReToAdmin,
                    Date = DateTime.Now,
                    ReId = Id

                };
                _context.RequestTraffics.Add(RequestTraffic);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       

        public bool RefernceReTotech(int Id, string UserId)
        {
            try
            {
                var RequestTraffic = new RequestTraffic
                {


                    UserId = UserId,
                    Action = Helper.RefernceReTotech,
                    Date = DateTime.Now,
                    ReId = Id

                };
                _context.RequestTraffics.Add(RequestTraffic);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       

      

        public bool Save(int Id, string UserId)
        {
            try
            {
                var RequestTraffic = new RequestTraffic
                {
                  
                    
                    UserId= UserId,
                    Action = Helper.Save,
                    Date = DateTime.Now,
                    ReId=Id

                };
                _context.RequestTraffics.Add(RequestTraffic);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        

        public bool Update(int Id, string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
