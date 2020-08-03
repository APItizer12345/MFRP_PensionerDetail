using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MFRP_Pension_Detail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionerDetailController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PensionerDetailController));
        private IConfiguration configuration;
        public PensionerDetailController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        // GET: api/PensionerDetail
        [HttpGet]
        public List<PensionerDetail> Get()
        {
            List<PensionerDetail> pensionDetails = getDetails();
            _log4net.Info("Pensioner details invoked!");
            return pensionDetails.ToList();

        }

        // GET: api/PensionerDetail/5
        [HttpGet("{aadhar}")]
        public PensionerDetail GetDetail(string aadhar)
        {
            List<PensionerDetail> pensionDetails = getDetails();
            _log4net.Info("Pensioner details invoked by Aadhar Number!");
            return pensionDetails.FirstOrDefault(s => s.aadharNumber == aadhar);
        }

        [HttpGet]
        [Route("api/PensionerDetail/csv")]
        public List<PensionerDetail> getDetails()
        {
            _log4net.Warn("Data is read from CSV file");
            List<PensionerDetail> pensionerdetail = new List<PensionerDetail>();

            string dbConn = configuration.GetValue<string>("MySettings:DbConnection");
            using (StreamReader sr = new StreamReader(dbConn))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    pensionerdetail.Add(new PensionerDetail() { name = values[0], date_of_birth = Convert.ToDateTime(values[1]), pan = values[2], aadharNumber = values[3], salaryEarned = Convert.ToInt32(values[4]), allowances = Convert.ToInt32(values[5]), pensionType = (PensionType)Enum.Parse(typeof(PensionType), values[6]), bankName = values[7], accountNumber = values[8], bankType = (BankType)Enum.Parse(typeof(BankType), values[9]) });
                    //  Console.WriteLine(values[0]);
                }

            }
            return pensionerdetail.ToList();
        }


    }
}