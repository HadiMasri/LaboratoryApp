   M S B A M L   `   `   `  ����H  DLaboratory.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Laboratory.UI.ViewsLaboratory.UI.Views  5          Laboratory.UI.Views.Tests   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Laboratory.UI.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � -   5          �Name$  grdTest��5
      .+�5   
   �  � RowDefinitions 5   
   �� 5      $	��300 �6    �� 5      $��* �6    .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ patientGroupBox��5   <   $��5��6   $��0��6/   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Custom=�6V   ���#fcfcfc   
Background �#24426E   
Foreground
 �����$��New Test��6�   $��Stretch=�6  $	��Top=�6/  $	��250��6I  $��	60,0,60,0q�6V  5      �� 5   
   -   5         ��Name$ txtCode��5   /   $��0��6   $��0��6    %  !MaterialDesignFloatingHintTextBox#��[  6@   $	��Top=�6{   $��
90,50,40,0q�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Code:��6�   	 �� TextWrapping$
	 Wrap=�6�   $��Stretch=�6�   $��43��6  6  �� 5      -   5        $ txtAppearingName��5   L   $��0��6   $��0��6'   $��90,100,40,0q�67   #��[  6g   $ Appearing Name:��6�   $
	 Wrap=�6�   $	��Top=�6�   $��Stretch=�6  $��43��6!  6/  �� 5      -   5        $ txtTestName��5   K   $��0��6   $��1��6'   $��
90,50,40,0q�67   #��[  6a   $ 
Test Name:��6�   $
	 Wrap=�6�   $	��Top=�6�   $��Stretch=�6�   $��43��6  6"  �� 5      -   5        
 ��Name$
 comboCategory��5   (   $��0��6   $��1��6?    �� DisplayMemberPath$
 Name��6r   $ Category��6�   $��90,100,40,0q�6�   $��43��6�   $	��Top=�6�    & "MaterialDesignFloatingHintComboBox#��[ 6)   �� SelectedValue 6O   �� *
GenderId+��6�   �� *#!LongListToTestComboVirtualization+��5      �� 5       .R�5!      $� 5"      5$      �� 5%      -   5        $
 
comboUnits��5%   8   $��0��6   $��2��6(   $
 Name��6m   $ Units��6�   $��
90,50,40,0q�6�   $��43��6�   $	��Top=�6�   #��[ 6    6L   �� *UnitId+��6�   �� *#!LongListToTestComboVirtualization+��5&      �� 5'      .R�5(      $� 5)      5+      �� 5,      -   5        $ txtPrice��5,   7   $��0��6   $��2��6'   #��[  6J   $��90,100,40,0q�6�   $ Price:��6�   $
	 Wrap=�6�   $	��Top=�6�   $��Stretch=�6�   $��43��6  6  �� 5-      -	   5        $ txtNote��5-   L   $��0��6   $��3��6(   $��5��68   #��[  6]   $	��Top=�6�   $	��100��6�    �� AcceptsReturn$
 True��6�   $
	 Wrap=�5.   	   " �� VerticalScrollBarVisibility$
 Auto=�6   $��50,50,100,0q�6@   $ Notes:��6U   �� 51   
   -
   5         ��Name$ addTest��51   .   $��0��6   $��4��6   $	��100��6Q   ���#090D40$��0,200,100,0q�6r   $	��Top=�6�    � ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton��6�   $	��Add��6�   ��52      �� 53       �� 
TargetType" ��6    " MaterialDesignRaisedDarkButton �� BasedOn# [ 65    �� Triggers 54      �� 55       �� Binding 6&   �� *SelectedItems.Count+ �� ElementName$ comboCategory�� �� Value 06h   .a�56      ��  �� Property � {� �� Value$ False��6:   57      �� 58       6&   �� *Text.Length+$ txtCode�� �� UpdateSourceTrigger$ PropertyChanged=� 06�   .a�59      ��  � {�$ False��6:   5:      �� 5;       6&   �� *Text.Length+$ txtAppearingName��$ PropertyChanged=� 06�   .a�5<      ��  � {�$ False��6:   5=      �� 5>       6&   �� *Text.Length+$ txtTestName��$ PropertyChanged=� 06�   .a�5?      ��  � {�$ False��6:   5@      �� 5A       6&   �� *Text.Length+$ txtPrice��$ PropertyChanged=� 06�   .a�5B      ��  � {�$ False��6:   5C      5E       � Triggers 5G      :� 5H       :� RoutedEvent$ 
MouseEnter��6   .[�5I      �� .��5J      �� .��5K      �� 	 �� To #0104246-    g� Duration$ 0:0:0.3D�6:    �� 
TargetName$ addTest��6M    �� TargetProperty$ Background.Color�6n   5L      5M      5N      :� 5O      $ 
MouseLeave��6   .[�5P      �� .��5Q      �� .��5R      ��  #090D406-   $ addTest��6:   $ 0:0:0.3D�6[   $ Background.Color�6o   5S      5T      5U      5W      �� 5X      -   5        $ btnNew��5X   6   $��0��6   $��3��6&   $	��New��6G   $	��100��6U   ���#61637A$8 2Resource name: MaterialDesignRaisedLightDarkButton��6�   $��150,200,0,0q�6�   $	��Top=�6�    5Y      :� 5Z      $ 
MouseEnter��6   .[�5[      �� .��5\      �� .��5]      ��  #48495c6-   $ 0:0:0.3D�6:   $ btnNew��6M   $ Background.Color�6m   5^      5_      5`      :� 5a      $ 
MouseLeave��6   .[�5b      �� .��5c      �� .��5d      ��  #61637A6-   $ btnNew��6:   $ 0:0:0.3D�6Z   $ Background.Color�6n   5e      5f      5g      5i      5j      � 5k      $��1��6   .+�5l      &   System.Windows.Controls.DataGrid  -   5           Name$  	testsGrid��5l   (   $��0��6   $��	60,0,60,0q�6j   !   
IsReadOnly$
! True��6   "   CanUserAddRows$" False��6�   #   SelectionUnit$# FullRow=�6�   $   SelectionMode$$ Extended=�6�   % � 	Resources% 5m      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        7 �� 5n      8   "  6Y   .�5o      ��  � �� �#24426E6;   �� 5p       � ��$ Center=�6K   �� 5q       � ��
 �����6;   �� 5r       � ��$ 0q�6@   5s      5t      &   Columns& 5u      0  *System.Windows.Controls.DataGridTextColumn  5v      ,  &System.Windows.Controls.DataGridColumn'   Header$
' Code��6.   (   Width5  /System.Windows.Controls.DataGridLengthConverter$	( 135 6U   1  +System.Windows.Controls.DataGridBoundColumn)   Binding) 6<   �� *Code+*   ElementStyle* 5w      �� 5x   "   " ��6(   .�5y   &   ��  � ��$ Center=�6L   5z   #   5|        5}      $' Appearing Name��6.   $	( 135 6e   ) 6F   �� *
AppearName+* 5~      �� 5   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�        5�      $' 	Test Name��6.   $( * 6Z   ) 6A   �� *Name+* 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�        5�      $' Category��6.   $( * 6a   ) 6@   �� *CategoryName+* 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�        5�      $' Price��6.   $( * 6W   ) 6=   �� *Price+* 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�        5�      $
' Unit��6.   $( * 6Y   ) 6<   �� *
UnitName+* 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�        5�      $
' Note��6.   $( * 6U   ) 6<   �� *Note+* 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      + 	  CellTemplate+ 5�      �� 5�   "   .R�5�   &   �� $ addRange��6-   -   5        
�������$��Range��5�   e   $��0q�6v   $��60��6�   $��30��6�   $��0q�6�   ��5�   *   �� 5�   .   , �� 
TargetType", ��6>   .R�5�   2   �� - ��Name$
- test��6:   . �� CornerRadius$. 5��6H   $��0q�6Y   ���#666563._�5�   6   �� $��Center=�6H   $��Center=�6c   5�   3   / �� Triggers/ 5�   2   :� 5�   6   $ 
MouseEnter��6C   .[�5�   :   �� .��5�   >   �� .��5�   B   ��  #2626246Q   $ 0:0:0.3D�6^   $
 test��6q   $ Background.Color�6�   5�   ?   5�   ;   5�   7   :� 5�   6   $ 
MouseLeave��6C   .[�5�   :   �� .��5�   >   �� .��5�   B   ��  #6665636Q   $
 test��6^   $ 0:0:0.3D�6|   $ Background.Color�6�   5�   ?   5�   ;   5�   7   5�   /   5�   '   5�   #   5�      	  5�      + 5�      �� 5�   "   .R�5�   &   �� $ deletBtn��6-   -   5        
������ ���#f01a50$��0q�5�   �   $��90��6�   $��30��6�   $��0q�6�   .��5�   *   '
  !MaterialDesignThemes.Wpf.PackIcon
  0 
 Name$0 	deletIcon��6B   1 
  Kind$1 DeleteEmpty=�6U   $��60��6h   $��30��6s    5�   *   :� 5�   .   $ 
MouseEnter��6;   .[�5�   2   �� .��5�   6   �� .��5�   :   ��  #1f080e6I   $ 0:0:0.3D�6V   $ deletBtn��6i   $ Foreground.Color�6�   5�   7   5�   3   5�   /   :� 5�   .   $ 
MouseLeave��6;   .[�5�   2   �� .��5�   6   �� .��5�   :   ��  #f01a506I   $ deletBtn��6V   $ 0:0:0.3D�6x   $ Foreground.Color�6�   5�   7   5�   3   5�   /   :� 5�   .   $ 
MouseEnter��6;   .[�5�   2   �� .��5�   6   �� .��5�   :   W� $ 	deletIcon��6K   $ 0:0:0.3D�6n   $ Width�6�   	2 W� To2 656�   5�   7   5�   3   5�   /   :� 5�   .   $ 
MouseEnter��6;   .[�5�   2   �� .��5�   6   �� .��5�   :   W� $ 	deletIcon��6K   $ 0:0:0.3D�6n   $ Height�6�   2 356�   5�   7   5�   3   5�   /   :� 5�   .   $ 
MouseLeave��6;   .[�5�   2   �� .��5�   6   �� .��5�   :   W� $ 	deletIcon��6K   $ 0:0:0.3D�6n   $ Width�6�   2 606�   5�   7   5�   3   5�   /   :� 5�   .   $ 
MouseLeave��6;   .[�5�   2   �� .��5�   6   �� .��5�   :   W� $ 	deletIcon��6K   $ 0:0:0.3D�6n   $ Height�6�   2 306�   5�   7   5�   3   5�   /   5�   '   5�   #   5�      5�      5�      5�      5     5     