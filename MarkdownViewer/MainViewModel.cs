using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace MarkdownViewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string _markdownText;
        string _htmlText;
        readonly string _style;

        public MainViewModel()
        {
            MarkdownText = "\r\nAnalogClock is a classic clock containing hour, minute, and second hands, with a circle of \r\ntick marks showing minutes and hours. A single solution contains versions for iOS, Android, and Windows Phone. \r\n\r\n**If you open the solution in Xamarin Studio, it will not be able to load the Windows Phone project;\r\nand if you open the solution in Xamarin Studio under Windows, it will not be able to load the iOS project either.**\r\n\r\nAll three versions share a *ClockModel* class that implements the *INotifyPropertyChanged* interface, \r\nand provides angle values for the clock hands. The *ClockModel* class also creates a rudimentary timer \r\nusing the *await* operator and the *Task.Delay* method.\r\n\r\nAll three versions draw the clockface ticks using a circle rendered with a dotted line.\r\nThe iOS and Android versions draw the clock hands from code using a graphics path with Bezier curves.\r\nThe Windows Phone version defines the clock entirely in XAML and is updated from the *ClockModel*\r\nclass defined as a resource.\r\n\r\nAuthor\r\n------\r\n\r\nCharles Petzold";
            _style = File.ReadAllText("markdown.css");
        }

        public string MarkdownText
        {
            get => _markdownText;
            set
            {
                _markdownText = value;
                OnPropertyChanged();
            }
        }

        public string HtmlText
        {
            get => _htmlText;
            set
            {
                _htmlText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ConvertMarkdown()
        {
            string html = Markdig.Markdown.ToHtml(MarkdownText);
            HtmlText = $"<html>\n<head>\n<style>\n{_style}\n</style>\n</head>\n<body class=\"markdown-body\">\n{html}\n</body>\n</html>";
        }
    }
}