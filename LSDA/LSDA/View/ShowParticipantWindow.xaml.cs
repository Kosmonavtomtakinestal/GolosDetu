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
    }
}
