using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyDiHon_API.Models;
using ParkyDiHon_API.Models.Dtos;
using ParkyDiHon_API.Repository.IRepository;

namespace ParkyDiHon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : Controller
    {
        private readonly INationalParkRepository _npRepo;
        private readonly IMapper _mapper;
        public NationalParksController(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var obj = _npRepo.GetNationalParks();

            var objDto = new List<NationalParkDto>();

            foreach (var item in obj)
            {
                objDto.Add(_mapper.Map<NationalParkDto>(item));
            }

            return Ok(objDto);
        }

        [HttpGet("{nationalParkId:int}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var obj = _npRepo.GetNationalPark(nationalParkId);

            if (obj == null)
            {
                return NotFound();
            }

            var ObjDto = _mapper.Map<NationalParkDto>(obj);

            return Ok(ObjDto);
        }

        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDto parkDto)
        {
            if (parkDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_npRepo.NationalParkExists(parkDto.Name))
            {
                ModelState.AddModelError("", "National Park already exist!");
                return StatusCode(404, ModelState);
            }


            var obj = _mapper.Map<NationalPark>(parkDto);

            if (!_npRepo.CreateNationalPark(obj))
            {
                ModelState.AddModelError("", $"something went wrong.");
                return StatusCode(505, ModelState);
            }

            return CreatedAtRoute("GetNationalPark", new { nationalParkId = obj.Id }, obj);
        }

        [HttpPatch("{nationalId:int}",Name= "UpdateNationalPark")]
        public IActionResult UpdateNationalPark(int nationalId, [FromBody] NationalParkDto parkDto)
        {
            if(nationalId == 0 || nationalId != parkDto.Id)
            {
                return BadRequest(ModelState);
            }


            var obj = _mapper.Map<NationalPark>(parkDto);

            if (!_npRepo.UpdateNationalPark(obj))
            {
                ModelState.AddModelError("", $"something went wrong.");
                return StatusCode(505, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{nationalId:int}", Name = "DeleteNationalPark")]
        public IActionResult DeleteNationalPark(int nationalId)
        {
            if(!_npRepo.NationalParkExists(nationalId))
            {
                return BadRequest(ModelState);
            }


            var obj = _npRepo.GetNationalPark(nationalId);

            if (!_npRepo.DeleteNationalPark(obj))
            {
                ModelState.AddModelError("", $"something went wrong.");
                return StatusCode(505, ModelState);
            }

            return NoContent();
        }
    }
}
