using Engine.ViewModel;

namespace Textual_Pleasure.View
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();
      GameSession session = new GameSession();
        DataContext = session;
    }
  }
}
