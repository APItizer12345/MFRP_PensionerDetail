using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFRP_Pension_Detail
{
    public class PensionerDetail
    {
        public string name { get; set; }
        public DateTime dateofbirth{get; set; }
        public string pan { get; set; }
        public int salaryEarned { get; set; }
        public int allowances { get; set; }
        public string aadharNumber { get; set; }
        public PensionType pensionType { get; set; }
        public string bankName { get; set; }
        public string accountNumber { get; set; }
        public BankType bankType { get; set; }


    }

    public enum PensionType
    {
        Self=1,
        Family=2
    }
    public enum BankType
    {
        Public=1,
        Private=2
    }

    
}
