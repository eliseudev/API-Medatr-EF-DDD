using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarUsuarioHandler(IMediator mediator, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            //Validando se o request veio preenchido
            if (request == null)
            {
                AddNotification("Request", "Informe os dados do usuário");
                return new Response(this);
            }
            //Verificar se o usuário existe
            if (_repositoryUsuario.Existe(x => x.Email == request.Email))
            {
                AddNotification("Email", "E-Mail já cadastrado no sistema");
                return new Response(this);
            }

            Entities.Usuario usuario = new Entities.Usuario(request.PrimeiroNome, request.UltimoNome, request.Email, request.Senha);
            AddNotifications(usuario);

            if (IsInvalid())
            {
                return new Response(this);
            }

            usuario = _repositoryUsuario.Adicionar(usuario);

            //Criar meu objeto de resposta
            var response = new Response(this, usuario);

            AdicionarUsuarioNotification adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario);

            await _mediator.Publish(adicionarUsuarioNotification);

            return await Task.FromResult(response);
        }
    }
}