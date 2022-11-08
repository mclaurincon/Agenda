using Microsoft.EntityFrameworkCore;
using Agenda.Model;

namespace Agenda.Contexto
{
    public class TarefaContexto : DbContext
    {
        public TarefaContexto(DbContextOptions<TarefaContexto>options) : base(options)
        {

        }
        public DbSet<Tarefa> tarefas { get; set; } = null;
    }
}
