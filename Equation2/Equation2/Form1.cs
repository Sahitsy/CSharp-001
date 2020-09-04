using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equation2
{
    public partial class Form1 : Form
    {
        double a, b, c, Delta, RacineDelta;

        public Form1()
        {
            InitializeComponent();
        }

        // Résolution de l'équation
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupération des valeurs saisies
                a = double.Parse(textBoxA.Text);
                b = double.Parse(textBoxB.Text);
                c = double.Parse(textBoxC.Text);
            }
            catch
            {
                // Si on n'arrive pas => Erreur
                textBoxA.Text = "0,0";
                textBoxB.Text = "0,0";
                textBoxC.Text = "0,0";
                MessageBox.Show("Veuillez recommencer!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Calcul de Delta
            Delta = (b * b) - 4.0 * a * c;
            textBoxDelta.Text = Convert.ToString(Delta);

            // En fonction de la valeur du Delta :

            // Delta Négatif
            if (Delta < 0)
            {
                double dn;
                dn = (-1 * Delta);
                RacineDelta = (Math.Sqrt(dn)) / (2 * a);
                string rrdd = Convert.ToString(RacineDelta);

                // Solution
                double x1, x2;
                x1 = (-1 * b) / (2 * a);
                x2 = (-1 * b) / (2 * a);

                string xx1, xx2;
                xx1 = Convert.ToString(x1);
                xx2 = Convert.ToString(x2);

                textBoxINFO.Text = "Delta est négatif. L'équation a 2 racines complexes conjuguées: z1 et z2 :";

                pictureBox3.Image = global::Equation2.Properties.Resources.Delta3;
                textBoxX1.Text = xx1 + " - i(" + rrdd + ")";
                textBoxX2.Text = xx1 + " + i(" + rrdd + ")";
            }

            // Delta = Zéro
            if (Delta == 0)
            {
                // Solution
                double x1;
                string xx1;
                x1 = (-1 * b) / (2 * a);
                xx1 = Convert.ToString(x1);

                textBoxINFO.Text = "Delta vaut : 0. L'équation a une racine double: x1 = x2 :";

                pictureBox3.Image = global::Equation2.Properties.Resources.Delta2;
                textBoxX1.Text = xx1;
                textBoxX2.Text = xx1;
            }

            // Delta Positif
            if (Delta > 0)
            {
                RacineDelta = Math.Sqrt(Delta);
                string rrdd = Convert.ToString(RacineDelta);

                // Solution
                double x1, x2;
                x1 = ((-1 * b) - RacineDelta) / (2 * a);
                x2 = ((-1 * b) + RacineDelta) / (2 * a);

                string xx1, xx2;
                xx1 = Convert.ToString(x1);
                xx2 = Convert.ToString(x2);

                textBoxINFO.Text = "La racine de Delta vaut : " + rrdd + ". L'équation a 2 racines distinctes: x1 et x2 :";

                pictureBox3.Image = global::Equation2.Properties.Resources.Delta1;
                textBoxX1.Text = xx1;
                textBoxX2.Text = xx2;
            }
        }
    }
}
