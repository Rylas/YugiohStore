   M S B A M L   `   `   `  ����E  AYugiohShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:YugiohShop.ViewYugiohShop.View  5   	   ;"clr-namespace:YugiohShop.ViewModelYugiohShop.ViewModel  5   	   7 clr-namespace:YugiohShop.HelpersYugiohShop.Helpers  5	   	   "    YugiohShop.View.RegisterView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   +localclr-namespace:YugiohShop.View   5   	   1local1"clr-namespace:YugiohShop.ViewModel   5   	   0helpers clr-namespace:YugiohShop.Helpers   5	   	     � Title$  RegisterView��5   	   $	��450��6   $	��800��6+    � DataContext 5      2   ,YugiohShop.ViewModel.RegisterWindowViewModel  5   
    � 	Resources 5          BooleanToVisibilityConverter7   1YugiohShop.Helpers.ImageUrlToBitmapImageConverter " ImageUrlToBitmapImageConverter��%:   &	        &	      �� 5   
   6'     5   
   61   5      .��5      � .+�5   
   �� ���#1a1a1a$��Right=�6&   $	��300��6B   ._�5      �� $��Center=�6   $��Center=�64   .+�5      �� $��0,0,0,60q�6   .+�5      �� $	��100��6s   $	��100��6�   $��0,0,0,20q�6�   ��6   �� *
ImageUrl+ �� 	Converter# [ 6�   �� 5      $��Yugioh Store��6    
��� ���$��20(�6F   $
��Bold"�6T    �� TextAlignment$ Center=�6f   $��0,0,0,20q�6}   5      �� 5      $��Login��6   
�������$��16(�6<   $ Center=�6J   $��0,0,0,20q�6a   �� 5      $��LOGIN��6   $	��200��6)   $��40��65   
��� ������#1a1a1a$��16(�6h   ��6v   �� *NavigateToLoginCommand+5      5      �� 5    
   $
��Left=�6   $	��500��60   $	��Top=�6<   $��	40,65,0,0q�6T   .+�5!      �� $��Register Account��6   $��24(�60   $
��Bold"�6>   $��0,0,0,20q�6P   
��� ���6b   �� 5#      $��0,0,0,10q�6   .+�5$      �� $��Username��6   $��16(�6,   $��5,0,0,5q�6:   �� 5%      $	��300��6   $��30��6&   $
��Left=�62   ��6M   �� *UsernameReg+ �� UpdateSourceTrigger$ PropertyChanged=�5&      �� 5(      $��0,0,0,10q�6   $	��301��6+   $
��Left=�67   .+�5)      �� $��Password��6   $��16(�6,   $��5,0,0,5q�6:   � 5*      .+�5+      G� -   5        $��PasswordBoxReg��5+   "   $	��300��68   $��30��6D   $
��Left=�6P   -   'YugiohShop.Helpers.PasswordBoxAssistant   BindPassword$
 True��5,         BoundPassword 5-      �� *PasswordReg+ �� Mode$ TwoWay=�$ PropertyChanged=��� 5.      $	��300��6   $��30��6*   $
��Left=�66   ��6Q   �� *PasswordReg+$ TwoWay=�$ PropertyChanged=�y�6�   �� *IsPasswordVisible+# [  5/      50      �� 52      $��0,0,0,10q�6   $	��301��6+   $
��Left=�67   .+�53      �� $��Confirm Password��6   $��16(�64   $��5,0,0,5q�6B   � 54      .+�55      G� -   5        $��RePasswordBoxReg��55   "   $	��300��6:   $��30��6F   $
��Left=�6R   $
 True��56       57      �� *PasswordReReg+$ TwoWay=�$ PropertyChanged=��� 58      $	��300��6   $��30��6*   $
��Left=�66   ��6Q   �� *PasswordReReg+$ TwoWay=�$ PropertyChanged=�y�6�   �� *IsPasswordVisible+# [  59      �� 5;      $��Show password��6   $��Right=�63   $��0,5,0,0q�6O   	 d� 	IsChecked	 6`   �� *IsPasswordVisible+5<      �� 5=      $��REGISTER��6   $	��140��6(   $��40��64   
��� ������#1a1a1a$��16(�6g   $
��Left=�6u   $��
160,0,0, 0q�6�   ��6�   �� *RegisterCommand+6�   5>      5?      5@      