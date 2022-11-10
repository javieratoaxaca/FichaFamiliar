using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppFichaFamiliar.Modelo;
using AppFichaFamiliar.Data;


using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace AppFichaFamiliar.Vista
{
    public partial class frmFichaFamiliar : Form
    {
        readonly capaNegocioDatosTerritoriales cmDatosTerritoriales;
        readonly capaNegocioTutora cmTutora;
        readonly capaNegocioRegiones cmRegiones;
        readonly capaNegocioCrisInco cmCrisInco;
        readonly capaNegocioDispersion cmDispersion;
        readonly capaNegocioComportamiento cmComportamiento;
        readonly capaNegocioBajaTutora cmBaja;
        string idRegionGlobal = "";
        string idFamilia = "";

        public frmFichaFamiliar()
        {
            InitializeComponent();
            diseñoPersonalizado();
            cmDatosTerritoriales = new capaNegocioDatosTerritoriales();
            cmRegiones = new capaNegocioRegiones();
            cmTutora = new capaNegocioTutora();
            cmCrisInco = new capaNegocioCrisInco();
            cmDispersion = new capaNegocioDispersion();
            cmComportamiento = new capaNegocioComportamiento();
            cmBaja = new capaNegocioBajaTutora();
        }

        private void btnCerrarFrm_Click(object sender, EventArgs e)
        {

        }

        #region Personalizar SubMenu Lateral Busqueda Avanzada
        private void diseñoPersonalizado()
        {
            /*pnlSubMenuAdmin.Visible = false;
            pnlSubMenuMetas.Visible = false;*/
            subPnlDatosBusqueda.Visible = false;
        }
        //metodo para Ocultar el Submenu
        private void ocultarSubMenu()
        {

            if (subPnlDatosBusqueda.Visible == true)
                subPnlDatosBusqueda.Visible = false;
        }
        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        #endregion

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlDatosBusqueda);
            cajasTextoVacias();
            // gcmbRegion.DataSource = cmDatosTerritoriales.CargarCmbRegion();
            gcmbRegion.DataSource = cmRegiones.CargarCmbRegion(); //Paso los datos de mi metodo "CargarCmbRegion" para cargar el ComboBox ya que cmRegiones es mi clase de Regiones que se conecta a mi modelo de Regiones
            //listViewRegiones.Items.Add(cmRegiones.CargarCmbRegion());
            gcmbRegion.DisplayMember = "nomRegion"; 
            gcmbRegion.ValueMember = "idRegion";
        }

        public void cajasTextoVacias()
        {
            //Datos Territoriales
            txtIdRegion.Text = "";
            txtRegion.Text = "";
            txtInegi.Text = "";
            txtIdSare.Text = "";
            txtSare.Text = "";
            txtCveMun.Text = "";
            txtMunicipio.Text = "";
            txtCveLoc.Text = "";
            txtLocalidad.Text = "";
            //Tutora
            txtIdTutora.Text = "";
            txtNombreCompleto.Text = "";
            txtEstatus.Text = "";
            //Cris - Incorporacion
            txtCrisCR2022.Text = "";
            txtCrisFecha2022.Text = "";
            txtIncCR2022.Text = "";
            txtIncFecha2022.Text = "";

            txtCrisCodRes2021.Text = "";
            txtCrisFecha2021.Text = "";
            txtIncCodRes2021.Text = "";
            txtIncFecha2021.Text = "";

            txtCrisCodRes2020.Text = "";
            txtCrisFecha2020.Text = "";
            txtIncCR2020.Text = "";
            txtIncFecha2020.Text = "";
            //Dispersion
            //Año 2019
            txtInc19.Text = "";
            txtEneFeb19.Text = "";
            txtMarAbr19.Text = "";
            txtMayJun19.Text = "";
            txtJulAgost19.Text = "";
            txtSeptOct19.Text = "";
            txtNovDic19.Text = "";
            txtRez19.Text = "";
            //Año 2020
            txtInc20.Text = "";
            txtEneFeb20.Text = "";
            txtMarAbr20.Text = "";
            txtMayJun20.Text = "";
            txtJulAgost20.Text = "";
            txtSeptOct20.Text = "";
            txtNovDic20.Text = "";
            txtRez20.Text = "";
            //Año 2021
            txtInc21.Text = "";
            txtEneFeb21.Text = "";
            txtMarAbr21.Text = "";
            txtMayJun21.Text = "";
            txtJulAgost21.Text = "";
            txtSeptOct21.Text = "";
            txtNovDic21.Text = "";
            txtRez21.Text = "";
            //Año 2022
            txtInc22.Text = "";
            txtEneFeb22.Text = "";
            txtMarAbr22.Text = "";
            txtMayJun22.Text = "";
            txtJulAgost22.Text = "";
            txtSeptOct22.Text = "";
            txtNovDic22.Text = "";
            txtRez22.Text = "";
            /*Comportamiento
            txtLiqSem1_2022.Text = "";
            txtLiqSem1_2021.Text = "";
            txtLiqSem2_2021.Text = "";*/
            /*Bajas Tutora*/
            txtAnioBajaTutora.Text = "";
            txtBimBajaTutora.Text = "";
            txtCausalBajaTutora.Text = "";

        }

        private void btnBuscarFamiliaId_Click_1(object sender, EventArgs e)
        {
            var cdTutora = new capaDatosTutora();
            var cdTerritorio = new capaDatosTerritoriales();
            var cdIncorporacion = new capaDatosCrisInco();
            var cdBajaTutora = new capaDatosBajaTutora();
            var cdComportamientoTutora = new capaDatosComportamiento();
            var cdDispersionTutora = new capaDatosDispersion();

            //Seccion para los Datos de la Tutora
            if (string.IsNullOrEmpty(txtIdFamilia.Text))
            {
                //labelDialogResult.Text = "Dialog Box Result";
                var result = OLMessageBox.Show("No dejar Campos Vacios",
                "Id Familia Vacio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                //labelDialogResult.Text = result.ToString() + " Selected";
            }
         
            else if (!cmTutora.ExisteTutora(txtIdFamilia.Text))
            {
                var result = OLMessageBox.Show("El Familia Id es Incorrecto o No Existe,\n Por favor de Hacer una Busqueda Avanzada",
                 "Id Familia Vacio",
                 MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);

            }
            else
            {
                if (cmBaja.ExisteTutora(txtIdFamilia.Text) && cmTutora.ExisteTutora(txtIdFamilia.Text) && cmDatosTerritoriales.ExisteTutora(txtIdFamilia.Text) && cmCrisInco.ExisteTutora(txtIdFamilia.Text) && cmDispersion.ExisteTutora(txtIdFamilia.Text) && cmComportamiento.ExisteTutora(txtIdFamilia.Text))
                {
                   // Seccion de Datos de Tutora
                    cdTutora = cmTutora.getTutora(txtIdFamilia.Text);
                    txtIdTutora.Text = cdTutora.IdIntegrante;
                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                    txtEstatus.Text = cdTutora.SituacionFamilia;

                    //Seccion de Datos Territoriales
                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(txtIdFamilia.Text);
                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                    txtRegion.Text = cdTerritorio.Region;
                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                    txtSare.Text = cdTerritorio.Sare;
                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                    txtMunicipio.Text = cdTerritorio.Municipio;
                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                    txtLocalidad.Text = cdTerritorio.Localidad;

                    //Seccion de Datos de Incorporacion
                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;


                    //Seccion de Datos Dispersion:
                    cdDispersionTutora = cmDispersion.getDispersionTutora(txtIdFamilia.Text);
                    //Año 2019
                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                    //Año 2020
                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                    //Año 2021
                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                    //Año 2022
                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(txtSearch.Text);
                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                    */
                    // Seccion de Datos de Baja Tutora.
                    cdBajaTutora = cmBaja.getBajaTutora(txtIdFamilia.Text);
                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                    
                }
            }

        }

        private void Any()
        {
            //-| IWin32Window owner:
            //Displays a message box in front of the specified object and with the other specified parameters.           
            OLMessageBox.Show(this, "Text");
            OLMessageBox.Show(this, "Text", "Caption");
            OLMessageBox.Show(this, "Text", "Caption", MessageBoxButtons.OKCancel);
            //Etc
        }

       private void btnSearchAvanzada_Click(object sender, EventArgs e)
        {
            var cdTutora = new capaDatosTutora();
            var cdTerritorial = new capaDatosTerritoriales();
            var cdTerritorialRegion = new capaDatosTerritoriales();
            var cdTerritorio = new capaDatosTerritoriales();
            var cdIncorporacion = new capaDatosCrisInco();
            var cdBajaTutora = new capaDatosBajaTutora();
            var cdComportamientoTutora = new capaDatosComportamiento();
            var cdDispersionTutora = new capaDatosDispersion();
            string getIdFamilia = "";
            string getIdNameFullTutora = "";
            string getIdCurp = "";

            switch (idRegionGlobal)
            {
                #region CasoRegion20001
                case "20001":
                    {
                        cajasTextoVacias();
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                    
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cajasTextoVacias();



                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20002
                case "20002":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;*/

                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20003
                case "20003":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                    
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20004
                case "20004":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                    
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20005
                case "20005":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                    
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20006
                case "20006":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20007
                case "20007":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20008
                case "20008":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */

                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20009
                case "20009":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20010
                case "20010":
                    {
                        cajasTextoVacias();
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20011
                case "20011":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20012
                case "20012":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20013
                case "20013":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20014
                case "20014":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion

                #region CasoRegion20015
                case "20015":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                #endregion
                #region CasoRegion20016
                case "20016":
                    {
                        cdTutora = cmTutora.getIdFamiliaTutora(txtSearchNameFull.Text);


                        getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                        getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                        getIdCurp = cdTutora.CurpTutora;

                        if (string.IsNullOrEmpty(txtSearchNameFull.Text) && string.IsNullOrEmpty(txtSearchCurp.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }

                        else
                        {
                            cdTerritorialRegion = cmDatosTerritoriales.getIdRegion(txtSearchNameFull.Text);
                            string idFamilia = "";
                            if (idRegionGlobal == Convert.ToString(cdTerritorialRegion.IdRegion))
                            {
                                cdTerritorial = cmDatosTerritoriales.getDatosTerritorioComplete(idRegionGlobal, getIdFamilia, getIdCurp, getIdNameFullTutora);
                                idFamilia = cdTerritorialRegion.IdFamilia.ToString();
                                if (cmTutora.ExisteTutora(idFamilia))
                                {
                                    var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{idFamilia}", "  Curp Tutora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Seccion de Datos de Tutora
                                    cdTutora = cmTutora.getTutora(idFamilia);
                                    txtIdTutora.Text = cdTutora.IdIntegrante;
                                    txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                    txtEstatus.Text = cdTutora.SituacionFamilia;
                                    txtdataCurpTutora.Text = cdTutora.CurpTutora;

                                    //Seccion de Datos Territoriales
                                    cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(idFamilia);
                                    txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                    txtRegion.Text = cdTerritorio.Region;
                                    txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                    txtSare.Text = cdTerritorio.Sare;
                                    txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                    txtCveMun.Text = cdTerritorio.CveMunicipio;
                                    txtMunicipio.Text = cdTerritorio.Municipio;
                                    txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                    txtLocalidad.Text = cdTerritorio.Localidad;

                                    //Seccion de Datos de Incorporacion
                                    cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                    txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                    txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                    txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                    txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                    txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                    txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                    txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                    txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                    txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                    txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                    txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                    txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                    //Seccion de Datos Dispersion:
                                    cdDispersionTutora = cmDispersion.getDispersionTutora(idFamilia);
                                    //Año 2019
                                    txtInc19.Text = cdDispersionTutora.Incorp2019;
                                    txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                    txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                    txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                    txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                    txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                    txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                    txtRez19.Text = cdDispersionTutora.Rezago2019;
                                    //Año 2020
                                    txtInc20.Text = cdDispersionTutora.Incorp2020;
                                    txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                    txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                    txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                    txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                    txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                    txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                    txtRez20.Text = cdDispersionTutora.Rezago2020;
                                    //Año 2021
                                    txtInc21.Text = cdDispersionTutora.Incorp2021;
                                    txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                    txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                    txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                    txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                    txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                    txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                    txtRez21.Text = cdDispersionTutora.Rezago2021;
                                    //Año 2022
                                    txtInc22.Text = cdDispersionTutora.Incorp2022;
                                    txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                    txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                    txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                    txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                    txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                    txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                    txtRez22.Text = cdDispersionTutora.Rezago2022;

                                    /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                    cdComportamientoTutora = cmComportamiento.getComportamientoTutora(idFamilia);
                                    txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                    txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                    txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                    txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                    */
                                    // Seccion de Datos de Baja Tutora.
                                    cdBajaTutora = cmBaja.getBajaTutora(idFamilia);
                                    txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                    txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                    txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                                }

                            }
                            else
                            {

                                var result = OLMessageBox.Show($"Datos No Encontrados: {cdTerritorial.CurpTutora}\n No Pertenece a la Region:{idRegionGlobal}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;


                #endregion


                #region CasoRegion20000
                default:
                    {
                        #region BusquedaCurp 
                        
                        if (string.IsNullOrEmpty(txtSearchCurp.Text)) //Validacion del campo no venga vacio

                        {
                            //Manda mensaje
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " DATO CURP ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }
                        else
                        {
                            cdTutora = cmTutora.getFullTutora(txtSearchCurp.Text, txtSearchNameFull.Text);
                            getIdFamilia = Convert.ToString(cdTutora.IdFamilia);
                            getIdNameFullTutora = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                            getIdCurp = cdTutora.CurpTutora;

                            if (cdTutora.IdFamilia == 0)
                            {
                                var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp Correcto", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // var result = OLMessageBox.Show($"Datos Encontrados: \n Familia id:{getIdFamilia} \n Tutora:{getIdNameFullTutora} \n CurpTutora:{getIdCurp} ", "  Curp Tutora ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Seccion de Datos de Tutora
                                cdTutora = cmTutora.getTutora(getIdFamilia);
                                txtIdTutora.Text = cdTutora.IdIntegrante;
                                txtdataCurpTutora.Text = cdTutora.CurpTutora;
                                txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
                                txtEstatus.Text = cdTutora.SituacionFamilia;

                                //Seccion de Datos Territoriales
                                cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(getIdFamilia);
                                txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
                                txtRegion.Text = cdTerritorio.Region;
                                txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
                                txtSare.Text = cdTerritorio.Sare;
                                txtInegi.Text = cdTerritorio.CveLocalidadOficial;
                                txtCveMun.Text = cdTerritorio.CveMunicipio;
                                txtMunicipio.Text = cdTerritorio.Municipio;
                                txtCveLoc.Text = cdTerritorio.CveLocalidad;
                                txtLocalidad.Text = cdTerritorio.Localidad;

                                //Seccion de Datos de Incorporacion
                                cdIncorporacion = cmCrisInco.getDatosIncorporacion(txtIdFamilia.Text);
                                txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
                                txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
                                txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
                                txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

                                txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
                                txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
                                txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
                                txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

                                txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
                                txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
                                txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
                                txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

                                //Seccion de Datos Dispersion:
                                cdDispersionTutora = cmDispersion.getDispersionTutora(getIdFamilia);
                                //Año 2019
                                txtInc19.Text = cdDispersionTutora.Incorp2019;
                                txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
                                txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
                                txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
                                txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
                                txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
                                txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
                                txtRez19.Text = cdDispersionTutora.Rezago2019;
                                //Año 2020
                                txtInc20.Text = cdDispersionTutora.Incorp2020;
                                txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
                                txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
                                txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
                                txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
                                txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
                                txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
                                txtRez20.Text = cdDispersionTutora.Rezago2020;
                                //Año 2021
                                txtInc21.Text = cdDispersionTutora.Incorp2021;
                                txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
                                txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
                                txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
                                txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
                                txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
                                txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
                                txtRez21.Text = cdDispersionTutora.Rezago2021;
                                //Año 2022
                                txtInc22.Text = cdDispersionTutora.Incorp2022;
                                txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
                                txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
                                txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
                                txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
                                txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
                                txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
                                txtRez22.Text = cdDispersionTutora.Rezago2022;

                                /*Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
                                cdComportamientoTutora = cmComportamiento.getComportamientoTutora(getIdFamilia);
                                txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
                                txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
                                txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
                                txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;
                                */
                                // Seccion de Datos de Baja Tutora.
                                cdBajaTutora = cmBaja.getBajaTutora(getIdFamilia);
                                txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
                                txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
                                txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
                            }
                        }
                        #endregion
                        #region BusquedaNombre
                                               
                        if (string.IsNullOrEmpty(txtSearchNameFull.Text))
                        {
                            var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //lblRegion.Text = "";
                        }
                        else
                        {

                            cmDatosTerritoriales.CargarGridBuscar(dtgvListadoTutora, txtSearchNameFull.Text);
                            lblFamiliaId.Text = dtgvListadoTutora.CurrentRow.Cells[0].Value.ToString();

                        }
                        #endregion
                    }
                    break;
                  #endregion
                  
            }
        }

        // Seleccion de Region 
        private void gcmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idRegion;
            idRegion = gcmbRegion.SelectedValue.ToString();
            idRegionGlobal = idRegion;
            //lblRegion.Text = idRegion;
        }

        private void dtgvListadoTutora_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var cdTutora = new capaDatosTutora();
            var cdTerritorial = new capaDatosTerritoriales();
            var cdTerritorialRegion = new capaDatosTerritoriales();
            var cdTerritorio = new capaDatosTerritoriales();
            var cdIncorporacion = new capaDatosCrisInco();
            var cdBajaTutora = new capaDatosBajaTutora();
            var cdComportamientoTutora = new capaDatosComportamiento();
            var cdDispersionTutora = new capaDatosDispersion();

            lblFamiliaId.Text = dtgvListadoTutora.CurrentRow.Cells[0].Value.ToString();

            cdTutora = cmTutora.getTutora(lblFamiliaId.Text);
            txtIdTutora.Text = cdTutora.IdIntegrante;
            txtdataCurpTutora.Text = cdTutora.CurpTutora;
            txtNombreCompleto.Text = cdTutora.NombreTutora + " " + cdTutora.APaternoTutora + " " + cdTutora.AMaternoTutora;
            txtEstatus.Text = cdTutora.SituacionFamilia;

            //Seccion de Datos Territoriales
            cdTerritorio = cmDatosTerritoriales.getDatosTerritorio(lblFamiliaId.Text);
            txtIdRegion.Text = Convert.ToString(cdTerritorio.IdRegion);
            txtRegion.Text = cdTerritorio.Region;
            txtIdSare.Text = Convert.ToString(cdTerritorio.IdSare);
            txtSare.Text = cdTerritorio.Sare;
            txtInegi.Text = cdTerritorio.CveLocalidadOficial;
            txtCveMun.Text = cdTerritorio.CveMunicipio;
            txtMunicipio.Text = cdTerritorio.Municipio;
            txtCveLoc.Text = cdTerritorio.CveLocalidad;
            txtLocalidad.Text = cdTerritorio.Localidad;

            //Seccion de Datos de Incorporacion
            cdIncorporacion = cmCrisInco.getDatosIncorporacion(lblFamiliaId.Text);
            txtCrisCR2022.Text = cdIncorporacion.CR_CRIS_20221;
            txtCrisFecha2022.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20221;
            txtIncCR2022.Text = cdIncorporacion.CR_INCO_20221;
            txtIncFecha2022.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20221;

            txtCrisCodRes2021.Text = cdIncorporacion.CR_CRIS_20211;
            txtCrisFecha2021.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20211;
            txtIncCodRes2021.Text = cdIncorporacion.CR_INCO_20211;
            txtIncFecha2021.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20211;

            txtCrisCodRes2020.Text = cdIncorporacion.CR_CRIS_20201;
            txtCrisFecha2020.Text = cdIncorporacion.FECHA_ENCUESTA_CRIS_20201;
            txtIncCR2020.Text = cdIncorporacion.CR_INCO_20201;
            txtIncFecha2020.Text = cdIncorporacion.FECHA_CAPTURA_INCO_20201;

            //Seccion de Datos Dispersion:
            cdDispersionTutora = cmDispersion.getDispersionTutora(lblFamiliaId.Text);
            //Año 2019
            txtInc19.Text = cdDispersionTutora.Incorp2019;
            txtEneFeb19.Text = cdDispersionTutora.Bim01_2019;
            txtMarAbr19.Text = cdDispersionTutora.Bim02_2019;
            txtMayJun19.Text = cdDispersionTutora.Bim03_2019;
            txtJulAgost19.Text = cdDispersionTutora.Bim04_2019;
            txtSeptOct19.Text = cdDispersionTutora.Bim05_2019;
            txtNovDic19.Text = cdDispersionTutora.Bim06_2019;
            txtRez19.Text = cdDispersionTutora.Rezago2019;
            //Año 2020
            txtInc20.Text = cdDispersionTutora.Incorp2020;
            txtEneFeb20.Text = cdDispersionTutora.Bim01_2020;
            txtMarAbr20.Text = cdDispersionTutora.Bim02_2020;
            txtMayJun20.Text = cdDispersionTutora.Bim03_2020;
            txtJulAgost20.Text = cdDispersionTutora.Bim04_2020;
            txtSeptOct20.Text = cdDispersionTutora.Bim05_2020;
            txtNovDic20.Text = cdDispersionTutora.Bim06_2020;
            txtRez20.Text = cdDispersionTutora.Rezago2020;
            //Año 2021
            txtInc21.Text = cdDispersionTutora.Incorp2021;
            txtEneFeb21.Text = cdDispersionTutora.Bim01_2021;
            txtMarAbr21.Text = cdDispersionTutora.Bim02_2021;
            txtMayJun21.Text = cdDispersionTutora.Bim03_2021;
            txtJulAgost21.Text = cdDispersionTutora.Bim04_2021;
            txtSeptOct21.Text = cdDispersionTutora.Bim05_2021;
            txtNovDic21.Text = cdDispersionTutora.Bim06_2021;
            txtRez21.Text = cdDispersionTutora.Rezago2021;
            //Año 2022
            txtInc22.Text = cdDispersionTutora.Incorp2022;
            txtEneFeb22.Text = cdDispersionTutora.Bim01_2022;
            txtMarAbr22.Text = cdDispersionTutora.Bim02_2022;
            txtMayJun22.Text = cdDispersionTutora.Bim03_2022;
            txtJulAgost22.Text = cdDispersionTutora.Bim04_2022;
            txtSeptOct22.Text = cdDispersionTutora.Bim05_2022;
            txtNovDic22.Text = cdDispersionTutora.Bim06_2022;
            txtRez22.Text = cdDispersionTutora.Rezago2022;

            //Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
            cdComportamientoTutora = cmComportamiento.getComportamientoTutora(lblFamiliaId.Text);
            //txtLiqSem1_2022.Text = cdComportamientoTutora.LiquidadoraSem1_2022;
            //txtLiqSem2_2022.Text = cdComportamientoTutora.LiquidadoraSem2_2022;
            //txtLiqSem1_2021.Text = cdComportamientoTutora.LiquidadoraSem1_2021;
            //txtLiqSem2_2021.Text = cdComportamientoTutora.LiquidadoraSem2_2021;

            // Seccion de Datos de Baja Tutora.
            cdBajaTutora = cmBaja.getBajaTutora(lblFamiliaId.Text);
            txtAnioBajaTutora.Text = cdBajaTutora.AnioBaja;
            txtBimBajaTutora.Text = cdBajaTutora.BimBaja;
            txtCausalBajaTutora.Text = cdBajaTutora.MotivoBaja;
        }



        private void btnDetallesTerritorial_Click_1(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyTerritorio2);
        }


        private void btnDetallesTitular_Click_1(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyTitular2);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyInc1);
        }

        private void btnDetallesInco2021_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyInc2);
        }

        private void btnDetallesInco2020_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyInc3);
        }
        
        private void btnDetalleBeca2022_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyBeca22);
        }

        private void btnDetalleBeca2021_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyBeca21);
        }

        private void btnDetalleBeca2020_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyBeca20);
        }

        private void btnDetalleBeca2019_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyBeca19);
        }
                
        private void btnDetallesInco2022_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyInc1);
        }

        private void btnDetallesInco2021_Click_1(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyInc2);
        }

        private void btnDetallesInco2020_Click_1(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlIzqBodyInc3);
        }

        private void btnDetallesContentIncorporaciones_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlContentIncorporaciones);
            
        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void dtgvListadoTutora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = string.Format(txtIdFamilia.Text + ".pdf",DateTime.Now.ToString("ddMMyyyy"));

            string paginaHtmlText = Properties.Resources.index.ToString();
            string font = Properties.Resources.segoeuil.ToString();
            //paginaHtmlText = paginaHtmlText.Replace("@estilo", Properties.Resources.bootstrap_min.ToString());
            //Datos Teritoriales
            paginaHtmlText = paginaHtmlText.Replace("@CveLocalidad", txtInegi.Text);
            paginaHtmlText = paginaHtmlText.Replace("@cveMun",txtCveMun.Text);
            paginaHtmlText = paginaHtmlText.Replace("@cveLocalidad",txtCveLoc.Text);
            paginaHtmlText = paginaHtmlText.Replace("@Municipio",txtMunicipio.Text);
            paginaHtmlText = paginaHtmlText.Replace("@Localidad",txtLocalidad.Text);
            paginaHtmlText = paginaHtmlText.Replace("@IdRegion",txtIdRegion.Text);
            paginaHtmlText = paginaHtmlText.Replace("@NombreRegion",txtRegion.Text);
            paginaHtmlText = paginaHtmlText.Replace("@IdSare",txtIdSare.Text);
            paginaHtmlText = paginaHtmlText.Replace("@NombreSare",txtSare.Text);
            //Datos de la Tutora
            paginaHtmlText = paginaHtmlText.Replace("@NombreTutora",txtNombreCompleto.Text);
            paginaHtmlText = paginaHtmlText.Replace("@curpTutora", txtdataCurpTutora.Text);
            paginaHtmlText = paginaHtmlText.Replace("@IdTutora",txtIdTutora.Text);
            paginaHtmlText = paginaHtmlText.Replace("@estadoTutora",txtEstatus.Text);
            paginaHtmlText = paginaHtmlText.Replace("@anioBaja",txtAnioBajaTutora.Text);
            paginaHtmlText = paginaHtmlText.Replace("@BimBaja",txtBimBajaTutora.Text);
            paginaHtmlText = paginaHtmlText.Replace("@causalBaja",txtCausalBajaTutora.Text);
            //Datos de Dispersion de Apoyos Año 2022
            paginaHtmlText = paginaHtmlText.Replace("@Incorporacion22", txtInc22.Text);
            paginaHtmlText = paginaHtmlText.Replace("@Rezago22", txtRez22.Text);
            paginaHtmlText = paginaHtmlText.Replace("@EneFeb22", txtEneFeb22.Text);
            paginaHtmlText = paginaHtmlText.Replace("@MarAbr22", txtMarAbr22.Text);
            paginaHtmlText = paginaHtmlText.Replace("@MayJun22", txtMayJun22.Text);
            paginaHtmlText = paginaHtmlText.Replace("@JulAgos22", txtJulAgost22.Text);
            paginaHtmlText = paginaHtmlText.Replace("@SeptOct22", txtSeptOct22.Text);
            paginaHtmlText = paginaHtmlText.Replace("@NovDic22", txtNovDic22.Text);
            //Datos de Dispersion de Apoyos Año 2021
            paginaHtmlText = paginaHtmlText.Replace("@Incorporacion21", txtInc21.Text);
            paginaHtmlText = paginaHtmlText.Replace("@Rezago21", txtRez21.Text);
            paginaHtmlText = paginaHtmlText.Replace("@EneFeb21", txtEneFeb21.Text);
            paginaHtmlText = paginaHtmlText.Replace("@MarAbr21", txtMarAbr21.Text);
            paginaHtmlText = paginaHtmlText.Replace("@MayJun21", txtMayJun21.Text);
            paginaHtmlText = paginaHtmlText.Replace("@JulAgos21", txtJulAgost21.Text);
            paginaHtmlText = paginaHtmlText.Replace("@SeptOct21", txtSeptOct21.Text);
            paginaHtmlText = paginaHtmlText.Replace("@NovDic21", txtNovDic21.Text);
            //Datos de Dispersion de Apoyos Año 2020
            paginaHtmlText = paginaHtmlText.Replace("@Incorporacion20", txtInc20.Text);
            paginaHtmlText = paginaHtmlText.Replace("@Rezago20", txtRez20.Text);
            paginaHtmlText = paginaHtmlText.Replace("@EneFeb20", txtEneFeb20.Text);
            paginaHtmlText = paginaHtmlText.Replace("@MarAbr20", txtMarAbr20.Text);
            paginaHtmlText = paginaHtmlText.Replace("@MayJun20", txtMayJun20.Text);
            paginaHtmlText = paginaHtmlText.Replace("@JulAgos20", txtJulAgost20.Text);
            paginaHtmlText = paginaHtmlText.Replace("@SeptOct20", txtSeptOct20.Text);
            paginaHtmlText = paginaHtmlText.Replace("@NovDic20", txtNovDic20.Text);
            //Datos de Dispersion de Apoyos Año 2019
            paginaHtmlText = paginaHtmlText.Replace("@Incorporacion19", txtInc19.Text);
            paginaHtmlText = paginaHtmlText.Replace("@Rezago19", txtRez19.Text);
            paginaHtmlText = paginaHtmlText.Replace("@EneFeb19", txtEneFeb19.Text);
            paginaHtmlText = paginaHtmlText.Replace("@MarAbr19", txtMarAbr19.Text);
            paginaHtmlText = paginaHtmlText.Replace("@MayJun19", txtMayJun19.Text);
            paginaHtmlText = paginaHtmlText.Replace("@JulAgos19", txtJulAgost19.Text);
            paginaHtmlText = paginaHtmlText.Replace("@SeptOct19", txtSeptOct19.Text);
            paginaHtmlText = paginaHtmlText.Replace("@NovDic19", txtNovDic19.Text);



            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fS = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.LETTER.Rotate(), 5, 5, 5, 5);
                    BaseFont fuente = BaseFont.CreateFont(BaseFont.COURIER,BaseFont.CP1250,true);

                    
                    iTextSharp.text.Font fontBody = new iTextSharp.text.Font(fuente,14f,iTextSharp.text.Font.NORMAL,BaseColor.GRAY);
                    PdfWriter wt = PdfWriter.GetInstance(pdfDoc, fS);

                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase("",fontBody));
                    //pdfDoc.Add(new FontStyle(Properties.Resources.segoeuil));

                    using (StringReader sr = new StringReader(paginaHtmlText))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(wt, pdfDoc, sr);
                        //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                      
                    }
                    pdfDoc.Close();
                    fS.Close();
                }
            }
        }
    }
}