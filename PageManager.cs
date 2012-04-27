#region Using Statements
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Microsoft.Phone.Controls;
#endregion

namespace PhysicsCS
{
    public class PageManager
    {
        // Get the number of current pages on the managed pivot
        public int PageCount
        {
            get { return Pages.Count; }
        }

        public Dictionary<string, PivotItem> Pages
        {
            get;
            private set;
        }

        public PageManager()
        {
            Pages = new Dictionary<string, PivotItem>();
        }

        public void CreatePage(string pageTitle)
        {
            PivotItem newPage = new PivotItem();
            newPage.Header = pageTitle;
            Pages.Add(pageTitle, newPage);
        }

        public void PopulatePage(string pageTitle, List<string> pageData)
        {
            StackPanel contentPanel = new StackPanel();
            
            foreach(string data in pageData)
            {
                TextBlock text = new TextBlock();
                text.Text = data;
                contentPanel.Children.Add(text);
            }

            Pages[pageTitle].Content = contentPanel;
        }

        public PivotItem GetPage(string pageTitle)
        {
            return Pages[pageTitle];
        }
    }
}
