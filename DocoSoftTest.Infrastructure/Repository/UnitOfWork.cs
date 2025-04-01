using DocoSoftTest.Application.Interfaces;

namespace DocoSoftTest.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository)
        {
            Users = userRepository;
        }

        public IUserRepository Users { get; set; }
    }
}
