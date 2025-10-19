﻿using DevFreela.Core.Entities;
using DevFreela.Application.Models;
using DevFreela.Infrastructere.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public UsersController(DevFreelaDbContext context)
        {
            _context = context;
        }
        // GET api/users
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users
                .Include(u => u.Skills)
                .ThenInclude(u => u.Skill)
                .SingleOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var model = UserViewModel.FromEntity(user);

            return Ok(model);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = new User(model.FullName,model.Email,model.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(int id ,UserSkillsInputModel model)
        {
            var userskills = model.SkillsIds.Select(s => new UserSkill(id, s)).ToList();

            _context.UserSkills.AddRange(userskills);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"FIle: {file.FileName}, Size: {file.Length}";

            // Processar a imagem
            return Ok(description);
        }
    }
}