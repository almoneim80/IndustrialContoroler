namespace IndustrialContoroler.Models.Repositories
{
    public interface IServiceREpositoryRequest<T> where T : class
    {
        List<T> GetAll();

        T FindBy(int Id);

        T FindBy(string Name);

        bool Save(T model);

        bool RefernceToTech(T model);
        
        bool RefernceToAdmin(T model);



        bool Delete(int Id);
    }
}
