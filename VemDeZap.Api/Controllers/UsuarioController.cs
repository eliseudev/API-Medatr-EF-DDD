using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Commands.Usuario.AdicionarUsuario;
using VemDeZap.Infra.Repositories.Transactions;

namespace VemDeZap.Api.Controllers
{
    public class UsuarioController : Base.ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }

       [AllowAnonymous]
       [HttpPost]
       [Route("Adicionar")]
       public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuarioRequest request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        } 
    }
}
