   M S B A M L   `   `   `  ����E  ATMS.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TMS.Client.WindowsTMS.Client.Windows  5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   > :TMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0#clr-namespace:TMS.Data;assembly=TMSTMS.Data 5	   	   %    TMS.Client.Windows.ReportWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TMS.Client.Windows     5   	   Oextended:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   4data#clr-namespace:TMS.Data;assembly=TMS     5	   	   -   5        $��MyWindow��5   	     � Title$  Report��5   	   $	��450��6   $	��800��6%    � 	Resources 5         Enum_Activity S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� TypeName �� 
TargetType �� Property �� Value	 �� Triggers
 P� Property P� Value  MyButtonTemplate��%�  &	        '�� r     '��     '�� \    '�� x    S� 5   
   $ 	GetValues��5      "  6$    5      M� 5      $ data:ActivityType��6   5      �� 5   
   " ��6   .�5      ��  � ��$ 15(�6)   �� 5       � ��$ Myanmar Text)�6+   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5!      ��  � �� �#4545486+   5#      �� 5%   
   " ��6   .�5'      ��  � ��$ 
5, 5, 5, 5q�6'   �� 5(       � �� �#3737386+   �� 5)       � ��$ 
5, 5, 5, 5q�6(   �� 5*       � ��$ 0q�60   �� 5+       � ��$ 15(�6)   �� 5,       � ��
 �����6+   �� 5-       � ��$ Myanmar Text)�6+   �� 5.       �@�Cursor$
 Hand��6'   	 50      P� 52      
 �@J�IsMouseOver . . �55      ��  � ��$ 
5, 5, 5, 5q�60   �� 56       � ��$ 0q�68   �� 57       � ��$ 15(�61   �� 58       � ��
 �����63   �� 59       � ��$ Myanmar Text)�63   �� 5:       �@�Cursor$
 Hand��6/   �� 5;       � ��$ 
5, 5, 5, 5q�6/   �� 5=       � �� �#27272763   �� 5>       � ��# �  61   5@      5D      �� 5F   
   " ��6   .�5H      ��  � ��$ 3q�6(   �� 5I       � ��$ 
5, 5, 5, 5q�6'   �� 5J       � ��$ 15(�6)   �� 5K       � ��
 �����6+   �� 5L       � ��$ Myanmar Text)�6+   �� 5M       � �� �#3737386+   �� 5N       � ��$ 0q�60   5P      5T      .��5V      �� .+�5X   
   �� $��Center=�6   ��6-   ��  �� ElementName$ MyWindow�� �� Path$ Header��� 5Z   
   $��Task:��6   �� 5[   
   -   5        $��ComboBox_Tasks��5[       �� DisplayMemberPath$ taskName��5\       �� SelectedValuePath$ Id��60   ��5[   )   �� $ MyWindow��$ Tasks� �� Mode$ OneWay=�{�5]      �� $ MyWindow��$ Active�5^      �� 5`   
   $��	Activity:��6   �� 5a   
   -   5        $��ComboBox_Activity��5a      ��6,   ��  �� Source# [  {�5b      �� $ MyWindow��$ Active�5c      �� 5e   
   $��Begin date:��6   &   Xceed.Wpf.Toolkit.DateTimePicker  5f   
   -   5        $��DateTimePicker_BeginTime��5f   "    � Language$ en-US�6B   {�5g      �� $ MyWindow��$ Active�5i      �� 5k   
   $��	End date:��6     5l   
   -   5        $��DateTimePicker_EndTime��5l   "   $ en-US�6@   {�5m      �� $ MyWindow��$ Active�5o      �� 5q   
   $��Description:��6   �� 5r   
   -   5        $��RichTextBox_Description��5r      $��Bottom=�65   {�5s      �� $ MyWindow��$ Active��� 5u   
   -   5        $��Label_Error_list��5u      �� 5v   
   -   5        $��Submit��5v      6"   5x      5z      