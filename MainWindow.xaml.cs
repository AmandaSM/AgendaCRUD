using AgendaCrud.Data;
using AgendaCrud.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace AgendaCrud
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();


        }

        IClienteRepository repository = new SqLiteClienteRepository();
        TbCliente cliente = new TbCliente();

        private string Operacao { get; set; }

        //Eventos

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidarCampos() == true)
            {
                //pegando dados da tela

                cliente = new TbCliente();


                cliente.nome = textNome.Text;
                cliente.telefone = textTelefone.Text;

                //gravando dados
                if (Operacao == "inserir")
                {
                    repository.SaveTbCliente(cliente);
                    if (cliente.id <= 0)
                    {
                        MessageBoxResult result = MessageBox.Show("falha ao salvar os dados");
                    }
                    else
                    {
                        this.AtualizarGrid();
                    }

                }
                else if (Operacao == "alterar")
                {
                    cliente.id = Convert.ToInt32(textID.Text);

                    this.repository.AlterarCliente(cliente);

                    if (cliente.id <= 0)
                    {
                        MessageBoxResult result = MessageBox.Show("falha ao salvar os dados");
                    }
                    else
                    {
                        this.AtualizarGrid();
                    }

                }

                this.LimparTela();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Preencha os campos!");

            }

        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {

            //configuração de localizar
            this.Operacao = "localizar";
            this.DesabilitarBotao(this.Operacao);
            this.VerificarDadosPLocalizar();
            this.LimparTela();
            textID.IsReadOnly = true;


        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            this.Operacao = "inserir";
            textID.IsReadOnly = true;
            this.DesabilitarBotao(this.Operacao);
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            this.Operacao = "alterar";
            this.DesabilitarBotao(Operacao);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimparTela();
            this.Operacao = "cancelar";
            this.DesabilitarBotao(Operacao);
            textID.IsReadOnly = false;

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Operacao = "excluir";
                cliente = new TbCliente();
                cliente.id = Convert.ToInt32(textID.Text);
                this.repository.DeleteCliente(cliente);
                this.AtualizarGrid();
                MessageBoxResult result = MessageBox.Show($"Registro {cliente.id} excluido com sucesso");
                this.LimparTela();


            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show($"Registro {cliente.id} falha ao excluir ");


            }

        }

        private void GridDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dgvDados.SelectedIndex >= 0)
                {
                    cliente = (TbCliente)dgvDados.SelectedItem;
                    textID.Text = cliente.id.ToString();
                    textNome.Text = cliente.nome;
                    textTelefone.Text = cliente.telefone;
                    this.Operacao = "grid";
                    this.DesabilitarBotao(this.Operacao);
                }
            }
            catch (Exception)
            {

                MessageBoxResult result = MessageBox.Show("falha ao carregar dados");
            }

        }


        //Métodos

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

            AtualizarGrid();
        }

        private void LimparTela()
        {
            //limpando dados da tela
            textID.IsReadOnly = false;
            textNome.Clear();
            textTelefone.Clear();
            if (this.Operacao != "localizar")
            {
                textID.Clear();

            }
        }

        private void AtualizarGrid()
        {

            dgvDados.ItemsSource = repository.GetListaCliente();

        }

        private void AtualizarGrid(String nomeCampo, string valor)
        {
            var valorA= repository.GetListaLocalizarCliente(nomeCampo, valor);
            if (valorA.Count >0)
            {
                dgvDados.ItemsSource = valorA;
                this.LimparTela();
            }
            else
            {
                MessageBoxResult msn = MessageBox.Show(" dados não existente no banco!");
            }
           
        }

        private void DesabilitarBotao(String operacao)
        {
            btnAlterar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnInserir.IsEnabled = false;
            btnLocalizar.IsEnabled = false;
            btnExcluir.IsEnabled = false;
            btnSalvar.IsEnabled = false;

            if (operacao == "inserir" || operacao == "cancelar")
            {
                textID.IsReadOnly = true;
                btnInserir.IsEnabled = true;
                btnSalvar.IsEnabled = true;
                btnCancelar.IsEnabled = true;
                btnAlterar.IsEnabled = true;
                btnLocalizar.IsEnabled = true;


            }
            else if (operacao == "localizar")
            {
                textID.IsReadOnly = true;
                btnAlterar.IsEnabled = true;
                btnLocalizar.IsEnabled = true;
                btnExcluir.IsEnabled = true;
            }
            else if (operacao == "alterar")
            {
                textID.IsReadOnly = true;
                btnSalvar.IsEnabled = true;
                btnAlterar.IsEnabled = true;
                btnInserir.IsEnabled = true;
                btnLocalizar.IsEnabled = true;
                btnExcluir.IsEnabled = true;
                btnCancelar.IsEnabled = true;

            }
            else if (operacao == "grid")
            {
                btnExcluir.IsEnabled = true;
                btnInserir.IsEnabled = true;
                btnCancelar.IsEnabled = true;
                btnAlterar.IsEnabled = true;
                btnLocalizar.IsEnabled = true;


            }

        }

        private void VerificarDadosPLocalizar()
        {
            try
            {
                if (textID.Text != "")
                {
                    List<TbCliente> listaClientePorId = new List<TbCliente>();
                    TbCliente dados = this.repository.GetTbCliente(Convert.ToInt32(textID.Text));
                    if (dados != null)
                    {
                        listaClientePorId.Add(dados);
                        dgvDados.ItemsSource = listaClientePorId;
                    }
                    else
                    {
                        MessageBoxResult msn = MessageBox.Show("ID pesquisado não existente");
                    }
                }

                if (textTelefone.Text != "")
                {
                    this.AtualizarGrid("telefone", textTelefone.Text);
                }
                if (textNome.Text != "")
                {
                    this.AtualizarGrid("nome", textNome.Text);

                }
            }
            catch (Exception)
            {

                MessageBoxResult result = MessageBox.Show("falha ao localizar os dados");

            }

        }

        private bool ValidarCampos()
        {
            if (Operacao == "inserir")
            {
                if ((textNome.Text != "") && (textTelefone.Text != ""))
                {
                    return true;

                }
            }else if ((textID.Text != "") && (textNome.Text != "") && (textTelefone.Text != ""))
            {
                return true;
            }
            return false;
        }

    }
}
