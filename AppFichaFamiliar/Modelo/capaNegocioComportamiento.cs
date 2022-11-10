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
    class capaNegocioComportamiento:ConexionBD
    {

        public capaDatosComportamiento getComportamientoTutora(string idFamilia)
        {

            var cdComportamientoTutora = new capaDatosComportamiento();

            try
            {
                var Query = $"SELECT liquidadoraSem1_2021,liquidadoraSem2_2021,liquidadoraSem1_2022,liquidadoraSem2_2022 FROM comportamiento where idFamilia like '%{idFamilia}%' limit 1 ";
                //string Query = string.Format("SELECT liquidadoraSem1_2021,liquidadoraSem2_2021,liquidadoraSem1_2022,liquidadoraSem2_2022 FROM comportamiento where idFamilia like '{0}' limit 1",idFamilia);
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdComportamientoTutora.LiquidadoraSem1_2021 = dr["liquidadoraSem1_2021"].ToString();
                    cdComportamientoTutora.LiquidadoraSem2_2021 = dr["liquidadoraSem2_2021"].ToString(); 
                    cdComportamientoTutora.LiquidadoraSem1_2022 = dr["liquidadoraSem1_2022"].ToString();
                    cdComportamientoTutora.LiquidadoraSem2_2022 = dr["liquidadoraSem2_2022"].ToString();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdComportamientoTutora;
        }

        //verificacion si existe o no la Tutora
        public bool ExisteTutora(string idFamilia)
        {
            //capaDatosTutora ctd = new capaDatosTutora();
            //Data.Producto dtProducto = new Data.Producto();
            try
            {
                var Query = string.Format("SELECT idFamilia FROM comportamiento WHERE idFamilia LIKE '{0}' limit 1", idFamilia);
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
                /*var query = string.Format("SELECT * from comportamiento ");//creamos la consulta a la base */
                var query = $"SELECT * from comportamiento";
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
                /*var query = string.Format("SELECT * from comportamiento WHERE idFamilia LIKE '%{0}%' ", txtBuscar);//creamos la consulta a la base */
                var query = $"SELECT * from comportamiento WHERE idFamilia LIKE '%{txtBuscar}%'";
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
