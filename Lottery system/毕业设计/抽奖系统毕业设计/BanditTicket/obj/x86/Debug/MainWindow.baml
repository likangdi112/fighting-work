   M S B A M L   `   `   `  ����  BanditTicket    BanditTicket.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  window��5   	    � Title$ 
MainWindow��5   	   $	��350��6   $	��525��6)    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � 	Resources 5       �� 
TargetType �� Property �� Value��%g   'n�       �� 5	   
   " n�6   .�5
      ��  �@J�Opacity$ 0Q�6(   -   5        5      5      .��5      � -   5         �Name$ 	grid_Body��5      ��6   �� 	 �� ElementName$	 window��
 �� Path$
 Width���6N   �� $	 window��$
 Height���5   
   !� 5       !� Visual 5      �� 5       �� CornerRadius$ 15��6   ��6/   �� $	 window��$
 Width���6_   �� $	 window��$
 Height���5      �� 5       �� 
StartPoint$ 0.5,0&�62    �� EndPoint$ 0.5,1&�6E   .��5   "   �  � Color$ #333333��6/    � Offset$ 0Q�6?   � 5   "   $ Black��6/   $ 1Q�6=   5      5      5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5       $��50 �6   .+�5"   
   �� -   5         ��Name$ border��5"      ���	#66000000._�5#      �� $��Title��6   
�������$��30��68   $
��Left=�6C   $��10q�6^   5$      � 5%   
   -   5         �Name$ 	wrapPanel��5%      $��1��6'   5'      �� 5(   
   -   5        $��Button��5(      $��2��6"   6/   n� 5*   
   -   5         n�Name$ 
thumb_Left��5*      $
��Left=�6&   $��3��6C    � Cursor$ SizeWE��6T   n� 5+   
   -   5        $ 	thumb_Top��5+      $	��Top=�6&   $��3��6C   $ SizeNS��6T   n� 5,   
   -	   5        $ thumb_Right��5,      $��Right=�6&   $��3��6C   $ SizeWE��6T   n� 5-   
   -
   5        $ thumb_Bottom��5-      $��Bottom=�6&   $��3��6C   $ SizeNS��6T   n� 5/   
   -   5        $ thumb_LeftTop��5/      $
��Left=�6+   $	��Top=�6H   $��3��6d   $ SizeNWSE��6u   n� 50   
   -   5        $ thumb_RightTop��50      $��Right=�6+   $	��Top=�6H   $��3��6d   $ SizeNESW��6u   n� 51   
   -   5        $ thumb_LeftBottom��51      $
��Left=�6+   $��Bottom=�6H   $��3��6d   $ SizeNESW��6u   n� 52   
   -   5        $ thumb_RightBottom��52      $��Right=�6+   $��Bottom=�6H   $��3��6d   $ SizeNWSE��6u   53      54      