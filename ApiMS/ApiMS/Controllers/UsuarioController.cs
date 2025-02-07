﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMS.Core.Entities;
using ApiMS.Infrastructure.Database;

namespace ApiMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public UsuarioController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioEntity>>> GetUsuarioEntity()
        {
            return await _context.UsuarioEntity.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEntity>> GetUsuarioEntity(Guid id)
        {
            var usuarioEntity = await _context.UsuarioEntity.FindAsync(id);

            if (usuarioEntity == null)
            {
                return NotFound();
            }

            return usuarioEntity;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioEntity(Guid id, UsuarioEntity usuarioEntity)
        {
            if (id != usuarioEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioEntity>> PostUsuarioEntity(UsuarioEntity usuarioEntity)
        {
            _context.UsuarioEntity.Add(usuarioEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioEntity", new { id = usuarioEntity.Id }, usuarioEntity);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioEntity(Guid id)
        {
            var usuarioEntity = await _context.UsuarioEntity.FindAsync(id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            _context.UsuarioEntity.Remove(usuarioEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioEntityExists(Guid id)
        {
            return _context.UsuarioEntity.Any(e => e.Id == id);
        }
    }
}
