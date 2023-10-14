using Xeptions;

namespace xChanger.Api.Services.Foundations.Applicants.Exceptions
{
    public class NullApplicantsException : Xeption
    {
        public NullApplicantsException()
            : base(message: "Applicants is null")
        { }
    }
}
