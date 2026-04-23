namespace XamarinFormsAssesment
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddEntryPage), typeof(AddEntryPage));
            Routing.RegisterRoute(nameof(ViewEntryPage), typeof(ViewEntryPage));
        }
    }
}
