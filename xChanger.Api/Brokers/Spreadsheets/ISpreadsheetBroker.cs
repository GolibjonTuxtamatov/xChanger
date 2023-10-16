using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Brokers.Spreadsheets
{
    public interface ISpreadsheetBroker
    {
        ValueTask<IList<Applicant>> ReadFromeExcel(MemoryStream memoryStream);
    }
}
