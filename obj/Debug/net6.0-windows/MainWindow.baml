   M S B A M L   `   `   `  ????H  Dlmorgado_nasa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:lmorgado_nasalmorgado_nasa  5   	       lmorgado_nasa.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:lmorgado_nasa     5   	   -   5          ?Name$	  App??5   	    ? Title$ lmorgado_nasa??5	   	   $	??450??6   $	??800??6,    ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? 
TargetType ?? Property ?? Value ?? Color*  $System.Windows.Controls.DataGridCell ?? Triggers P? Property	 P? Value
 ?? 
TargetType&   System.Windows.Controls.DataGrid??%  '        '  	    '  ?    ?? 5   
   "  6   .?5      ??  ? ??$ Center=?6;   ?? 5       ? ??$ 10q?6(   ?? 5       ? ??$
 Bold"?6+   ?? 5       ? ??$ 16(?6)   ?? 5       ? ?? 5      ?? 5      $ 	#80423E3B??6&   5      5      ?? 5   
   "  6    5      P? 5       ?@ 
IsSelected$
	 True??60   . ?5      ??  ? ??
 ?????63   ?? 5       ? ?? 5      ?? 5      $ 	#80423E3B??6.   5!      5"      .?5$      ??  ? ?? 5%      ?? 5&      "
  6&   .R?5'      ?? #??z??6!   #??z??5(      #??z??5)      ._?5*      ?? $??Center=?6/   $??Center=?6J   5+      5,      5.      5/      ?? 50   
   "  6   .?51      ??  ? ?? 52      ?? 53      $ 	#80423E3B??6&   55      ?? 56       ? ??
 ?????6+   ?? 57       ?@ RowBackground 58      ?? 59      $ 	#80423E3B??6&   5;      ?? 5<       ? ??$ 2q?60   ?? 5=       ? ??
 ???? 6,   5>      5?      .??5A      ? -   5         ?Name$ MainGrid??5A      .+?5B   
   ?? -   5         ??Name$ POTDImg??5B      $?? ??6!   $??UniformToFill=?6,   ?? 5C   
   -   5        $#??Get more infos about the APOD??5C      $
??Left=?69   $??	10,10,0,0q?6T   $	??Top=?6g   6     5D   
   -   5          Name$ NeoData??5D      $??	0,222,0,0q?6O      
IsReadOnly$
 True??6b   $ ?? IsSynchronizedWithCurrentItem$
 TrueY?6t      SelectionMode$ Single=?6?    ?? SelectedIndex$ 0??6?      GridLinesVisibility$ Vertical=?6?      VerticalGridLinesBrush
 ?   ?$??Bottom=?6      Columns 5E      4  .System.Windows.Controls.DataGridTemplateColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Header$ View in browser??6)      CellTemplate 5G      ?? 5H      .R?5I      ?? -   5        ??5I   %   ?? *id+6<   5J      5L      5N      ?? 5O   
   -   5         ??Name$ Units??5O      $??	10,85,0,0q?6"   $	??120??65   $
??Left=?6k   $	??Top=?6?   ?? 5P   
   $??Diameter Units??6   $
??Left=?6)   $??	10,54,0,0q?6D   $	??Top=?6W   $	??120??6o   $??Center=?6{   $??Center=?6?   ???	#80423E3B
???????6?   (  "System.Windows.Controls.DatePicker  5Q   
   -   5          Name$ 	StartDate??5Q      $
??Left=?6(   $??
10,155,0,0q?6C   $	??Top=?6W   $	??120??6o      DisplayDate$ 
2023-02-05??6{   6?   ?? 5R   
   $
??Date??6   $
??Left=?6   $??
10,124,0,0q?6:   $	??Top=?6N   $	??120??6f   $??Center=?6r   $??Center=?6?   ???	#80423E3B
???????6?   5S      5T      