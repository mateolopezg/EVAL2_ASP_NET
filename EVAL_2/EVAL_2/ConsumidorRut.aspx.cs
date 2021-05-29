using System;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EVAL_2
{
    public partial class ConsumidorRut : System.Web.UI.Page
    {
        ServiceReference1.WS_Vuelos_1__0__0SoapClient WS = new ServiceReference1.WS_Vuelos_1__0__0SoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);

                DataSet ds = WS.IdPasajero(id);
                GridView1.Visible = true;
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error : ", err);
            }
        }
    }
}