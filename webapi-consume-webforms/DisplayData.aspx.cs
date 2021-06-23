using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webapi_consume_webforms.Models;
using System.Net.Http;

namespace webapi_consume_webforms
{
    public partial class DisplayData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<EmpClass> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:51460/api/");

            var consumeapi = hc.GetAsync("EmpDetails");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<EmpClass>>();
                displayrecords.Wait();

                empobj = displayrecords.Result;
                GridView1.DataSource = empobj;
                GridView1.DataBind();
            }
        }
    }
}