   M S B A M L   `   `   `  ����Q  MMessenger_KasperskyLab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Messenger_KasperskyLabMessenger_KasperskyLab  5   	   $    Messenger_KasperskyLab.Connect   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Messenger_KasperskyLab     5   	     � Title$  Connect��5   	   $	��300��6   $	��300��6&    � 
ResizeMode$ CanMinimize=�62    � WindowStartupLocation$ CenterScreen=�6K    � WindowStyle$
 None=�6p   .��5	      � -   5        $��0,0,2,0q�5	      .+�5
   
   �� -   5         ��Name$ 
textBoxURL��5
      $
��Left=�6&   $��28��6A   $��	53,10,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��174��6�   4  .System.Windows.Automation.AutomationProperties   HelpText$! Input URL (ex. "127.0.0.1")��6�    �� MaxLines$ 1��6�    �� 	MaxLength$	 255��6�   $��Center=�6�   $��1��6  $��	127.0.0.1��6*  �� 5   
   -   5        $ textBoxLogin��5      $
��Left=�6(   $��28��6C   $��
102,65,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��180��6�   $ 1��6�   $ 30��6�   $��Center=�6�   $��3��6�   $	��i@i��6�   �� 5   
   -   5        $ textBoxPort��5      $
��Left=�6'   $��28��6B   $��
232,10,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $��50��6�   $ 4��6�   $ 1��6�   $��Center=�6�   $��2��6�   $
��5222��6�   �� 5   
   -   5        	 ��Name$	 lableURL��5      $	��URL��6"   $
��Left=�60   $��	10,12,0,0q�6K   $	��Top=�6^   �� 5   
   -   5        $	 label��5      $��Login@Domain��6   $
��Left=�66   $��	10,65,0,0q�6Q   $	��Top=�6d   $��28��6|   �� 5   
   -   5        $	 
label_Copy��5      $��Password��6$   $
��Left=�67   $��
10,115,0,0q�6R   $	��Top=�6f   $��28��6~   �� 5   
   -   5        
 ��Name$
 checkBoxSecConnect��5      $��Secure Connection��6/   $
��Left=�6K   $��102,155,0,0q�6f   $	��Top=�6{   $��5��6�   �� 5   
   -	   5        $
	 info��5      $��Label��6   $
��Left=�6.   $	��Top=�6I   $	��298��6a   $��Center=�6m   ���	#7F000000$��Bottom=�6�   $	��110��6�   $��	0,180,0,0q�6�   G� 5   
   -
   5         G�Name$ passwordBox��5      $
��Left=�6+   $��102,115,0,0q�6F   $	��Top=�6[   $	��180��6s   $��28��6   $��Center=�6�   $��4��6�    G� Password$	 123��6�   �� 5   
   -   5         ��Name$ button��5      $��Connect��6!   $
��Left=�63   $��226,148,0,0q�6N   $	��Top=�6c   $��56��6{   $��27��6�    �� 	IsDefault . $��6��6�   5      5      