using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;


namespace DisplayWSVuelos_1._0._0
{
    /// <summary>
    /// Descripción breve de WS_Vuelos_1__0__0
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Vuelos_1__0__0 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet ListarVuelos()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-41O2J8S\\SQLEXPRESS; Initial Catalog=bd_vuelo; Integrated Security=True;";
            SqlDataAdapter ad = new SqlDataAdapter("Select * from pasajes", conn);
            DataSet dataSet = new DataSet();
            ad.Fill(dataSet);
            return dataSet;
        }

        [WebMethod]
        public DataSet IdVuelo(int vuelo)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-41O2J8S\\SQLEXPRESS; Initial Catalog=bd_vuela; Integrated Security=True;";
            SqlDataAdapter ad = new SqlDataAdapter("EXEC dbo.SP_consultaIdVuelos @vuelo =" + vuelo, conn);
            DataSet dataSet = new DataSet();
            ad.Fill(dataSet);
            return dataSet;
        }

        [WebMethod]
        public DataSet IdPasajero(int id)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-41O2J8S\\SQLEXPRESS; Initial Catalog=bd_vuela; Integrated Security=True;";
            SqlDataAdapter ad = new SqlDataAdapter("EXEC dbo.SP_consultaRut @id =" + id,  conn);
            DataSet dataSet = new DataSet();
            ad.Fill(dataSet);
            return dataSet;
        }
    }
}
