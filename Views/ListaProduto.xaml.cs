using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        private readonly SQLiteDatabaseHelper _databaseHelper;

        public ListaProduto()
        {
            InitializeComponent();

            string dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "minhascompras.db3"
            );

            _databaseHelper = new SQLiteDatabaseHelper(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await CarregarProdutos();
        }

        private async Task CarregarProdutos()
        {
            List<Produto> produtos = await _databaseHelper.GetAll();

            listaProdutos.ItemsSource = produtos;
        }

        private async void OnNovoProdutoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new NovoProduto(_databaseHelper)
            );
        }
    }
}