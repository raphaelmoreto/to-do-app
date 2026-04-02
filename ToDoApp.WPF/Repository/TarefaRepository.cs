using System.Collections.Generic;
using ToDoApp.WPF.Models;

namespace ToDoApp.WPF.Repository
{
    public class TarefaRepository
    {
        private readonly List<TarefaModel> _tarefas = new List<TarefaModel>();

        public List<TarefaModel> Listar()
        {
            return _tarefas;
        }

        public void Adicionar(TarefaModel tarefa)
        {
            _tarefas.Add(tarefa);
        }

        public void Atualizar(TarefaModel tarefa)
        {
            // Como é lista em memória, já está atualizado por referência
        }

        public void Remover(TarefaModel tarefa)
        {
            _tarefas.Remove(tarefa);
        }
    }
}
