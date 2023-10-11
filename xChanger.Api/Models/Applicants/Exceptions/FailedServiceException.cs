using System;
using Xeptions;

namespace xChanger.Api.Models.Applicants.Exceptions
{
    public class FailedServiceException : Xeption
    {
        public FailedServiceException(Exception exception)
            : base(message: "Failed service error occured",
                 innerException: exception)
        { }
    }
}
