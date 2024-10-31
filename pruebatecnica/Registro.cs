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
	public partial class Registro : DevExpress.XtraEditors.XtraForm
	{

		private string cadena = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;
		public Registro()
		{
			InitializeComponent();
		}

		private void simpleButtonVolverRegistro_Click(object sender, EventArgs e)
		{
			frmLogin frm = new frmLogin();
			frm.Show();
			this.Close();
		}

		// registra usuario mediante Store Procedure en bd
		private bool RegistroUsuario(string correo, string clave)
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(cadena))
				{
					SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", cn);
					cmd.CommandType = CommandType.StoredProcedure;

					// Parámetros de entrada
					cmd.Parameters.AddWithValue("@CORREO", correo);
					cmd.Parameters.AddWithValue("@CLAVE", clave);

					// Parámetros de salida
					SqlParameter registradoParam = new SqlParameter("@REGISTRADO", SqlDbType.Bit);
					registradoParam.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(registradoParam);

					SqlParameter mensajeParam = new SqlParameter("@MENSAJE", SqlDbType.VarChar, 100);
					mensajeParam.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(mensajeParam);

					cn.Open();
					cmd.ExecuteNonQuery();

					// Captura el valor de los parámetros de salida
					bool registrado = Convert.ToBoolean(cmd.Parameters["@REGISTRADO"].Value);
					string mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();

					// Muestra mensaje con los valores de salida
					MessageBox.Show(mensaje, "Resultado del Registro");

					return registrado;
				}
			}
			catch (SqlException sqlEx)
			{
				MessageBox.Show($"Error en la validación: {sqlEx.Message}", "Error");
				return false; // Indica que la validación falló
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error inesperado: {ex.Message}", "Error");
				return false; // Indica que la validación falló
			}
		}
		private void RegistroUsuario_Click(object sender, EventArgs e)
		{
			// Captura los valores ingresados por el usuario
			string correo = txtRegistrarCorreo.Text;
			string clave = txtRegistrarContraseña.Text;

			string confirmarClave = txtRegistrarConfirmarContraseña.Text;

			// Valida que los campos no estén vacíos
			if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(clave))
			{
				MessageBox.Show("Por favor ingrese correo y contraseña.", "Error");
				return;
			}

			if (clave != confirmarClave)
			{
				MessageBox.Show("Las contraseñas no coinciden", "Error");
				return;
			}

			// Valida el usuario en la base de datos
			if (RegistroUsuario(correo, clave))
			{
				MessageBox.Show("Login exitoso en registro", "Acceso");
				this.Hide(); 
				frmLogin frm = new frmLogin();
				frm.Show();
			}
			else
			{
				MessageBox.Show("Usuario o contraseña incorrectos", "Error");
			}
		}
		private void frmLogin_Load(object sender, EventArgs e)
		{

		}
		private void Registro_Load(object sender, EventArgs e)
		{

		}
	}
}