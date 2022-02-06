using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using ToDo.App.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.App.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage {

        public HomePage() {
            InitializeComponent();
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            LoadItems();
        }

        private async void LoadItems() {
            var items = await App.Context.GetItemsAsync();
            Lista_Tareas.ItemsSource = items;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new AddPage());
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e) {
            if (await DisplayAlert("Confirmacion", "Estas seguro de eliminar el elemento?", "si", "no")) {
                var item = (ToDoItem)(sender as MenuItem).CommandParameter;
                var result = await App.Context.DeleteItemAsync(item);

                if (result == 1) {
                    LoadItems();
                }
            }
        }
        private async void btnEdit_Clicked(object sender, EventArgs e) {
            ToDoItem item = (ToDoItem)((Button)sender).CommandParameter;
            await Navigation.PushAsync(new EditPage(item));
        }
    }
}