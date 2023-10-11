using Moq;
using xChanger.Api.Models.Applicants;
using xChanger.Api.Models.Applicants.Exceptions;
using Xunit;

namespace xChanger.Api.Tests.Unit.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionIfApplicantsIsNullAndLogItAsync()
        {
            //given
            List<Applicant> nullApplicants = null;

            var nullApplicantsException = new NullApplicantsException();

            ApplicantsValidationException expectedApplicantsValidationException =
                new ApplicantsValidationException(nullApplicantsException);

            //when
            ValueTask<IQueryable<Applicant>> addApplicantsTask =
                this.applicantService.AddApplicantsAsync(nullApplicants);

            //then
            await Assert.ThrowsAsync<ApplicantsValidationException>(() =>
                addApplicantsTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedApplicantsValidationException))),
                Times.Once());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantsAsync(It.IsAny<List<Applicant>>()),
                Times.Never());

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
