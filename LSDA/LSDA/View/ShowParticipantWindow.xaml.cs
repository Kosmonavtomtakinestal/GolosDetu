using LSDA.Database.Models;
using System.Windows;

namespace LSDA.View
{
    public partial class ShowParticipantWindow : Window
    {
        public Participant CurrentParticipant { get; set; }

        public ShowParticipantWindow(Participant participant)
        {
            CurrentParticipant = participant;

            InitializeComponent();
        }

        private void IsGolos_Checked(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser == null)
                return;

            App.DatabaseContext.Votes.Add
                (
                    new Vote()
                    {
                        Participant = CurrentParticipant,
                        User = App.CurrentUser!
                    }
                );

            if (CurrentParticipant.Result == null)
            {
                App.DatabaseContext.Results.Add
                    (
                        new Result()
                        {
                            Participant = CurrentParticipant,
                            Count = 1
                        }
                    );
            }
            else
                CurrentParticipant.Result.Count += 1;

            App.DatabaseContext.SaveChanges();
        }

        private void IsGolos_Unchecked(object sender, RoutedEventArgs e)
        {
            App.CurrentUser!.Votes.FirstOrDefault(x => x.Participant == CurrentParticipant)!.Participant.Result!.Count -= 1;

            App.DatabaseContext.Votes.Remove(App.CurrentUser!.Votes.FirstOrDefault(x => x.Participant == CurrentParticipant)!);

            App.DatabaseContext.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser == null)
                return;

            if (App.CurrentUser.Votes.FirstOrDefault(x => x.Participant == CurrentParticipant)! != null)
                IsGolos.IsChecked = true;

            Golos.Visibility = Visibility.Visible;
        }
    }
}
