using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection.Emit;
using ToDoApp.WPF.Commands;
using ToDoApp.WPF.Models;
using ToDoApp.WPF.Repository;

namespace ToDoApp.WPF.ViewModels
{
    public class TarefaViewModel : BindableBase
    {
        private readonly TarefaRepository _repository;

        public ObservableCollection<TarefaModel> Tarefas { get; set; }

        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private TarefaModel _tarefaSelecionada;
        public TarefaModel TarefaSelecionada
        {
            get => _tarefaSelecionada;
            set
            {
                SetProperty(ref _tarefaSelecionada, value);
                RemoverCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AdicionarCommand { get; }
        public RelayCommand ConcluirCommand { get; }
        public RelayCommand RemoverCommand { get; }

        public TarefaViewModel()
        {
            _repository = new TarefaRepository();

            Tarefas = new ObservableCollection<TarefaModel>(_repository.Listar());

            AdicionarCommand = new RelayCommand(_ => Adicionar());
            ConcluirCommand = new RelayCommand(t => Concluir());
            RemoverCommand = new RelayCommand(_ => Remover(), _=> TarefaSelecionada != null);
        }

        private void Adicionar()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
                return;

            var tarefa = new TarefaModel
            (
                Titulo
            );

            _repository.Adicionar(tarefa);
            Tarefas.Add(tarefa);

            Titulo = string.Empty;
            AtualizarLista();
        }

        private void Remover()
        {
            if (TarefaSelecionada == null)
                return;

            _repository.Remover(TarefaSelecionada);
            AtualizarLista();
        }

        private void Concluir()
        {
            if (TarefaSelecionada == null)
                return;

            TarefaSelecionada.AtribuirConclusao();
            _repository.Atualizar(TarefaSelecionada);

            RaisePropertyChanged(nameof(Tarefas));
        }

        private void AtualizarLista()
        {
            Tarefas.Clear();
            foreach (var item in _repository.Listar())
                Tarefas.Add(item);
        }
    }
}
