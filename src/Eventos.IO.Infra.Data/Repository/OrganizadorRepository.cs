
namespace Eventos.IO.Infra.Data.Repository
{
    using System.Collections.Generic;
    using Domain.Organizadores;
    using Domain.Organizadores.Repository;
    using Eventos.IO.Infra.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using Dapper;
    using System.Linq;

    public class OrganizadorRepository : Repository<Organizador>, IOrganizadorRepository
    {
        public OrganizadorRepository(EventosContext context) 
            : base(context)
        {
        }

        public override int Adicionar(List<Organizador> obj)
        {
            var sql = "INSERT INTO ORGANIZADORES (Id, Nome, CPF, Email) " +
                                   "VALUES (@Id, @Nome, @CPF, @Email)";

            var count = Db.Database.GetDbConnection()
                         .Execute(sql, obj.ToArray());

            return count;
        }

        public override List<Organizador> ObterTodos()
        {
            var sql = "SELECT * FROM ORGANIZADORES O ORDER BY O.NOME";

            return Db.Database.GetDbConnection()
                    .Query<Organizador>(sql)
                    .ToList();
        }
    }
}
