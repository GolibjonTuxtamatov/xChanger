using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace xChanger.Api.Services.Foundations.Applicants
{
    public interface IApplicantService
    {
        ValueTask<string> AddApplicantsAsync(IFormFile file);
    }
}
