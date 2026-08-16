using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views
{
    public partial class NovoProduto : ContentPage
    {
        private readonly SQLiteDatabaseHelper _databaseHelper;

        public NovoProduto(SQLiteDatabaseHelper databaseHelper)
        {
            InitializeComponent();

            _databaseHelper = databaseHelper;
        }

        private async void OnSalvarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                await DisplayAlertAsync(
                    "Atenção",
                    "Digite a descrição do produto.",
                    "OK"
                );

                return;
            }

            if (!double.TryParse(txtQuantidade.Text, out double quantidade))
            {
                await DisplayAlertAsync(
                    "Atenção",
                    "Digite uma quantidade válida.",
                    "OK"
                );

                return;
            }

            if (!double.TryParse(txtPreco.Text, out double preco))
            {
                await DisplayAlertAsync(
                    "Atenção",
                    "Digite um preço válido.",
                    "OK"
                );

                return;
            }

            Produto produto = new Produto
            {
                Descricao = txtDescricao.Text,
                Quantidade = quantidade,
                Preco = preco
            };

            await _databaseHelper.Insert(produto);

            await DisplayAlertAsync(
                "Sucesso",
                "Produto cadastrado com sucesso!",
                "OK"
            );

            txtDescricao.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
        }
    }
}