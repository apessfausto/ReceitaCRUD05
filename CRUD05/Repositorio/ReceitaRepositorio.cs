using CRUD05.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD05.Repositorio
{
    public class ReceitaRepositorio
    {
        public int Salvar(Receita receita)
        {
            using (Context ctx = new Context())
            {
                ctx.Receitas.Add(receita);
                return ctx.SaveChanges();

            }

        }

        public int Deletar(Receita receita)
        {
            using (Context ctx = new Context())
            {
                ctx.Receitas.Attach(receita);
                ctx.Entry(receita).State = EntityState.Deleted;
                return ctx.SaveChanges();

            }

        }

        public int Editar(Receita receita)
        {
            using (Context ctx = new Context())
            {
                ctx.Receitas.Attach(receita);
                ctx.Entry(receita).State = EntityState.Modified;
                return ctx.SaveChanges();

            }

        }

        public List<Receita> Listar()
        {
            using (Context ctx = new Context())
            {
                return ctx.Receitas.ToList();
            }

        }
    }
}
