using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }

        public async ValueTask<Applicant> InsertApplicantAsync(Applicant applicant)
        {
            using var broker = new StorageBroker(this.configuration);

            var applicantEntityEntry = await broker.Applicants.AddAsync(applicant);
            await broker.SaveChangesAsync();

            return applicantEntityEntry.Entity;
        }
    }
}