using System;
using VemDeZap.Domain.Entities;
using VemDeZap.Domain.Interfaces.Repositories;
using VemDeZap.Infra.Repositories.Base;

namespace VemDeZap.Infra.Repositories
{
    public class RepositoryGrupo : RepositoryBase<Grupo, Guid>, IRepositoryGrupo
    {
        private readonly VemDeZapContext _context;
        public RepositoryGrupo(VemDeZapContext context) : base(context)
        {
            _context = context;
        }
    }
}
