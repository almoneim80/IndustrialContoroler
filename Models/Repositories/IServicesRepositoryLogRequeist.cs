namespace IndustrialContoroler.Models.Repositories
{
    public interface IServicesRepositoryLogRequeist<T> where T : class
    {
        List<T> GetAll();

        T FindBy(int Id);

        bool Save(int Id, string UserId);

        bool Update(int Id, string UserId);

        bool Delete(int Id, string UserId);

        bool ReferenceReToAdmin(int Id, string UserId);
        bool RefernceReTotech(int Id, string UserId);
        bool DeleteLog(int Id);

    }
}
