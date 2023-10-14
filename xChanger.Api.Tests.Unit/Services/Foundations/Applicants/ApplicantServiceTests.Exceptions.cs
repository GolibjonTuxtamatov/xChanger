using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Moq;
using xChanger.Api.Models.Applicants;
using xChanger.Api.Services.Foundations.Applicants.Exceptions;
using Xunit;

namespace xChanger.Api.Tests.Unit.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowCrirticalDependencyExceptionOnAddIfOccurssqlErrorAndLogItAsync()
        {
            //given
            List<Applicant> applicants = CreateRandomApplicants().ToList();
            SqlException sqlException = GetSqlError();

            var failedApplicantsStorageExceptionc =
                new FailedApplicantsStorageException(sqlException);

            var expectedApplicantsDependencyException =
                new ApplicantsDependencyException(failedApplicantsStorageExceptionc);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertApplicantsAsync(applicants))
                .ThrowsAsync(sqlException);

            //when
            ValueTask<IQueryable<Applicant>> addApplicantTask =
                this.applicantService.AddApplicantsAsync(applicants);

            //then
            await Assert.ThrowsAsync<ApplicantsDependencyException>(() =>
                addApplicantTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantsAsync(applicants),
                Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedApplicantsDependencyException))),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDuplicateKeyDependencyExceptionOnAddAndLogItAsync()
        {
            //given
            List<Applicant> applicants = CreateRandomApplicants().ToList();
            var duplicateKeyException = new DuplicateKeyException(GetRandomString());

            var alreadyExistApplicantException =
                new AlreadyExistApplicantException(duplicateKeyException);

            var expectedApplicantsDependecyValidationException =
                new ApplicantsDependecyValidationException(alreadyExistApplicantException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertApplicantsAsync(applicants))
                .ThrowsAsync(duplicateKeyException);

            //when
            ValueTask<IQueryable<Applicant>> addApplicantTask =
                this.applicantService.AddApplicantsAsync(applicants);

            //then
            await Assert.ThrowsAsync<ApplicantsDependecyValidationException>(() =>
                addApplicantTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantsAsync(applicants),
                Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedApplicantsDependecyValidationException))),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddAndLogItAsync()
        {
            //given
            List<Applicant> applicants = CreateRandomApplicants().ToList();
            var serviceException = new Exception();

            var failedServiceException =
                new FailedServiceException(serviceException);

            var expectedApplicantServiceException =
                new ApplicantServiceException(failedServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertApplicantsAsync(applicants))
                .ThrowsAsync(serviceException);

            //when
            ValueTask<IQueryable<Applicant>> addApplicantTask =
                this.applicantService.AddApplicantsAsync(applicants);

            //then
            await Assert.ThrowsAsync<ApplicantServiceException>(() =>
                addApplicantTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantsAsync(applicants),
                Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedApplicantServiceException))),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
