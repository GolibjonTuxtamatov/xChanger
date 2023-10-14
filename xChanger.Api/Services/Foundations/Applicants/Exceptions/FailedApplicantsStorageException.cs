using System;
using Xeptions;

namespace xChanger.Api.Services.Foundations.Applicants.Exceptions
{
    public class FailedApplicantsStorageException : Xeption
    {
        public FailedApplicantsStorageException(Exception exception)
            : base(message: "Failed storage error occured, contact support",
                 innerException: exception)
        { }
    }
}
