#region Using Statements
using System;
using System.Net;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
#endregion

namespace PhysicsCS
{
    public class DataFeed
    {
        // Instance Variables
        // All of the page data, key: (string) Page title;
        //                       Value: (List<string>) Strings of data 
        Dictionary<string, List<string>> PageData;

        // Name of parent page
        string Parent;

        // Initialize Method
        public DataFeed(string ParentName)
        {
            Parent = ParentName;
            PageData = new Dictionary<string, List<string>>();
            LoadData();
        }

        // Load Data 
        public void LoadData()
        {
            // TODO: Database?
            /******* Formulas *******/
            // Common Formulas Page
            List<string> F_Common = new List<string>();
            F_Common.Add("Velocity\n-> V = Vo + (a * t)");
            F_Common.Add("Kinetic Energy\n-> KE = 1/2 * m * v^2");
           
            // Work and Energy Page
            List<string> F_WorkAndEnergy = new List<string>();
            F_WorkAndEnergy.Add("Kinetic Energy\n-> KE = 1/2 * m * v^2");
            F_WorkAndEnergy.Add("Potential Energy(Gravity)\n-> PE = m * g * h");
            F_WorkAndEnergy.Add("Potential Energy(spring)\n-> PE = 1/2 * k * x^2");

            /******* Units *******/
            // S.I Units
            List<string> U_SIunits = new List<string>();
            U_SIunits.Add("Force -> Newtons(N)");
            U_SIunits.Add("Mass -> Kilograms(kg)");
            U_SIunits.Add("Displacement -> Meters(m)");

            /******* Quick Review *******/
            // Topics Page
            List<string> ReviewTopics = new List<string>();
            ReviewTopics.Add("Motion(Constant Acceleration)");
            ReviewTopics.Add("Work and Energy");
            ReviewTopics.Add("Electricity");
            ReviewTopics.Add("Magnetism");

            // Index Page
            List<string> ReviewIndex = new List<string>();
            ReviewIndex.Add("Capacitance");
            ReviewIndex.Add("Kinetic Energy");
            ReviewIndex.Add("Torque");

            /******* Common Pages *******/
            // Error Page
            List<string> ErrorPage = new List<string>();
            ErrorPage.Add("Oops!");
            ErrorPage.Add("Seems as though there has been an error...");

            switch(Parent)
            {
                case "FormulasPivot":
                    PageData.Add("Common", F_Common);
                    PageData.Add("Work & Energy", F_WorkAndEnergy);
                    PageData.Add("Error", ErrorPage);
                    break;
                case "UnitsPivot":            
                    PageData.Add("SI Units", U_SIunits);
                    PageData.Add("Error", ErrorPage);
                    break;
                case "QuickReviewPivot":
                    PageData.Add("Topics", ReviewTopics);
                    PageData.Add("Index", ReviewIndex);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(Parent, "DataFeed Parent name invalid");
            }
        }

        // Provide titles of pages
        public string[] GetPageTitles()
        {
            string[] pageTitles = new string[PageData.Count];
            PageData.Keys.CopyTo(pageTitles, 0);

            //int i = 0;
            //foreach (string key in PageData.Keys)
            //{
            //    pageTitles[i] = key;
            //}

            return pageTitles;
        }

        // Provide data for requested page
        public List<string> GetPageData(string PageTitle)
        {
            return PageData[PageTitle];
        }
    }
}
