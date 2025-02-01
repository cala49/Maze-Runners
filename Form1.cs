using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Runners
{
    public partial class FormPresentacion : Form
    {
        public FormPresentacion()
        {
            InitializeComponent();
        }

        private void btnCambioForm_Click(object sender, EventArgs e)
        {
            FormJuego formJuego = new FormJuego();
            formJuego.ShowDialog();
        }

        private void btnPrologo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La historia fue creada para proporcionar un contexto emocionante y atractivo" +
                " para un juego de aventuras en un laberinto. Al situar a los personajes en el misterioso " +
                "entorno de Tartaria, se busca captar la atención del jugador y sumergirlo en una " +
                "narrativa que resalte la importancia de la colaboración, la valentía y la superación " +
                "de desafíos. La recolección de banderas sirve como un objetivo claro, añadiendo un" +
                " elemento de competencia y logro, lo que enriquece la experiencia de juego y motiva " +
                "a los jugadores a seguir adelante en su aventura. Digamos que esta version es solo el " +
                "principio de dichos desafios y que vendran nuevas actualizaciones para un mayor disfrute " +
                "de los mismos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
