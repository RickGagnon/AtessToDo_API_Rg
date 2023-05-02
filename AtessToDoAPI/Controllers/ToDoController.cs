using Microsoft.AspNetCore.Mvc;

namespace AtessToDoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        [HttpGet(Name = "Todo")]
        public IEnumerable<ToDo> Get()
        {

            return new ToDo[]
            {
                new ToDo{itemDescription="aaa",itemCompleted=false},
                new ToDo{itemDescription="bbb",itemCompleted=false},
            };
            
        }
    }
}