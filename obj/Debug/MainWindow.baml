   M S B A M L   `   `   `  ����E  AAgendaCrud, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AgendaCrud
AgendaCrud  5   	       AgendaCrud.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:AgendaCrud     5   	   ���	#ff292929  � Title$  Agenda��5
   	   $	��600��6   $	��800��6%   .��5      � -   5         � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��65 �6   �� 5      $��* �6   .+�5      � $��0��6   .+�5      �� $��ID��6   $
��Left=�62   $��
100,30,0,0q�6M   $	��Top=�6a   �� 5      $
��NOME��6   $
��Left=�62   $��
100,60,0,0q�6M   $	��Top=�6a   �� 5      $��TELEFONE��6   $
��Left=�62   $��
100,90,0,0q�6M   $	��Top=�6a   �� 5      -   5         ��Name$ textID��5      
�������$
��Left=�6C   $��
200,35,0,0q�6^    �� TextWrapping$
 Wrap=�6r   $�� ��6�   $	��Top=�6�   �� 5      -   5        $ textNome��5      
�������$
��Left=�6C   $��
200,65,0,0q�6^   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��288��6�   �� 5      -   5        $ textTelefone��5      
�������$
��Left=�6C   $��
200,95,0,0q�6^   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��299��6�   5      � 5   
   $��1��6   .+�5      �  � ColumnDefinitions 5      �� 5      $	��125 �6'   �� 5      $	��125 �6'   �� 5      $	��125 �6'   �� 5      $	��125 �6'   �� 5       $	��125 �6'   �� 5!      $	��125 �6'   .+�5%      �� -   5         ��Name$ 
btnInserir��5%   /   $��0��6   $��INSERIR��6E   $
��AUTO��6X   $��10 0 0 0q�6f   6x   �� 5&      -   5        $ 
btnAlterar��5&   /   $��1��6   $��ALTERAR��6E   $
��AUTO��6Y   $��10 0 0 0q�6g   {�.  6�   �� 5'      -   5        $ btnLocalizar��5'   +   $��2��6   $��	LOCALIZAR��6A   $
��AUTO��6U   $��10 0 0 0q�6c   6u   �� 5(      -   5        $ 
btnExcluir��5(   +   $��3��6   $��EXCLUIR��6A   $
��AUTO��6S   $��10 0 0 0q�6a   {�.  6�   �� 5)      -	   5        $ 	btnSalvar��5)   +   $��4��6   $��SALVAR��6A   $
��AUTO��6R   $��10 0 0 0q�6`   {�.  6�   �� 5*      -
   5        $ btnCancelar��5*   +   $��5��6   $��CANCELAR��6A   $
��AUTO��6V   $��10 0 0 0q�6d   {�.  6�   5,      5-      &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$ dgvDados��5.       $��2��6   $
��Left=�62   $��10q�6M   $	��758��6Y      
IsReadOnly .    SelectionMode$ Single=�6x   6�   50      51      