using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Services.Foundations.Applicants
{
    public interface IApplicantService
    {
        ValueTask<IQueryable<Applicant>> AddApplicantsAsync(List<Applicant> applicants);
    }
}
