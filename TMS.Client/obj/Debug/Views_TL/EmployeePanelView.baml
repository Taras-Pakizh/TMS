   M S B A M L   `   `   `  ����E  ATMS.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TMS.Client.TeamLead.ViewsTMS.Client.TeamLead.Views  5      1    +TMS.Client.TeamLead.Views.EmployeePanelView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:TMS.Client.TeamLead.Views     5      ��5	      �� 5
   
     �� 
StartPoint$  -1,-1&�6    �� EndPoint$ 1.5,1.5&�61   .��5      �  � Color$	 Red��6    � Offset$	 0.0Q�6'   � 5      $
 Blue��6   $	 1.0Q�6(   5      .��5      � .+�5   
   �� -   5        $
��Back��5       $
��Back��6   $
��Left=�6,   $��
913,20,0,0q�6G   $	��Top=�6[   $��75��6s   ��5      �� 5      $  -1,-1&�6&   $ 1.5,1.5&�69   .��5      � $ DarkSlateBlue��6#   $	 0.0Q�69   � 5      $ SkyBlue��6#   $	 1.0Q�63   5      ��5      �� 5      $	  0,0&�6&   $	 1,1&�67   .��5      � $	 Red��6#   $ 0Q�6/   � 5      $ Yellow��6#   $	 1.0Q�62   5      ��5       �� 5!      $	  0,0&�6&   $	 1,1&�67   .��5"      � $	 Red��6#   $	 0.0Q�6/   � 5#      $
 Blue��6#   $	 1.0Q�60   5$      5&      �� 5'   
   $��50, 10q�6   $
��Left=�6%   $��Center=�6@   .+�5(      �� $	��Top=�6   $
��Left=�61   $��5q�6L   .+�5)      �� $��Center=�6   $��..\Images\user.png��65   $��50��6Q   $��50��6\   $��10q�6h   6v   �� 5*      -   5         ��Name$
 Name��5*   (   $
��Name��6   $	��0,5q�66   $��16(�6C   
�������6f   �� 5+      -   5        $ Email��5+   )   $��Email��6   $	��0,5q�68   $��16(�6E   
�������6h   �� 5,      -   5        $
 Role��5,   (   $
��Role��6   $	��0,5q�66   $��16(�6C   
�������6f   5-      �� 5.      $	��Top=�6   $
��Left=�61   $��5q�6L   .+�5/      �� -   5        $ BackEnd_Developing��5/   <   $��FrontEnd_Developing: 0 h��6   
�������$	��0,5q�6k   $��14(�6x   6�   �� 50      -   5        $ FrontEnd_Developing��50   )   $��Email��6   $	��0,5q�6F   
�������$��14(�6f   6v   �� 51      -   5        $ Testing��51   (   $
��Role��6   $	��0,5q�69   $��14(�6F   
�������6i   �� 52      -   5        $ UI_Designing��52   (   $
��Role��6   $	��0,5q�6>   $��14(�6K   
�������6n   �� 53      -	   5        $ DB_Designing��53   (   $
��Role��6   $	��0,5q�6>   $��14(�6K   
�������6n   �� 54      -
   5        $ 
Bug_fixing��54   (   $
��Role��6   $	��0,5q�6<   $��14(�6I   
�������6l   55      56      &   System.Windows.Controls.DataGrid  57   
   -   5        $��Reports��57         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6"      AutoGenerateColumns .  $
��Left=�6N   $	��325��6i   $��
288,55,0,0q�6v   $	��Top=�6�   $	��700��6�      Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ Activity��6%   	   MaxWidth$	 70Q�67   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6F   �� *
activity+6f     5:      $ Start��6%   $	 50Q�64   
 6B   �� *start+ �� StringFormat$ 
dd-MM-yyyy��6w     5;      $	 End��6%   $	 50Q�62   
 6@   �� *end+$ 
dd-MM-yyyy��6s     5<      $ Description��6%   
 6:   �� *description+6]     5=      $ Effort��6%   $	 40Q�65   
 6C   �� *effort+6a   5?      �� 5@   
   $��Reports:��6   $
��Left=�6#   
�������$��
288,15,0,0q�6Q   $	��Top=�6e   $��20(�6}   �� 5A   
   -   5        $��Approve��5A   &   $��Approves��6   $
��Left=�65   
�������$��295,390,0,0q�6c   $	��Top=�6x   6�   5E      5F      