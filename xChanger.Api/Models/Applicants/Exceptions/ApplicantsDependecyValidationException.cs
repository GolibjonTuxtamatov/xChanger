using Xeptions;

namespace xChanger.Api.Models.Applicants.Exceptions
{
    public class ApplicantsDependecyValidationException : Xeption
    {
        public ApplicantsDependecyValidationException(Xeption exception)
            : base(message: "Applicant dependency validation exception error occured, fix the error and try again",
                 innerException: exception)
        { }
    }
}
