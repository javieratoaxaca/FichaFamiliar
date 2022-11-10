using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFichaFamiliar.Data
{
    class capaDatosBajaTutora
    {
        private Int64 idBajaFamilia;
        private Int64 idFamilia;
        private string idIntegrante;
        private string curpTutora;
        private string nameCompleto;
        private string nombreTutora;
        private string apTutora;
        private string amTutora;
        private string anioBaja;
        private string bimBaja;
        private string motivoBaja;

        public Int64 IdBajaFamilia
        {
            get
            {
                return idBajaFamilia;
            }

            set
            {
                idBajaFamilia = value;
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

        public string NameCompleto
        {
            get
            {
                return nameCompleto;
            }

            set
            {
                nameCompleto = value;
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

        public string ApTutora
        {
            get
            {
                return apTutora;
            }

            set
            {
                apTutora = value;
            }
        }

        public string AmTutora
        {
            get
            {
                return amTutora;
            }

            set
            {
                amTutora = value;
            }
        }

        public string AnioBaja
        {
            get
            {
                return anioBaja;
            }

            set
            {
                anioBaja = value;
            }
        }

        public string BimBaja
        {
            get
            {
                return bimBaja;
            }

            set
            {
                bimBaja = value;
            }
        }

        public string MotivoBaja
        {
            get
            {
                return motivoBaja;
            }

            set
            {
                motivoBaja = value;
            }
        }
    }
}
