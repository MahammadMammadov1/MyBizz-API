using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mybizz.DAL;
using Mybizz.DTOs.Profession;
using Mybizz.Entities;

namespace Mybizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        private readonly AppDbContext _appDb;
        private readonly IMapper _mapper;

        public ProfessionsController(AppDbContext appDb,IMapper mapper)
        {
            _appDb = appDb;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var prof = _appDb.Professions.ToList();

            IEnumerable<ProfessionGetDto> professions = prof.Select(x => new ProfessionGetDto
            {
                Name = x.Name,
                IsDeleted = x.IsDeleted,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
            });

            return Ok(professions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var prof = _appDb.Professions.FirstOrDefault(x => x.Id == id);

            ProfessionGetDto professionGet = _mapper.Map<ProfessionGetDto>(prof);
            return Ok(professionGet);   
           
        }

        [HttpPost]
        public IActionResult Create(ProfessionCreateDto dto)
        {
            Profession profession = _mapper.Map<Profession>(dto);
            profession.CreatedDate = DateTime.UtcNow.AddHours(4);
            profession.UpdatedDate = DateTime.UtcNow.AddHours(4);
            profession.IsDeleted = false;
            _appDb.Professions.Add(profession);
            _appDb.SaveChanges();
            return Ok(profession);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProfessionUpdateDto dto)
        { 
            var prof = _appDb.Professions.Find(id);
            if (prof == null) return BadRequest();
            prof = _mapper.Map(dto, prof);
            _appDb.SaveChanges();
            return Ok(prof);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _appDb.Professions.Find(id);
            _appDb.Remove(prof);
            _appDb.SaveChanges();
            return NoContent();
        }

    }
}
