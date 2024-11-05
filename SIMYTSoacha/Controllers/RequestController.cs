using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Requests>>> GetAllRequest()
        {
            var request = await _requestService.GetAllRequestsAsync();
            return Ok(request);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Requests>> GetRequestById(int id)
        {
            var reque = await _requestService.GetRequestsByIdAsync(id);
            if (reque == null)
            {
                return NotFound();
            }
            return Ok(reque);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateRequest([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Requests re = await _requestService.CreateRequestAsync(request.PeopleId, request.RequestDate
                , request.OfficerId, request.Isdeleted);
            return CreatedAtAction(nameof(GetRequestById), new { id = re.RequestId }, re);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRequest(int id, [FromForm] int PeopleId, DateTime RequestDate
            , int OfficerId, bool isDeleted)
        {

            var existingReque = await _requestService.GetRequestsByIdAsync(id);
            if (existingReque == null)
            {
                return NotFound();
            }

            existingReque.PeopleId = PeopleId;
            existingReque.Request = RequestDate;
            existingReque.OfficerId = OfficerId;
            existingReque.Isdeleted = isDeleted;

            await _requestService.UpdateRequestAsync(existingReque);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteRequest(int id)
        {
            var reque = await _requestService.GetRequestsByIdAsync(id);
            if (reque == null)
                return NotFound();

            await _requestService.SoftDeleteRequestsByIdAsync(id);
            return NoContent();
        }

        public class Request
        {
            public int PeopleId { get; set; }
            public DateTime RequestDate { get; set; }
            public int OfficerId { get; set; }
            public bool Isdeleted { get; set; } = false;
        }
    }
}
