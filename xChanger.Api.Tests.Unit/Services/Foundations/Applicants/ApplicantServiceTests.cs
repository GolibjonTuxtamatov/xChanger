using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using xChanger.Api.Brokers.Loggings;
using xChanger.Api.Brokers.Storages;
using xChanger.Api.Models.Applicants;
using xChanger.Api.Services.Foundations.Applicants;
using Xeptions;

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

        private Expression<Func<Xeption,bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

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

        private SqlException GetSqlError() =>
            (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));

        private string GetRandomString() =>
            new MnemonicString().GetValue();

        private DateTimeOffset CreateDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();
    }
}
