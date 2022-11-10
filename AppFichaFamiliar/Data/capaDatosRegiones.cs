using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFichaFamiliar.Data
{
    class capaDatosRegiones
    {
        private int idRegion;
        private string nombreRegion;

        public int IdRegion
        {
            get
            {
                return idRegion;
            }

            set
            {
                idRegion = value;
            }
        }

        public string NombreRegion
        {
            get
            {
                return nombreRegion;
            }

            set
            {
                nombreRegion = value;
            }
        }
    }
}
