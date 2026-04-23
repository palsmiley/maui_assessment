namespace XamarinFormsAssesment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var people = App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
        }

        private void OnAddClicked(object? sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(AddEntryPage));
        }

        private void OnViewClicked(object? sender, EventArgs e)
        {
            var temp = App.PersonRepo.GetPeopleData();
            var people = App.PersonRepo.GetAllPeople();
            var label = (Label)sender;
            var item = label.BindingContext;
            int index = people.IndexOf(item.ToString());

            Navigation.PushAsync(new ViewEntryPage(temp[index]));
        }
    }
}