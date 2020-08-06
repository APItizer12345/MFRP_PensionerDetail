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
        // Defining log Object
        //--------------------
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PensionerDetailController));
        private IConfiguration configuration;
       // string dbconn = "demo.csv";
      
       // Dependency Injection
       //---------------------
        public PensionerDetailController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        //Getting the details of the pensioner details from csv file 
        //----------------------------------------------------------------------------------

        // GET: api/PensionerDetail
        [HttpGet]
        public List<PensionerDetail> Get()
        {
            List<PensionerDetail> pensionDetails = getDetails();
            _log4net.Info("Pensioner details invoked!");
            return pensionDetails.ToList();

        }
        //Getting the details of the pensioner details from csv file by giving Aadhar Number
        //----------------------------------------------------------------------------------

        // GET: api/PensionerDetail/5
        [HttpGet("{aadhar}")]
        public PensionerDetail GetDetail(string aadhar)
        {
            List<PensionerDetail> pensionDetails = getDetails();
            _log4net.Info("Pensioner details invoked by Aadhar Number!");
            return pensionDetails.FirstOrDefault(s => s.aadharNumber == aadhar);
        }

        // Getting the Values from Csv File
        //----------------------------------
        [HttpGet]
        [Route("api/PensionerDetail/csv")]
        public List<PensionerDetail> getDetails()
        {
            _log4net.Warn("Data is read from CSV file");  // Logging Implemented
            List<PensionerDetail> pensionerdetail = new List<PensionerDetail>();
            try
            {
                string csvConn = configuration.GetValue<string>("MySettings:CsvConnection");  // Initializing the csvConn  for the File path
                using (StreamReader sr = new StreamReader(csvConn))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        //Adding the values from file
                        pensionerdetail.Add(new PensionerDetail() { name = values[0], dateofbirth = Convert.ToDateTime(values[1]), pan = values[2], aadharNumber = values[3], salaryEarned = Convert.ToInt32(values[4]), allowances = Convert.ToInt32(values[5]), pensionType = (PensionType)Enum.Parse(typeof(PensionType), values[6]), bankName = values[7], accountNumber = values[8], bankType = (BankType)Enum.Parse(typeof(BankType), values[9]) });
                        //  Console.WriteLine(values[0]);
                    }

                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Values not found",e);
            }
            return pensionerdetail.ToList();  
        }


    }
}