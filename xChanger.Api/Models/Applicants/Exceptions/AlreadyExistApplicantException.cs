using System;
using Xeptions;

namespace xChanger.Api.Models.Applicants.Exceptions
{
    public class AlreadyExistApplicantException : Xeption
    {
        public AlreadyExistApplicantException(Exception exception)
            : base(message: "Applicant already exist",
                 innerException: exception)
        { }
    }
}
