using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AppFichaFamiliar.Config;
using AppFichaFamiliar.Data;
using System.Data;

namespace AppFichaFamiliar.Modelo
{
    class capaNegocioTutora:ConexionBD
    {

        public capaNegocioTutora() { }
        // Metodo para obtener los datos y manejar la informacion de este 
        public capaDatosTutora getTutora(string idFamilia)
        {

            var cdTutora = new capaDatosTutora();

            try
            {
                
                var Query = string.Format("SELECT idTutora,idIntegrante,nombreTutora,apTutora,amTutora,situacionFamilia,curpTutora FROM tutora where idFamilia LIKE '{0}'  limit 1", idFamilia);
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    
                    cdTutora.IdTutora = Int64.Parse(dr["idTutora"].ToString());
                    cdTutora.IdIntegrante = dr["idIntegrante"].ToString();
                    cdTutora.NombreTutora = dr["nombreTutora"].ToString();
                    cdTutora.APaternoTutora= dr["apTutora"].ToString();
                    cdTutora.AMaternoTutora= dr["amTutora"].ToString();
                    cdTutora.SituacionFamilia= dr["situacionFamilia"].ToString();
                    cdTutora.CurpTutora = dr["curpTutora"].ToString();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdTutora;
        }
        //verificacion si existe o no la Tutora
        public bool ExisteTutora(string idFamilia)
        {
            //capaDatosTutora ctd = new capaDatosTutora();
            //Data.Producto dtProducto = new Data.Producto();
            try
            {
                var Query = $"SELECT idFamilia FROM tutora WHERE idFamilia LIKE '{idFamilia}' limit 1";
                var dr = GetDataReader(Query);
                return dr.HasRows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExisteCurpTutora(string curpTutora,string idRegion,string idFamilia)
        {
            try
            {
                var Query =$"SELECT C.curpTutora FROM tutora as C ,estructterritorial as A  WHERE A.idRegion ='{idRegion}' and A.curpTutora='{curpTutora}' and A.idFamilia='{idFamilia}'" ;
                var dr = GetDataReader(Query);
                return dr.HasRows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExisteNameFullTutora(string nameFullTutora)
        {
            try
            {
                var Query = $"SELECT nameFullTutora FROM tutora WHERE nameFullTutora LIKE '{nameFullTutora}' limit 1";
                var dr = GetDataReader(Query);
                return dr.HasRows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public capaDatosTutora getIdFamiliaTutora(string curpTutora )
        {

            var cdTutora = new capaDatosTutora();

            try
            {

                //var Query = $"SELECT idFamilia FROM tutora where curpTutora='{curpTutora}'";
                var Query = string.Format("SELECT idFamilia,curpTutora,nombreTutora,apTutora,amTutora FROM tutora where curpTutora LIKE '{0}' limit 1", curpTutora);
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdTutora.IdFamilia = Convert.ToInt64(dr["idFamilia"].ToString());
                    cdTutora.CurpTutora = dr["curpTutora"].ToString();
                    cdTutora.NombreTutora = dr["nombreTutora"].ToString();
                    cdTutora.APaternoTutora = dr["apTutora"].ToString();
                    cdTutora.AMaternoTutora = dr["amTutora"].ToString();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdTutora;
        }
        public capaDatosTutora getNameFullTutora(string nameFullTutora)
        {

            var cdTutora = new capaDatosTutora();

            try
            {

                //var Query = $"SELECT idFamilia FROM tutora where curpTutora='{curpTutora}'";
                var Query = string.Format("SELECT idFamilia,curpTutora, nombreTutora,apTutora,amTutora FROM tutora where nameFullTutora LIKE '{0}' limit 1", nameFullTutora);
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdTutora.IdFamilia = Convert.ToInt64(dr["idFamilia"].ToString());
                    cdTutora.CurpTutora = dr["curpTutora"].ToString();
                    cdTutora.NombreTutora = dr["nombreTutora"].ToString();
                    cdTutora.APaternoTutora = dr["apTutora"].ToString();
                    cdTutora.AMaternoTutora = dr["amTutora"].ToString();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdTutora;
        }

        public capaDatosTutora getFullTutora(string curp,string nameFullTutora)
        {

            var cdTutora = new capaDatosTutora();

            try
            {

                //var Query = $"SELECT idFamilia FROM tutora where curpTutora='{curpTutora}'";
                var Query = $"SELECT idFamilia,curpTutora,nombreTutora,apTutora,amTutora  FROM tutora where curpTutora='%{curp}%' || nameFullTutora='%{nameFullTutora}%' limit 1" ;
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdTutora.IdFamilia = Convert.ToInt64(dr["idFamilia"].ToString());
                    cdTutora.CurpTutora = dr["curpTutora"].ToString();
                    cdTutora.NombreTutora = dr["nombreTutora"].ToString();
                    cdTutora.APaternoTutora = dr["apTutora"].ToString();
                    cdTutora.AMaternoTutora = dr["amTutora"].ToString();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdTutora;
        }

        public void CargarGrid(DataGridView grid)
        {

            try
            {

                var query = string.Format("SELECT  idTutora,idFamilia,idIntegrante,curpTutota,nombreTutora,apTutora,amTutora, situacionFamilia from tutora ");//creamos la consulta a la base 
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

                var query = $"SELECT idTutora,idFamilia,idIntegrante,curpTutota,nombreTutora,apTutora,amTutora, situacionFamilia from tutora WHERE idFamilia LIKE '%{txtBuscar}%' ";//creamos la consulta a la base 
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
