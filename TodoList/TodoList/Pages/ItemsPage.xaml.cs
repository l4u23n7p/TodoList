using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Models;
using TodoList.Services;
using TodoList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            ItemsListView.ItemsSource = ItemViewModel.TodoItems;

            ItemsListView.RefreshCommand = RefreshCommand;

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as TodoItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(item));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    ItemsListView.IsRefreshing = true;

                    ItemViewModel.RefreshData();

                    ItemsListView.IsRefreshing = false;
                });
            }
        }

        public async void BtnAddItem(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItem()));
        }

    }
}