using Windows.Storage;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();

        private void REB_Loaded(object sender, RoutedEventArgs e)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            var localValue = localSettings.Values["ts4"] as string;
            var text = string.IsNullOrEmpty(localValue) ? string.Empty : localValue;
            REB.Document.SetText(TextSetOptions.FormatRtf, text);
        }

        private void REB_TextChanged(object sender, RoutedEventArgs e)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            REB.Document.GetText(TextGetOptions.FormatRtf, out var tmpNar);
            if (!string.IsNullOrEmpty(tmpNar) && !string.IsNullOrWhiteSpace(tmpNar))
            {
                localSettings.Values["ts4"] = tmpNar;
            }
        }
    }
}
