   M S B A M L   `   `   `  ����>  :dzh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:dzhdzh  5          dzh.ListViews   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:dzh     5        N� Title$  	ListViews��5	      .��5
      �� -   5        $��CarList��5
   i   
�������$��Disabled=�6x   ��6P   �� ��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ 12(�6-   �� 5       �@�Cursor$
 Hand��6+   �� 5       � ��
 �   �6/    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  � ��
 � ���67   5      P� 5       �@��
IsSelected . . �5      ��  � ��
 � ���67   5      5       �� View 5   
   �� 5      .P�5      �� $��车位��6!    �� Width$	 120��6-   	 �� DisplayMemberBinding	 69   �� 
 �� Path$
 location��� 5      $��车号��6!   $	 120��6-   	 69   �� $
 number��� 5      $��编号��6!   $	 200��6-   	 69   �� $	
 mid��� 5       $��串口��6!   $	 120��6-   	 69   �� $	
 com��� 5!      $��	波特率��6!   $	 120��6.   	 6:   �� $

 rate�5"      5$      5%      