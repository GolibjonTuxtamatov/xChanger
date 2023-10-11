using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }

        public async Task<IQueryable<Applicant>> InsertApplicantsAsync(IEnumerable<Applicant> applicants)
        {
            using var broker = new StorageBroker(this.configuration);

            await broker.Applicants.AddRangeAsync(applicants);
            await broker.SaveChangesAsync();

            return broker.Applicants.AsQueryable();
        }
    }
}