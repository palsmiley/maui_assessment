using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using XamarinFormsAssesment.Models;

namespace XamarinFormsAssesment;

public partial class AddEntryPage : ContentPage
{
    public AddEntryPage()
    {
        InitializeComponent();
    }

    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        App.PersonRepo.AddNewPerson(new Person { FirstName = firstName.Text, LastName = lastName.Text, DateOfBirth = dateOfBirth.Date ?? DateTime.Now });

        string text = "Entry added";
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;

        var toast = Toast.Make(text, duration, fontSize);
        toast.Show(cancellationTokenSource.Token);

        Navigation.PopAsync();
    }
}