using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.Models.Dtos;
using ParkyAPI.Models.Dtos.Trail;
using ParkyAPI.Repository.IRepository;
using System.Collections.Generic;

namespace ParkyAPI.Controllers
{
    //[Route("api/Trails")]
    [Route("api/v{version:apiVersion}/trails")]
    [ApiController]
   // [ApiExplorerSettings(GroupName = "ParkyOpenAPISpecTrail")]
    public class TrailsController : ControllerBase
    {
        private readonly ITrailRepository _trailRepo;
        private readonly IMapper _mapper;

        public TrailsController(ITrailRepository trailRepo, IMapper mapper)
        {
            _mapper= mapper;
            _trailRepo = trailRepo;
        }

        /// <summary>
        /// Get All Trails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(List<TrailDto>))]
        [ProducesResponseType(400)]
		

		public IActionResult GetTrails() 
        { 
            var objList = _trailRepo.GetTrails(); // to avoid exposing our model we return the data in dto 
            var objDto = new List<TrailDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<TrailDto>(obj));
            }

            return Ok (objDto);
        }

        /// <summary>
        /// Get Single Trail
        /// </summary>
        /// <param name="trailId">The trail id</param>
        /// <returns></returns>

        [HttpGet("{trailId:int}",Name ="GetTrail")]
        [ProducesResponseType(200, Type = typeof(TrailDto))]
        [ProducesResponseType(404)] //not found
        [ProducesDefaultResponseType] // default for any other errors 
        [Authorize(Roles = "Admin")]
        public IActionResult GetTrail(int trailId)
        { 
            var obj = _trailRepo.GetTrailsInNationalParK(trailId);

            if (obj ==null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<TrailDto>(obj);

            return Ok (objDto);
        }

        /// <summary>
        /// Get All Trails in A Specific NP
        /// </summary>
        /// <param name="nationalParkId"></param>
        /// <returns></returns>

        [HttpGet("[action]/{nationalParkId:int}")]
        [ProducesResponseType(200, Type = typeof(TrailDto))]
        [ProducesResponseType(400)] // bad request
        [ProducesResponseType(404)] //not found
        [ProducesDefaultResponseType] // default for any other errors 
        public IActionResult GetTrailInNationalPark(int nationalParkId)
        {
            var objList = _trailRepo.GetAllTrailsInNationalPark(nationalParkId);

            if (objList == null)
            {
                return NotFound();
            }

            var objDto = new List<TrailDto>();


            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<TrailDto>(obj));
            }



            return Ok(objDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TrailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // bad request
        [ProducesResponseType(404)] //not found
        [ProducesResponseType(500)]
        public IActionResult CreateTrail([FromBody] TrailCreateDto trailDto)
        {
            if(trailDto== null) 
            {
                return BadRequest(ModelState);
            }

            if(_trailRepo.TrailExists(trailDto.Name))
            {
                ModelState.AddModelError("", $"Trail {trailDto.Name} Exists!");
                return StatusCode(404,ModelState);
            }
            

            var trailObj = _mapper.Map<Trail> (trailDto);

            if (!_trailRepo.CreateTrail(trailObj))
            {
                ModelState.AddModelError("", $"Something went wrong when adding the record {trailObj.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetTrail",new { trailId = trailObj.Id },trailObj);
        }

        [HttpPatch("{trailId:int}", Name = "UpdateTrail")]

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //not found
        [ProducesResponseType(500)] //internal server error

        public IActionResult UpdateTrail(int trailId, [FromBody] TrailUpdateDto trailDto)
        {
            if (trailDto == null || trailId != trailDto.Id)
            {
                return BadRequest(ModelState);
            }

            var trailObj = _mapper.Map<Trail>(trailDto);

            if (!_trailRepo.UpdateTrail(trailObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {trailObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{trailId:int}", Name = "DeleteTrail")]

        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)] //not found
        [ProducesResponseType(500)]

        public IActionResult DeleteTrail(int trailId)
        {
            if (!_trailRepo.TrailExists(trailId))
            {
                return NotFound();
            }
            var trailObj = _trailRepo.GetTrailsInNationalParK(trailId);

            if (!_trailRepo.DeleteTrail(trailObj))
            {
                ModelState.AddModelError("", $"Something went wrong when delete the record {trailObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
