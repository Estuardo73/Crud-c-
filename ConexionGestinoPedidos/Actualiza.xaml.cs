using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ConexionGestinoPedidos
{
    /// <summary>
    /// Lógica de interacción para Actualiza.xaml
    /// </summary>
    public partial class Actualiza : Window
    {
        public Actualiza(int idCliente)
        {
            InitializeComponent();
            ClienteP = idCliente;

            string miConexion = ConfigurationManager.ConnectionStrings
                ["ConexionGestinoPedidos.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);
        }

        private void btnAct_Click(object sender, RoutedEventArgs e)
        {
            if (txtClienteUpd.Text != "")
            {
                string actualizar = "UPDATE CLIENTE SET nombre =@nombrecli WHERE Id="+ClienteP;
                SqlCommand miSqlComando = new SqlCommand(actualizar, miConexionSql);
                miConexionSql.Open();
                miSqlComando.Parameters.AddWithValue("@nombrecli", txtClienteUpd.Text);
                miSqlComando.ExecuteNonQuery();
                miConexionSql.Close();
                txtClienteUpd.Text = "";
                MessageBox.Show("actualizacino exitosa");
            }
            else
            {
                MessageBox.Show("Debe de ingresar un nombre valido");
            }
            this.Close();
        }
        SqlConnection miConexionSql;
        private int ClienteP;
    }
}
