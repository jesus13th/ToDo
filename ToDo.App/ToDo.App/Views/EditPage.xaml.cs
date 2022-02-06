using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDo.App.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.App.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage {
        public ToDoItem Item { get; private set; }
        public TimeSpan Time { get; set; }
        public EditPage(ToDoItem item) {
            InitializeComponent();
            Item = item;
            Time = Item.DateTime.TimeOfDay;
            BindingContext = this;
        }
        private async void guardarBtn_Clicked(object sender, EventArgs e) {
            try {
                var item = new ToDoItem {
                    Id = Item.Id,
                    Name = nombreEntry.Text,
                    Description = descripcionEntry.Text,
                    DateTime = registerDate.Date + registerTime.Time
                };

                var result = await App.Context.UpdateItemAsync(item);

                if (result == 1) {
                    await Navigation.PopAsync();
                } else {
                    await DisplayAlert("Error", "Hubo un error al actualiar la tarea", "Aceptar");
                }
            } catch (Exception ex) {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}