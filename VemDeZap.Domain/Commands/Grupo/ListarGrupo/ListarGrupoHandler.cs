using MediatR;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Interfaces.Repositories;
using VemDeZap.Domain.Resources;

namespace VemDeZap.Domain.Commands.Grupo.ListarGrupo
{
    public class ListarGrupoHandler : Notifiable, IRequestHandler<ListarGrupoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGrupo _repositoryGrupo;

        public ListarGrupoHandler(IMediator mediator, IRepositoryGrupo repositoryGrupo)
        {
            _mediator = mediator;
            _repositoryGrupo = repositoryGrupo;
        }

        public async Task<Response> Handle(ListarGrupoRequest request, CancellationToken cancellationToken)
        {
            //Valida se o objeto request esta nulo
            if (request == null)
            {
                AddNotification("Resquest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Grupo"));
                return new Response(this);
            }

            var grupoCollection = _repositoryGrupo.Listar().ToList();

            //Cria objeto de resposta
            var response = new Response(this, grupoCollection);

            ////Retorna o resultado
            return await Task.FromResult(response);
        }
    }
}
