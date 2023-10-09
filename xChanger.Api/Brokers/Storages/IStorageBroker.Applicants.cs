using System.Threading.Tasks;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Applicant> InsertApplicantAsync(Applicant applicant);
    }
}
