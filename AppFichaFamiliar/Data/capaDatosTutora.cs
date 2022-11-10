using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFichaFamiliar.Data
{
    class capaDatosTutora
    {
        private Int64 idTutora;
        private Int64 idFamilia;
        private string idIntegrante;
        private string curpTutora;
        private string nombreTutora;
        private string aPaternoTutora;
        private string aMaternoTutora;
        private string situacionFamilia;

        public Int64 IdTutora
        {
            get
            {
                return idTutora;
            }

            set
            {
                idTutora = value;
            }
        }

        public Int64 IdFamilia
        {
            get
            {
                return idFamilia;
            }

            set
            {
                idFamilia = value;
            }
        }

        public string IdIntegrante
        {
            get
            {
                return idIntegrante;
            }

            set
            {
                idIntegrante = value;
            }
        }

        public string CurpTutora
        {
            get
            {
                return curpTutora;
            }

            set
            {
                curpTutora = value;
            }
        }

        public string NombreTutora
        {
            get
            {
                return nombreTutora;
            }

            set
            {
                nombreTutora = value;
            }
        }

        public string APaternoTutora
        {
            get
            {
                return aPaternoTutora;
            }

            set
            {
                aPaternoTutora = value;
            }
        }

        public string AMaternoTutora
        {
            get
            {
                return aMaternoTutora;
            }

            set
            {
                aMaternoTutora = value;
            }
        }

        public string SituacionFamilia
        {
            get
            {
                return situacionFamilia;
            }

            set
            {
                situacionFamilia = value;
            }
        }
    }
}
