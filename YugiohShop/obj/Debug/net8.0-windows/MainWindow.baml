   M S B A M L   `   `   `  ����E  AYugiohShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:YugiohShop
YugiohShop  5   	   ;"clr-namespace:YugiohShop.ViewModelYugiohShop.ViewModel  5   	   1clr-namespace:YugiohShop.ViewYugiohShop.View  5	   	       YugiohShop.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   &localclr-namespace:YugiohShop   5   	   4	viewmodel"clr-namespace:YugiohShop.ViewModel   5   	   ,local1clr-namespace:YugiohShop.View   5	   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1000��6)    � 	Resources 5       �� DataType+   %YugiohShop.ViewModel.ProductViewModel!   YugiohShop.View.ProductView-   'YugiohShop.ViewModel.DashboardViewModel#   YugiohShop.View.DashboardView)   #YugiohShop.ViewModel.BillsViewModel   YugiohShop.View.BillView(   "YugiohShop.ViewModel.CartViewModel   YugiohShop.View.CartView1	   +YugiohShop.ViewModel.ManageAccountViewModel'
   !YugiohShop.View.ManageAccountView-   'YugiohShop.ViewModel.DailyBillViewModel#   YugiohShop.View.DailyBillView    BooleanToVisibilityConverter  MenuButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property	 P� Value
 �� 
TargetName��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)(�� �     5      *, +)&	  ,    &	 ?    �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5      �� 5   
   "  6   .R�5        5      �� 5    
   6'   �� 5!   
   " ��6(   .�5"      ��  � �� �#9B44446+   �� 5#       � ��
 �����6+   �� 5$       � ��$ 40��6'   �� 5%       � ��$ 5q�6'   �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� #��z��6!   #��z��6K   #��z��6w   ._�5*      � .+�5+   "   A� $	��Dot��6*   
�������$��5��6B   $��5��6L   $
��Left=�6W   $��Center=�6r   $��5,0,0,0q�6�   $y�	Collapsed=�6�   �� 5,   "   $��Center=�63   $��Center=�6P   $��10,0,0,0q�6k   5-      5.       5/      P� 50       �@J�	IsFocused$
	 True��6;   . �51   "   �� $	
 Dot��6)    � y�$ Visible=�6P   �� 52   "    � ��$
 Bold"�6?   53      55      57      58      59      .��5:      � ���#E3E3E3$	��790��6    $	��Top=�6-   .+�5<   
   �� ���#1a1a1a$	��Top=�6'   ._�5=      �� $	��Top=�6   $��Center=�61   $
��0,20q�6N    �� Orientation$ 
Horizontal=�6\   .+�5>      �� 
��� ���$��16(�6p   $
��Bold"�6~    �� TextAlignment$ Center=�6�   $��0,0,80,0q�6�   $��Center=�6�   ��6   �� *CurrentAccount.Name+ �� StringFormat$ Welcome, {0}��6�   �� 5A      $ 
Horizontal=�6|   y�6   �� *IsAdminVisible+ �� 	Converter# [  .+�5B      �� $��Product List��6   #��[ 64   
��� ���$��80��6�   ���#1a1a1a��6p   �� *NavigateToProductListCommand+6�   �� 5C      -   5        $��DashboardBtn��5C   1   $��	Dashboard��6   #��[ 6E   $��80��6�   
��� ������#1a1a1a��6n   �� *NavigateToDashboardCommand+6�   �� 5D      -   5        $��BillBtn��5D   -   $��Bills��6   #��[ 6<   $��80��6�   
��� ������#1a1a1a��6e   �� *NavigateToBillsCommand+6�   �� 5E      -   5        $��
AccountBtn��5E   0   $��Accounts��6   #��[ 6B   $��80��6�   
��� ������#1a1a1a��6k   �� *NavigateToAccountsCommand+6�   5F      �� 5I      $ 
Horizontal=�6|   y�6   �� *IsStaffVisible+# [  .+�5J      �� $��Orders��6   #��[ 6.   $��80��6�   
��� ������#1a1a1a��6W   �� *NavigateToOrdersCommand+6�   �� 5K      $��Daily Bills��6   #��[ 63   $��80��6�   
��� ������#1a1a1a��6\   �� *NavigateToDailyBillsCommand+6�   5L      �� 5M      $ 
Horizontal=�6{   y�6   �� *IsUserVisible+# [  .+�5N      �� $��Store��6   #��[ 6-   $��80��6�   
��� ������#1a1a1a��6V   �� *NavigateToProductListCommand+6�   �� 5O      $
��Cart��6   #��[ 6,   $��80��6   
��� ������#1a1a1a��6U   �� *NavigateToCartCommand+6�   5P      �� 5Q      $ 
Horizontal=�6   .+�5R      �� $��Log Out��6   #��[ 6/   $��80��6z   
��� ������#1a1a1a��6X   �� *LogoutCommand+6�   5S      5T      5U      � 5X   
   $��Bottom=�6   .+�5Y      �� $��1��6   ��6*   �� *CurrentViewModel+5Z      5[      5\      