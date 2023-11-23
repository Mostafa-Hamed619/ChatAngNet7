using ChatApi.DTOs;
using ChatApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatServices chatServices;
        public ChatController(ChatServices chatServices)
        {
            this.chatServices = chatServices;
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser(UserDTO model)
        {
            if (chatServices.AddUserToList(model.Name))
            {
                return NoContent();
            }
            return BadRequest("this name is already taken, please choose another name");
        }
    }
}
