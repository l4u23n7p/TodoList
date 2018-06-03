using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        private TodoItem item;
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(TodoItem todoItem) : base()
        {
            InitializeComponent();
            item = todoItem;
            BindingContext = item;

            if (item.IsDone)
                Done.IsVisible = false;
            else
                Done.IsVisible = true;
        }

        public async void BtnDone(object sender, EventArgs e)
        {
            Done.IsEnabled = false;
            TodoItem newItem = new TodoItem
            {
                ID = item.ID,
                Text = item.Text,
                CreatedDate = item.CreatedDate,
                Description = item.Description,
                IsDone = true,
                DoneDate = DateTime.Now,
                Priority = item.Priority
            };
            if (await ItemsService.UpdateItem(newItem))
            {
                await DisplayAlert("Succes", "Item modifié", "Ok");
                Done.IsVisible = false;
            }
            else
            {
                await DisplayAlert("Erreur", "une erreur est survenue", "Ok");
                Done.IsEnabled = true;
            }
        }
    }
}