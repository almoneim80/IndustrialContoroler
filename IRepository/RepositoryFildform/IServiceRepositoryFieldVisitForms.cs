namespace IndustrialContoroler.IRepository.RepositoryFildform
{
    public interface IServiceRepositoryFieldVisitForms<T> where T : class
    {
        List<T> GetAll();

        T FindBy(int Id);

        T FindBy(string Name);

        bool Save(T model);

        bool RefernceToTechToEdit(T model);

        bool RefernceToAdmin(T model);
        bool RejectFieldVisit(T model);
        bool AcceptFieldVisit(T model);


        bool Delete(int Id);
    }
}
