using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class BorgarListPage : ContentPage
{
    private BorgarListODModel _viewMode;
    public BorgarListPage(BorgarListODModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetBorgarListDOCommand.Execute(null);
    }
}