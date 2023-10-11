using System;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
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
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistApplicantException =
                    new AlreadyExistApplicantException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistApplicantException);
            }
            catch (Exception serviceException)
            {
                var failedServiceException =
                    new FailedServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceException);
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

        private ApplicantsDependecyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var applicantsDependecyValidationException =
                new ApplicantsDependecyValidationException(exception);

            this.loggingBroker.LogError(applicantsDependecyValidationException);

            return applicantsDependecyValidationException;
        }

        private ApplicantServiceException CreateAndLogServiceException(Xeption exception)
        {
            var applicantServiceException =
                new ApplicantServiceException(exception);

            this.loggingBroker.LogError(applicantServiceException);

            return applicantServiceException;
        }
    }
}
