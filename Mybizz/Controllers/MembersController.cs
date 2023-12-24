using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mybizz.DAL;
using Mybizz.DTOs.Member;
using Mybizz.Entities;

namespace Mybizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _appDb;
        private readonly IMapper _mapper;

        public MembersController(AppDbContext appDb, IMapper mapper)
        {
            _appDb = appDb;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var members = _appDb.Members.ToList();
            var memberDTOs = members.Select(member => _mapper.Map<MemberGetDto>(member));
            return Ok(memberDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var member = _appDb.Members.FirstOrDefault(x => x.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            var memberDTO = _mapper.Map<MemberGetDto>(member);
            return Ok(memberDTO);
        }

        [HttpPost]
        public IActionResult Create(MemberCreateDto dto)
        {
            var member = _mapper.Map<Member>(dto);
            member.CreatedDate = DateTime.UtcNow;
            member.UpdatedDate = DateTime.UtcNow;
            member.IsDeleted = false;

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                var fileName = $"{Guid.NewGuid()}_{dto.ImageFile.FileName}";
                var filePath = Path.Combine(uploadPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    dto.ImageFile.CopyTo(fileStream);
                }

                member.ImagePath = filePath;
            }

            _appDb.Members.Add(member);
            _appDb.SaveChanges();

            return Ok(member);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MemberUpdateDto dto)
        {
            var member = _appDb.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            member = _mapper.Map(dto, member);
            member.UpdatedDate = DateTime.UtcNow.AddHours(4);

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                var fileName = $"{Guid.NewGuid()}_{dto.ImageFile.FileName}";
                var filePath = Path.Combine(uploadPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    dto.ImageFile.CopyTo(fileStream);
                }

                member.ImagePath = filePath; 
            }


            _appDb.SaveChanges();

            return Ok(member);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var member = _appDb.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(member.ImagePath))
            {
                if (System.IO.File.Exists(member.ImagePath))
                {
                    System.IO.File.Delete(member.ImagePath);
                }
            }

            _appDb.Members.Remove(member);
            _appDb.SaveChanges();

            return NoContent();
        }

    }
}
