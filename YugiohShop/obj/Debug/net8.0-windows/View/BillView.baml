   M S B A M L   `   `   `  ����E  AYugiohShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:YugiohShop.ViewYugiohShop.View  5      ;"clr-namespace:YugiohShop.ViewModelYugiohShop.ViewModel  5          YugiohShop.View.BillView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:YugiohShop.View     5      8	viewmodel"clr-namespace:YugiohShop.ViewModel     5        � 	Resources  5
      -   'YugiohShop.ViewModel.BillInfosConverter   BillInfosConverter��%   &	          5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��24(�6/   $
��Bold"�6=   $��Center=�6O   $��0,20,0,0q�6l   $��0��6~   ��6   �� *	TitleText+6~   � 5   
   $��1��6   $��
20,10,20,0q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��StartDatePicker��5      $��0��6`   $��10q�6p      SelectedDate 60   �� *	StartDate+ �� Mode$ TwoWay=�6p   �� 5      -   5        $��ViewBtn��5      $
��VIEW��6$   $��1��6S   $��10q�6c   ��63   �� *ViewCommand+6c   �� 5      $��EXPORT��6   $��2��6H   $��10q�6X   ��6&   �� *ExportCommand+6X     5       -   5        $��EndDatePicker��5       $��3��6\   $��10q�6l    6.   �� *	EndDate+$ TwoWay=�6l   5!      &   System.Windows.Controls.DataGrid  5#   
      CanUserAddRows$ False��6      AutoGenerateColumns$ False��6H   $��20,10,20,20q�6d   $��2��6y   ��6*   �� *Bills+   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *	Bill.Id+  5&      $ Checkin��6%   	 66   �� *Bill.DateBook+  5'      $ Checkout��6%   	 67   �� *Bill.DateCheckOut+  5(      $ Food Details��6%   	 6;   �� *Bill.BillDetails+
 �� 	Converter#
 [    5)      $ Price��6%   	 64   �� *
TotalPrice+  5*      $ 
Created By��6%   	 69   �� *Bill.userID+5,      5-      5.      