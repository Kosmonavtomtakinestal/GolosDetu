using System.ComponentModel.DataAnnotations.Schema;

namespace LSDA.Database.Models
{
    public partial class Participant
    {
        [NotMapped]
        public string? FullName =>  $"{Surname} {Name} {Patronymic}";
    }
}
