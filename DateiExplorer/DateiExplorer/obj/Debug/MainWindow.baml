   M S B A M L   `   `   `  ����H  DDateiExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DateiExplorerDateiExplorer  5   	       DateiExplorer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DateiExplorer     5   	   -   5        $��Fenster��5   5     � Title$  
MainWindow��6	   $	��350��6   $	��525��6)   .��5	      ]� .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��	10,15,0,0q�6C   .+�5      �� $-��'Geben Sie einen Pfad zum durchsuchen an��6   �� 5      -   5        $��input��5      $	��200��6#   �� 5      -   5        $��ok��5      $��50��6   .��6;   OK6?   5      �� 5   
   .��5   
   � -   5        $��output��5      $��10,10,10,20q�6   $
��Auto=�62    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5      �� 5      $��30 �6$   �� 5      .+�5      �� $
��Name��6   $��0��6'   $��0��67   
���   �$��1q�6X   �� 5      $	��Art��6   $��1��6&   $��0��66   
���   �$��1q�6W   �� 5      $��Größe��6   $��2��6(   $��0��68   
���   �$��1q�6Y   �� 5      $��	Attribute��6   $��3��6,   $��0��6<   
���   �$��1q�6]   �� 5      $��0��6   $��0��6/   $��Right=�6<   $��10��6X   �� 5       -   5        $
��name��5       $��0��6)   $��1��69   6H   �� 5!      -   5        $��ordner��5!      $��1��6+   $��1��6;   6J   �� 5"      -   5        $��groesse��5"      $��2��6,   $��1��6<   6K   �� 5#      -   5        $��
attributes��5#      $��3��6/   $��1��6?   6N   5$      5%      5&      5'      