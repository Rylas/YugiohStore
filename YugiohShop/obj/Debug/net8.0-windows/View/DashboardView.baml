   M S B A M L   `   `   `  ����E  AYugiohShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:YugiohShop.ViewYugiohShop.View  5      ;"clr-namespace:YugiohShop.ViewModelYugiohShop.ViewModel  6:   #    YugiohShop.View.DashboardView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      )localclr-namespace:YugiohShop.View  5      2	viewmodel"clr-namespace:YugiohShop.ViewModel  6:   .��5      �� $
��Auto=�6   ��66   �� *ActualHeight+  �� RelativeSource  ��  �� AncestorType
 Window.��5   
   �  � RowDefinitions 5      �� 5      $��80 �6    6.   �� 5      $	��200 �6    6/   �� 5      $��* �6    6-   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��200, 0, 0, 0q�6?   $
��Left=�6U   .+�5      �� $��5q�6    �� Padding$ 10q�6$   $��1q�61   
������� �� CornerRadius$ 5��6]   $	��200��6n   ._�5      �� $ 
Horizontal=�6!   .+�5      �� $��54��6%   .+�5      �� $��20(�6D   $
��Bold"�6R   
���   ���6(   �� *
StaffCount+6d   �� 5      $��Available Accounts��6(   $��12(�6B   ���#6666P   5      5      5      �� 5      $��20,0,0,0q�6   $ 10q�6+   $��1q�68   
�������$ 5��6d   $	��200��6u   ._�5      �� $ 
Horizontal=�6!   .+�5      �� $��54��6%   .+�5      �� $��20(�6E   $
��Bold"�6S   
���   ���6(   �� *TotalOrders+6e   �� 5       $��Orders Count��6(   $��12(�6<   ���#6666J   5!      5"      5#      �� 5$      $��20,0,0,0q�6   $ 10q�6+   $��1q�68   
�������$ 5��6d   $	��200��6u   ._�5%      �� $ 
Horizontal=�6!   .+�5&      �� $��54��6%   .+�5'      �� $��20(�6c   $
��Bold"�6q   
���   ���6(   �� *TotalRevenue+ �� StringFormat$ 
{0:N0} VND��6�   �� 5(      $��Total Revenues��6(   $��12(�6>   ���#6666L   5)      5*      5+      5,      �� 5-      $��1��6   $��0,12,0,0q�6&   $ 
Horizontal=�68   
������ $��Center=�6j   .+�5.        OxyPlot.Wpf.PlotView  $	��350��6?   
������ $��Right=�6d      Model 6   �� *PiechartModel+6d   5/      �� 50      $��2��6   $��0,16,0,0q�6&   .+�51        $
��Auto��6@   $	��300��6M   
������  6   �� *LinechartModel+6Z   52      53      54      55      