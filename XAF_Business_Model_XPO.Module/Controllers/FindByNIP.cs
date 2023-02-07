using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Native.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.XtraPrinting;
using MySolution.Module.BusinessObjects;
using SimpleProjectManager.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace XAF_Business_Model_XPO.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FindByNIP : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public FindByNIP()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

            TargetViewType = ViewType.DetailView; ;
            //Activate the controller only for root Views.
            TargetViewNesting = Nesting.Root;
            //Specify the type of objects that can use the controller.    
            TargetObjectType = typeof(Customer);

            ParametrizedAction findByNIP =
            new ParametrizedAction(this, "FindByNIP", PredefinedCategory.View, typeof(string))
            {
                ImageName = "Action_Search",
                NullValuePrompt = "Find company by NIP..."
            };
            findByNIP.Execute += FindByNIP_Execute;
        }
        private void FindByNIP_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            string paramValue = e.ParameterCurrentValue as string;

            if (paramValue.All(char.IsDigit) == true && paramValue.Length == 10)
            {
                string response;
               // API(paramValue);
                var currentcustomer = (Customer)View.CurrentObject;
                currentcustomer.Street = paramValue;

            }


        }
        
       
        /*
        static async void API(string NIP)
        {
            HttpClient httpClient = new HttpClient();

            string requestAddress = "https://wl-api.mf.gov.pl//api/search/nip/" + NIP + "?date=" + DateTime.Now.Date.ToString();

            string response = await httpClient.GetStringAsync(requestAddress);
            Console.WriteLine("https://wl-api.mf.gov.pl//api/search/nip/" + NIP + "?date=" + DateTime.Now.ToString("yyyy-MM-dd"));
           
          
            return response;

        }
        */
       
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
