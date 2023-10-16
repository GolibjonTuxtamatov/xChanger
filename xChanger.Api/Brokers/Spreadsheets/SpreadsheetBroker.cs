using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using OfficeOpenXml;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Brokers.Spreadsheets
{
    public class SpreadsheetBroker : ISpreadsheetBroker
    {
        public async ValueTask<IList<Applicant>> ReadFromeExcel(MemoryStream excelFile)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var applicants = new List<Applicant>();

            using var excelPackage = new ExcelPackage(excelFile);
            var worksheet = excelPackage.Workbook.Worksheets[0];

            for(int row = 2;row<=worksheet.Dimension.Rows;row++)
            {
                applicants.Add(
                    new Applicant
                    {
                        Id = Guid.NewGuid(),
                        FirstName = worksheet.Cells[row,1].Value.ToString(),
                        Lastname = worksheet.Cells[row,2].Value.ToString(),
                        DateOfBirth = ConvertToDatimeOffset(worksheet.Cells[row,3].Value.ToString()),
                        Email = worksheet.Cells[row,4].Value.ToString(),
                        PhoneNumber = worksheet.Cells[row,5].Value.ToString(),
                    });
            }

            return applicants;
        }

        private DateTimeOffset ConvertToDatimeOffset(string date)
        {
            DateTime.TryParseExact(date, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime);

            var convertedDate = new DateTimeOffset(parsedDateTime);

            return convertedDate;
        }
    }
}
