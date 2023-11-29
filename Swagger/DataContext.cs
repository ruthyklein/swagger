using CsvHelper;
using Microsoft.Extensions.Logging;
using Swagger.Controllers;
using System.Formats.Asn1;
using System.Globalization;

namespace Swagger
{
    public class DataContext: IDataContext
    {

        public List<Event> EventList { get; set; }

        //all lists - data from DB
        public DataContext()
        {
            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                EventList = csv.GetRecords<Event>().ToList();
            }
            //EventList = new List<Event>();
            //EventList.Add(new Event { Id = 0, Title = "default" });
        }
    }
}
