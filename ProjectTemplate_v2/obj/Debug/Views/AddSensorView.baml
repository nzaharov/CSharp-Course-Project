   M S B A M L   `   `   `  ����M  IProjectTemplate_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjectTemplate_v2.ViewsProjectTemplate_v2.Views  5      ,    &ProjectTemplate_v2.Views.AddSensorView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ProjectTemplate_v2.Views     5        � Triggers  5
      :� 5   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�5       W� From$	 0.0X�5      	 W� To$	 1.0X�6    g� Duration$ 0:0:0.5D�6#   5      5      5      .��5      �� .+�5   
   ��  �� Left$ 50��6   
 �� Top$ 30��6&    � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%R   '��       �� 5      "	 ��6   .�5      �� 
 � ��$ 20(�61   5      5      .+�5      �� $
��Name��6   �� 5      $	��300��6,   $��	40 5 0 30q�68   $��16(�6K   ��6   �� *Name+6K   �� 5!      $	��URL��6   �� 5"      $	��300��6+   $��	40 5 0 30q�67   $��16(�6J   ��6   �� *Url+6J   �� 5$      $��Sensor Type��6   �� 5%      $	��300��6   $��	40 5 0 30q�6#   $��16(�66   ��6D   �� *Types+ �� SelectedItem 6b   �� *SelectedItem+�� 5'      $��Acceptable Values��6   � 5(      $��	40 5 0 30q�6   y�6+   �� *Visibility1+.+�5)      �� $	��120��64   $��16(�6@    �� TextAlignment$ Right=�6N   ��6   �� *
MinValue+6N   �� 5*      $��16(�61   
�����w�$��SemiBold"�6[   ��6   �� *Unit+6[   �� 5+      $��-��6   $��	10 0 10 0q�6%   
�����w�$��SemiBold"�6T   �� 5,      $	��120��64   $��16(�6@   $ Right=�6N   ��6   �� *
MaxValue+6N   �� 5-      $��16(�61   
�����w�$��SemiBold"�6[   ��6   �� *Unit+6[   5.      �� 5/      $	��130��68   $��16(�6D   $��
200 5 0 30q�6S    �� SelectedIndex 6   �� *Opened+y�6g   �� *Visibility2+.@�50      �� $��Closed��6   �� 51      $��Opened��6   52      �� 54      $��Geo Coordinates��6   � 55      $��40 5 0 0q�6   .+�56      �� $	��140��64   $��16(�6@   $ Right=�6N   ��6   �� *
Latitude+6N   �� 57      $��°��6   $��0 0 10 0q�6%   
�����w�$��SemiBold"�6S   �� 58      $	��140��65   $��16(�6A   $ Right=�6O   ��6   �� *	Longitude+6O   �� 59      $��°��6   
�����w�$��SemiBold"�6A   5:      5<      �� 5>   
    �� Right$ 60��6   $ 60��6(   .+�5?      �� $��Description��6   $��20(�6+   �� 5@      $��	10 20 0 0q�63   $��10q�6F   $	��300��6S   $	��400��6`   $��16(�6l   ���	#FFE7F4F4 �� SelectionBrush
 ��� � �� TextWrapping$
 Wrap=�5A   ,   $	��Top=�6@   ��5@      �� *Description+5A   @   5B      �� 5D   
   $��Track Sensor��6    �� Bottom$ 80��6I   $	 330��6\   $��20(�6o    d� 	IsChecked 6*   �� *
Tracking+6o   �� 5F   
   $��Submit��63   $ 80��6D   $ 70��6W   $��19(�6i   ��6   �� *SubmitCommand+6i   5H      5I      