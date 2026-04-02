using System;

namespace ToDoApp.WPF.Models
{
    public class TarefaModel : BaseModel
    {
        public string Titulo { get; private set; } = string.Empty;
        public bool Concluida { get; private set; } = false;

        public TarefaModel(string titulo)
        {
            Id = Guid.NewGuid();
            AtribuirTitulo(titulo);
        }

        public void AtribuirTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo) || titulo.Equals(Titulo))
                return;

            Titulo = titulo;
        }

        public void AtribuirConclusao()
        {
            if (!Concluida)
            {
                Concluida = true;
                return;
            }

            Concluida = false;
        }
    }
}
