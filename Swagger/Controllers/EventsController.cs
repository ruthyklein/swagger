using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static int count = 1;

        static DataContext context = new DataContext();
        //static List<Event> events = new List<Event>() {
        //    new Event { Id=count++,Title="first",Start=new DateTime(2023,11,01),End=new DateTime(2023,11,02)},
        //    new Event { Id=count++,Title="second",Start=new DateTime(2023,11,02),End=new DateTime(2023,11,03)},
        //    new Event { Id=count++,Title="third",Start=new DateTime(2023,11,03),End=new DateTime(2023,11,04)},
        //    new Event { Id=count++,Title="forth",Start=new DateTime(2023,11,05),End=new DateTime(2023,11,06)}
        //};
        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult Get()
        {
            //return events;
            return Ok(context.EventList);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var eve= context.EventList.Find(e => e.Id == id);
            if (eve is null)
            {
                return NotFound();
            }
            return Ok(eve);
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event value)
        {
            context.EventList.Add(new Event { Id = count++, Title=value.Title,Start=value.Start,End=value.End });
        }
      
        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            for (int i = 0; i <= id; i++)
            {
                if (context.EventList[i].Id == id)
                {
                    context.EventList[i].Title = value.Title;
                    context.EventList[i].Start = value.Start;
                    context.EventList[i].End = value.End;
                }
            }
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            for (int i = 0; i <= id; i++)
            {
                if (context.EventList[i].Id == id)
                {
                    context.EventList.Remove(context.EventList[i]);
                }
            }
            //Event eve = context.EventList.Find(e => e.Id == id);
            //context.EventList.Remove(eve);

        }
    }
}
