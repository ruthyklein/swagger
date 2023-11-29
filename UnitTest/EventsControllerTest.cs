
using Microsoft.AspNetCore.Mvc;
using Swagger.Controllers;

namespace UnitTest
{
    public class EventsControllerTest
    {
        private readonly EventsController _eventsController;
        public EventsControllerTest() {
            var context=new DataContextFake();
            _eventsController = new EventsController(context);
        }
        [Fact]
        public void Get_ReturnOk()
        {
        
            var result= _eventsController.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            int id = 5;
            var result = _eventsController.Get(id);
            Assert.IsType<NotFoundResult>(result);    
        }
    }
}