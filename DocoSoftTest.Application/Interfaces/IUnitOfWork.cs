namespace DocoSoftTest.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
