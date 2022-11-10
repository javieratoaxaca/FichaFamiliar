using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AppFichaFamiliar.Config;
using System.Data;

namespace AppFichaFamiliar.Modelo
{
    class capaNegocioRegiones:ConexionBD
    {
        //este metodo lo tengo como un DataTable para que cargue todos los datos de mi consulta y pueda manipular los campos dentro de mi ComboBox
        public DataTable CargarCmbRegion()
        {
            try
            {

                var query = string.Format("SELECT idRegion,nomRegion FROM regiones");//creamos la consulta a la base 
                //creamos el cmd para que se lleve el query y cargue la conexion con la DB
                var cmd = new MySqlCommand(query, GetConnection());

                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
