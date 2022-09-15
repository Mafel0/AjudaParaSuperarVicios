using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class frmCadastro : Form
    {
        public DateTime campoData
        {
            get; set;
        }
    

        
        public string Tipo
        {
            get;set;
        }

        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            Tipo = cmbTipo.Text.ToString();
            campoData = dtpData.Value;
            DateTime Vdias = DateTime.Now;

            if ((cmbTipo.Text != "") && (dtpData.Text != "") && (campoData <= Vdias))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("TEXT.txt");
                    //Inserir informações no arquivo
                    sw.WriteLine(Tipo);
                    sw.WriteLine(campoData);
                    sw.Close();
                }
                catch (Exception erroarquivo)
                {
                    Console.WriteLine("Exception: " + erroarquivo.Message);
                }
                this.Close();

            }
            else
            {
                MessageBox.Show(
                    "Preencha corretamente!",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }

        private void mskData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
