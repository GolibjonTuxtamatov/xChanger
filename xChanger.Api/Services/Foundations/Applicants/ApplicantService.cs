using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xChanger.Api.Brokers.Loggings;
using xChanger.Api.Brokers.Storages;
using xChanger.Api.Models.Applicants;
using xChanger.Api.Models.Applicants.Exceptions;

namespace xChanger.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantService(IStorageBroker storageBroker,ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<IQueryable<Applicant>> AddApplicantsAsync(List<Applicant> applicants) =>
            TryCatch(async () =>
            {
                ValidateApplicantsNotNull(applicants);

                return await this.storageBroker.InsertApplicantsAsync(applicants);
            });
    }
}