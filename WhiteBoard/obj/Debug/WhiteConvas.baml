   M S B A M L   `   `   `  ����E  AWhiteBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WhiteBoard
WhiteBoard  5          WhiteBoard.WhiteConvas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WhiteBoard     5      -   5          �Name$  BoardWindow��5	   S    � Title$ WhiteConvas��6    � WindowStyle$
 None=�6    � WindowStartupLocation$ CenterScreen=�6.    � AllowsTransparency .  J� 	AllowDrop .  � SizeToContent$ WidthAndHeight=�6�    � 	Resources 5
         StoryboardRightImage �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value  StoryboardLeftImage��%�  &	        &	 <    �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $	 	RightPage��6�   .\�5        $
 0��6'   $ 1Q�63     5      $
 0:0:0.2��6'   $	 0.8Q�69     5      $
 0:0:0.4��6'   $ 1Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $	 	RightPage��6�   .\�5        $
 0��6'   $ 1Q�63     5      $
 0:0:0.2��6'   $	 0.8Q�69     5      $
 0:0:0.4��6'   $ 1Q�69   5      5      �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $	 LeftPage��6�   .\�5        $
 0��6'   $ 1Q�63     5      $
 0:0:0.2��6'   $	 0.8Q�69     5      $
 0:0:0.4��6'   $ 1Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $	 LeftPage��6�   .\�5        $
 0��6'   $ 1Q�63     5      $
 0:0:0.2��6'   $	 0.8Q�69     5       $
 0:0:0.4��6'   $ 1Q�69   5!      5"      5#      .��5$      �� $	��Top=�6   .+�5%   
   �� $��5,5,5,0q�6   $	��Top=�6+   ���#C7D2DD._�5&      � $	��600��6    � ColumnDefinitions 5'      �� 5(      -   5         ��Name$ LeftGrid��5(   '   $��50 �69   �� 5)      -   5        $ 
CenterGrid��5)   '   $��* �6;   �� 5*      -   5        $ 	RightGrid��5*   '   $��50 �6:   .+�5-      �� -   5        $��InkCovasBorder��5-   )   $��1��6   $��Center=�6?   $��2,0,2,0q�6Z   $	��Top=�6t   ���#C7D2DD._�5.      �� -   5         ��Name$ 
MainConvas��5.      $	��600��61   $	��600��6>   .+�5/      � -   5         �Name$ ContentPanel��5/   4    �� Left$ 0��6$   ��6J   �� *ActualWidth+ �� ElementName$ canvasPageContent�� �� Mode$ OneWay=���6�   �� *ActualHeight+$ canvasPageContent��$ OneWay=���52      �� 53   "    �� Color$ White��6d    �� Opacity 63   �� *Value+$ sldstyle��6d   z�55      V� 56   "   .~�57   &   �� �� 58   &   �� 59   &   T� 5:   &   5;   #   5=      5>      5?      �� 5A      -   5         ��Name$ LeftPage��5A      $��0��6*   $	��100��6:   $��50��6G   $��images/左侧页.png��6R   z�5C      V� 5D      .~�5E      �� �� 5F      �� 5G      T� 5H      5I      5K      �� 5M      -	   5        $ 	RightPage��5M      $��2��6+   $	��100��6;   $��50��6H   $��images/右侧页.png��6S   z�5O      V� 5P      .~�5Q      �� �� 5R      �� 5S      T� 5T      5U      5W      5X      5Y      �� 5Z   
   $��20��6   $��Bottom=�6   ���	#FF3B373B$��5,5,5,5q�6O   $	��Top=�6i   ���#C7D2DD._�5[         WhiteBoard.PageBar  -
   5          Name$ pageBar��5[   9   $��Center=�6   $��Center=�6J   $y�Hidden=�6e   5\      5]      5a      