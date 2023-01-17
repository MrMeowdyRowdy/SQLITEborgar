using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class StudentListPage : ContentPage
{
    private BorgarListODModel _viewMode;
    public StudentListPage(BorgarListODModel viewModel)
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