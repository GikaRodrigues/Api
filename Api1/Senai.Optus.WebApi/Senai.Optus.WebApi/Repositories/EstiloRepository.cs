using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Cadastrar(Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilos);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscada = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilos.IdEstilo);
                EstiloBuscada.Nome = estilos.Nome;
                ctx.Estilos.Update(EstiloBuscada);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscada = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(EstiloBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
