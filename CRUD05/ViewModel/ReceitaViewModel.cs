using CRUD05.Model;
using CRUD05.Repositorio;
using Mvvm;
using Mvvm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD05.ViewModel
{
    public class ReceitaViewModel : BindableBase
    {

        private readonly ReceitaRepositorio _receitaRepositorio;

        private Receita _receita;

        public Receita Receita
        {
            get { return _receita; }
            set { SetProperty(ref _receita, value); }
        }


        private int _id;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _nomeReceita;

        public string NomeReceita
        {
            get { return _nomeReceita; }
            set { SetProperty(ref _nomeReceita, value); }
        }

        private string _estilo;

        public string Estilo
        {
            get { return _estilo; }
            set { SetProperty(ref _estilo, value); }
        }

        private string _ingredientes;

        public string Ingredientes
        {
            get { return _ingredientes; }
            set { SetProperty(ref _ingredientes, value); }
        }


        public DelegateCommand SalvarCommand { get; set; }
        public DelegateCommand EditarCommand { get; set; }
        public DelegateCommand DeletarCommand { get; set; }

        private List<Receita> _receitas;

        public List<Receita> Receitas
        {
            get { return _receitas; }
            set { SetProperty(ref _receitas, value); }
        }

        //construtor
        public ReceitaViewModel()
        {
            SalvarCommand = new DelegateCommand(Salvar);
            EditarCommand = new DelegateCommand(Editar);
            DeletarCommand = new DelegateCommand(Deletar);
            _receitaRepositorio = new ReceitaRepositorio();
            CarregarDados();
        }

        private void CarregarDados()
        {
            Receitas = new List<Receita>();
            Receitas = _receitaRepositorio.Listar();
        }

        private void Deletar()
        {
            int resultado = _receitaRepositorio.Deletar(new Receita { Id = Receita.Id, NomeReceita = Receita.NomeReceita, Estilo = Receita.Estilo, Ingredientes = Receita.Ingredientes });
            if (resultado == 1)
            {
                MessageBox.Show("Receita removida com sucesso");
             
            }
            else
            {
                MessageBox.Show("Erro ao deletar a receita");
            }
            CarregarDados();
            LimparTela();
        }

        private void Editar()
        {
            Id = Receita.Id;
            NomeReceita = Receita.NomeReceita;
            Estilo = Receita.Estilo;
            Ingredientes = Receita.Ingredientes;

        }

        private void Salvar()
        {

            int resultado = 0;

            if (Id == 0)
            {

                resultado = _receitaRepositorio.Salvar(new Receita { NomeReceita = NomeReceita, Estilo = Estilo, Ingredientes = Ingredientes });
            }
            else
            {

                resultado = _receitaRepositorio.Editar(new Receita { Id = Id, NomeReceita = NomeReceita, Estilo = Estilo, Ingredientes = Ingredientes });

            }
            if (resultado == 1)
            {
                MessageBox.Show("Receita salva com sucesso.");
                
            }
            else
            {
                MessageBox.Show("Erro ao salvar a receita");

            }
            LimparTela();
            CarregarDados();
        }

        private void LimparTela()
        {
            Id = 0;

            NomeReceita = string.Empty;
            Estilo = string.Empty;
            Ingredientes = string.Empty;

        }


    }
}
