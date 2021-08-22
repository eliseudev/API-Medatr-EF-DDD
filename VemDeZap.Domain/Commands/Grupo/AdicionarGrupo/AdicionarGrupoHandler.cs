using MediatR;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Interfaces.Repositories;
using VemDeZap.Domain.Resources;

namespace VemDeZap.Domain.Commands.Grupo.AdicionarGrupo
{
    public class AdicionarGrupoHandler : Notifiable, IRequestHandler<AdicionarGrupoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGrupo _repositoryGrupo;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarGrupoHandler(IMediator mediator, IRepositoryGrupo repositoryGrupo, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryGrupo = repositoryGrupo;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AdicionarGrupoRequest request, CancellationToken cancellationToken)
        {
            //Validando se o request veio preenchido
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return new Response(this);
            }

            var usuario = _repositoryUsuario.ObterPorId(request.IdUsuario);

            if (usuario == null)
            {
                AddNotification("Usuário", MSG.X0_NAO_INFORMADA.ToFormat("Usuário"));
                return new Response(this);
            }

            Entities.Grupo grupo = new Entities.Grupo(usuario, request.Nome, request.Nicho);
            AddNotifications(grupo);

            if (IsInvalid())
            {
                return new Response(this);
            }

            grupo = _repositoryGrupo.Adicionar(grupo);

            var result = new { Id = grupo.Id, Nome = grupo.Nome, Nicho = grupo.Nicho };

            //Criar meu objeto de resposta
            var response = new Response(this, result);

            return await Task.FromResult(response);
        }
    }
}
