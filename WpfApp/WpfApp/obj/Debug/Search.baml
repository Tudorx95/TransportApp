   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5      5clr-namespace:WpfApp.ComponentsWpfApp.Components  5          WpfApp.Search   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:WpfApp     5      6
componentsclr-namespace:WpfApp.Components     5      .��5      � ��5   
   �� 5        j� Stretch$  UniformToFill=�6b    �� ImageSource 6   ��     WpfApp.Components.Resource   
simple_map �� Source# Z 6b   .+�5   
   �� .+�5      �� -   5         ��Name$ 	LeftImage��5      $	��401��5      $	��562��6   $y�	Collapsed=�5       �� Left$ 12��5      
 �� Top$	 100��6!   $
��Fill=�5      5      � 5   
   -   5         �Name$ 
ImagePopup��5       � 	StaysOpen .  $��Center=�66   	 � HorizontalOffset$	 0��5      
 � VerticalOffset$
 0��6!   .��5      �� 
���   � J� Opacity$	 0.8Q�6(   ._�5      �� $	��800��5      $	��800��6    $��Center=�5       $��Center=�61   ��5      ��  �� ElementName$ 	LeftImage�� �� Path$ Source�z�5!      �� 5"       �� ScaleX$ 1Q�6)    �� ScaleY$ 1Q�64   5$      5%      5&      �� 5)   
   $��1��6   $��Center=�6%   $��Center=�6@   $	��600��6]   .+�5+      �� $��Discover Your Next Ride��6   $��30(�67   $
��Bold"�6E   
���   �$��Center=�5,      $��0,0,0,20q�61   �� 5.      ���#fff �� Padding$ 15q�6'   $	��450��64   $
��0,10q�6@    �� CornerRadius$ 15��6N    J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         Color$
 Gray��6'      
BlurRadius$ 20Q�64      ShadowDepth$ 2Q�6D      Opacity$	 0.3Q�6T   ._�53      � .+�54      �� -   5         ��Name$ FloatingLabel��54       $)��#Enter location or transport type...��67   $��14(�55      ���#888$	��Top=�6<   $��15,0,0,0q�56      $y�Visible=�6.   $ 1Q�6C   z�57      T� 58       T� Y$ 15Q�61   5:      �� 5<      -   5         ��Name$ SearchTextBox��5<      $��18(�65   
������ $��0q�5=      $��Center=�6.   $��10,15,45,15q�6I   5?      �� 5A      -   5        $��45��5A      $��45��6(   ���#4A90E2
�������$��Right=�5B      $��Center=�65   
������  � Cursor$
 Hand��5C   3   $��0,0,10,0q�6A   .��5E      �� $��Segoe MDL2 Assets)�6$   $	����6C   $��20(�6S   5F      5G      5H      �� 5J      -   5         ��Name$ SuggestionsListBox��5J      $	��450��62   $��0,5,0,0q�6>   $y�	Collapsed=�5K      6)   �� 5N      -   5        $��Find path to destination��5N      $	��200��5O      $��40��5P      ���#4A90E2
�������$��Center=�5S      $	��Top=�5T      $��0,20,0,0q�5U      $
 Hand��5V      5W      5X      � 5Z   
   $��Right=�6   $��Stretch=�6+   $��2��6G   .+�5\      �� $	��500��6   ���#ccc$��Stretch=�64   $��Stretch=�6P   ._�5]      �� -   5         ��Name$ RouteDisplay��5]      $y�	Collapsed=�63    �� Orientation$ Vertical=�6J   $��10q�6a   .+�5_      &   System.Windows.Controls.DataGrid  -	   5          Name$ StationsDataGrid��5_         AutoGenerateColumns .  "    VerticalScrollBarVisibility$
  Auto=�6U   $!   HorizontalScrollBarVisibility$
! Auto=�5`      $	��300��6@   $	��340��6P   "   AlternatingRowBackground" �#f9f9f9#   RowBackground# �#ffffff$   GridLinesVisibility$
$ None=�5c      %   HeadersVisibility$% Column=�5d      $��0q�5e      $��Segoe UI)�5f      $��14(�5g      & � 	Resources& 5i      =  7System.Windows.Controls.Primitives.DataGridColumnHeader' �� 
TargetType( �� Property) �� Value*  $System.Windows.Controls.DataGridCell��%m  '        '  �     �� 5k      "'  6$   .�5l   "   �� ( � ��) �#007ACC6?   �� 5m   "   ( � ��
) �����6?   �� 5n   "   ( � ��$
) Bold"�6?   �� 5o   "   ( � ��$
) 10,5q�6<   5p      �� 5s      "'  6$   .�5t   "   �� ( � ��$) 10q�6<   �� 5u   "   ( � ��$) Stretch=�6H   �� 5v   "   ( � ��$) Center=�6F   5w      5x      *   Columns* 5z      0  *System.Windows.Controls.DataGridTextColumn  5{      ,  &System.Windows.Controls.DataGridColumn+   Header$+ Station Name��61   1  +System.Windows.Controls.DataGridBoundColumn,   Binding, 6G   �� *StationName+  5|      $+ Arrival Times��61   , 6H   �� *ArrivalTimesDisplay+5~      �� 5      ���#007ACC$��5q�5�      $ 10��5�      ���#F0F0F0$��20q�5�      $	��400��5�      $ 10q�5�      ._�5�      r� -
   5        - r�Name$- Media��5�   '   $��Center=�5�   #   $��Stretch=�5�   #   $	��550��5�   #   $	��550��5�   #   . r� LoadedBehavior$. Manual=�5�   #   / r� UnloadedBehavior$
/ Stop=�5�   #   5�   #   5�      5�      5�      5�      5�      5�      