using Xeptions;

namespace xChanger.Api.Models.Applicants.Exceptions
{
    public class NullApplicantsException : Xeption
    {
        public NullApplicantsException()
            :base(message:"Applicants is null")
        { }
    }
}
