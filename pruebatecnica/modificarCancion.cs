using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pruebatecnica.frmMain;

namespace pruebatecnica
{
	public partial class modificarCancion : DevExpress.XtraEditors.XtraForm
	{
		private Cancion cancion;

		public modificarCancion(Cancion cancionDetalles)
		{
			InitializeComponent();
			cancion = cancionDetalles;
		}

		private void modificarCancion_Load(object sender, EventArgs e)
		{

			textEditCANCION2.Text = cancion.Titulo; 
			textEditARTISTA2.Text = cancion.Artista;
			textEditALBUM2.Text = cancion.Album;
			textEditGENERO2.Text = cancion.Genero;
			textEditAÑO2.Text = cancion.Ano;
			textEditDURACION2.Text = cancion.Duracion;
			textEditCOMPOSITOR2.Text = cancion.Compositor;
			textEditPRODUCTOR2.Text = cancion.Productor;
			textEditDISCOGRAFIA2.Text = cancion.Discografia;
			textEditIDIOMA2.Text = cancion.Idioma;
			textEditFORMATO2.Text = cancion.Formato;
			textEditCALIDAD2.Text = cancion.Calidad;
			textEditPRECIO2.Text = cancion.Precio;
			textEditPOPULARIDAD2.Text = cancion.Popularidad;
			textEditBPM2.Text = cancion.Bpm;
			textEditPLATAFORMA2.Text = cancion.Reproductor_web;
			dateEditLANZAMIENTO2.Text = cancion.Fecha_lanzamiento;
			textEditIDIOMAORIGINAL2.Text = cancion.Idioma_original;
			textEditPISTA2.Text = cancion.Numero_pista;
			textEditCOMENTARIOS2.Text = cancion.Comentarios;
		}

		private void salirModificacionCancion_Click(object sender, EventArgs e)
		{
			frmMain frm = new frmMain();
			frm.Show();
			this.Close();
		}

		private void actualizarCancion_Click(object sender, EventArgs e)
		{
			// Cadena de conexión a la base de datos
			using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString))
			{
				// query SQL de actualización en la bd

				string query = "UPDATE CANCIONES SET TITULO = @Titulo, ARTISTA = @Artista, ALBUM = @Album, GENERO = @Genero, ANO = @Ano, " +
							   "DURACION = @Duracion, COMPOSITOR = @Compositor, PRODUCTOR = @Productor, DISCOGRAFIA = @Discografia, IDIOMA = @Idioma, " +
							   "FORMATO = @Formato, CALIDAD = @Calidad, PRECIO = @Precio, POPULARIDAD = @Popularidad, BPM = @Bpm, " +
							   "REPRODUCTOR_WEB = @Reproductor_web, FECHA_LANZAMIENTO = @Fecha_Lanzamiento, IDIOMA_ORIGINAL = @Idioma_original, " +
							   "NUMERO_PISTA = @Numero_pista, COMENTARIOS = @Comentarios WHERE TITULO = @Titulo";

				SqlCommand cmd = new SqlCommand(query, cn);
				cmd.Parameters.AddWithValue("@Titulo", textEditCANCION2.Text);
				cmd.Parameters.AddWithValue("@Artista", textEditARTISTA2.Text);
				cmd.Parameters.AddWithValue("@Album", textEditALBUM2.Text);
				cmd.Parameters.AddWithValue("@Genero", textEditGENERO2.Text);

				// Convierte a entero (Int32) si el campo ANO es numérico en la base de datos
				cmd.Parameters.AddWithValue("@Ano", int.TryParse(textEditAÑO2.Text, out int ano) ? ano : (object)DBNull.Value);

				// Convierte a decimal o float si el campo DURACION es numérico
				cmd.Parameters.AddWithValue("@Duracion", decimal.TryParse(textEditDURACION2.Text, out decimal duracion) ? duracion : (object)DBNull.Value);

				cmd.Parameters.AddWithValue("@Compositor", textEditCOMPOSITOR2.Text);
				cmd.Parameters.AddWithValue("@Productor", textEditPRODUCTOR2.Text);
				cmd.Parameters.AddWithValue("@Discografia", textEditDISCOGRAFIA2.Text);
				cmd.Parameters.AddWithValue("@Idioma", textEditIDIOMA2.Text);
				cmd.Parameters.AddWithValue("@Formato", textEditFORMATO2.Text);
				cmd.Parameters.AddWithValue("@Calidad", textEditCALIDAD2.Text);

				// Convierte a decimal o float si el campo PRECIO es numérico
				cmd.Parameters.AddWithValue("@Precio", decimal.TryParse(textEditPRECIO2.Text, out decimal precio) ? precio : (object)DBNull.Value);

				// Convierte a entero (Int32) si el campo POPULARIDAD es numérico
				cmd.Parameters.AddWithValue("@Popularidad", int.TryParse(textEditPOPULARIDAD2.Text, out int popularidad) ? popularidad : (object)DBNull.Value);

				// Convierte a entero (Int32) si el campo BPM es numérico
				cmd.Parameters.AddWithValue("@Bpm", int.TryParse(textEditBPM2.Text, out int bpm) ? bpm : (object)DBNull.Value);

				cmd.Parameters.AddWithValue("@Reproductor_web", textEditPLATAFORMA2.Text);

				// Asegura de convertir la fecha
				cmd.Parameters.AddWithValue("@Fecha_Lanzamiento", DateTime.TryParse(dateEditLANZAMIENTO2.Text, out DateTime fechaLanzamiento) ? fechaLanzamiento : (object)DBNull.Value);

				cmd.Parameters.AddWithValue("@Idioma_original", textEditIDIOMAORIGINAL2.Text);

				// Convierte a entero (Int32) si el campo NUMERO_PISTA es numérico
				cmd.Parameters.AddWithValue("@Numero_pista", int.TryParse(textEditPISTA2.Text, out int numeroPista) ? numeroPista : (object)DBNull.Value);

				cmd.Parameters.AddWithValue("@Comentarios", textEditCOMENTARIOS2.Text);

				cn.Open();
				int rowsAffected = cmd.ExecuteNonQuery();

				// Verifica si la actualización fue exitosa
				if (rowsAffected > 0)
				{
					XtraMessageBox.Show("La canción se ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				else
				{
					XtraMessageBox.Show("Hubo un problema al actualizar la canción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}


	}
}