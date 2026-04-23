using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using XamarinFormsAssesment.Models;

namespace XamarinFormsAssesment;

public partial class ViewEntryPage : ContentPage
{
    Person data; 

	public ViewEntryPage(Person data)
	{
		InitializeComponent();
        this.data = data;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        id.Text = String.Format("ID: {0}", data.Id);
        firstName.Text = String.Format("First Name: {0}", data.FirstName);
        lastName.Text = String.Format("Last Name: {0}", data.LastName);
        dateOfBirth.Text = String.Format("Date of Birth: {0}", data.DateOfBirth.ToShortDateString());
    }

    public void OnDeleteButtonClicked(object sender, EventArgs args)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var temp = App.PersonRepo.GetPeopleData();
        App.PersonRepo.DeletePerson(temp.FirstOrDefault(x => x.Id == data.Id));

        string text = "Entry deleted.";
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;

        var toast = Toast.Make(text, duration, fontSize);
        toast.Show(cancellationTokenSource.Token);

        Navigation.PopAsync();
    }
}