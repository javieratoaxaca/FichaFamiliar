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
    class capaNegocioDispersion:ConexionBD
    {

        public capaDatosDispersion getDispersionTutora(string idFamilia)
        {

            var cdDispersionTutora = new capaDatosDispersion();

            try
            {
                var Query = string.Format("SELECT INC_2019,B_2019_01,B_2019_02,B_2019_03,B_2019_04,B_2019_05,B_2019_06,REZ_2019,INC_2020,B_2020_01,B_2020_02,B_2020_03,B_2020_04,B_2020_05,B_2020_06,REZ_2020,INC_2021,B_2021_01,B_2021_02,B_2021_03,B_2021_04,B_2021_05,B_2021_06,REZ_2021, INC_2022,B_2022_01,B_2022_02,B_2022_03,B_2022_04,B_2022_05,B_2022_06,REZ_2022 FROM dispersion where idFamilia like '{0}' limit 1", idFamilia);

                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDispersionTutora.Incorp2019 = dr["INC_2019"].ToString();
                    cdDispersionTutora.Bim01_2019= dr["B_2019_01"].ToString(); 
                    cdDispersionTutora.Bim02_2019 = dr["B_2019_02"].ToString(); 
                    cdDispersionTutora.Bim03_2019 = dr["B_2019_03"].ToString(); 
                    cdDispersionTutora.Bim04_2019 = dr["B_2019_04"].ToString(); 
                    cdDispersionTutora.Bim05_2019 = dr["B_2019_05"].ToString(); 
                    cdDispersionTutora.Bim06_2019 = dr["B_2019_06"].ToString(); 
                    cdDispersionTutora.Rezago2019= dr["REZ_2019"].ToString();

                    cdDispersionTutora.Incorp2020 = dr["INC_2020"].ToString();
                    cdDispersionTutora.Bim01_2020 = dr["B_2020_01"].ToString();
                    cdDispersionTutora.Bim02_2020 = dr["B_2020_02"].ToString();
                    cdDispersionTutora.Bim03_2020 = dr["B_2020_03"].ToString();
                    cdDispersionTutora.Bim04_2020 = dr["B_2020_04"].ToString();
                    cdDispersionTutora.Bim05_2020 = dr["B_2020_05"].ToString();
                    cdDispersionTutora.Bim06_2020 = dr["B_2020_06"].ToString();
                    cdDispersionTutora.Rezago2020 = dr["REZ_2020"].ToString();

                    cdDispersionTutora.Incorp2021 = dr["INC_2021"].ToString();
                    cdDispersionTutora.Bim01_2021 = dr["B_2021_01"].ToString();
                    cdDispersionTutora.Bim02_2021 = dr["B_2021_02"].ToString();
                    cdDispersionTutora.Bim03_2021 = dr["B_2021_03"].ToString();
                    cdDispersionTutora.Bim04_2021 = dr["B_2021_04"].ToString();
                    cdDispersionTutora.Bim05_2021 = dr["B_2021_05"].ToString();
                    cdDispersionTutora.Bim06_2021 = dr["B_2021_06"].ToString();
                    cdDispersionTutora.Rezago2021 = dr["REZ_2021"].ToString();

                    cdDispersionTutora.Incorp2022 = dr["INC_2022"].ToString();
                    cdDispersionTutora.Bim01_2022 = dr["B_2022_01"].ToString();
                    cdDispersionTutora.Bim02_2022 = dr["B_2022_02"].ToString();
                    cdDispersionTutora.Bim03_2022 = dr["B_2022_03"].ToString();
                    cdDispersionTutora.Bim04_2022 = dr["B_2022_04"].ToString();
                    cdDispersionTutora.Bim05_2022 = dr["B_2022_05"].ToString();
                    cdDispersionTutora.Bim06_2022 = dr["B_2022_06"].ToString();
                    cdDispersionTutora.Rezago2022 = dr["REZ_2022"].ToString();

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDispersionTutora;
        }

        //verificacion si existe o no la Tutora
        public bool ExisteTutora(string idFamilia)
        {
            //capaDatosTutora ctd = new capaDatosTutora();
            //Data.Producto dtProducto = new Data.Producto();
            try
            {
                var Query = string.Format("SELECT idFamilia FROM dispersion WHERE idFamilia LIKE '{0}' limit 1", idFamilia);
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

                var query = string.Format("SELECT * from dispersion ");//creamos la consulta a la base 
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

                var query = $"SELECT * from dispersion WHERE idFamilia LIKE '%{txtBuscar}%' ";//creamos la consulta a la base 
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
