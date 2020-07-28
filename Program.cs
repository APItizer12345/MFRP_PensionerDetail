using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MFRP_Pension_Detail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            List<PensionerDetail> pensionerdetail = new List<PensionerDetail>();
            using (StreamReader sr = new StreamReader("D:\\demo.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    pensionerdetail.Add(new PensionerDetail() { name = values[0], date_of_birth = Convert.ToDateTime(values[1]), pan = values[2], aadharNumber = values[3], salaryEarned = Convert.ToInt32(values[4]), allowances = Convert.ToInt32(values[5]),pensionType=(PensionType)Enum.Parse(typeof(PensionType),values[6]) , bankName = values[7], accountNumber = values[8], bankType = (BankType)Enum.Parse(typeof(BankType), values[9]) });
                    //  Console.WriteLine(values[0]);
                }

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
