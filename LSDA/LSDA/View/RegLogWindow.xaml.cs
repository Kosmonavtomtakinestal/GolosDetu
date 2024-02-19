using LSDA.Database.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LSDA.View
{
    public partial class RegLogWindow : Window
    {
        public RegLogWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExitTabItem.IsSelected)
            {
                new MainWindow().Show();
                Close();
            }

            if (Auto.IsSelected)
            {
                AutoEll.Fill = Brushes.Black;
                RegEll.Fill = Brushes.Gray;
                return;
            }

            AutoEll.Fill = Brushes.Gray;
            RegEll.Fill = Brushes.Black;
        }

        private void AuthorizationClickButton(object sender, RoutedEventArgs e)
        {
            if (AutoPhoneTextBox.Text == "" || AutoIINTextBox.Text == "")
            {
                AutoErrors.Text = "Не правильный 'Номер телефона' или 'ИНН'";
                return;
            }

            User user = App.DatabaseContext.Users.FirstOrDefault(u => u.Inn == AutoIINTextBox.Text.Trim() && u.Phone == AutoPhoneTextBox.Text.Trim())!;

            if (user == null)
            {
                AutoErrors.Text = "Пользователя не существует";
                return;
            }

            App.CurrentUser = user;
            new MainWindow().Show();
            Close();
        }

        private void RegistrationClickButton(object sender, RoutedEventArgs e)
        {
            if (RegNameTextBox.Text == "" || RegSurnameTextBox.Text == "" ||
                RegPatronymicTextBox.Text == "" || RegSeriesTextBox.Text == "" ||
                RegNumberTextBox.Text == "" || RegPhoneTextBox.Text == "" ||
                RegIINTextBox.Text == "")
            {
                RegErrors.Text = "Проверьте введенные данные";
                return;
            }

            try
            {
                App.DatabaseContext.Users.Add
                    (
                        new User()
                        {
                            Inn = RegIINTextBox.Text.Trim(),
                            Name = RegNameTextBox.Text.Trim(),
                            Phone = RegPhoneTextBox.Text.Trim(),
                            Number = RegNumberTextBox.Text.Trim(),
                            Patronymic = RegPatronymicTextBox.Text.Trim(),
                            Series = RegSeriesTextBox.Text.Trim(),
                            Surname = RegSurnameTextBox.Text.Trim(),
                            Role = App.DatabaseContext.Roles.First()
                        }
                    );

                App.DatabaseContext.SaveChanges();
            }
            catch (Exception)
            {
                RegErrors.Text = "Проверьте введенные данные";
            }
        }
    }
}
