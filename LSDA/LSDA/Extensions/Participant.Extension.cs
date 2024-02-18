namespace LSDA.Database.Models
{
    public partial class Participant
    {
        private string fullname = null!;

        public string Fullname
        {
            get => fullname;
            set
            {
                fullname = $"{Surname} {Name} {Patronymic}";
            }
        }
    }
}
