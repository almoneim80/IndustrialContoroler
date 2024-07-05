using IndustrialContoroler.Models;

namespace IndustrialContoroler.IRepository.RepositoryFildform.GenericRepositry
{

    public class ServicesFieldVisitForms : IServiceRepositoryFieldVisitForms<Facility>
    {
        private readonly IndustrialContorolerDatabaseContext _context;

        public ServicesFieldVisitForms(IndustrialContorolerDatabaseContext context)
        {
            _context = context;
        }

        public bool AcceptFieldVisit(Facility model)
        {
            try
            {
                model.FaReference = 3;
                model.IsRead = false;
                _context.Facilities.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Facility FindBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Facility FindBy(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Facility> GetAll()
        {
            try
            {
                return _context.Facilities.OrderBy(x => x.FaAddress).Where(x => x.IsDeleted.Equals(false)).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool RefernceToAdmin(Facility model)
        {
            try
            {
                model.FaReference = 2;
                model.IsRead = false;
                _context.Facilities.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

       

        public bool RefernceToTechToEdit(Facility model)
        {
            try
            {
                model.FaReference = 5;
                model.IsRead = false;
                _context.Facilities.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool RejectFieldVisit(Facility model)
        {
            try
            {
                model.FaReference = 4;
                model.IsRead = false;
                _context.Facilities.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Save(Facility model)
        {
            throw new NotImplementedException();
        }
    }
}
