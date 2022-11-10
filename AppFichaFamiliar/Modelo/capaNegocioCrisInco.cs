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
    class capaNegocioCrisInco:ConexionBD
    {

        //Seccion de datos
        public capaDatosCrisInco getDatosIncorporacion(string idFamilia)
        {

            var cdDatosIncorporacion = new capaDatosCrisInco();

            try
            {
                var Query = string.Format("SELECT CR_CRIS_2020,FECHA_ENCUESTA_CRIS_2020,CR_INCO_2020,FECHA_CAPTURA_INCO_2020,"+
                                                  "CR_CRIS_2021,FECHA_ENCUESTA_CRIS_2021,CR_INCO_2021,FECHA_CAPTURA_INCO_2021,"+
                                                  "CR_CRIS_2022,FECHA_ENCUESTA_CRIS_2022,CR_INCO_2022,FECHA_CAPTURA_INCO_2022 FROM cris_inco where idFamilia like '{0}' limit 1", idFamilia);
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDatosIncorporacion.CR_CRIS_20201= dr["CR_CRIS_2020"].ToString(); 
                    cdDatosIncorporacion.FECHA_ENCUESTA_CRIS_20201= dr["FECHA_ENCUESTA_CRIS_2020"].ToString(); ;
                    cdDatosIncorporacion.CR_INCO_20201=dr["CR_INCO_2020"].ToString(); ;
                    cdDatosIncorporacion.FECHA_CAPTURA_INCO_20201= dr["FECHA_CAPTURA_INCO_2020"].ToString(); ;

                    cdDatosIncorporacion.CR_CRIS_20211 = dr["CR_CRIS_2021"].ToString(); ;
                    cdDatosIncorporacion.FECHA_ENCUESTA_CRIS_20211 = dr["FECHA_ENCUESTA_CRIS_2021"].ToString(); ;
                    cdDatosIncorporacion.CR_INCO_20211 = dr["CR_INCO_2021"].ToString(); ;
                    cdDatosIncorporacion.FECHA_CAPTURA_INCO_20211 = dr["FECHA_CAPTURA_INCO_2021"].ToString(); ;

                    cdDatosIncorporacion.CR_CRIS_20221 = dr["CR_CRIS_2022"].ToString(); ;
                    cdDatosIncorporacion.FECHA_ENCUESTA_CRIS_20221 = dr["FECHA_ENCUESTA_CRIS_2022"].ToString(); ;
                    cdDatosIncorporacion.CR_INCO_20221 = dr["CR_INCO_2022"].ToString(); ;
                    cdDatosIncorporacion.FECHA_CAPTURA_INCO_20221 = dr["FECHA_CAPTURA_INCO_2022"].ToString(); ;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDatosIncorporacion;
        }

        //verificacion si existe o no la Tutora
        public bool ExisteTutora(string idFamilia)
        {
            //capaDatosTutora ctd = new capaDatosTutora();
            //Data.Producto dtProducto = new Data.Producto();
            try
            {
                var Query = string.Format("SELECT idFamilia FROM cris_inco WHERE idFamilia LIKE '{0}' limit 1", idFamilia);
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
                var query = string.Format("SELECT idFamilia,idIntegrante,curpTutora,nombreCTutora,CR_CRIS_2021,FECHA_ENCUESTA_CRIS_2021,CR_INCO_2021,FECHA_ENTREGA_INCO_2021,CR_CRIS_2020,FECHA_ENCUESTA_CRIS_2020,CR_INCO_2020,FECHA_ENTREGA_INCO_2020  from cris_inco ");//creamos la consulta a la base 
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
                var query = $"SELECT idFamilia,idIntegrante,curpTutora,nombreCTutora,CR_CRIS_2021,FECHA_ENCUESTA_CRIS_2021,CR_INCO_2021,FECHA_ENTREGA_INCO_2021,CR_CRIS_2020,FECHA_ENCUESTA_CRIS_2020,CR_INCO_2020,FECHA_ENTREGA_INCO_2020  from cris_inco WHERE idFamilia LIKE '%{txtBuscar}%'";//creamos la consulta a la base 
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
