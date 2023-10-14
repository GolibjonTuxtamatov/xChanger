using System;
using Xeptions;

namespace xChanger.Api.Services.Foundations.Applicants.Exceptions
{
    public class AlreadyExistApplicantException : Xeption
    {
        public AlreadyExistApplicantException(Exception exception)
            : base(message: "Applicant already exist",
                 innerException: exception)
        { }
    }
}
