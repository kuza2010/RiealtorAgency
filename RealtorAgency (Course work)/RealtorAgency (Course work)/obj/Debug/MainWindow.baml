   M S B A M L   `   `   `  ����V  RRealtorAgency (Course work), Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:RealtorAgency__Course_work_RealtorAgency__Course_work_  5   	   ,    &RealtorAgency__Course_work_.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:RealtorAgency__Course_work_     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Респект™��5	   	   $	��170��6   $	��400��6'    � 
ResizeMode$ CanMinimize=�63    � Icon$ Resources/Main.ico��6L    � 	Resources 5
         MainBackground �� Property �� Value  	MenuStyle  
MenuStyle2  ButtonToolBarStyle �� 
TargetType  ButtonToolBarTemplate ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 D     &	 N    &	 Z    &	 �    7  �� 5   
   .�5      ��  � �� �#edf4fc63   5      �� 5   
   .�5   
   ��  � ��$ TimeNewRoman)�6-   �� 5   
    � ��$
 20pt(�6+   �� 5   
    � ��
 �   �6-   �� 5       � ��$ Italic$�60   �� 5       � ��$
 Left=�6:   �� 5   
    � ��$ center=�64   5      �� 5   
   .�5      ��  � ��$ TimeNewRoman)�61   �� 5       � ��$
 20pt(�6/   �� 5       � ��$ Italic$�60   �� 5       � ��
 �   �61   �� 5       � ��$ Center=�6:   �� 5       � ��$ center=�68   5      �� 5   
   .�5      ��  � �� �#b6e2f562   �� 5        � ��$ TimeNewRoman)�62   �� 5!       � ��$
 10pt(�60   �� 5"       � ��
 �   �62   �� 5#       � ��$ 0q�67   �� 5$       � ��$ 35��6.   �� 5%       � ��$	 130��6-   5&      �� 5(   
   " ��6   .R�5)      �� $ BorderButtonToolBar��6   $	 15��62   8��  ._�5*      �� $��Center=�6!   $��Center=�6>   #��z��5+   !   5,      
 5-      P� 5.       �@J�IsMouseOver . . �5/      �� $ BorderButtonToolBar��6    � �� �#9ad3fa6T   50      P� 51       � �� . . �52      �� $ BorderButtonToolBar��6    � ��$	 1.5q�6Y   �� 53      $ BorderButtonToolBar��6    � �� �#6792c16U   54      56      57      .��59      � -   5         �Name$ MainGrid��59      #��[  6   .+�5;   
   �� .+�5<      �  � ColumnDefinitions 5=      �� 5>      $��3* �6'   64   �� 5?      $��1* �6'   64    � RowDefinitions 5A      �� 5B      6&   �� 5C      6&   .+�5F      �� $��1��6   $��0��6(   $��Resources/firm.png��65   $��0,0,10,0q�6Q   6f   �� 5G      $��0��6   $��0��6-   .+�5H      �� -   5         ��Name$ FirmName��5H      #��[ 6.   $'��!Риэлторская фирма��6Q   �� 5I      -   5        $ 	FirmName2��5I      #��[ 6/   $��Респект��6S   5J      �� 5L      $��1��6   $��0��6&   $��2��66   .+�5M      �� -   5         ��Name$ GoClient��5M      #��[ 6/   $(��"Перейти к клиентам��6a   
 �� Top$ 5��6~    �� Left$ 10��6�   6�   �� 5N      -   5        $
 Exit��5N      #��[ 6+   $��
Выход��6]   $ 5��6m    �� Right$ 10��6}   6�   5O      5P      5Q      5R      5T      