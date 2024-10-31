using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using static DevExpress.XtraEditors.RoundedSkinPanel;

namespace pruebatecnica
{
	public partial class frmLogin : DevExpress.XtraEditors.XtraForm
	{
		// cadena de conexion a la bd
		private string cadena = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;
		public frmLogin()
		{
			InitializeComponent();
		}

		private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
		{

		}

		private void labelControl1_Click(object sender, EventArgs e)
		{

		}

		private void labelControl3_Click(object sender, EventArgs e)
		{

		}

		private void textEdit2_EditValueChanged(object sender, EventArgs e)
		{

		}
		//realiza la validacion en la bd de las credenciales
		private bool ValidarUsuario(string correo, string clave)
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(cadena))
				{
					SqlCommand cmd = new SqlCommand("SP_VALIDARUSUARIO", cn);
					cmd.Parameters.AddWithValue("CORREO", correo);
					cmd.Parameters.AddWithValue("CLAVE", clave);
					cmd.CommandType = CommandType.StoredProcedure;

					cn.Open();
					object result = cmd.ExecuteScalar();
					return result != null && Convert.ToInt32(result) != 0;
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
		private void bttnOK_Click(object sender, EventArgs e)
		{
			// Captura los valores ingresados por el usuario
			string correo = txtUserName.Text;
			string clave = txtPassword.Text;
			string confirmarClave = txtPasswordConfirmar.Text;

			// Valida que los campos no estén vacíos
			if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(clave))
			{
				MessageBox.Show("Por favor ingrese correo y contraseña.", "Error");
				return;
			}

			// Valida que la contraseña no sea diferente en la confirmacion
			if (clave != confirmarClave)
			{
				MessageBox.Show("Las contraseñas no coinciden", "Error");
				return;
			}

			// Valida el usuario en la base de datos
			if (ValidarUsuario(correo, clave))
			{
				MessageBox.Show("Login exitoso", "Acceso");
				this.Hide();

				frmMain frm = new frmMain();
				frm.Show();
			}
			else
			{
				MessageBox.Show("Usuario o contraseña incorrectos", "Error");
			}
		}

		private void labelControl4_Click(object sender, EventArgs e)
		{

		}

		private void txtUserName_EditValueChanged(object sender, EventArgs e)
		{

		}
		// boton para registar
		private void simpleButtonRegistrame_Click(object sender, EventArgs e)  
		{

			// Abre el formulario principal
			Registro frm = new Registro();
			frm.Show();
			this.Hide(); 
		}
		private void frmLogin_Load(object sender, EventArgs e)
		{

		}
	}
}