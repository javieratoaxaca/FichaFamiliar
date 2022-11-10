using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AppFichaFamiliar.Config;
using AppFichaFamiliar.Data;
using System.Data;

namespace AppFichaFamiliar.Modelo
{
    class capaNegocioBajaTutora:ConexionBD
    {
        //Seccion de datos
        public capaDatosBajaTutora getBajaTutora(string idFamilia)
        {

            capaDatosBajaTutora cdBajaTutora = new capaDatosBajaTutora();

            try
            {
                var Query = string.Format("SELECT * FROM bajafamilia where idFamilia like '{0}' limit 1",idFamilia);
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdBajaTutora.AnioBaja = dr["baja"].ToString();
                    cdBajaTutora.BimBaja = dr["bim_baja"].ToString(); ;
                    cdBajaTutora.MotivoBaja = dr["motivo_baja"].ToString(); ;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdBajaTutora;
        }

        //verificacion si existe o no la Tutora
        public bool ExisteTutora(string idFamilia)
        {
            //capaDatosTutora ctd = new capaDatosTutora();
            //Data.Producto dtProducto = new Data.Producto();
            try
            {
                var Query = string.Format("SELECT idFamilia FROM bajafamilia WHERE idFamilia LIKE '{0}' limit 1", idFamilia);
                var dr = GetDataReader(Query);
                return dr.HasRows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void CargarGrid(DataGridView grid)
        {

            try
            {

                var query = string.Format("SELECT * from bajafamilia ");//creamos la consulta a la base 
                //creamos el cmd para que se lleve el query y cargue la conexion con la DB
                var cmd = new MySqlCommand(query, GetConnection());

                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                grid.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        //Metodo para cargar el DataGridView con el dato a buscar en el total de los Registros de la Tabla de estructterritorial
        public void CargarGridBuscar(DataGridView grid, string txtBuscar)
        {


            try
            {

                var query = $"SELECT * from bajafamilia WHERE idFamilia LIKE '%{txtBuscar}%' ";//creamos la consulta a la base 
                //creamos el cmd para que se lleve el query y cargue la conexion con la DB
                var cmd = new MySqlCommand(query, GetConnection());

                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                grid.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
    }
}
