using System.Windows.Controls;
using System.Windows.Input;

namespace ToDoApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for TarefaView.xaml
    /// </summary>
    public partial class TarefaView : UserControl
    {
        public TarefaView()
        {
            InitializeComponent();
        }

        //MÉTODO DE EVENTO. RODA QUANDO CLICA COM O MOUSE EM ALGUM ITEM DA LISTA
        private void ListBoxItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //sender -> QUEM DISPAROU O EVENTO (O ITEM CLICADO)
            //e -> INFORMAÇÕES DO CLIQUE (QUAL BOTÃO DO MOUSE FOI CLICADO: ESQUERDO OU DIREITO)

            //VERIFICA SE QUEM DISPAROU O EVENTO É UM "ListBoxItem". SE FOR, GUARDA ELE NA VARIÁVEL "item"
            if (sender is ListBoxItem item)
            {
                //FORÇA O ITEM CLICADO A FICAR SELECIONADO
                item.IsSelected = true;
            }
        }
    }
}
