   M S B A M L   `   `   `  ����V  RRealtorAgency (Course work), Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:RealtorAgency__Course_work_RealtorAgency__Course_work_  5   	   (    "RealtorAgency__Course_work_.Client   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:RealtorAgency__Course_work_     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Клиенты™��5	   	   $	��499��6   $	��630��6'    � Icon$ Resources/Client.ico��5
        � 	Resources 5         MainBackground �� Property �� Value �� 
TargetType  	MenuStyle  
MenuStyle2  ButtonToolBarStyle �� 
TargetType  ButtonToolBarTemplate ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName��%N  &	        '�� D     &	 �     &	 �    &	 �    &	     7  �� 5   
   .�5      ��  � �� �#edf4fc63   5      �� 5   
   " ��6   .�5      ��  � ��$ 	20 8 20 8q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 30��6'   5      �� 5   
   .�5      ��  � ��$ TimeNewRoman)�61   �� 5       � ��$
 20pt(�6/   �� 5       � ��
 �   �61   �� 5       � ��$ Italic$�60   �� 5       � ��$
 Left=�6:   �� 5       � ��$ center=�68   5      �� 5   
   .�5      ��  � ��$ TimeNewRoman)�61   �� 5       � ��$
 20pt(�6/   �� 5       � ��$ Italic$�60   �� 5        � ��
 �   �61   �� 5!       � ��$ Center=�6:   �� 5"       � ��$ center=�68   5#      �� 5$   
   .�5%      ��  � �� �#b6e2f562   �� 5&       � ��$ TimeNewRoman)�62   �� 5'       � ��$
 10pt(�60   �� 5(       � ��
 �   �62   �� 5)       � ��$ 0q�67   �� 5*       � ��$ 25��6.   �� 5+       � ��$ 75��6-   5,      �� 5.   
   " ��6   .R�5/      �� $ BorderButtonToolBar��6   $	 15��62   8��  ._�50      �� $��Center=�6!   $��Center=�6>   #��z��51   !   52      
 53      P� 54       �@J�IsMouseOver . . �55      �� $ BorderButtonToolBar��6    � �� �#9ad3fa6T   56      P� 57       � �� . . �58      �� $ BorderButtonToolBar��6    � ��$	 1.5q�6Y   �� 59      $ BorderButtonToolBar��6    � �� �#6792c16U   5:      5<      5>      .��5@      � -   5         �Name$ MainGrid��5@      #��[  6    � RowDefinitions 5A   
   �� 5B      $
��Auto �6   �� 5C      $��* �6   �� 5D      $
��Auto �6   .+�5G   
   � $��0��6    � ColumnDefinitions 5H      �� 5I      6%   �� 5J      $	��100 �6#   61   .+�5M      �� $��1��6   $��0��6$   $��0,0,10,0q�62   $��Resources/firm.png��6D   6b   �� 5N      $��0��6   .+�5O      �� -   5         ��Name$ FirmName��5O      #��[ 6*   $'��!Риэлторская фирма��6M   $��	100,0,0,0q�6i   �� 5P      $��1��6   $��0��6&   $��2��66   .+�5Q      �� -   5         ��Name$
 Info��5Q      $��Инфо��6+   
 �� Top$ 5��6;    �� Left$ 10��6J   #��[ 6[   6�   �� 5R      -   5        $ 	FirmName2��5R      #��[ 6/   $��Респект��6S    �� Right$ 50��6e   5S      5U      5V      &   System.Windows.Controls.DataGrid  5X   
   -   5          Name$ clientsGrid��5X         CanUserAddRows .     AutoGenerateColumns .  $��1��6[   #��[  6i      Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Фамилия+6S     5[      $ Имя��6&   $
 0.6* 6K    63   �� *Имя+6K     5\      $ Отчество��6&   $
 0.8* 6V    68   �� *Отчество+6V     5]      $ Телефон��6&   $ * 6T    67   �� *Телефон+6T     5^      $% Дата регистрации��6&   $ * 6f    6@   �� *!Дата регистрации+6f   5`      �� 5b   
   $��Center=�6   $��1��63    �� Orientation$ 
Horizontal=�6@   $��101,323,101,0q�6Y   $��2��6p   .+�5c      �� -   5        $ AddClientas��5c      #��[ 6D   $��Добавить��6v   6�   �� 5d      -   5        $ Delete��5d      $��Удалить��6%   #��[ 6R   5e      5g      5i      