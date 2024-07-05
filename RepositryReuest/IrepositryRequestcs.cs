namespace IndustrialContoroler.RepositryReuest
{
    public interface IrepositryRequestcs<T> where T : class
    {

        List<T> GetAll();

        //T FindBy(int Id);
        T FindBy(int Id);

        //T FindBy(string Name);

        bool Save(T model);

        //bool Delete(int Id);
        bool Delete(int Id);
    }
}
