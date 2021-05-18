using System;
using Microsoft.AspNetCore.Mvc;
using myweddingApi.Attributes;
using myweddingApi.Database;
using myweddingApi.Repositories;

namespace myweddingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        [ApiKey]
        [HttpPost]
        public IActionResult AddMessage([FromBody] MessageRequest messageRequest)
        {
            var result = _messageRepository.Create(new Message(messageRequest.Name, messageRequest.Contact, messageRequest.Text));
            if (result != null)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [Route("healthcheck")]
        public IActionResult Healthcheck()
        {
            return Ok("healthcheck");
        }
    }

    public class MessageRequest
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Text { get; set; }
    }
}
