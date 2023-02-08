using DevExpress.CodeParser;
using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Native.Json;
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
using Newtonsoft.Json;
using SimpleProjectManager.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static DevExpress.Office.Utils.HdcOriginModifier;

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

                var currentcustomer = (Customer)View.CurrentObject;
                currentcustomer.Street = paramValue;
                
                string url = "https://wl-api.mf.gov.pl/api/search/nip/" + paramValue + "?date=" + DateTime.Now.ToString("yyyy-MM-dd");
               
                WebRequest requestObjectGet = WebRequest.Create(url);
                requestObjectGet.Method = "GET";
                HttpWebResponse responseObjectGet = null;
               
                    responseObjectGet = (HttpWebResponse)requestObjectGet.GetResponse();

                    string responsestr = null;
                    using (Stream stream = responseObjectGet.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(stream);
                        responsestr = sr.ReadToEnd();
                        sr.Close();
                    }
                    Console.WriteLine(responsestr);
                
                var companyModel = JsonConvert.DeserializeObject<CompanyModel>(responsestr);
                
                Console.WriteLine(companyModel.result.subject.name.ToString());
                currentcustomer.CustomerName= companyModel.result.subject.name;
                currentcustomer.VatNumber = companyModel.result.subject.nip;
                currentcustomer.Regon = companyModel.result.subject.regon;
                currentcustomer.NumberInRegisterOfRecords = companyModel.result.subject.krs;
                //currentcustomer.Street = companyModel.result.subject.workingAddress.Substring(0, companyModel.result.subject.workingAddress.IndexOf(",", StringComparison.Ordinal));
                string[] customerAddress = companyModel.result.subject.workingAddress.Split(",");
                currentcustomer.Street = customerAddress[0];
                currentcustomer.PostalCode = customerAddress[1].Substring(1, 7);
                currentcustomer.City = customerAddress[1].Substring(8, customerAddress[1].Length - 8);
               
                
            }
                
        }

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
