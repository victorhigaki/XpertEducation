namespace XpertEducation.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
