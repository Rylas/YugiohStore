   M S B A M L   `   `   `  ����E  AYugiohShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:YugiohShop
YugiohShop  5      ;"clr-namespace:YugiohShop.ViewModelYugiohShop.ViewModel  5      !    YugiohShop.View.ProductView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      *localclr-namespace:YugiohShop     5      5local1"clr-namespace:YugiohShop.ViewModel     5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      $	��600��5      $	��900��6     � 	Resources  5      7   1YugiohShop.ViewModel.BooleanToVisibilityConverter    BooleanToVisibilityConverter0   *YugiohShop.ViewModel.BoolToStatusConverter  BoolToStatusConverter  ProductListTemplate �� Padding �� StringFormat `� 	Converter �� Path �� 
TargetType �� Property �� Value �� Triggers	 �� Binding
 �� Value��%O  &	        &	      &	 &     7    5	   
   6.     5
   
   6'   �� 5   
   .R�5      �� 
�������$��1q�6(   $ 10q�6<   $��5q�6I   ._�5      �� $��Center=�6   .+�5      �� $	��100��69   $	��100��6E   $��5q�6R   ��6   �� *	ImageLink+6R   �� 5      $	��100��66   $��18(�6B   $
��Bold"�6P   $��Center=�6b   ��6    �� *Name+6b   �� 5      $��18(�6S   $
��Bold"�6a   $��Center=�6s   ��6    �� *Price+$  {0:N0} VND��6s   �� 5      $��Center=�6    ��5      `� 5      8   .1�5   "   �� $ Status�6*   5      ��5      �� 5      " ��6$   .�5   "   ��  � �� �#9B44446?    5   "   �� 5   &   	 62   �� *Status+
 True6M   .a�5   *   ��  � ��
 � � �6G   5   '   5      5!      5"      5#      5$      5%      .��5'      �  � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   �� 5+      $��* �6   .+�54   
   � $��1��6   $��0, 80, 0, 0q�6    � ColumnDefinitions 55      �� 56      $��6* �6#   �� 57      $��4* �6#   .+�59      �� $��0��6   
�������$
��Auto=�6>   .��5:      �� 
������ #��[ 5<      ��5:   4   �� *ProductList+ �� SelectedItem 5;      �� *SelectedProduct+ �� Mode$ TwoWay=���5=      �� 5>      .R�5?      A�  A� Columns$ 3��6*   5@      ��5B      �� 5C      " ��6    .�5D      ��  � ��$ Center=�6K   �� 5E       � ��$ Center=�6I   5F      5H      5I      � 5K      $��1��6   $��10,0,0,0q�6#   
���������5L      �� 5M      " �6    5N      �� 5O      	 6*   �� *SelectedProduct+
 6N   Z� .a�5P   "   ��  � y�$ 	Collapsed=�6?   5Q      �� 5R      	 6*   �� *SelectedProduct+.a�5S   "   ��  � y�$ Visible=�6?   5T      5V       5Y      �� 5Z      $
��Auto �6$   �� 5[      $��* �6$   �� 5\      $
��Auto �6$   .+�5`      � $��	0,10,0,10q�6   $��0��6*    5a      �� 5b      $
��Auto �6+   �� 5c      $��* �6+    5e      �� 5f      $
��Auto �6(   �� 5g      $��* �6(   .+�5j      �� $��1��6!    �� Orientation$ 
Horizontal=�61   $��Center=�6J   $
��10,0q�6e   .+�5l      �� $��Center=�5m       $��0,0,10,0q�5n       
�������$��Italic$�5p       ��5l   $   �� *SelectedProduct.Quantity+$ In stock: {0}��5p       �� 5r      $��	Quantity:��6$   $��Center=�5s       $��0,0,10,0q�5t       $
��Left=�5u       $
��Bold"�5v       
���   �5w       �� 5y      
�������$��1q�5z   !    �� CornerRadius$ 5��5{   !   
�������$ 2q�5}   !   ._�5~      ,  &MaterialDesignThemes.Wpf.NumericUpDown  $��60��6;   $��30��5   %   $	��5,0q�5�   %   $��Center=�5�   %   $��Right=�5�   %      Value 5�   %   �� *ItemQuantity+$ TwoWay=�5�   %   5�      5�      5�      �� 5�      
�������$��1��6,   $��10q�69   $ 10q�6E   
�������$��1q�5�   1   $ 10��6E   ._�5�      �� .+�5�      �� $��18(�5�   !   $
��Bold"�6/   $��0,5,0,10q�6A   ���#333��5�   $   �� *SelectedProduct.Name+$ Product: {0}��5�   !   �� 5�      $��16(�5�   !   $��0,0,0,10q�6/   ���#555��5�   $   �� *SelectedProduct.Price+$ Price: {0:N0} VND��5�   !   �� 5�      $	��200��5�      $	��200��6)   $��Center=�5�      $
��0,10q�6:   ��5�       �� *SelectedProduct.ImageLink+5�   :   5�      5�      �� 5�      $ 
Horizontal=�6   $��0,20,0,0q�66   $��2��6H   $��Bottom=�6U   $��Right=�6p   .+�5�      �� $	��100��6   $��40��6)   $��Add to Cart��65   $��5q�6n   ��6K   �� *AddItemCommand+6n   5�      5�      5�      5�      5�      