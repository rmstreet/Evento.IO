
namespace Eventos.IO.Infra.Data.Repository
{
    using Context;
    using Dapper;
    using Domain.Eventos;
    using Domain.Eventos.Repository;    
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(EventosContext context) :base(context) { }
                
        public void AdicionarEndereco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            var sql = @"SELECT * FROM Enderecos E " +
                       "WHERE E.Id = @uid";

            var endereco = Db.Database.GetDbConnection().Query<Endereco>(sql, new { uid = id });

            return endereco.SingleOrDefault();
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            var sql = @"SELECT * FROM EVENTOS E " +
                       "WHERE E.EXCLUIDO = 0 " +
                       "AND E.ORGANIZADORID = @oid " +
                       "ORDER BY E.DATAFIM DESC";

            return Db.Database.GetDbConnection().Query<Evento>(sql, new {oid = organizadorId });            
        }

        public override Evento ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Eventos E " +
                       "LEFT JOIN Enderecos EN " +
                       "ON E.d = EN.EventoId " +
                       "WHERE E.Id = @uid";

            var evento = Db.Database.GetDbConnection().Query<Evento, Endereco, Evento>(sql,
                (e, en) => 
                {
                    if (en != null)
                        e.AtribuirEndereco(en);
                    return e;
                }, new { uid = id });

            return evento.FirstOrDefault();
        }

        public override int Adicionar(List<Evento> obj)
        {
            var sql = "INSERT INTO EVENTOS (Id, Nome, DescricaoCurta, DescricaoLonga, DataInicio, DataFim, Gratuito," +
                                           "Valor, Online, NomeEmpresa, Excluido, CategoriaId, EnderecoId, OrganizadorId) " +
                                   "VALUES (@Id, @Nome, @DescricaoCurta, @DescricaoLonga, @DataInicio, @DataFim, @Gratuito," +
                                           "@Valor, @Online, @NomeEmpresa, @Excluido, @CategoriaId, @EnderecoId, @OrganizadorId)";

            var count = Db.Database.GetDbConnection().Execute(sql, obj.ToArray());

            return count;
        }

        public override List<Evento> ObterTodos()
        {
            var sql = "SELECT * FROM EVENTOS E " +
                      "WHERE E.EXCLUIDO = 0 " +
                      "ORDER BY E.DATAFIM DESC ";

            return Db.Database.GetDbConnection().Query<Evento>(sql).ToList();
        }

        public override void Remover(Guid id)
        {
            var evento = ObterPorId(id);
            evento.ExcluirEvento();
            Atualizar(evento);
        }
    }
}
