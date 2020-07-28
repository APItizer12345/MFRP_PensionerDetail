using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MFRP_Pension_Detail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionerDetailController : ControllerBase
    {
        private List<PensionerDetail> pensiondetail = new List<PensionerDetail>();

        public PensionerDetailController(List<PensionerDetail> pensiondetails)
        {
            pensiondetail = pensiondetails;
        }
        // GET: api/PensionerDetail
        [HttpGet]
        public IEnumerable<PensionerDetail> Get()
        {
            return pensiondetail.ToList();
        }

        // GET: api/PensionerDetail/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        
    }
}
