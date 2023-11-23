
using Microsoft.AspNetCore.Mvc;
using Swagger.Controllers;

namespace UnitTest
{
    public class EventsControllerTest
    {
        [Fact]
        public void Get_ReturnOk()
        {
            var controller = new EventsController();
            var result=controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            int id = 5;
            var controller = new EventsController();
            var result = controller.Get(id);
            Assert.IsType<NotFoundResult>(result);    
        }
    }
}