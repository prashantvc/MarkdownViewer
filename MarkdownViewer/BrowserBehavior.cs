using System.Windows;
using System.Windows.Controls;

namespace MarkdownViewer
{
    public class BrowserBehavior
    {
        public static readonly DependencyProperty HtmlTextProperty = DependencyProperty.RegisterAttached(
            "HtmlText",
            typeof(string),
            typeof(BrowserBehavior),
            new FrameworkPropertyMetadata(OnHtmlChanged));

        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static string GetHtmlText(WebBrowser browser)
        {
            return (string)browser.GetValue(HtmlTextProperty);
        }

        public static void SetHtmlText(WebBrowser browser, string value)
        {
            browser.SetValue(HtmlTextProperty, value);
        }

        static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = dependencyObject as WebBrowser;
            webBrowser?.NavigateToString(e.NewValue as string ?? "&nbsp;");
        }
    }
}