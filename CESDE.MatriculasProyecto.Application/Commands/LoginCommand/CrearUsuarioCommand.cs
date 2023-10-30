using AutoMapper;
using CESDE.MatriculasProyecto.Application.Interfaces;
using CESDE.MatriculasProyecto.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESDE.MatriculasProyecto.Application.Commands.LoginCommand
{
    public class CrearUsuarioCommand : IRequest<Usuario>
    {
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;

    }

    public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, Usuario>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CrearUsuarioCommandHandler> _logger;

        public CrearUsuarioCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CrearUsuarioCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Usuario> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("CrearUsuarioCommandHandler Started");

            Random random = new Random();
            var caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] caracteres = new char[6];

            for (int i = 0; i < 6; i++)
            {
                caracteres[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }
            var contrasena = new string(caracteres);
            var login = new Usuario()
            {
                Usuario1 = request.Usuario,
                Contraseña = request.Contraseña
            };
            var DatoExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Usuario1 == request.Usuario && x.Contraseña == request.Contraseña);

            if (DatoExistente != null)
            {
                throw new Exception("El usuario ya se encuentra registrado");
            }

            _context.Usuarios.Add(login);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogDebug("CrearLoginUsuarioCommandHandler Finished");

            return login;
        }
    }
}
