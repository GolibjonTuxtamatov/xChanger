﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Moq;
using xChanger.Api.Models.Applicants;
using xChanger.Api.Models.Applicants.Exceptions;
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
    }
}