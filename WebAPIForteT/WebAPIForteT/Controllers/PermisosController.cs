using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIForteT.Data;
using WebAPIForteT.Models;

namespace WebAPIForteT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PermisosController(ApiDbContext context)
        {
            _context = context;
        }

        //Get: API/Permisos/GetPermisos
        [HttpGet("GetPermisos")]        
        public async Task<ActionResult<IEnumerable<Permiso>>> GetPermisos()
        {
            try
            {      

                return await _context.Permisos.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(500,"Ha ocurrido un error");
            }            
        }

         //Get: API/Permisos/GetPermisos
        [HttpGet("GetPermisos/{id}")]
        public async Task<ActionResult<Permiso>> GetPermisoId(int id)
        {           
                var permiso = await _context.Permisos.FindAsync(id);
                if (permiso == null){
                    return NotFound();
                }
                return permiso;          
        }


        //POST: API/Permisos/
        [HttpPost("CreatePermiso")]
        public async Task<ActionResult<Permiso>> PostPermiso(Permiso permiso) //IActionResult Create([FromBody] Permiso request)
        {
            try 
            {
                _context.Permisos.Add(permiso);
                await _context.SaveChangesAsync();
                return (permiso);
            }
            catch 
            {
                return StatusCode(500,"Ha ocurrido un error");
            }
        }


        //PUT: API/Permisos/
        [HttpPut("UpdatePermiso/{id}")]        
        public async Task<IActionResult> PutPermiso(int id, Permiso permiso)
        {
            if(id != permiso.Id)
            {
                return BadRequest();

            }
            _context.Entry(permiso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch 
            {
                if(!PermisoExists(id))
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


        //PUT: API/Permisos/DeletePermiso/{id}
        [HttpDelete("DeletePermiso/{Id}")]
        public async Task<IActionResult> DeletePermisoId(int id)
        {
            
            try
            {
                var permiso = await _context.Permisos.FindAsync(id);
                if (permiso == null)
                {
                    return NotFound();
                }

                _context.Entry(permiso).State = EntityState.Deleted;
                _context.Permisos.Remove(permiso);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            catch 
            {
                return StatusCode(500, "Ha ocurrido un error");
            }


        }

        private bool PermisoExists(int id)
        {
            return _context.Permisos.Any(e => e.Id == id);
        }

        //Get: API/Permisos/GetTipoPermisos
        [HttpGet("GetTiposPermisos")]
        public async Task<ActionResult<IEnumerable<TipoPermiso>>> GetTipoPermisos()
        {
            try
            {
                return await _context.TipoPermisos.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error");
            }
        }


        //Get: API/Permisos/GetTiposPermisos/{id}
        [HttpGet("GetTiposPermisos/{id}")]
        public async Task<ActionResult<TipoPermiso>> GetTiposPermisoId(int id)
        {
            var tipopermiso = await _context.TipoPermisos.FindAsync(id);
            if (tipopermiso == null)
            {
                return NotFound();
            }
            return tipopermiso;
        }


    }
}
