using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace pruebatecnica
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Accede a la cadena de conexión
			string connectionString = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();
					//MessageBox.Show("Conexión exitosa a la base de datos.", "Conexión");
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error en la conexión: {ex.Message}", "Error");
					return; // Sale si la conexión falla
				}
			}
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmLogin());
		}
	}
}
