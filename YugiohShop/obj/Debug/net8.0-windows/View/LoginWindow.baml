   M S B A M L   `   `   `  ����E  AYugiohShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:YugiohShop.ViewYugiohShop.View  5   	   ;"clr-namespace:YugiohShop.ViewModelYugiohShop.ViewModel  5   	   7 clr-namespace:YugiohShop.HelpersYugiohShop.Helpers  5	   	   !    YugiohShop.View.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   +localclr-namespace:YugiohShop.View   5   	   1local1"clr-namespace:YugiohShop.ViewModel   5   	   0helpers clr-namespace:YugiohShop.Helpers   5	   	     � Title$  LoginWindow��5   	   $	��450��6   $	��750��6*    � DataContext 5      /   )YugiohShop.ViewModel.LoginWindowViewModel  5   
    � 	Resources 5          BooleanToVisibilityConverter7   1YugiohShop.Helpers.ImageUrlToBitmapImageConverter " ImageUrlToBitmapImageConverter��%:   &	        &	      �� 5   
   6'     5   
   61   5      .��5      � .+�5      �� ���#1a1a1a$
��Left=�6"   $	��300��6=   ._�5   
   �� $��Center=�6   $��Center=�60   .+�5      �� $��0,0,0,60q�6   .+�5      �� $	��100��6s   $	��100��6�   $��0,0,0,20q�6�   ��6   �� *
ImageUrl+ �� 	Converter# [ 6�   �� 5      $��Yugioh Store��6    
��� ���$��20(�6F   $
��Bold"�6T    �� TextAlignment$ Center=�6f   $��0,0,0,20q�6}   5      �� 5      $��Register Your Account��6   
�������$��16(�6H   $ Center=�6V   $��0,0,0,20q�6m   �� 5      $��SIGNUP��6   $	��200��6&   $��40��62   
��� ������#1a1a1a$��16(�6e   ��6s   �� *NavigateToRegisterCommand+5      5      �� 5"   
   $��Right=�6   $	��500��61   $	��Top=�6=   $��
0,65,-89,0q�6U   .+�5#      �� $��LOGIN��6   $��24(�6%   $
��Bold"�63   $��0,0,0,20q�6E   
��� ���6W   �� 5%      $��0,0,0,10q�6   .+�5&      �� $��Username��6   $��16(�6,   $��5,0,0,5q�6:   �� 5'      $	��300��6   $��30��6&   $
��Left=�62   ��6M   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5(      �� 5*      $��0,0,0,10q�6   $	��301��6+   $
��Left=�67   .+�5+      �� $��Password��6   $��16(�6,   $��5,0,0,5q�6:   � 5,      .+�5-      G� -   5        $��
PasswordBx��5-   "   $	��300��64   $��30��6@   $
��Left=�6L   -   'YugiohShop.Helpers.PasswordBoxAssistant   BindPassword$
 True��5.   "      BoundPassword 5/   "   �� *
Password+ �� Mode$ TwoWay=�$ PropertyChanged=��� 50      $	��300��6   $��30��6*   $
��Left=�66   ��6Q   �� *
Password+$ TwoWay=�$ PropertyChanged=�y�6�   �� *IsPasswordVisible+# [  51      �� 52      $��Show password��6   $��Right=�63   $��0,5,0,0q�6O   	 d� 	IsChecked	 6`   �� *IsPasswordVisible+53      �� 54      $��LOGIN��6   $	��140��6%   $��40��61   
��� ������#1a1a1a$��16(�6d   $
��Left=�6r   $��
160, 0,0,0q�6�   ��6�   �� *LoginCommand+6�   55      58      5;      