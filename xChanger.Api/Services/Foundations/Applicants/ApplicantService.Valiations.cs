using System.Collections.Generic;
using xChanger.Api.Models.Applicants;
using xChanger.Api.Services.Foundations.Applicants.Exceptions;

namespace xChanger.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private void ValidateApplicantsNotNull(List<Applicant> applicants)
        {
            if (applicants == null)
            {
                throw new NullApplicantsException();
            }
        }
    }
}
