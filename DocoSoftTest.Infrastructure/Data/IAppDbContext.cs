using DocoSoftTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocoSoftTest.Infrastructure.Data
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
    }
}
