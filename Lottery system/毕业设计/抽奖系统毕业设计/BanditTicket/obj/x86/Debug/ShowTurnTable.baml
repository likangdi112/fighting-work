   M S B A M L   `   `   `  ����  BanditTicket     BanditTicket.ShowTurnTable   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      
������   � 	Resources  5         	zhuandong g� RepeatBehavior �� TargetProperty �� 
TargetName O� KeyTime O� Value �� 	KeySpline  ButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType A�Name �� ImageSource J� SnapsToDevicePixels �� Triggers P� Property P� Value��%�  &	        &	 �    �� 5	   
   $ 1x��6'   .��5
      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ path1��6�   .\�5      �� $ 0��6'   $ 0Q�63   �� 5      $ 0:0:2��6'   $ 450.742Q�67   $ 1,0,1,1��6G   �� 5      $ 0:0:5��6'   $ 4409.245Q�67   �� 5      $ 0:0:7��6'   $
 5062Q�67   $ 0,0,0,1��6D   5      5      �� 5   
   " ��6$   .�5      ��  � ��	 5      �� 5      "
 ��6&   .R�5      � .+�5      A� $ ellipse��6&   
�������$��3��6F   ��5   "   �� 5   &   $ image\10.jpg��62   6O   5      �� 5      #��z��6/   ��. # z 6�   #��z��6�   5        5!      P� 5"       �@J�	IsFocused . 6;   P� 5#       �@��IsDefaulted . 6=   P� 5$       �@J�IsMouseOver . 5&      P� 5'       � �� . 5)      55      57      58      59      .��5:      � -   5         �Name$ 
LayoutRoot��5:      $	��474��6   $	��474��6+   .+�5;   
   F� ������@�Ӡ��Fc{Fc{���@�����7�z����� @Fc{�� @@���� @(�z7�z�����@@������@SFc{�����@���(�z���@�Р��%& Ѡ����Р%& ����������p�c��s��Z!a�mA�Ud���7d(XM	$��-1q�6k   �� Stretch$
 Fill=�6w  $��5��6�   � UseLayoutRounding .   J� RenderTransformOrigin$ 0.5,0.5&�6�  
�������z�5<      V� 5=      .~�5>      �� �� 5?      �� 5@       �� Angle$ 0Q�6&   T� 5A      5B      ��5D      �� 5I      $ image\11.jpg��6   6:   5K      F� 5L   
   -   5         F�Name$ path1��5L      +��������[ ��h�@t*�@�@��@�
@t*	$��214,106,208.616,0q�6J   $
 Fill=�6e   
�������$��3��6�    .  $ 0.493,1.002&�6�   $��126.684��6�   $	��Top=�6�   z�5M      V� 5N      .~�5O      �� �� 5P      �� 5Q      $ 22Q�6&   T� 5R      5S      ��5U      �� 5V       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5W      �  � Color$	 Red��6#    � Offset$ 0Q�6/   � 5X      $ 	#FFFFF500��6#   $ 1Q�65   � 5Y      $ 	#FFFF5A00��6#   $ 0.272Q�65   5Z      5\      �� 5]   
   -   5         ��Name$ btnStartTurntable��5]      
���   � � Cursor$
 Hand��6[   $��20(�6�   $��Center=�6�   $	��150��6�   #���  6�   $��Center=�6�   $	��150��6  $��161,158,163,165q�6   � FocusVisualStyle 6,   Z� 6  F� 5^   
   ����� ���,1���� -1 -1����,1 ��� -12����� W� �� W��2�� W� W�2�� W� ��� W����2�� -1 ���,1� ��    �l2�     ���QV �� ��� ��l2�l2� �� �� ��ӍQV ��l2� ���    �QV�QV ��	$
 Fill=�6N  ���	#99E6FF00��5_      �� 5e      $ image\13.jpg��6   6:   5g      �� 5h   
   -   5        $��thanks_join1��5h      $��32��6)   $	��103��65   $��250,62,122,0q�6A   $
��Wrap=�6W   $	��Top=�6k   $ 0.5,0.5&�6�    �� TextAlignment$ Center=�6�   $��21.333(�6�   
���   �z�6�   V� 5i      .~�5j      �� �� 5k      �� 5l      $ 25Q�6   T� 5m      5n      �� 5o   !     � Language$  zh-cn�6%   6:   �� 5p   
   -   5        $��thanks_join2��5p      $��Right=�6)   $��0,291,25,151q�6E   $
��Wrap=�6[   $	��103��6o   $��32��6{   $ 0.5,0.5&�6�   $ Center=�6�   $��21.333(�6�   
���   �z�6�   V� 5q      .~�5r      �� �� 5s      �� 5t      $	 110Q�6   T� 5u      5v      �� 5w   !   $  zh-cn�6%   6:   �� 5x   
   -   5        $��thanks_join3��5x      $��32��6)   $	��103��65   $��125,0,246,64q�6A   $
��Wrap=�6W   $��Bottom=�6k   $ 0.5,0.5&�6�   $ Center=�6�   $��21.333(�6�   
���   �z�6�   V� 5y      .~�5z      �� �� 5{      �� 5|      $ 30Q�6   T� 5}      5~      �� 5   !   $  zh-cn�6%   6:   �� 5�   
   -   5        $��thanks_join4��5�      $
��Left=�6)   $��23,156,0,285q�6D   $
��Wrap=�6Z   $	��103��6n   $��32��6z   $ 0.5,0.5&�6�   $ Center=�6�   $��21.333(�6�   
���   �z�6�   V� 5�      .~�5�      �� �� 5�      �� 5�      $	 110Q�6   T� 5�      5�      �� 5�   !   $  zh-cn�6%   6:   �� 5�   
   -   5        $��first_prize��5�      $��31.646��6(   $��
0,157,23,0q�68   $
��Wrap=�6L   $	��Top=�6`   $ 0.5,0.5&�6x   $ Center=�6�   $��21.333(�6�   
���   �$��Right=�6�   $��94��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 60Q�6   T� 5�      5�      5�      �� 5�   
   -	   5        $��second_prize��5�      $��32��6(   $��
0,0,118,65q�64   $
��Wrap=�6H   $��Bottom=�6\   $ 0.5,0.5&�6w   $ Center=�6�   $��21.333(�6�   
���   �$��Right=�6�   $	��103��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ -20.82Q�6   T� 5�      5�      5�      �� 5�   
   -
   5        $��third_prize��5�      $��32��6'   $��
21,0,0,153q�63   $
��Wrap=�6G   $��Bottom=�6[   $ 0.5,0.5&�6v   $ Center=�6�   $��21.333(�6�   
���   �$
��Left=�6�   $	��103��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 70.994Q�6   T� 5�      5�      5�      �� 5�   
   -   5        $��lucky_prize��5�      $��32��6(   $	��103��64   $��
117,58,0,0q�6@   $
��Wrap=�6T   $	��Top=�6h   $ 0.5,0.5&�6�   $ Center=�6�   $��21.333(�6�   
���   �$
��Left=�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ -20.426Q�6   T� 5�      5�      5�      5�      5�      