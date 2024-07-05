using IndustrialContoroler.Models;
using Microsoft.AspNetCore.Mvc;
namespace IndustrialContoroler.IRepository.AttachmentRepository
{
    public class AttachmentRepository<T> : IAttachmentRepository<T> where T : class
    {
        private readonly IndustrialContorolerDatabaseContext _context;
        public AttachmentRepository(IndustrialContorolerDatabaseContext context)
        {
            _context = context;
        }

       

        public T Add(T attachment)
        {
            try
            {
                var SqlCommand = _context.Add(attachment);
                var RowCount = _context.SaveChanges();
                return attachment;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public bool Save(T model)
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
