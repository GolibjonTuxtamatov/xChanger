using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<IQueryable<Applicant>> InsertApplicantsAsync(IEnumerable<Applicant> applicants);
    }
}
