   M S B A M L   `   `   `  ����Q  MConexionGestinoPedidos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ConexionGestinoPedidosConexionGestinoPedidos  5   	   '    !ConexionGestinoPedidos.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ConexionGestinoPedidos     5   	     � Title$  Clientes Pedidos��5   	   $	��800��6"   $	��900��6/   .��5	      � $��0,0,-87,-21q�6   $	��592��6    $	��Top=�6-   .+�5
   
   �� $��Clientes��6   $
��Left=�6#   $��	18,24,0,0q�6>   $	��Top=�6Q   $��30��6i   $	��110��6u   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $��lstClientes��5      $
��Left=�6%   $	��180��6@   $��	18,59,0,0q�6M   $	��Top=�6`   $	��212��6x   5      �� 5   
   $��Pedidos��6   $
��Left=�6"   $��
250,29,0,0q�6=   $	��Top=�6Q   $��30��6i   $	��110��6u   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $��
lstPedidos��5      $
��Left=�6%   $	��180��6@   $��
250,59,0,0q�6M   $	��Top=�6a   $	��235��6y   �� 5   
   $��Lista de pedidos��6   $
��Left=�6+   $��
505,29,0,0q�6F   $	��Top=�6Z   $��30��6r   $	��175��6~   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $��lstPedidoslista��5      $��505,59,104,0q�6)   $��82��6?   $	��Top=�6K   &   System.Windows.Controls.DataGrid  5   
   -   5        $��grdDatos��5      $
��Left=�6$   $	��100��6?   $��
27,492,0,0q�6L   $	��Top=�6`   $	��690��6x   5      �� 5   
   -   5        $��Eliminar��5      $
��Left=�6$   $��
785,34,0,0q�6?   $	��Top=�6S   $��75��6k   
���  �� J� RenderTransformOrigin$ 2.067,-10.35&�6�   �� 5   
   -   5        $��
DelCliente��5      $��Eliminar��6#   $
��Left=�66   $��
18,255,0,0q�6Q   $	��Top=�6e   $��75��6}   
���� ��6�   �� 5   
   -   5        $��Insertar��5      $��Insertar��6!   $
��Left=�64   $��115,255,0,0q�6O   $	��Top=�6d   $��75��6|   
���   �6�   �� 5   
   -   5        $��
txtCliente��5      $
��Left=�6$   $��23��6?   $��117,295,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   $ 1.25,0&�6�   �� 5   
   $��Cliente��6   $
��Left=�6"   $��
27,292,0,0q�6=   $	��Top=�6Q   �� 5   
   -	   5        $��BtnUpd��5      $��
Actualizar��6   $
��Left=�64   $��220,255,0,0q�6O   $	��Top=�6d   $��75��6|   6�   5      5      