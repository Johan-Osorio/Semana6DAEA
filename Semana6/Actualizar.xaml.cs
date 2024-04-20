using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Semana6
{
    /// <summary>
    /// Lógica de interacción para Actualizar.xaml
    /// </summary>
    public partial class Actualizar : Window
    {
        private string connectionString = "Data Source=LAB1504-29\\SQLEXPRESS;Initial Catalog=Neptuno;User Id=johan;Password=123456";
        public Actualizar()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string idCliente = Z.Text;
            string nombreCompañia = A.Text;
            string nombreContacto = B.Text;
            string cargoContacto = C.Text;
            string direccion = D.Text;
            string ciudad = E.Text;
            string region = F.Text;
            string codPostal = G.Text;
            string pais = H.Text;
            string telefono = I.Text;
            string fax = J.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("USP_ActualizarClientes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.Parameters.AddWithValue("@NombreCompañia", nombreCompañia);
                    command.Parameters.AddWithValue("@NombreContacto", nombreContacto);
                    command.Parameters.AddWithValue("@CargoContacto", cargoContacto);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Ciudad", ciudad);
                    command.Parameters.AddWithValue("@Region", region);
                    command.Parameters.AddWithValue("@CodPostal", codPostal);
                    command.Parameters.AddWithValue("@Pais", pais);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Fax", fax);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cliente registrado correctamente");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged_Z(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_6(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_7(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_8(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_9(object sender, TextChangedEventArgs e)
        {

        }
    }
}
