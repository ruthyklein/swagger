using Swagger.Controllers;

namespace Swagger
{
    public class DataContext
    {

        public List<Event> EventList { get; set; }

        //all lists - data from DB
        public DataContext()
        {
            EventList = new List<Event>();

            EventList.Add(new Event { Id = 0, Title = "default" });
        }
    }
}
