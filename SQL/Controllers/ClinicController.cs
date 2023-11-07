using EFCore1.DTOs;
using EFCore1.Models;
using EFCore1.Repository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQL.Models;

namespace EFCore1.Controllers
{
    [Route("api/showcase")]
    [ApiController]
    public class EfTestController : ControllerBase
    {
        private readonly EFCoreContext _dbContext;

        public EfTestController(EFCoreContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet("connection-test")]
        public async Task<ActionResult> TestConnection()
        {
            if (_dbContext.Database.CanConnect())
            {
                return Ok(_dbContext.Database.ProviderName);
            }

            return BadRequest();
        }

        [HttpGet("change-tracker-test")]
        public async Task<ActionResult> TestChangeTracking()
        {
          
            _ = _dbContext.ChangeTracker;

            _dbContext.Attach(new Owner { Id = 1 });

            
            var users = await _dbContext.Owners.ToListAsync();

         
            users.First().Name = "Change tracked";

           
            _dbContext.Entry(users.Last()).State = EntityState.Detached;

            _dbContext.ChangeTracker.Clear();

            var deatachedUsers = await _dbContext.Owners.AsNoTracking().ToListAsync();

            return Ok();
        }

        [HttpGet("owners")]
        public async Task<ActionResult> GetOwners()
        {
            var repo = new OwnersRepository(_dbContext);
            var users = await repo.Get();

            return Ok(users);
        }

        [HttpPost("owners")]
        public async Task<ActionResult> CreateOwner(OwnerDto owner)
        {
            var repo = new OwnersRepository(_dbContext);
          

            return Ok();
        }

        [HttpPut("owners")]
        public async Task<ActionResult> UpdateOwner(Owner owner)
        {
            var repo = new OwnersRepository(_dbContext);
            await repo.Update(owner);

            return Ok();
        }

        [HttpDelete("owners/{id}")]
        public async Task<ActionResult> DeleteOwner([FromRoute] int id)
        {
            var repo = new OwnersRepository(_dbContext);
            await repo.Delete(id);

            return Ok();
        }

        [HttpPost("owners/{id}/owners-settings")]
        public async Task<ActionResult> CreateOwnerSetting(
            [FromRoute] int id,
            OwnerSettings settings)
        {
            var repo = new OwnersRepository(_dbContext);
            await repo.InsertOneToOne(id, settings);

            return Ok();
        }

        [HttpPost("owners/{id}/Clinic")]
        public async Task<ActionResult> CreateClinics(
        [FromRoute] int id,
            ICollection<Clinic> clinics)
        {
            var repo = new OwnersRepository(_dbContext);
            await repo.InsertManyToMany(id, clinics);

            return Ok();
        }
    }
}
