using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using xChanger.Api.Brokers.Storages;
using xChanger.Api.Models.Applicants;

namespace xChanger.Api.Services.Foundations.Applicants
{
    public class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;

        public ApplicantService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<string> AddApplicantsAsync(IFormFile excelFile)
        {
            

            throw new NotImplementedException();
        }
    }
}
