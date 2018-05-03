using System.Windows;

namespace Textual_Pleasure
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
      MainWindow window = new MainWindow();
      if (e.Args.Length == 1)
        MessageBox.Show($"Now opening file: \n\n{0}", e.Args[0]);
      window.Show();
    }
  }
}
