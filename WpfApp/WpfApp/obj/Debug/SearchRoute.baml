   M S B A M L   `   `   `  ����
  WpfApp    WpfApp.SearchRoute   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Search Route��5   	    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ��5   
   �� 5       �� ImageSource$ Images/umbrelas.jpg��6   .+�5   
   �� -   5         ��Name$ MapImage��5      $%��Images/Maps/default_map_new.png��5      $��Uniform=�5      $��Center=�5      $��Center=�5      5      �� 5   
   
�������
�������$��1q�67   $��Right=�5      $	��Top=�6-   $��5q�5      $	��360��6   $	��500��6(    �� CornerRadius$ 15��5      5      �� 5    
   -   5         ��Name$ 	PinCanvas��5       $��Center=�5!      $��Center=�5"       J� IsHitTestVisible .  ��5$      �� *ActualWidth+ �� ElementName$ MapImage����5%      �� *ActualHeight+$ MapImage��5&      �� 5(   
   -   5        	 ��Name$	 InstructionBorder��5(      $��Center=�5)   	   $	��Top=�5*   	   
��� E��$ 10��5,   	   
 �� Padding$
 10q�5-   	   $��0,10,0,0q�5.   	   ._�5/      �� -   5         ��Name$ InstructionTextBlock��5/      $��16(�50      
����  �$*��$Please select the starting location.��52       �� TextAlignment$ Center=�53      54      �� 57   
    �� Orientation$ 
Horizontal=�6   $
��Left=�58      $	��Top=�59      $��	10,50,0,0q�5:      .+�5<      �� -   5         ��Name$ ResetButton��5<      $��Reset Selection��5=      $
��10,5q�5>      $��16(�5?      $
��Bold"�5@      
����������#007ACC���#005F99$��1q�5D      ��5F      �� 5G       �� 
TargetType" ��6   .�5H      ��  �� Property �@J�Effect �� Value 5I      3  -System.Windows.Media.Effects.DropShadowEffect  5J   "      ShadowDepth$ 3Q�63      
BlurRadius$ 6Q�6C      Color$
 Gray��6R      Opacity$	 0.3Q�6_   5L       �� Triggers 5M      P� 5N       P� Property �@J�IsMouseOver P� Value . . �5O   "   ��  � �� �#005F996?   5P      P� 5Q       � �� . . �5R   "   ��  � �� �#004A7C6?   �� 5S   "    �@J�Effect 5T   &     5U   *   $ 0Q�6;   $ 0Q�6K   $ Transparent��6Z   5W   #   5X      5Z      5\      �� 5^      -   5        $ GenerateRouteButton��5^      $��Generate my route!��5_      $
��10,5q�5`      $��16(�5a      $
��Bold"�5b      
����������#007ACC���#005F99$��1q�5f      $y�	Collapsed=�5g      $��10,0,0,0q�5h      ��5j      �� 5k      " ��6   .�5l      ��  �@J�Effect 5m        5n   "   $ 3Q�63   $ 6Q�6C   $
 Gray��6R   $	 0.3Q�6_   5p       5q      P� 5r       �@J�IsMouseOver . . �5s   "   ��  � �� �#005F996?   5t      P� 5u       � �� . . �5v   "   ��  � �� �#004A7C6?   �� 5w   "    �@J�Effect 5x   &     5y   *   $ 0Q�6;   $ 0Q�6K   $ Transparent��6Z   5{   #   5|      5~      5�      5�      �� 5�   
   -   5        $��RouteDisplayPanel��5�      $��	10,10,0,0q�6.   $	��Top=�6A   $��Right=�6Y   5�      �� 5�   
   ���#FFFFFF���#007ACC$��1q�5�      $ 5��5�      $��10q�5�      $
 5q�5�      $	��Top=�5�      $
��Left=�5�      ._�5�      �� -	   5        $ CoordinatesTextBlock��5�      
���   �$��14(�5�      $
��Bold"�5�      5�      5�      5�      