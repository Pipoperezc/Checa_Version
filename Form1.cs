using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace Checa_Version
{
    public partial class Form1 : Form
    {
        private string lcVersion_local;
        private string lcVersion_Server;

        public string lcRuta_local;
        public string lcRuta_Servidor;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var oArchivo_Ini = new Archivo_Ini("config.ini");
            lcRuta_local = oArchivo_Ini.Read( "ruta_local", "LOCALIZ_ARCHIVOS");
            lcRuta_Servidor = oArchivo_Ini.Read("ruta_servidor", "LOCALIZ_ARCHIVOS");
            oArchivo_Ini = null;

            lcRuta_local = lcRuta_local + "newberry.exe";
            lcRuta_Servidor = lcRuta_Servidor + "newberry.exe";


            Version_Servidor();
            textBox1.Text = lcVersion_Server;
        }


        private void Termina_Proceso(string lcProceso)
        {// Termina_Proceso
            Process[] oProcesoCierre = Process.GetProcessesByName(lcProceso);
            if (oProcesoCierre.Length > 0)
            { //If
                string lcDialogo = "La aplicacion se encuentra abierta, Favor de Guardar su informacion porque se cerrara para su actualizacion";
                string lcTitulo_Dialogo = "Aplicacion Abierta";
                MessageBoxButtons oBoton_Dialogo = MessageBoxButtons.OK;
                MessageBox.Show(lcDialogo, lcTitulo_Dialogo, oBoton_Dialogo);

                try
                {
                    oProcesoCierre[0].Kill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } // if
            oProcesoCierre = null;
        }// Termnina_Proceso

        public string Version_Servidor()
        { //Version_Servidor
            string lcVersion = "";
            if (File.Exists(@lcRuta_Servidor))
            {
                var VersionInfo = FileVersionInfo.GetVersionInfo(@lcRuta_Servidor);
                lcVersion = VersionInfo.ProductVersion;
            }
            else
            {
                string lcMensaje = "No existe el archivo";
                string lcTitulo = "No Hay Archivo";
                MessageBoxButtons oBotonDialogo = MessageBoxButtons.OK;
                DialogResult oDialogo;
                oDialogo = MessageBox.Show(lcMensaje, lcTitulo, oBotonDialogo);
            };
            lcVersion_Server = lcVersion;
            return lcVersion_Server; 
        } // Version_Servidor

        public string Version_Local()
        { //Version_local 
            string lcVersion = "";
            if (File.Exists(@lcRuta_local))
            {
                var VersionInfo = FileVersionInfo.GetVersionInfo(@lcRuta_local);
                lcVersion = VersionInfo.ProductVersion;
             }
            else
            {
                string lcMensaje = "No existe el archivo";
                string lcTitulo = "No Hay Archivo";
                MessageBoxButtons oBotonDialogo = MessageBoxButtons.OK;
                DialogResult oDialogo;
                oDialogo = MessageBox.Show(lcMensaje, lcTitulo, oBotonDialogo);
            };
            lcVersion_local = lcVersion;
            return lcVersion_local;
        } //Version_local 

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
