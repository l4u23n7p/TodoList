using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Services;
using TodoList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItem : ContentPage
    {
        public NewItem()
        {
            InitializeComponent();
        }

        public async void BtnSave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(text.Text) && !string.IsNullOrWhiteSpace(description.Text))
            {

                TodoItem newItem = new TodoItem();
                newItem.ID = await ItemsService.LastID();
                newItem.Text = text.Text;
                newItem.Description = description.Text;
                newItem.CreatedDate = DateTime.Now;
                if (await ItemsService.AddNewItem(newItem))
                {
                    await DisplayAlert("Succes !", "L'item est créé", "Ok");
                    ItemViewModel.RefreshData();
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("Erreur !", "Une erreur est survenue", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Erreur !", "Les champs sont vides", "Ok");
            }
        }
    }
}