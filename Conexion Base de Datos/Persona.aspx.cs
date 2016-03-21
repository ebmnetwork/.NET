using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace PRUEBAS
{
    public partial class Persona1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
            ListarEmpleados();
        }

        public void ListarEmpleados()
        {
            using (SqlConnection cn = AccesoDatos.ConexionSql("nameAppConfig"))
            {
                //hacemos la consulta a la base de datos
                SqlCommand cmd = new SqlCommand("Select * from TB_EMPLEADO", cn);
                //objeto adapter para hacer el enlace y llenado del dataset
                SqlDataAdapter adapter = new SqlDataAdapter();
                //asignamos la propiedad selectcommand al objeto command para que ejecute consulta
                adapter.SelectCommand = cmd;
                //abrimos la conexion
                cn.Open();
                //creamos objeto dataset
                DataSet objdataset = new DataSet();
                //llenamos el datable del dataset
                //el metodo fill obtiene los datos recuperados del dataadapter y los coloca dentro del dataset
                adapter.Fill(objdataset);
                //cerramos conexion
                cn.Close();
                //enlazamos los datos al griedvied
                GridView1.DataSource = objdataset;
                GridView1.DataBind();
            }
        }
    }
}