namespace IndustrialContoroler.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        //from temp table
        List<T> GetAll();

        //get all facility data with Is_deleted condation
        List<T> GetAllFaData(Func<T, bool> predicate);

        void DeleteTmp(int Id);
    }
}
