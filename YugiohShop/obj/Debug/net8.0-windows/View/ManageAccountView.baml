   M S B A M L   `   `   `  ����E  AYugiohShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:YugiohShop.ViewYugiohShop.View  5      ;"clr-namespace:YugiohShop.ViewModelYugiohShop.ViewModel  6:   '    !YugiohShop.View.ManageAccountView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:YugiohShop.View     5      8	viewmodel"clr-namespace:YugiohShop.ViewModel     6:     � 	Resources  5	      *   $YugiohShop.ViewModel.GenderConverter   GenderConverter(   "YugiohShop.ViewModel.TypeConverter  TypeConverter��%:   &	        &	        5
   
   6$     5   
   6"   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��10q�6,   $	��Top=�68   .+�5      �� $ 
Horizontal=�6   $��5q�62   .+�5      �� $��Account ID:��6   $	��120��6.   �� 5      $	��200��6   ${�False��6I   ��6&   �� *EditingAccount.Id+6I   5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      �� $��Name:��6   $	��120��6(   �� 5      $	��200��6   ��6&   �� *EditingAccount.Name+5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      �� $��	Password:��6   $	��120��6,   G� 5      -   5         G�Name$ PasswordBox��5   *   $	��200��6   .   (YugiohShop.ViewModel.PasswordBoxBehavior   Password 5       �� *EditingAccount.Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5!      �� 5$      $ 
Horizontal=�6   $��5q�62   .+�5%      �� $��Type:��6   $	��120��6(   �� 5&      $	��200��6   ��5'      �� *Types+ �� SelectedItem 5(      �� *EditingAccount.Type+ �� 	Converter# [ 5)      �� 5+      $ 
Horizontal=�6   $��5q�62   .+�5,      �� $	��Add��6   $	��100��6'   ��63   �� *
AddCommand+�� 5-      $��Update��6   $	��100��6*   $��5,0,0,0q�66   ��6G   �� *UpdateCommand+�� 5.      $��Delete��6   $	��100��6*   $��5,0,0,0q�66   ��6G   �� *DeleteCommand+5/      50      &   System.Windows.Controls.DataGrid  52   
   $��1��6   	   AutoGenerateColumns$	 False��6A   $��10q�6]   
   
IsReadOnly$

 True��53      ��52       �� *
Accounts+ 53   !   �� *SelectedAccount+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Account ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6P     56      $
 Name��6%   $	 200 6L    63   �� *Name+6L     57      $ Password��6%   $	 150 6T    67   �� *
Password+6T     58      $
 Type��6%   $ 50 6L    63   �� *Type+6L   5:      5;      5<      