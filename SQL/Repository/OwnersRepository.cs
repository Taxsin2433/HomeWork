using EFCore1.Context;
using EFCore1.Models;

using Microsoft.EntityFrameworkCore;
using SQL.Models;
using System.Reflection.Metadata;

namespace EFCore1.Repository
{
    public class OwnersRepository
    {
        private readonly EFCoreContext _dbContext;

        public OwnersRepository(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(Owner owner)
        {
    
            await _dbContext.Owners.AddAsync(owner);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Owner owner)
        {

            _dbContext.Update(owner);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var tacker = new Owner { Id = id };
            _dbContext.Owners.Attach(tacker);
            _dbContext.Remove(tacker);
            await _dbContext.SaveChangesAsync();
        }

        public async Task InsertOneToOne(int ownerID, OwnerSettings settings)
        {
         
            var existingUser = await _dbContext.Owners.FindAsync(ownerID);
            if (existingUser == null) return;

         
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task InsertManyToMany(int ownerID, ICollection<Clinic> clinics)
        {
     
            var existingUser = await _dbContext.Owners.FindAsync(ownerID);
            if (existingUser == null) return;

            existingUser.ClinicSubscriptions = clinics;
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Owner>> Get()
        {
            return (await _dbContext.Owners
                 .AsNoTracking()
                 .Select(x => new
                 {
                     Owner = x,
                     Clinic = x.ClinicSubscriptions
                 })
                 .ToListAsync())
                 .Select(x =>
                 {
                     var owner = x.Owner;
                     owner.ClinicSubscriptions = x.Clinic;

                     return owner;
                 });
        }

        public async Task TransactionSample()
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
            
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
        }
    }
}
//2
    