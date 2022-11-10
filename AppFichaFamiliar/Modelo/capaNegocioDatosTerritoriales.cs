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
    class capaNegocioDatosTerritoriales:ConexionBD
    {
        public capaNegocioDatosTerritoriales() { }
        //CapaDataConexionBD cDConexionBd;

        public DataTable CargarCmbRegion()
        {


            try
            {

                var query = string.Format("SELECT idRegion,region FROM estructterritorial group by idRegion");//creamos la consulta a la base 
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

        /*Metodo para Buscar los datos a la base de datos*/

        public capaDatosTerritoriales getDatosTerritorio(string idFamilia)
        {

            var cdDatosTerritoriales = new capaDatosTerritoriales();

            try
            {
                var Query = $"SELECT idRegion,region,idSare,sare,cveLocOfi,cveMun,municipio,cveLoc,localidad FROM estructterritorial where idFamilia LIKE '{idFamilia}' limit 1";
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDatosTerritoriales.IdRegion = Convert.ToInt64( dr["idRegion"].ToString());
                    cdDatosTerritoriales.Region = dr["region"].ToString();
                    cdDatosTerritoriales.IdSare = Convert.ToInt64(dr["idSare"]);
                    cdDatosTerritoriales.Sare = dr["sare"].ToString();
                    cdDatosTerritoriales.CveLocalidadOficial = dr["cveLocOfi"].ToString();
                    cdDatosTerritoriales.CveMunicipio = dr["cveMun"].ToString();
                    cdDatosTerritoriales.Municipio = dr["municipio"].ToString();
                    cdDatosTerritoriales.CveLocalidad = dr["cveLoc"].ToString();
                    cdDatosTerritoriales.Localidad = dr["localidad"].ToString();

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDatosTerritoriales;
        }
        public capaDatosTerritoriales getIdRegion(string curp)
        {

            var cdDatosTerritorialesIdRegion = new capaDatosTerritoriales();

            try
            {
                var Query = $"SELECT idSare,idFamilia,curpTutora FROM estructterritorial where curpTutora ='{curp}' limit 1";
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDatosTerritorialesIdRegion.IdRegion = Convert.ToInt64(dr["idSare"].ToString());
                    cdDatosTerritorialesIdRegion.IdFamilia = Convert.ToInt64(dr["idFamilia"].ToString());
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDatosTerritorialesIdRegion;
        }
        public capaDatosTerritoriales getIdRegionNombreTutora(string nanmeFullTutora)
        {

            var cdDatosTerritorialesIdRegion = new capaDatosTerritoriales();

            try
            {
                var Query = $"SELECT idRegion,idFamilia,curpTutora FROM estructterritorial where nameFullTutora ='{nanmeFullTutora}' limit 1";
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDatosTerritorialesIdRegion.IdRegion = Convert.ToInt64(dr["idRegion"].ToString());
                    cdDatosTerritorialesIdRegion.IdFamilia = Convert.ToInt64(dr["idFamilia"].ToString());
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDatosTerritorialesIdRegion;
        }
        public capaDatosTerritoriales getDatosTerritorioComplete(string idRegion, string curpTutora, string idFamilia, string nameFullTutora)
        {

            var cdDatosTerritoriales = new capaDatosTerritoriales();

            try
            {
                var Query = $"SELECT idFamilia,idRegion,region,cveLocOfi,cveMun,municipio,cveLoc,localidad FROM estructterritorial where idRegion={idRegion} && curpTutora={curpTutora} && idFamilia='{idFamilia}' && nameFullTutora='{nameFullTutora}' limit 1";
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDatosTerritoriales.IdRegion = Convert.ToInt64(dr["idRegion"].ToString());
                    cdDatosTerritoriales.IdFamilia= Convert.ToInt64(dr["idFamilia"].ToString());
                    cdDatosTerritoriales.Region = dr["region"].ToString();
                    cdDatosTerritoriales.CveLocalidadOficial = dr["cveLocOfi"].ToString();
                    cdDatosTerritoriales.CveMunicipio = dr["cveMun"].ToString();
                    cdDatosTerritoriales.Municipio = dr["municipio"].ToString();
                    cdDatosTerritoriales.CveLocalidad = dr["cveLoc"].ToString();
                    cdDatosTerritoriales.Localidad = dr["localidad"].ToString();

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDatosTerritoriales;
        }

        //verificacion si existe o no la Tutora
        public bool ExisteTutora(string idFamilia)
        {
            //capaDatosTutora ctd = new capaDatosTutora();
            //Data.Producto dtProducto = new Data.Producto();
            try
            {
                var Query = string.Format("SELECT idFamilia FROM estructterritorial WHERE idFamilia LIKE '{0}' limit 1", idFamilia);
                var dr = GetDataReader(Query);
                return dr.HasRows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //Metodo para cargar el DataGridView con el total de los Registros de la Tabla de estructterritorial
        public void CargarGrid(DataGridView grid)
        {

            try
            {
                var query = string.Format("SELECT  idEstructuraTerritorial,idFamilia,idRegion,region,cveLocOfi,cveMun, municipio,cveLoc,localidad from estructterritorial ");//creamos la consulta a la base 
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
                var query = $"SELECT idFamilia as Familia_ID,curpTutora as Curp_Tutora,nameFullTutora as Nombre_Tutora, municipio as Municipio, localidad as Localidad from estructterritorial WHERE nameFullTutora LIKE '%{txtBuscar}%' ";//creamos la consulta a la base 
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
