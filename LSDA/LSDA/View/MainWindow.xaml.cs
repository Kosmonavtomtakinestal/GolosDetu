using LSDA.Database.Models;
using LSDA.Extensions;
using System.Collections.ObjectModel;
using System.Windows;
using Window = HandyControl.Controls.Window;

namespace LSDA.View
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Participant> Participants
        {
            get { return (ObservableCollection<Participant>)GetValue(ParticipantsProperty); }
            set { SetValue(ParticipantsProperty, value); }
        }
        public static readonly DependencyProperty ParticipantsProperty =
            DependencyProperty.Register("Participants", typeof(ObservableCollection<Participant>), typeof(MainWindow));


        public MainWindow()
        {
            Participants = App.DatabaseContext.Participants.TakeToObservable();

            InitializeComponent();
        }

        private void OpeningAccountClickButton(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser != null)
                return;

            new RegLogWindow().Show();
            Close();
        }

        private void ListParticipantsMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}