using CESDE.MatriculasProyecto.Application.Commands.LoginCommand;
using CESDE.MatriculasProyecto.Application.Interfaces;
using CESDE.MatriculasProyecto.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CESDE.MatriculasProyecto.API.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext _context;

        public UsuarioController(IMediator mediator, IApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

    [HttpPost("CrearUsuario")]
    public async Task<IActionResult> CrearUsuario(CrearUsuarioCommand request)
    {
        try
        {
            var resultado = await _mediator.Send(request);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ha ocurrido un error al crear el usuario. Detalle: {ex.Message}");
        }

    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] Usuario request, CancellationToken cancellationToken)
    {
        if (request == null)
            return BadRequest();
        await _context.Usuarios.AddAsync(request);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(new { Message = "Usuario Registrado con Exito!" });
    }

    [HttpPost("Autenticacion")]

    public async Task<IActionResult> Autenticacion([FromBody] Usuario request)
    {
        if (request == null)
        {
            return BadRequest();
        }
        var login = await _context.Usuarios.FirstOrDefaultAsync(x => x.Usuario1 == request.Usuario1 && x.Contraseña == request.Contraseña);
        if (login == null)
            return NotFound(new { Message = "Usuario no encontrado" });
        return Ok(new
        {
            Message = "Login Exitoso!"
        });
    }

    [HttpPut("ActualizarLoginUsuario")]
    public async Task<IActionResult> ActualizarLoginUsuario(ActualizarCommand request)
    {
        try
        {
            var resultado = await _mediator.Send(request);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ha ocurrido un error al actualizar el usuario. Detalle: {ex.Message}");
        }
    }
    
    }
}
