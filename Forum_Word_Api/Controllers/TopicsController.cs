using forum_api.Models;
using forum_api.Services;
using forum_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _service;

        public TopicsController(ITopicService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(this._service.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            return Ok(this._service.FindById(id));
        }


        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            this._service.Create(topic);
            return Ok("Created");
        }

        [HttpPut("{id}")]
        public IActionResult Update(Topic topic)
        {
            this._service.Update(topic);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._service.Delete(id);
            return Ok("Deleted");
        }
    }
}
