   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.ComponentsWpfApp.Components  5   	       WpfApp.SearchRoute   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6
componentsclr-namespace:WpfApp.Components     5   	   -   5          � Title$  Search Route��5   	    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ��5   
   �� 5       �� ImageSource 6   ��     WpfApp.Components.Resource   umbrelas_jpg �� Source# Z .+�5   
   �� -   5         ��Name$ MapImage��5      $��Uniform=�5      $��Center=�5      $��Center=�5      ��5      ��    default_map_new# Z 5      �� 5   
   
�������
�������$��1q�67   $��Right=�5      $	��Top=�6-   $��5q�5      $	��360��6   $	��500��6(    �� CornerRadius$ 15��5      5      �� 5!   
   -   5        	 ��Name$	 	PinCanvas��5!      $��Center=�5"      $��Center=�5#      
 J� IsHitTestVisible
 .  ��5%      �� *ActualWidth+ �� ElementName$ MapImage����5&      �� *ActualHeight+$ MapImage��5'      �� 5)   
   -   5         ��Name$ InstructionBorder��5)      $��Center=�5*   	   $	��Top=�5+   	   
��� E��$ 10��5-   	    �� Padding$ 10q�5.   	   $��0,10,0,0q�5/   	   ._�50      �� -   5         ��Name$ InstructionTextBlock��50      $��16(�51      
����  �$*��$Please select the starting location.��53       �� TextAlignment$ Center=�54      55      �� 58   
    �� Orientation$ 
Horizontal=�6   $
��Left=�59      $	��Top=�5:      $��	10,50,0,0q�5;      .+�5=      �� -   5         ��Name$ ResetButton��5=      $��Reset Selection��5>      $
��10,5q�5?      $��16(�5@      $
��Bold"�5A      
����������#007ACC���#005F99$��1q�5E      ��5G      �� 5H       �� 
TargetType" ��6   .�5I      ��  �� Property �@J�Effect �� Value 5J      3  -System.Windows.Media.Effects.DropShadowEffect  5K   "      ShadowDepth$ 3Q�63      
BlurRadius$ 6Q�6C      Color$
 Gray��6R      Opacity$	 0.3Q�6_   5M       �� Triggers 5N      P� 5O       P� Property �@J�IsMouseOver P� Value . . �5P   "   ��  � �� �#005F996?   5Q      P� 5R       � �� . . �5S   "   ��  � �� �#004A7C6?   �� 5T   "    �@J�Effect 5U   &     5V   *   $ 0Q�6;   $ 0Q�6K   $ Transparent��6Z   5X   #   5Y      5[      5]      �� 5_      -   5        $ GenerateRouteButton��5_      $��Generate my route!��5`      $
��10,5q�5a      $��16(�5b      $
��Bold"�5c      
����������#007ACC���#005F99$��1q�5g      $y�	Collapsed=�5h      $��10,0,0,0q�5i      ��5k      �� 5l      " ��6   .�5m      ��  �@J�Effect 5n        5o   "   $ 3Q�63   $ 6Q�6C   $
 Gray��6R   $	 0.3Q�6_   5q       5r      P� 5s       �@J�IsMouseOver . . �5t   "   ��  � �� �#005F996?   5u      P� 5v       � �� . . �5w   "   ��  � �� �#004A7C6?   �� 5x   "    �@J�Effect 5y   &     5z   *   $ 0Q�6;   $ 0Q�6K   $ Transparent��6Z   5|   #   5}      5      5�      5�      �� 5�   
   -   5        $��RouteDisplayPanel��5�      $��	10,10,0,0q�6.   $	��Top=�6A   $��Right=�6Y   5�      �� 5�   
   ���#FFFFFF���#007ACC$��1q�5�      $ 5��5�      $��10q�5�      $ 5q�5�      $	��Top=�5�      $
��Left=�5�      ._�5�      �� -	   5        $ CoordinatesTextBlock��5�      
���   �$��14(�5�      $
��Bold"�5�      5�      5�      5�      