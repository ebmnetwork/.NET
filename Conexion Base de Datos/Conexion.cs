using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; //Debe ser agregado
using System.Collections;

namespace PRUEBAS
{
    public class AccesoDatos
    {
       public static SqlConnection ConexionSql(string conString)
        {

            try
            {
                string ctn = ConfigurationManager.ConnectionStrings["nameAppConfig"].ToString();
                SqlConnection cn = new SqlConnection(ctn);
                return cn;
            }
            catch (Exception ex)
            {

                throw new ArgumentException ("Error al Conectar",ex);
            }
            
        }

    }
}