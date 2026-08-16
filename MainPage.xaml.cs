using MauiAppMinhasCompras.Views;

namespace MauiAppMinhasCompras
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnVerProdutosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaProduto());
        }

        private async void OnNovoProdutoClicked(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "minhascompras.db3"
            );

            var databaseHelper = new Helpers.SQLiteDatabaseHelper(dbPath);

            await Navigation.PushAsync(
                new NovoProduto(databaseHelper)
            );
        }
    }
}