using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFichaFamiliar.Data
{
    class capaDatosTerritoriales
    {
        private Int64 idEstructuraTerritorial;
        private Int64 idRegion;
        private Int64 idFamilia;
        private Int64 idSare;
        private string sare;
        private string idIntegrante;
        private string curpTutora;
        private string nameCompleto;
        private string nombreTutora;
        private string apTutora;
        private string amTutora;
        private string region;
        private string cveLocalidadOficial;
        private string cveMunicipio;
        private string municipio;
        private string cveLocalidad;
        private string localidad;
        private string microzona;

        public Int64 IdEstructuraTerritorial
        {
            get
            {
                return idEstructuraTerritorial;
            }

            set
            {
                idEstructuraTerritorial = value;
            }
        }

        public Int64 IdRegion
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

        public string Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }

        public string CveLocalidadOficial
        {
            get
            {
                return cveLocalidadOficial;
            }

            set
            {
                cveLocalidadOficial = value;
            }
        }

        public string CveMunicipio
        {
            get
            {
                return cveMunicipio;
            }

            set
            {
                cveMunicipio = value;
            }
        }

        public string Municipio
        {
            get
            {
                return municipio;
            }

            set
            {
                municipio = value;
            }
        }

        public string CveLocalidad
        {
            get
            {
                return cveLocalidad;
            }

            set
            {
                cveLocalidad = value;
            }
        }

        public string Localidad
        {
            get
            {
                return localidad;
            }

            set
            {
                localidad = value;
            }
        }

        public string Microzona
        {
            get
            {
                return microzona;
            }

            set
            {
                microzona = value;
            }
        }

        public long IdSare
        {
            get
            {
                return idSare;
            }

            set
            {
                idSare = value;
            }
        }

        public string Sare
        {
            get
            {
                return sare;
            }

            set
            {
                sare = value;
            }
        }
    }
}