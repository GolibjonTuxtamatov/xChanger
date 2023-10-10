using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xChanger.Api.Brokers.Storages;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Services.Foundations.Applicants
{
    public class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;

        public ApplicantService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<IQueryable<Applicant>> AddApplicantsAsync(List<Applicant> applicants) =>
            await this.storageBroker.InsertApplicantsAsync(applicants);
    }
}
