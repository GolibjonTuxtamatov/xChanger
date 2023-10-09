using Microsoft.EntityFrameworkCore;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }
    }
}