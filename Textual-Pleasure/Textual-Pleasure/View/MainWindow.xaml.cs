using Engine.ViewModel;

namespace Textual_Pleasure.View
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private GameSession session;
    
    public MainWindow()
    {
      InitializeComponent();
      session = new GameSession();
      DataContext = session;
    }
  }
}
