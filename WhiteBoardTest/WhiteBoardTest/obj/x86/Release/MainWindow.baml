   M S B A M L   `   `   `  ���� I  EWhiteBoardTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WhiteBoardTestWhiteBoardTest      WhiteBoardTest.MainWindow   #myclr-namespace:WhiteBoardTest  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $��BoardWindow��  � Title$  
MainWindow��$	��925��$	��950�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� J� 	AllowDrop .  � SizeToContent$ WidthAndHeight=�����  �� Color$ Black�� �� Opacity ��  �� Path$ Value� �� ElementName$ sldstyle��	 � 	Resources	    GlassButton
 �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� CornerRadius ��Name � RowDefinitions J� Opacity �� RelativeTransform �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y � Color � Offset �� EndPoint  �� 
StartPoint! �� Triggers" P� Property# P� Value$ �� 
TargetName% �� Property& �� Value' N� EnterActions  	Timeline1( N� ExitActions) ��Name  	Timeline2  CheckRadioFillNormal  CheckRadioStrokeNormal # StrokeThicknessRadioButtonStyle* �� 
TargetType+ ��Name, �� RadiusX- �� RadiusY  ButtonStyleReWrite  ButtonStyleReWriteOnly. �� ContentStringFormat/ �� ContentStringFormat 	 ButtonNoramlStyle0 �� BasedOn1 �� Triggers��%�  &	        7  7  &	 �    &	 �    &	 	    7  7  &	 �
    &	 �
    &		 �    7  �� "
 �� ���� 	Timeline1 .��U� $ 00:00:00X�$
 glow��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 1Q��� 	Timeline2 .��U� $ 00:00:00X�$
 glow��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�.R��� ���	#FFFFFFFF$��1,1,1,1q�$ 4,4,4,4��._��� $ border�����	#7F000000���	#FF000000$��1,1,1,1q�$ 4,4,4,4��._��  �� $��0.507* ��� $��0.493* �.+��� $
 glow��$ 0Q�$��Stretch=�$
��Auto��$��2��$ 4,4,4,4����
�  V� .~��� $ 1.702Q�$ 2.243Q��� $ 0Q�$ 0Q��� $ 0Q�T� $ -0.368Q�$ -0.152Q�.��� $ 	#B28DBDFF��$ 0Q�� $ 	#008DBDFF��$ 1Q��� $��Center=�$��Center=�$
��Auto��$��2���� $ shine��$��Stretch=�$��0,0,0,0q�$
��Auto��$ 4,4,0,0������ $ 0.494,0.889&�$  0.494,0.028&�.��� $ 	#99FFFFFF��$ 0Q�� $ 	#33FFFFFF��$ 1Q�! P� " � ��# . . ��� $$ shine��% �@J�Opacity$	& 0.4Q��� $$ border��% � ��& �	#CC000000�� $
$ glow��% � y�$& Hidden=�P� " �@J�IsMouseOver# . ' �� 8��  ( �� $) Timeline2_BeginStoryboard��8�� �� .��� $ 	#FFD2D4D2��$ 0Q�� $ 	#FFFFFFFF��$ 1Q��� .��� $ 	#FF004C94��$ 0Q�� $ 	#FF003C74��$ 1Q��� "* 	�.��� % � ��#& � ���� % � ��8&   �� % � ��8&  �� % � ��$& 1q��� % � ��& �� "
 	�.R�� $��40��$��38��.+��� $+ 	rectangle��$ 0Q����	#FF979797$, 2��$- 2��$��Stretch=�$��0,0,0,0q�$��Stretch=����� $ 0.55,1&�$  
0.55,0.026&�.��� $ 	#FF979797��$ 0Q�� $ 	#FFFFFFFF��$ 1Q�A� ���	#FF000000$��Center=�$��0,0,0,0q�$��Center=�#��z��#��z����Z� �� $+ rectangle_Copy��$ 0Q�$, 2��$- 2��$��1.749,0.763,1.964,2.765q���Z� ���� $ 0.558,0.989&�$  
0.55,0.026&�.��� $ 	#91FFFFFF��$ 0Q�� $ 	#16FFFFFF��$ 0.447Q�� $ 	#89FFFFFF��$ 0.288Q�! P� " �@J�IsMouseOver# . . ��� $$ 	rectangle��% �@J�Opacity$& 0.995Q��� $$ rectangle_Copy��% �@J�Opacity$& 1Q�P� " � ��# . . ��� $$ 	rectangle��% � ��& �� $ 0.55,1&�$  
0.55,0.026&�.��� $ 	#FF438A7E��$ 0Q�� $ 	#FFD6F2ED��$ 1Q��� $$ 	rectangle��% �@J�Opacity$& 1Q��� $$ rectangle_Copy��% �@J�Opacity$& 1Q��� $$ 	rectangle��% � ��& �	#FF3C6A62P� " �@d�	IsChecked$
# TrueY�. ��� $$ 	rectangle��% � ��& �	#FF6A6A6A�� $$ 	rectangle��% � ��& �� $ 0.55,1&�$  
0.55,0.026&�.��� $ 	#FF686868��$ 0Q�� $ 	#FFBFBFBF��$ 1Q��� $$ 	rectangle��% �@J�Opacity$& 1Q��� $$ rectangle_Copy��% �@J�Opacity$& 1Q�P� " � {�# .  . ��� #& � ��% � ���� "* ��.��� % � ��& �� "
 ��.R��� #��z��#��z��#��z��$ 2���� "* ��.��� % � ��& �� "
 ��.R��� #��z��#��z��#��z��$ 2��._��� $��Content��#��z��#/ z. #��z��#��z��#��z��#��z���� "* ��80   .��� % � ��
& ������� % � ��$& 0q�1 P� " �@J�IsMouseOver# . . ��� % � ��$& 5q�P� " � ��# . . ��� % � ��$& 5q�.��]� -   $��ContentPanel��.+��� $��Center=����� $ White�� �� $ Value�$ sldstyle��.+��� $��95��$��2,2,2,2q�
���   �$��画笔颜色��$	��Top=�$
��Auto�����	#FF3B373B.���� .+��� -   2 ��Name$2 Color_2��#��[	 $��Center=�$��80��$��30��$	��Top=�$
��0,10q�
����� ��� -   $2 Color_3��#��[	 $��Center=�$��80��$��30��$
��0,10q�$	��Top=�
��������� -   $2 Color_4��#��[	 $��Center=�$��80��$��30��$	��Top=�$
��0,10q�
���   ��� -   $2 Color_5��#��[	 $��Center=�$��80��$��30��$	��Top=�$
��0,10q�
���  ���� $��95��$��2,2,2,2q�
���   �$��画笔粗细��$	��Top=�$
��Auto�����	#FF3B373B.���� .+��� -   $2 Size_2��#��[	 $��Center=�
3 � Tag$3 15��$��80��$��30��$	��Top=�$	��0,5q�
������ ���� $��15��$��15��
���   ��� -   $2 Size_3��#��[	 $��Center=�$3 10��$��80��$��30��$
��0,10q�$	��Top=�
������ ���� $��10��$��10��
���   ��� -	   $2 Size_4��#��[	 $��Center=�$��80��$��30��$	��Top=�$3 5��$	��0,5q�
������ ���� $��5��$��5��
���   ��� -
   $2 Size_5��#��[	 $��Center=�$��80��$��30��$	��Top=�$3 2��$	��0,5q�
������ ���� $��2��$��2��
���   ��� $��95��$��2,2,2,2q�
���   �$��工具选取��$	��Top=�$
��Auto�����	#FF3B373B.���� .+��� -   $2 shape1��#��[	 $��Center=�$3 0��$��80��$��30��$	��Top=�$	��0,5q�
������ ���� $��35��$��18��
������ 
���  ���� -   $2 shape2��#��[	 $��Center=�$3 1��$��80��$��30��$
��0,10q�$	��Top=�
������ ��A� $��20��$��18��
������ 
���  ���� -   $2 shape3��#��[	 $��Center=�$��80��$��30��$	��Top=�$3 2��$	��0,5q�
������ ���� 	4 �� X1$4 0��	5 �� X2$5 50��	6 �� Y1$6 0��	7 �� Y2$7 0��
���  ��$��1���� $��透明度调节��$��95��$	��Top=�$��2,2,2,2q�
���   �$
��Auto�����	#FF3B373B.���� -   $��sldstyle��$��0,0,-2.333,0q�8 � Maximum$8 1Q�9 � Minimum$9 0Q�{�. $
��Left=�$��85��$��15���� ���	#FF3B373B$��5,5,5,5q�$ 8,8,8,8��$	��Top=����#C7D2DD._��� -   $��
inkContent��$��10,10,10,10q�: �� UseCustomCursor: . ; �� EditingModeInverted$	; Ink=�< �� EditingMode$	< Ink=�