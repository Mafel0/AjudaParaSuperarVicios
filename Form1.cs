using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;


namespace $safeprojectname$
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            CarregarInfos();

        }

        private void CarregarInfos()
        {
            string linha;
            StreamReader sr = new StreamReader("TEXT.txt");
            linha = sr.ReadLine();
            if (linha != null)
            {
                string Tipo = linha;
                //Read the next line
                linha = sr.ReadLine();
                DateTime campoData = Convert.ToDateTime(linha);
                DateTime Vdias = DateTime.Now;
                atualizaCampos(campoData, Vdias, Tipo);
            }
            sr.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DateTime Vdias = DateTime.Now;
            frmCadastro frmCad = new frmCadastro();

            frmCad.ShowDialog();
            atualizaCampos(frmCad.campoData, Vdias, frmCad.Tipo);
            

        }   
        
        private void atualizaCampos(DateTime campoData, DateTime Vdias, string Tipo)
        {
            double Diasm;
            double Horass;
            this.lblTipo.Text =Tipo;
            Diasm = (Vdias - campoData).TotalDays;
            Horass = (Vdias - campoData).TotalHours;
            double HorasFinais = (Math.Round(Horass, 0) - Math.Round(Diasm, 0) * 24);

            if (Diasm <0){
                Diasm = 0;
            }
            if (HorasFinais < 0)
            {
                HorasFinais = 0;
            }

            lblDias.Text = Diasm.ToString("0");
            lblHoras.Text =HorasFinais.ToString("0");
            
        }

        private void lblDias_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnDesistir_Click(object sender, EventArgs e)
        {
            Random numAleatorio = new Random();
            int valorInteiro = numAleatorio.Next(0, 7);

            SoundPlayer somDespertar = new SoundPlayer(@"Motivacao.wav");
            string[] frases = new string[]
            { "Se você está atravessando o inferno...não pare!",
            "A persistência é o caminho do êxito!",
            "Persista! A vida de vez em quando precisa ter a certeza de que você quer de verdade!",
            "O matadouro do fracasso NÃO é o seu destino!",
             "Sempre parece impossível. Até que seja feito!",
             "O matadouro do fracasso NÃO é o seu destino!",
             "Uma viagem de milhares de quilômetros começa com um único passo!"
            };
            somDespertar.Play();
            DialogResult dialogResult = MessageBox.Show(
            frases[valorInteiro],
            "NÃO DESISTA!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
            );
            if (dialogResult == DialogResult.OK)
                somDespertar.Stop();

               
        }
    }
}
