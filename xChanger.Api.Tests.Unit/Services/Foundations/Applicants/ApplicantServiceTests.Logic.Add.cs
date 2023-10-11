using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using xChanger.Api.Models.Applicants;
using Xunit;

namespace xChanger.Api.Tests.Unit.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldAddApplicantsAsync()
        {
            //given
            IQueryable<Applicant> randomApplicants = CreateRandomApplicants();
            IQueryable<Applicant> incomingApplicants = randomApplicants;
            IQueryable<Applicant> storedApplicants = incomingApplicants;
            IQueryable<Applicant> expectedStoredApplicants = storedApplicants.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertApplicantsAsync(incomingApplicants))
                .ReturnsAsync(expectedStoredApplicants);

            //when
            IQueryable<Applicant> actualApplicants =
                await this.applicantService.AddApplicantsAsync(incomingApplicants.ToList());

            //then
            expectedStoredApplicants.Should().BeEquivalentTo(actualApplicants);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantsAsync(incomingApplicants), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
