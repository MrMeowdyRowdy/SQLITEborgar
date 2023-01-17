using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class AddUpdateBorgarDetail : ContentPage
{
    public AddUpdateBorgarDetail(AddUpdateBorgarODModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}