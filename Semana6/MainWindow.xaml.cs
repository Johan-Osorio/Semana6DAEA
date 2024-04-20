using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Semana6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=LAB1504-29\\SQLEXPRESS;Initial Catalog=Neptuno;User Id=johan;Password=123456";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Formulario ventanaFormulario = new Formulario();

            ventanaFormulario.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string idCliente = "AAAA";
            string nombreCompañia = "JAOM";
            string nombreContacto = "Aylin";
            string cargoContacto = "Traductora";
            string direccion = "Huaycan";
            string ciudad = "Lima";
            string region = "Lima";
            string codPostal = "12345";
            string pais = "Peru";
            string telefono = "987654321";
            string fax = "JECM";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("USP_ActualizarCliente", connection))
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

            MessageBox.Show("Cliente actualizado correctamente.");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string idCliente = "AAAA";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("USP_EliminarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@idCliente", idCliente);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cliente eliminado correctamente.");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("USP_ListarClientes", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgClientes.ItemsSource = dt.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al listar clientes: " + ex.Message);
                }
            }
        }
    }
}