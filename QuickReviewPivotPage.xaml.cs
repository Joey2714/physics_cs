#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
#endregion

namespace PhysicsCS
{
    public partial class QuickReviewPivotPage : PhoneApplicationPage
    {
        #region Declarations

        // The class which creates and manages all pages to display
        public PageManager pageManager;

        // The class which handles and supplies all required data
        public DataFeed dataFeed;

        // An array of all page names
        string[] pageNames;

        #endregion

        public QuickReviewPivotPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
            AssemblePages();
            DisplayPages();
        }

        private void Initialize()
        {
            // Initialize classes that create displays and handle data
            pageManager = new PageManager();
            dataFeed = new DataFeed(this.QuickReviewPivot.Name);  // Gotta be a better way
            
            // Load page titles
            pageNames = dataFeed.GetPageTitles();
        }

        private void AssemblePages()
        {
            // Pass all page titles to page manager to create respective pages
            foreach (string pageTitle in pageNames)
            {
                pageManager.CreatePage(pageTitle);
                pageManager.PopulatePage(pageTitle, dataFeed.GetPageData(pageTitle));
            }
        }

        private void DisplayPages()
        {
            // Add one PivotItem per pagetitle to the Parent pivot
            foreach (string pageTitle in pageNames)
            {
                QuickReviewPivot.Items.Add(pageManager.GetPage(pageTitle));
            }
        }
    }
}