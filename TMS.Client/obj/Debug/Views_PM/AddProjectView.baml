   M S B A M L   `   `   `  ����E  ATMS.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:TMS.Client.Project_Manager.Views TMS.Client.Project_Manager.Views  5      5    /TMS.Client.Project_Manager.Views.AddProjectView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      e aSyncfusion.GridCommon.Wpf, Version=17.1460.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Linq.Base, Version=17.1460.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=17.1460.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_ [Syncfusion.Grid.Wpf, Version=17.1460.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf     5      @local.clr-namespace:TMS.Client.Project_Manager.Views     5      
��� �|�.��5
      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6%    �� Orientation$ Vertical=�62   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��16(�6   $
��Bold"�6*   Project name6J   �� 5      -   5         ��Name$ txtProjectName��5      $��16(�62   $	��150��6@   $
��auto��6L    �� TextWrapping$
 Wrap=�6Z   $��	10 0 0 15q�6n   6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��14(�6   Abbreviation68   �� 5      -   5        $ txtAbbreviation��5      $��16(�63   $	��150��6A   $
��auto��6M   $
 Wrap=�6[   $��	10 0 0 15q�6o   6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��14(�6   Description:68   �� 5      -   5        $ txtDescription��5   (   $��14(�6   $	��150��6A   $
��auto��6M   $
 Wrap=�6[   $��	10 0 0 15q�6o   6�   5       �� 5!      $ 
Horizontal=�6   .+�5"      �� $��14(�6   	Effort:63   &   Syncfusion.Windows.Shared.UpDown  5#      -   5        $��upDownProject��5#   $      MaxValue$ 100000Q�69      MinValue$ 0Q�6L   $	��100��6Y   $��	10 0 0 15q�6e   $��20��6x   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��14(�6   Start:62   (  "System.Windows.Controls.DatePicker  5'      -   5          Name$ 
dtpickFrom��5'      $��25��61   $��	10 0 0 15q�6=   6R   5(      �� 5)      $ 
Horizontal=�6   .+�5*      �� $��14(�6   End:60     5+      -   5        $ dtpickTo��5+      $��25��6/   $��	10 0 0 15q�6;   6P   5,      �� 5-      $ 
Horizontal=�6   $��Center=�62   $��10q�6O   .+�5.      �� -   5         ��Name$ btnAddProject��5.      $��14(�60   $��Add project��6>   $��0 5 10 0q�6T   $��3q�6f   $	��100��6r   6�   �� 5/      -   5        $ btnClear��5/      $��14(�6+   $	��New��69   $��0 5 10 0q�6G   $��3q�6Y   $	��100��6e   6�   50      51      �� 52   
   -	   5        	 ��Name$	 panelAddTask��52      $��
50 0 30 20q�6+   $��1��6?   $��2��6L   $y�Hidden=�6\   $ Vertical=�6p   $
��Left=�6�   .+�53      �� $ 
Horizontal=�6   .+�54      �� $ Vertical=�6   .+�55      �� .��6   Task6"   �� 56      -
   5        $ txtTask��56      $��14(�6/   $	��200��6=   $
��auto��6I   $
 Wrap=�6W   6m   57      �� 58      .+�59      �� $��10 0 0 0q�6   .��6/   Effort67     5:      -   5        $��upDown_task��5:   (   $ 100000Q�6;   $ 0Q�6N   $	��100��6[   $��10 0 0 0q�6h   $��21��6z   5;      5<      �� 5=      -   5        $ 
btnAddTask��5=      
 � ToolTip$
 
Add a task��6)   $��0 10 0 0q�6W   $��Right=�6�   $��Center=�6�   ��6i   Z� ��6�   Z� .��5>      �� $ 
Horizontal=�6   .+�5?      �� $��..\Images\plus.png��6   $��30��68   $��20��6C   6Q   �� 5@      .��6   
Add a task6(   5A      5B      �� 5C      -   5        $	 panelListTasks��5C   2   $ 
Horizontal=�6   $y�Hidden=�6J   .+�5D      �� -   5         ��Name$ listBoxTasks��5D      $��0 10 0 0q�61   $	��290��6C   6�   5H      5I      5J      5K      