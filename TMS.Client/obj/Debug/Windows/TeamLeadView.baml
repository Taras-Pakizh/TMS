   M S B A M L   `   `   `  ����E  ATMS.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TMS.Client.TeamLeadTMS.Client.TeamLead  5   	   O,clr-namespace:TMS.Client.TeamLead.ViewModelsTMS.Client.TeamLead.ViewModels  5   
   E'clr-namespace:TMS.Client.TeamLead.ViewsTMS.Client.TeamLead.Views  5   	   &     TMS.Client.TeamLead.TeamLeadView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TMS.Client.TeamLead     5   	   C
viewmodels,clr-namespace:TMS.Client.TeamLead.ViewModels     5   
   9views'clr-namespace:TMS.Client.TeamLead.Views     5   	   -   5          � Title$  	Team Lead��5
      $	��450��6   $	��900��6'    � WindowStartupLocation$ CenterScreen=�63    � 	Resources 5       �� DataType6   0TMS.Client.TeamLead.ViewModels.ProjectsViewModel,   &TMS.Client.TeamLead.Views.ProjectsView � DataContext7   1TMS.Client.TeamLead.ViewModels.EmployeesViewModel-   'TMS.Client.TeamLead.Views.EmployeesView9   3TMS.Client.TeamLead.ViewModels.ProfilePageViewModel/   )TMS.Client.TeamLead.Views.ProfilePageView��%8  (��       5   +   *, +)(�� O     5   ,   *, +)(�� �     5   *   *, +)�� 5   
   
projectsVM��"  6+   .R�5         6!   �� 5      �� 5   
   employeesVM��"  6,   .R�5         6"   �� 5      �� 5   
   	profileVM��"  6*   .R�5         6$   �� 5      5      ��5      �� 5   
    �� 
StartPoint$ -1,-1&�6    �� EndPoint$ 1.5,1.5&�61   .��5      �  � Color$	 Red��6    � Offset$	 0.0Q�6'   � 5      $
 Blue��6   $	 1.0Q�6(   5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $	��420 �6   �� 5      $��* �6   
 � ColumnDefinitions
 5!   
   �� 5"      $��80 �6   �� 5#      $��* �6   .+�5%   
   �� $��0��6   $��0��6%   $��80��62   $��0 0 0 0q�6=   ���	#FFEAE8E8.+�5&      �� -   5         ��Name$ LoadProjectsPage��5&       � ToolTip$ View Reports��6/   $��10 110 10 10q�6G   .��5'      �� $��../Images/reports.png��6   $��50��67   $��50��6B   6P   5(      �� 5)      -   5        $ LoadEmployeesPage��5)   .   $ View Employees��6   $��10q�6I   .��5*      �� $��../Images/emloyees.png��6   $��50��68   $��50��6C   6Q   5+      �� 5,      -   5        $ LoadProfilePage��5,   ,   $ View Profile��6   $��10q�6E   .��5-      �� $��../Images/profile.png��6   $��50��67   $��50��6B   6P   5.      5/      �� 50   
   $��0��6   $��1��6&   $��2��66   ��51      �� �� 52   
   -   5         ��Name$ default_image��52      $��../Images/Default.png��6'   $��0��6F   $��1��6S   6f   53      54      