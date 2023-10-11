using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using xChanger.Api.Models.Applicants;
using xChanger.Api.Models.Applicants.Exceptions;
using Xeptions;

namespace xChanger.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private delegate ValueTask<IQueryable<Applicant>> ReturningApplicantsfunction();

        private async ValueTask<IQueryable<Applicant>> TryCatch(ReturningApplicantsfunction returningApplicantsfunction)
        {
            try
            {
                return await returningApplicantsfunction();
            }
            catch (NullApplicantsException nullApplicantsException)
            {
                throw CreateAndLogValidationException(nullApplicantsException);
            }
            catch (SqlException sqlException)
            {
                var failedApplicantsStorageException =
                    new FailedApplicantsStorageException(sqlException);

                throw CreateAndLogCriticalException(failedApplicantsStorageException);
            }
        }

        private ApplicantsValidationException CreateAndLogValidationException(Xeption exception)
        {
            var applicantsValidationException =
                new ApplicantsValidationException(exception);

            this.loggingBroker.LogError(applicantsValidationException);

            return applicantsValidationException;
        }

        private ApplicantsDependencyException CreateAndLogCriticalException(Xeption exception)
        {
            var applicantsDependencyException =
                new ApplicantsDependencyException(exception);

            this.loggingBroker.LogCritical(applicantsDependencyException);

            return applicantsDependencyException;
        }
    }
}
