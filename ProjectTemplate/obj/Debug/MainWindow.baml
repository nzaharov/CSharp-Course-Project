   M S B A M L   `   `   `  ����J  FProjectTemplate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectTemplateProjectTemplate  5   	        ProjectTemplate.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProjectTemplate     5   	     � Title$  Project��5   	   $	��640��6   $
��1024��6&   $	��640��5	   	   $
��1024��6      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	   .��5      �� -   5         ��Name$ canvas1��5      .+�5   
   �� -   5         ��Name$ 	btnToMain��5      $
��1024��6<   $��^��6I   
 �� Top$ 0��6U   
������ 
�������$��0q�6�   $y�	Collapsed=�6�    K� ZIndex$ 12��6�    � Triggers 5      :� 5       :� RoutedEvent$ ButtonBase.Click��6   .[�5      �� .��5      ��  �� 
TargetName$ Frame1��6%    �� TargetProperty$ Margin�6D   .��5      t� 		 t� To$	 0 , 0 , 0, 0X�61   
 g� Duration$
 0:0:0.5D�6C   5      5      5      5      �� 5   
   -   5         ��Name$ 	stkPanel1��5       �� Orientation$ Vertical=�6(    � 	Resources 5       �� 
TargetType �� Property �� Value �� ElementName��%�   ' �       �� 5       "  �6   .�5!      ��  � �� 6.   �� *ActualWidth+$	 Grd���� 5"       �@ �NavigationUIVisibility$ Hidden=�6?   �� 5#       � ��$	 640��6/   5$      5%      .+�5&       � -   5          �Name$ Frame1��5&       � 5'      -   5        $ Frame2��5'        � Source$ MapPage.xaml?�6$   5(      �� 5*   
   -   5        $ btnToMap��5*      $
��1024��6:   $��V��6G    �� Bottom$ 0��6S   
������ 
����� �$��0q�6�    5+      :� 5,      $ ButtonBase.Click��6   .[�5-      �� .��5.      �� $ Frame1��6%   $ Margin�6D   .��5/      t� $	 0 , -2000 , 0, 0X�61   $
 0:0:0.7D�6G   50      51      52      54      55      56      