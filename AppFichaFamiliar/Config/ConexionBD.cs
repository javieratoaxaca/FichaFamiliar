using System;
using MySql.Data.MySqlClient;
using System.Data;
//using MySqlConnector;

namespace AppFichaFamiliar.Config
{
    class ConexionBD
    {
        //Seccion para lo de Azure for MySQL
       /* private string Server = "atoaxacalarios-cnbbbj.mysql.database.azure.com";
        private string UserID= "user_ext";
        private string Password= "0p0rtun1d4d35#";
        private string Database= "educacionbasica";
        private string Port = "3306";
        private string SslMode= " MySqlSslMode.Required";
        private string SslCA=$"D:/CertificadoSSL/DigiCertGlobalRootCA.crt.pem";*/
        string cad_cnx;
        MySqlConnection mysqlcnn;


        public ConexionBD()
        {
            cad_cnx = "Database=educacionbasica; SERVER=localhost;UID=root;password=oportunidades;";
            //cad_cnx = "SERVER=atoaxacalarios-cnbbbj.mysql.database.azure.com; PORT=3306;DATABASE=educacionbasica;UID=user_ext;PASSWORD=0p0rtun1d4d35#;"; // -->Usuario Externo
            //cad_cnx = "Server =" + Server + ";PORT=" + Port + ";DATABASE=" + Database + ";UID=" + UserID + ";PASSWORD=" + Password;
        }
        public MySqlConnection GetConnection()
        {
            try
            {
                mysqlcnn = new MySqlConnection(cad_cnx);
                mysqlcnn.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error: Al conectarse a la Base de datos." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Al realizar la conexion la Base de datos." + ex.Message);
            }

            return mysqlcnn;
        }
        public int ExecuteQuery(string SQL)
        {
            int result = 0;
            try
            {

                var MySqlCommand = new MySqlCommand(SQL, GetConnection());

                result = MySqlCommand.ExecuteNonQuery();
                mysqlcnn.Close();
            }
            catch (MySqlConnector.MySqlException ex)
            {
                throw new Exception("Error: Al ejecutar las sentencias SQL." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
        public MySqlDataReader GetDataReader(string SQL)
        {
            MySqlDataReader MySqlDr = null;
            try
            {
                var MySqlCommand = new MySqlCommand(SQL, GetConnection());
                var MySqlDap = new MySqlDataAdapter(MySqlCommand);
                MySqlDr = MySqlCommand.ExecuteReader();
            }
            catch (MySqlConnector.MySqlException ex)
            {
                throw new Exception("Error: Al ejecutar las sentencias SQL." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return MySqlDr;
        }
        public DataTable GetDataTabla(string SQL)
        {
            var dt = new DataTable();
            var ds = new DataSet();
            var MySqlCommand = new MySqlCommand(SQL, GetConnection());
            var MySqlDap = new MySqlDataAdapter(MySqlCommand);
            MySqlDap.SelectCommand = MySqlCommand;
            MySqlDap.Fill(ds);
            dt = ds.Tables[0];
            return dt;


        }

    }
}
