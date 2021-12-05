using DataApi1.Context;
using DataApi1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DataApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController : ControllerBase
    {
        private readonly MoneyContext dbContext;
        private readonly ILogger<MoneyController> logger;
        private string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
        public MoneyController(MoneyContext _dbContext, ILogger<MoneyController> _logger)
        {
            this.dbContext = _dbContext;
            this.logger = _logger;
        }
        [HttpGet]
        [Route("GetToday")]
        public Tarih_Date GetData()
        {
            Tarih_Date entity = (Tarih_Date)new XmlSerializer(typeof(Tarih_Date), new XmlRootAttribute()
            {
                ElementName = "Tarih_Date"
            }).Deserialize(XDocument.Load(this.today).CreateReader());
            try
            {
                this.dbContext.currencies.AddRange((IEnumerable<Currency>)entity.Cur);
                this.dbContext.tarih_Dates.Add(entity);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return entity;
        }
        [HttpGet]
        [Route("GetPast")]
        public Tarih_Date GetPast(string year, string month, string day)
        {
            int num1 = (int)short.Parse(DateTime.Now.Month.ToString());
            int num2 = (int)short.Parse(day);
            int num3 = (int)short.Parse(month);
            if (!(DateTime.Now.Year.ToString() == year) || num1 - num3 > 2 || num1 - num3 < -2)
                return (Tarih_Date)null;
            string uri = (string)null;
            if (num3 < 10 && num2 < 10)
                uri = "https://www.tcmb.gov.tr/kurlar/" + year + "0" + month + "/0" + day + "0" + month + year + ".xml";
            else if (num3 > 10 && num2 < 10)
                uri = "https://www.tcmb.gov.tr/kurlar/" + year + month + "/0" + day + month + year + ".xml";
            else if (num3 < 10 && num2 > 10)
                uri = "https://www.tcmb.gov.tr/kurlar/" + year + "0" + month + "/" + day + "0" + month + year + ".xml";
            else if (num3 >= 10 && num2 >= 10)
                uri = "https://www.tcmb.gov.tr/kurlar/" + year + month + "/" + day + month + year + ".xml";
            Tarih_Date entity = (Tarih_Date)new XmlSerializer(typeof(Tarih_Date), new XmlRootAttribute()
            {
                ElementName = "Tarih_Date"
            }).Deserialize(XDocument.Load(uri).CreateReader());
            try
            {
                try
                {
                    this.dbContext.currencies.AddRange((IEnumerable<Currency>)entity.Cur);
                    this.dbContext.tarih_Dates.Add(entity);
                    this.dbContext.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {
            }
            return entity;
        }
    }
}
