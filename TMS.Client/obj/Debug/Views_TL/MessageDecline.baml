   M S B A M L   `   `   `  ����E  ATMS.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TMS.Client.TeamLead.ViewsTMS.Client.TeamLead.Views  5   	   .    (TMS.Client.TeamLead.Views.MessageDecline   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:TMS.Client.TeamLead.Views     5   	     � Title$  Message��5       � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�67   ��5	      �� 5
   
    �� 
StartPoint$ -1,-1&�6    �� EndPoint$ 1.5,1.5&�61   .��5      �  � Color$	 Red��6    � Offset$	 0.0Q�6'   � 5      $
 Blue��6   $	 1.0Q�6(   5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $
��Auto �6   .+�5   
   �� 
�������Enter a message:69   �� 5   
   -   5        $��
messageBox��5      $��1��6$   $	��250��61    �� TextWrapping$
 Wrap=�6@   "	 �� VerticalScrollBarVisibility$
	 Auto=�6T   6y   � 5   
   $��2��6   $��Right=�6!   $��0,15,0,0q�6=   .+�5      �� -   5        
 ��Name$
 	btnAccept��5       �� 	IsDefault . $��60��6Q   $��0,0,10,0q�6_   .��6q   OK6u   �� 5      -   5        $
 	btnCancel��5       �� IsCancel . $��60��68   .��6F   Cancel6N   5      5      5      