   M S B A M L   `   `   `  ����E  AYugiohShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:YugiohShop.ViewYugiohShop.View  5   	   ;"clr-namespace:YugiohShop.ViewModelYugiohShop.ViewModel  5   	       YugiohShop.View.CartView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:YugiohShop.View     5   	   5local1"clr-namespace:YugiohShop.ViewModel     5   	   $	��450��5	   	   $	��600��6   .��5
      � .+�5   
   �� 
�������$��1��6(   .+�5      �� $
��Cart��6   $��24(�6$   $
��Bold"�62   $��0q�6D   $��Center=�6O   �� 5      ��6   �� *OrderDetails+��5      �� 5      .R�5      � $
��10,5q�6     � ColumnDefinitions  5      �� 5   "   $
��Auto �63   �� 5   "   $��* �63   �� 5   "   $��60 �63   �� 5   "   $��40 �63   .+�5      �� $��0��6$   $��50��64   $��UniformToFill=�6`   ��6@   �� *ProductImage+6`   �� 5      $��1��6)   $
��10,0q�69   $
��Left=�6G   .+�5   "   �� 
����  �$��16(�6[   $��NoWrap=�6i   ��6,   �� *ProductName+6i   �� 5   "   $��14(�6`   ��6,   �� *Price+ �� StringFormat$ 
{0:N0} VND��6`   5      �� 5      $��2��6)   $��Right=�6:   .+�5    "   �� $��14(�6F   $��NoWrap=�6T   $��Center=�6j   ��6,   �� *
Quantity+6j   �� 5!   "   $��14(�6b   $��
0, 20, 0,0q�6p   ��6,   �� *TotalAmount+$ {0:N0}��6p   5"      5%      5&      5(      5)      �� 5*   
    �� Orientation$ 
Horizontal=�6   $��2��6/   $��Bottom=�6<   $��5q�6X   $��Right=�6c   .+�5+      �� $��18(�6[   $
��Bold"�6i   $��10q�6{   $
��Left=�6�   ��6   �� *TotalBillAmount+$ Total: {0:N0} VND��6�   �� 5,      $	��100��6   $��60��6!   $��Checkout��6-   $��Right=�6d   ��6@   �� *CheckoutCommand+6d   5-      5.      5/      