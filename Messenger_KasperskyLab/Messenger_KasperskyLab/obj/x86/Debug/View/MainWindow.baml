   M S B A M L   `   `   `  ����  Messenger_KasperskyLab'    !Messenger_KasperskyLab.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   1   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6n     � Title$  Messenger 9000��6	   $��5q�6�    � WindowStyle$
 None=�6�   ���	#FF23A23C � WindowStartupLocation$ Manual=�6�   $	��507��6  $	��696��6   ��5      �� 5   
    �� Color$ White��6   .��5      � -   5         J� IsManipulationEnabled .  |�.   � ShowGridLines .  $��0,0,0,22q�5   �    � DataContext 6)   �� ��5	   
   �� 5
      $ White��6    � ColumnDefinitions 5   
   �� 5      $	��71* �6   �� 5      $
��103* �6   .+�5   
   �� -   5         ��Name$ textBoxInput��5   R   $��73��6   $��Stretch=�6   $��0,400,95,-13q�6<   $	��Top=�6h   $��5q�6�   	 �� 
AcceptsTab	 . 
 �� AcceptsReturn
 . 
���  �� �� 	IsEnabled . $��2��6�   �� 5   
   -   5         ��Name$ 
buttonSend��5   @   $��Отправить��6   $
��Left=�6%   $��85��6T   $��Stretch=�6_   $��3q�6{   $��0q�6�   $��311,400,0,-13q�6�   $��35��6�   $	��100��6�    �� 	IsDefault . 
�������
��� � ����	#FFFC0000$��1��68  �� 5   
   -   5        $ textBoxOutput��5   1   $	��350��6   $��0,45,0,0q�6   $	��Top=�6H   $��5q�6`    �� 
IsReadOnly . 
���  �� �� IsUndoEnabled .  $��2��6�   �� 5   
   -   5        $ buttonClose��5   Z   $��Close��6   $��35��6!   $��Right=�6-   $��0,5,5,0q�6I   $	��Top=�6o   $��75��6�   ���	#FF53AD80���	#FFBB0000$��3q�6�    �� 	ClickMode$ Release=�6�   $��0q�6�   $��1��6�   $��16(�6  ��5      �� 5      $ White��6"   5      �� 5   
   -   5         ��Name$ comboBoxUsers��5      $
��Left=�6*   $��5,5,0,0q�6E   $	��Top=�6V   $	��155��6n   $��35��6z   $��16(�6�   �� 5   
   -   5        $ textBoxInfo��5      $
��Left=�6'   $��35��6B   $��0,5,0,0q�6N    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��214��6�    J� 	AllowDrop .  |�.   .  .  $��1��6�   �� 5   
   -   5        $ buttonRefresh��5      $�� ��6(   $
��Left=�63   $��	165,5,0,0q�6N   $	��Top=�6a   $��40��6y   $��35��6�   $��0q�6�   ��6�   Z� ��6�   Z� ��5      �� 5       �� ImageSource$ refresh-128.png��6    j� Stretch$ Uniform=�6;   5      5      5       