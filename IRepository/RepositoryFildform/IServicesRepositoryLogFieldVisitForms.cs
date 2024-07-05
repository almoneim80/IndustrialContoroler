namespace IndustrialContoroler.IRepository.RepositoryFildform
{
    public interface IServicesRepositoryLogFieldVisitForms<T> where T : class

    {
        List<T> GetAll();

        T FindBy(int Id);

        bool Save(int Id, string UserId);

        bool Update(int Id, string UserId);

        bool Delete(int Id, string UserId);

        bool RefernceToAdmin(int Id, string UserId);
        bool RefernceTotechToEdit(int Id, string UserId);
        bool RejectfieldVisit(int Id, string UserId);
        bool AcceptFieldVisit(int Id, string UserId);

        bool DeleteLog(int Id);
    }
}
