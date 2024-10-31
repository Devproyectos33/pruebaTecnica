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

namespace pruebatecnica
{
	public partial class registroCancionArtista : DevExpress.XtraEditors.XtraForm
	{
		private string cadena = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;
		private bool precioModificado = false; // Variable para rastrear si el usuario ha comenzado a modificar el precio

		public registroCancionArtista()
		{
			InitializeComponent();

			textEditAÑO.KeyPress += textEditNumerico_KeyPress;
			textEditDURACION.KeyPress += textEditNumerico_KeyPress;
			textEditCALIDAD.KeyPress += textEditNumerico_KeyPress;
			textEditPRECIO.KeyPress += textEditDecimal_KeyPress;
			textEditPRECIO.Leave += textEditPRECIO_Leave;
			textEditPOPULARIDAD.KeyPress += textEditNumerico_KeyPress;
			textEditBPM.KeyPress += textEditNumerico_KeyPress;
			textEditPISTA.KeyPress += textEditNumerico_KeyPress;

			// Inicializar el campo de precio con "0.00"
			textEditPRECIO.Text = "0.00";
		}

		private void registroCancionArtista_Load(object sender, EventArgs e)
		{
		}

		private void textEditNumerico_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Permite solo dígitos y teclas de control (como Backspace)
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textEditDecimal_KeyPress(object sender, KeyPressEventArgs e)
		{
			TextEdit textEdit = sender as TextEdit;

			// Borra el valor inicial "0.00" si aún no ha sido modificado
			if (!precioModificado)
			{
				textEdit.Text = "";
				precioModificado = true;
			}

			// Permite solo dígitos, un solo punto decimal y teclas de control
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
				return;
			}

			// Permite solo un punto decimal
			if (e.KeyChar == '.' && textEdit.Text.Contains("."))
			{
				e.Handled = true;
				return;
			}

			// Restringe a dos decimales después del punto
			if (textEdit.Text.Contains("."))
			{
				int decimalPosition = textEdit.Text.IndexOf(".");
				string decimals = textEdit.Text.Substring(decimalPosition + 1);

				// Si ya tiene dos decimales, bloquea más entradas después del punto
				if (decimals.Length >= 2 && !char.IsControl(e.KeyChar))
				{
					e.Handled = true;
				}
			}
		}

		// Valida formato decimal y restaurar "0.00" si el campo queda vacío
		private void textEditPRECIO_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textEditPRECIO.Text))
			{
				textEditPRECIO.Text = "0.00";
				precioModificado = false;
			}
			else
			{
				// Intenta convertir el valor a decimal y forzar el formato "0.00"
				if (decimal.TryParse(textEditPRECIO.Text, out decimal value))
				{
					textEditPRECIO.Text = value.ToString("0.00");
				}
				else
				{
					MessageBox.Show("El valor ingresado no es un formato decimal válido. Ejemplo: 100.00");
					textEditPRECIO.Text = "0.00";
				}
			}
		}

		private bool ValidarCampos()
		{
			// Verifica si todos los campos obligatorios están llenos
			if (string.IsNullOrWhiteSpace(textEditCANCION.Text) ||
				string.IsNullOrWhiteSpace(textEditARTISTA.Text) ||
				string.IsNullOrWhiteSpace(textEditALBUM.Text) ||
				string.IsNullOrWhiteSpace(textEditGENERO.Text) ||
				string.IsNullOrWhiteSpace(textEditAÑO.Text) ||
				string.IsNullOrWhiteSpace(textEditDURACION.Text) ||
				string.IsNullOrWhiteSpace(textEditCOMPOSITOR.Text) ||
				string.IsNullOrWhiteSpace(textEditPRODUCTOR.Text) ||
				string.IsNullOrWhiteSpace(textEditDISCOGRAFIA.Text) ||
				string.IsNullOrWhiteSpace(textEditIDIOMA.Text) ||
				string.IsNullOrWhiteSpace(textEditFORMATO.Text) ||
				string.IsNullOrWhiteSpace(textEditCALIDAD.Text) ||
				string.IsNullOrWhiteSpace(textEditPRECIO.Text) ||
				string.IsNullOrWhiteSpace(textEditPOPULARIDAD.Text) ||
				string.IsNullOrWhiteSpace(textEditBPM.Text) ||
				string.IsNullOrWhiteSpace(textEditPLATAFORMA.Text) ||
				string.IsNullOrWhiteSpace(textEditIDIOMAORIGINAL.Text) ||
				string.IsNullOrWhiteSpace(textEditPISTA.Text))
			{
				MessageBox.Show("Por favor, complete todos los campos obligatorios.");
				return false;
			}

			return true;
		}

		private void InsertarDatos()
		{
			string query = "INSERT INTO Canciones (Titulo, Artista, Album, Genero, Ano, Duracion, Compositor, \n" +
				"Productor, Discografia, Idioma, Formato, Calidad, Precio, Popularidad, BPM, REPRODUCTOR_WEB, \n" +
				"Fecha_Lanzamiento, Idioma_Original, Numero_Pista, Comentarios) VALUES (@Valor1, @Valor2, @Valor3, \n" +
				"@Valor4, @Valor5, @Valor6,@Valor7, @Valor8, @Valor9,@Valor10, @Valor11, @Valor12,@Valor13, @Valor14, \n" +
				"@Valor15,@Valor16, @Valor17, @Valor18,@Valor19, @Valor20)";

			using (SqlConnection cn = new SqlConnection(cadena))  // Cadena de conexion
			{
				SqlCommand cmd = new SqlCommand(query, cn);

				cmd.Parameters.AddWithValue("@Valor1", textEditCANCION.Text);
				cmd.Parameters.AddWithValue("@Valor2", textEditARTISTA.Text);
				cmd.Parameters.AddWithValue("@Valor3", textEditALBUM.Text);
				cmd.Parameters.AddWithValue("@Valor4", textEditGENERO.Text);

				// Valida y agrega el año como int
				if (!int.TryParse(textEditAÑO.Text, out int año))
				{
					MessageBox.Show("El año ingresado no es válido.");
					return;
				}
				cmd.Parameters.AddWithValue("@Valor5", año);

				// Valida y agrega duración como int
				if (!int.TryParse(textEditDURACION.Text, out int duracion))
				{
					MessageBox.Show("La duración ingresada no es válida.");
					return;
				}
				cmd.Parameters.AddWithValue("@Valor6", duracion);

				cmd.Parameters.AddWithValue("@Valor7", textEditCOMPOSITOR.Text);
				cmd.Parameters.AddWithValue("@Valor8", textEditPRODUCTOR.Text);
				cmd.Parameters.AddWithValue("@Valor9", textEditDISCOGRAFIA.Text);
				cmd.Parameters.AddWithValue("@Valor10", textEditIDIOMA.Text);
				cmd.Parameters.AddWithValue("@Valor11", textEditFORMATO.Text);
				cmd.Parameters.AddWithValue("@Valor12", textEditCALIDAD.Text);

				// Convierte el precio a decimal
				decimal precio;
				if (!decimal.TryParse(textEditPRECIO.Text, out precio))
				{
					MessageBox.Show("El precio ingresado no es un formato decimal válido.");
					return; // Detiene la inserción si el precio no es válido
				}
				cmd.Parameters.AddWithValue("@Valor13", precio); // Asigna el valor decimal

				// Valida y agrega popularidad como int
				if (!int.TryParse(textEditPOPULARIDAD.Text, out int popularidad))
				{
					MessageBox.Show("La popularidad ingresada no es válida.");
					return;
				}
				cmd.Parameters.AddWithValue("@Valor14", popularidad);

				// Valida y agrega BPM como int
				if (!int.TryParse(textEditBPM.Text, out int bpm))
				{
					MessageBox.Show("El BPM ingresado no es válido.");
					return;
				}
				cmd.Parameters.AddWithValue("@Valor15", bpm);

				cmd.Parameters.AddWithValue("@Valor16", textEditPLATAFORMA.Text);

				// Usa la fecha correctamente
				cmd.Parameters.AddWithValue("@Valor17", dateEditLANZAMIENTO.DateTime);

				cmd.Parameters.AddWithValue("@Valor18", textEditIDIOMAORIGINAL.Text);

				// Valida y agrega número de pista como int
				if (!int.TryParse(textEditPISTA.Text, out int numeroPista))
				{
					MessageBox.Show("El número de pista ingresado no es válido.");
					return;
				}
				cmd.Parameters.AddWithValue("@Valor19", numeroPista);

				cmd.Parameters.AddWithValue("@Valor20", textEditCOMENTARIOS.Text);

				try
				{
					cn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Datos insertados correctamente");

					frmMain frm = new frmMain();
					frm.Show(); 
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error al insertar datos: " + ex.Message);
				}
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			// Valida los campos antes de insertar
			if (ValidarCampos())
			{
				InsertarDatos();
			}
		}

		private void dateTimeChartRangeControlClient1_CustomizeSeries(object sender, ClientDataSourceProviderCustomizeSeriesEventArgs e)
		{}

		private void salirRegistroCancion_Click(object sender, EventArgs e)
		{
			frmMain frm = new frmMain();
			frm.Show();
			this.Close();
		}
	}
}