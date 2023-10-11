using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xChanger.Api.Brokers.Loggings;
using xChanger.Api.Brokers.Storages;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Services.Foundations.Applicants
{
    public class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantService(IStorageBroker storageBroker,ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<IQueryable<Applicant>> AddApplicantsAsync(List<Applicant> applicants) =>
            await this.storageBroker.InsertApplicantsAsync(applicants);
    }
}
