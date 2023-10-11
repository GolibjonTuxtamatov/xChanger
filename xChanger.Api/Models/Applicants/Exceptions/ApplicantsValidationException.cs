using Xeptions;

namespace xChanger.Api.Models.Applicants.Exceptions
{
    public class ApplicantsValidationException : Xeption
    {
        public ApplicantsValidationException(Xeption innerException)
            :base(message:"Applicants validation error occured, fix the error and try again",
                 innerException)
        { }
    }
}
