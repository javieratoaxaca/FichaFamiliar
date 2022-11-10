using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFichaFamiliar.Data
{
    class capaDatosComportamiento
    {
        private Int64 idComportamiento;
        private Int64 idFamilia;
        private string idIntegrante;
        private string curpTutora;
        private string nombreCompletoTutora;
        private string nombreTutora;
        private string aPaternoTutora;
        private string aMaternoTutora;
        private string liquidadoraSem1_2022;
        private string liquidadoraSem2_2022;
        private string liquidadoraSem1_2021;
        private string liquidadoraSem2_2021;

        public Int64 IdComportamiento
        {
            get
            {
                return idComportamiento;
            }

            set
            {
                idComportamiento = value;
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

        public string NombreCompletoTutora
        {
            get
            {
                return nombreCompletoTutora;
            }

            set
            {
                nombreCompletoTutora = value;
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

        public string LiquidadoraSem1_2022
        {
            get
            {
                return liquidadoraSem1_2022;
            }

            set
            {
                liquidadoraSem1_2022 = value;
            }
        }

        public string LiquidadoraSem2_2022
        {
            get
            {
                return liquidadoraSem2_2022;
            }

            set
            {
                liquidadoraSem2_2022 = value;
            }
        }

        public string LiquidadoraSem1_2021
        {
            get
            {
                return liquidadoraSem1_2021;
            }

            set
            {
                liquidadoraSem1_2021 = value;
            }
        }

        public string LiquidadoraSem2_2021
        {
            get
            {
                return liquidadoraSem2_2021;
            }

            set
            {
                liquidadoraSem2_2021 = value;
            }
        }
    }
}
