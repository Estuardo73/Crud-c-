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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ConexionGestinoPedidos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings
                ["ConexionGestinoPedidos.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);

            MuestraTodosPedidos();
            MuestraClientes();
            /*Datos();*/

        }

        private void MuestraClientes()
        {
            try
            {
                string consulta = "SELECT * FROM CLIENTE";
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable clientesTabla = new DataTable();
                    miAdaptadorSql.Fill(clientesTabla);
                    lstClientes.DisplayMemberPath = "nombre";
                    lstClientes.SelectedValuePath = "Id";
                    lstClientes.ItemsSource = clientesTabla.DefaultView;
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }           

        }

        private void MuestraPedidos()
        {

            try
            {
                string consultaPedidos = "SELECT * FROM PEDIDO P INNER JOIN CLIENTE C ON P.cCliente = C.Id " +
                "WHERE C.Id = @ClienteId";

                SqlCommand sqlComando = new SqlCommand(consultaPedidos, miConexionSql);
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(sqlComando);
                using (miAdaptadorSql)
                {
                    sqlComando.Parameters.AddWithValue("@ClienteId", lstClientes.SelectedValue);
                    DataTable pedidosTabla = new DataTable();
                    miAdaptadorSql.Fill(pedidosTabla);
                    lstPedidos.DisplayMemberPath = "fechaPedido";
                    lstPedidos.SelectedValuePath = "Id";
                    lstPedidos.ItemsSource = pedidosTabla.DefaultView;
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            
        }

        private void MuestraTodosPedidos()
        {

            try
            {
                string consultaPedidos = "SELECT * ,CONCAT(Id,' ',Ccliente, ' ',fechaPedido,' ',formaPago) as Info FROM PEDIDO";
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consultaPedidos, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaPedidos = new DataTable();
                    miAdaptadorSql.Fill(tablaPedidos);
                    lstPedidoslista.DisplayMemberPath = "Info";
                    lstPedidoslista.SelectedValuePath = "Id";
                    lstPedidoslista.ItemsSource = tablaPedidos.DefaultView;
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void Datos()
        {

            try
            {
                string consultaPedidos = "SELECT * FROM PEDIDO";
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consultaPedidos, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable DatosPedidos = new DataTable();
                    miAdaptadorSql.Fill(DatosPedidos);
                    grdDatos.ItemsSource = DatosPedidos.DefaultView;
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }   


        SqlConnection miConexionSql;

       /* private void lstClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        } */

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            /* MessageBox.Show(lstPedidoslista.SelectedValue.ToString()); */

            string titulo = "Elimnar";
            string mensaje = "Desea borrar el registro";
            MessageBoxButton botones = MessageBoxButton.YesNo;
            var  pregunta = MessageBox.Show(mensaje, titulo, botones);

            if (pregunta == MessageBoxResult.Yes)
            {
                string borrar = "DELETE FROM PEDIDO WHERE Id=@Pedidoid";
                SqlCommand miSqlComando = new SqlCommand(borrar, miConexionSql);
                miConexionSql.Open();
                miSqlComando.Parameters.AddWithValue("@Pedidoid", lstPedidoslista.SelectedValue);
                miSqlComando.ExecuteNonQuery();
                miConexionSql.Close();
                MuestraTodosPedidos();

            }

        }

        private void Insertar_Click(object sender, RoutedEventArgs e)
        {

            if (txtCliente.Text !="")
            {
                string insertar = "INSERT INTO CLIENTE (nombre) VALUES (@nombre)";
                SqlCommand miSqlComando = new SqlCommand(insertar, miConexionSql);
                miConexionSql.Open();
                miSqlComando.Parameters.AddWithValue("@nombre", txtCliente.Text);
                miSqlComando.ExecuteNonQuery();
                miConexionSql.Close();
                MuestraClientes();
                txtCliente.Text = "";
            } else
            {
                MessageBox.Show("Debe de ingresar un nombre valido");
            }
            
        }

        private void DelCliente_Click(object sender, RoutedEventArgs e)
        {
            string titulo = "Elimnar";
            string mensaje = "Desea borrar el registro";
            MessageBoxButton botones = MessageBoxButton.YesNo;
            var pregunta = MessageBox.Show(mensaje, titulo, botones);

            if (pregunta == MessageBoxResult.Yes)
            {
                string borrar = "DELETE FROM CLIENTE WHERE Id=@clienteId";
                SqlCommand miSqlComando = new SqlCommand(borrar, miConexionSql);
                miConexionSql.Open();
                miSqlComando.Parameters.AddWithValue("@clienteId", lstClientes.SelectedValue);
                miSqlComando.ExecuteNonQuery();
                miConexionSql.Close();
                MuestraClientes();
            }
        }

        private void lstClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MuestraPedidos();
        }

        private void BtnUpd_Click(object sender, RoutedEventArgs e)
        {
            Actualiza ventanaUpd = new Actualiza((int)lstClientes.SelectedValue);
            /* ventanaUpd.Show();  */
            try
            {
                string consulta = "SELECT NOMBRE FROM CLIENTE WHERE Id=@clienteId";
                SqlCommand miSqlComando = new SqlCommand(consulta, miConexionSql);
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miSqlComando);
                using (miAdaptadorSql)
                {
                    miSqlComando.Parameters.AddWithValue("@clienteId", lstClientes.SelectedValue);
                    DataTable clienteTabla = new DataTable();
                    miAdaptadorSql.Fill(clienteTabla);
                    ventanaUpd.txtClienteUpd.Text = clienteTabla.Rows[0]["nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
            ventanaUpd.ShowDialog();
            MuestraClientes();            
        }
    }
}
