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
    public partial class FormulasPivotPage : PhoneApplicationPage
    {
        #region Declarations

        // The class which creates and manages all pages to display
        public PageManager pageManager;

        // The class which handles and supplies all required data
        public DataFeed dataFeed;

        // An array of all page names
        string[] pageNames;

        #endregion

        public FormulasPivotPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
            AssemblePages();     // Here or inside Initialize() ?  ALSO SEE UNITS
            DisplayPages();
        }

        private void Initialize()
        {
            // TODO: Add pivots title here rather than in xaml to make more dynamic ALSO SEE UNITS
            
            // Initialize classes that create displays and handle data
            pageManager = new PageManager();
            dataFeed = new DataFeed(this.FormulasPivot.Name);     // Better way?
            
            // Load the page titles
            pageNames = dataFeed.GetPageTitles();

            //AssemblePages();    ??   ALSO SEE UNITS
            //DisplayPages();
        }

        private void AssemblePages()
        {
            // Pass all page titles to page manager in order to create respective pages
            // Data comes from the dataFeed in the form of a List<string> of data points for the respective page
            foreach (string pageTitle in pageNames)
            {
                pageManager.CreatePage(pageTitle);
                pageManager.PopulatePage(pageTitle, dataFeed.GetPageData(pageTitle));
            }
        }

        private void DisplayPages()
        {
            // Add one PivotItem per pagetitle to the Parent pivot
            foreach(string pageTitle in pageNames)
            {
                FormulasPivot.Items.Add(pageManager.GetPage(pageTitle));
            }
        }
    }
}