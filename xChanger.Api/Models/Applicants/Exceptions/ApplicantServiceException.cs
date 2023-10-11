using Xeptions;

namespace xChanger.Api.Models.Applicants.Exceptions
{
    public class ApplicantServiceException : Xeption
    {
        public ApplicantServiceException(Xeption exception)
            : base(message: "Applicant service error occured, contact support",
                 innerException: exception)
        { }
    }
}
