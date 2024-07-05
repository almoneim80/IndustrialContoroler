using IndustrialContoroler.Models;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.IRepository.RepositoryFildform.GenericRepositry
{
    public class ServiceLogFieldVisitFoems : IServicesRepositoryLogFieldVisitForms<LogFieldVisitForms>
    {
        private readonly IndustrialContorolerDatabaseContext _context;

        public ServiceLogFieldVisitFoems(IndustrialContorolerDatabaseContext context)
        {
            _context = context;
        }

        public bool AcceptFieldVisit(int Id, string UserId)
        {
            try
            {
                var logfiledVist = new LogFieldVisitForms
                {


                    UserId = UserId,
                    Action = Helper.AcceptFieldVisit,
                    Date = DateTime.Now,
                    FaId = Id

                };
                _context.LogFieldVisitForms.Add(logfiledVist);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int Id, string UserId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLog(int Id)
        {
            try
            {
                var result = FindBy(Id);
                if (!result.Equals(null))
                {
                    result.IsDeleted = true;
                    _context.LogFieldVisitForms.Update(result);
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

        public LogFieldVisitForms FindBy(int Id)
        {
            try
            {
                
                return _context.LogFieldVisitForms.Include(x => x.facility).FirstOrDefault(x => x.LogId.Equals(Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<LogFieldVisitForms> GetAll()
        {
            return _context.LogFieldVisitForms.Include(x => x.facility).OrderByDescending(x => x.Date).Where(x => x.IsDeleted == false).ToList();

        }

      

        public bool RefernceToAdmin(int Id, string UserId)
        {
            try
            {
                var logfiledVist = new LogFieldVisitForms
                {


                    UserId = UserId,
                    Action = Helper.referenceFromTechToAdmin,
                    Date = DateTime.Now,
                    FaId = Id

                };
                _context.LogFieldVisitForms.Add(logfiledVist);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RefernceTotechToEdit(int Id, string UserId)
        {
            try
            {
                var logfiledVist = new LogFieldVisitForms
                {


                    UserId = UserId,
                    Action = Helper.referenceToTechToEdit,
                    Date = DateTime.Now,
                    FaId = Id

                };
                _context.LogFieldVisitForms.Add(logfiledVist);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RejectfieldVisit(int Id, string UserId)
        {
            try
            {
                var logfiledVist = new LogFieldVisitForms
                {


                    UserId = UserId,
                    Action = Helper.RejectFieldVisit,
                    Date = DateTime.Now,
                    FaId = Id

                };
                _context.LogFieldVisitForms.Add(logfiledVist);
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
            throw new NotImplementedException();
        }

        public bool Update(int Id, string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
