using forum_api.Models;
using forum_api.Services;
using forum_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IWordFilterService _serviceW;

        public CommentsController(ICommentService service, IWordFilterService _serviceW)
        {
            this._service = service;
            this._serviceW = _serviceW;
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


        [HttpPost("{idTopic}")]
        public IActionResult Create(int idTopic, Comment comment)
        {
            this._service.Create(comment);
            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(Comment comment)
        {
            this._service.Update(comment);
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
