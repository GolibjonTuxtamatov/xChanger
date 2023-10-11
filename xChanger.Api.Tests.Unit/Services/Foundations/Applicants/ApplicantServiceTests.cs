using Moq;
using Tynamix.ObjectFiller;
using xChanger.Api.Brokers.Loggings;
using xChanger.Api.Brokers.Storages;
using xChanger.Api.Models.Applicants;
using xChanger.Api.Services.Foundations.Applicants;

namespace xChanger.Api.Tests.Unit.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IApplicantService applicantService;

        public ApplicantServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.applicantService = new ApplicantService(
                this.storageBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }

        private IQueryable<Applicant> CreateRandomApplicants()
        {
            IQueryable<Applicant> applicants =
                CreateApplicantFiller(CreateDateTimeOffset()).Create(2).AsQueryable();

            return applicants;
        }

        private Filler<Applicant> CreateApplicantFiller(DateTimeOffset date)
        {
            var filler = new Filler<Applicant>();

            filler.Setup().OnType<DateTimeOffset>().Use(date);

            return filler;
        }

        private DateTimeOffset CreateDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();
    }
}
