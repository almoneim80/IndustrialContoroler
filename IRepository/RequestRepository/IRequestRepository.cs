namespace IndustrialContoroler.IRepository.RequestRepository
{
    public interface IRequestRepository<T> where T : class
    {
        T Add(T request);
        List<T> GetAll();

        
    }
}