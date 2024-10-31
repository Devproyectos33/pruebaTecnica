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
using System.Windows.Forms;
using static DevExpress.XtraEditors.RoundedSkinPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace pruebatecnica
{
	public partial class frmMain : DevExpress.XtraEditors.XtraForm
	{

		private string cadena = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;
		private List<string> cancionesOriginales = new List<string>(); // Lista para almacenar todas las canciones

		public frmMain()
		{
			InitializeComponent();
			this.Load += frmMain_Load;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			CargarCanciones(); // Carga las canciones en el ComboBoxEdit al inicio
			listadoCanciones.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard; // Permite que el usuario escriba en el ComboBoxEdit
			listadoCanciones.TextChanged += listadoCanciones_TextChanged; // Añade el evento TextChanged para filtrar en base al texto ingresado
		}

		private void CargarCanciones()
		{
			string query = "SELECT TITULO,ARTISTA FROM CANCIONES";
			using (SqlConnection cn = new SqlConnection(cadena))

			{
				SqlCommand cmd = new SqlCommand(query, cn);
				cn.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				// Limpia la lista original antes de cargar
				cancionesOriginales.Clear();
				listadoCanciones.Properties.Items.Clear();

				// Añade cada canción al ComboBoxEdit y a la lista original
				while (reader.Read())
				{
					// Combina el título y el artista en una sola línea
					string cancionArtista = $"{reader["TITULO"]} - {reader["ARTISTA"]}";
					listadoCanciones.Properties.Items.Add(cancionArtista);
					cancionesOriginales.Add(cancionArtista); // Agregar a la lista original
				}

				reader.Close();
			}
		}

		private void listadoCanciones_TextChanged(object sender, EventArgs e)
		{
			// Obtiene el texto actual ingresado
			string filtro = listadoCanciones.Text.ToLower();

			// Filtra los elementos buscando coincidencias al inicio de cada canción o artista
			var itemsFiltrados = cancionesOriginales
				.Where(item => item.ToLower().Contains(filtro)) // Busca en el texto completo (canción - artista)
				.ToList();

			// Actualiza los elementos mostrados en el ComboBoxEdit
			listadoCanciones.Properties.Items.BeginUpdate();
			listadoCanciones.Properties.Items.Clear();
			listadoCanciones.Properties.Items.AddRange(itemsFiltrados);
			listadoCanciones.Properties.Items.EndUpdate();

			// Muestra el Popup para que el usuario vea las coincidencias
			listadoCanciones.ShowPopup();
		}


		private void SalirBotton(object sender, EventArgs e)  // boton de salir
		{
			frmLogin frm = new frmLogin();
			frm.Show();
			this.Hide();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (XtraMessageBox.Show("Estas seguro de salir", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				e.Cancel = true;
			}
			else
			{
				Application.ExitThread();
			}
		}
		private void simpleButtonRegistrameRegistro_Click(object sender, EventArgs e)
		{

		}

		private void RegistrarCancion(object sender, EventArgs e)  // boton de registrar
		{
			frmLogin frm = new frmLogin();
			frm.Show(); 
			this.Hide();
		}

		private void frmMain_Load_1(object sender, EventArgs e)
		{

		}

		private void AgregarCancion_Click(object sender, EventArgs e)
		{
			registroCancionArtista frm = new registroCancionArtista();
			frm.Show();
			this.Hide();
		}

		private void editarCancion_Click(object sender, EventArgs e)
		{
			if (listadoCanciones.SelectedItem != null)
			{
				// Obtiene la canción seleccionada
				string cancionSeleccionada = listadoCanciones.SelectedItem.ToString();

				// Extrae el título y artista para hacer la consulta en la base de datos
				string[] partes = cancionSeleccionada.Split(new string[] { " - " }, StringSplitOptions.None);
				string titulo = partes[0]; // Título

				// Obtiene más información desde la base de datos
				var detallesCancion = ObtenerDetallesCancion(titulo);
				if (detallesCancion != null)
				{
					// Pasa todos los detalles de la canción al formulario modificarCancion
					modificarCancion frm = new modificarCancion(detallesCancion);
					frm.Show();
					this.Hide();
				}
				else
				{
					XtraMessageBox.Show("No se encontró la canción en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				XtraMessageBox.Show("Por favor, selecciona una canción para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		public class Cancion
		{
			public string Titulo { get; set; }
			public string Artista { get; set; }
			public string Album { get; set; }
			public string Genero { get; set; }
			public string Ano { get; set; }
			public string Duracion { get; set; }
			public string Compositor { get; set; }
			public string Productor { get; set; }
			public string Discografia { get; set; }
			public string Idioma { get; set; }
			public string Formato { get; set; }
			public string Calidad { get; set; }
			public string Precio { get; set; }
			public string Popularidad { get; set; }
			public string Bpm { get; set; }
			public string Reproductor_web { get; set; }
			public string Fecha_lanzamiento { get; set; }
			public string Idioma_original { get; set; }
			public string Numero_pista { get; set; }
			public string Comentarios { get; set; }
		}

		private Cancion ObtenerDetallesCancion(string titulo)
		{
			string query = "SELECT * FROM CANCIONES WHERE TITULO = @Titulo";
			using (SqlConnection cn = new SqlConnection(cadena))
			{
				SqlCommand cmd = new SqlCommand(query, cn);
				cmd.Parameters.AddWithValue("@Titulo", titulo);
				cn.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					return new Cancion
					{
						Titulo = reader["TITULO"].ToString(),
						Artista = reader["ARTISTA"].ToString(),
						Album = reader["ALBUM"].ToString(),
						Genero = reader["GENERO"].ToString(),
						Ano = reader["ANO"].ToString(),
						Duracion = reader["DURACION"].ToString(),
						Compositor = reader["COMPOSITOR"].ToString(),
						Productor = reader["PRODUCTOR"].ToString(),
						Discografia = reader["DISCOGRAFIA"].ToString(),
						Idioma = reader["IDIOMA"].ToString(),
						Formato = reader["FORMATO"].ToString(),
						Calidad = reader["CALIDAD"].ToString(),
						Precio = reader["PRECIO"].ToString(),
						Popularidad = reader["POPULARIDAD"].ToString(),
						Bpm = reader["BPM"].ToString(),
						Reproductor_web = reader["REPRODUCTOR_WEB"].ToString(),
						Fecha_lanzamiento = reader["FECHA_LANZAMIENTO"].ToString(),
						Idioma_original = reader["IDIOMA_ORIGINAL"].ToString(),
						Numero_pista = reader["NUMERO_PISTA"].ToString(),
						Comentarios = reader["COMENTARIOS"].ToString(),
															 
					};
				}
			}
			return null;
		}

		private void eliminarCancion_Click(object sender, EventArgs e)
		{
			if (listadoCanciones.SelectedItem != null)
			{
				// Obtiene la canción seleccionada
				string cancionSeleccionada = listadoCanciones.SelectedItem.ToString();
				string[] partes = cancionSeleccionada.Split(new string[] { " - " }, StringSplitOptions.None);
				string titulo = partes[0]; // Título de la canción

				// Confirmación de eliminación
				DialogResult result = XtraMessageBox.Show("¿Estás seguro de que deseas eliminar esta canción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					// Query que Elimina de la base de datos un registro
					string query = "DELETE FROM CANCIONES WHERE TITULO = @Titulo";
					using (SqlConnection cn = new SqlConnection(cadena))
					{
						SqlCommand cmd = new SqlCommand(query, cn);
						cmd.Parameters.AddWithValue("@Titulo", titulo);

						cn.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						// Verificar si la eliminación fue exitosa
						if (rowsAffected > 0)
						{
							XtraMessageBox.Show("La canción se ha eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
							CargarCanciones(); // Recarga el ComboBoxEdit
						}
						else
						{
							XtraMessageBox.Show("No se pudo eliminar la canción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
			else
			{
				XtraMessageBox.Show("Por favor, selecciona una canción para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

	}
}