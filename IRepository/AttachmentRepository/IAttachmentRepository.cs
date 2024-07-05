namespace IndustrialContoroler.IRepository.AttachmentRepository
{
    public interface IAttachmentRepository<T> where T : class
    {
        T Add(T attachment);
        bool Save(T model);

    }
}
