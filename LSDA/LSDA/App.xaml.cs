using LSDA.Database;
using LSDA.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace LSDA
{
    public partial class App : Application
    {
        public static readonly DatabaseContext DatabaseContext = new();

        public static User? CurrentUser { get; set; }
        public App()
        {
            DatabaseContext.Users.Load();
            DatabaseContext.Parties.Load();
            DatabaseContext.Votes.Load();
            DatabaseContext.Roles.Load();
            DatabaseContext.Participants.Load();
            DatabaseContext.Results.Load();
        }
    }
}
