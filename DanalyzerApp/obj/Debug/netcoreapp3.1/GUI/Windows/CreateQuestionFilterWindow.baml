   M S B A M L   `   `   `  ����G  CDanalyzerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DanalyzerApp.GUI.WindowsDanalyzerApp.GUI.Windows  5   	   1    +DanalyzerApp.GUI.Windows.CreateFilterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:DanalyzerApp.GUI.Windows     5   	     � Title$  Filter Creation��5   	   $	��244��6!   $	��614��6.   .��5	      � .+�5
   
   �� -   5         ��Name$ createFilterButton��5
      $��Create��6-   $��Right=�6>   $��
0,0,136,10q�6Z   $	��108��6n   $��31��6z   $��Bottom=�6�   6�   �� 5   
   -   5        $ cancelButton��5      $��Cancel��6'   $��	0,0,12,10q�68   $��31��6K   $��Bottom=�6W   $��Right=�6r   $	��108��6�   6�   �� 5   
   -   5         ��Name$ questionInput��5      $
��Left=�6)   $��22��6D   $��	29,36,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��173��6�   �� 5   
   $��	Question:��6   $
��Left=�6$   $��	29,10,0,0q�6?   $	��Top=�6R   �� 5   
   -   5        $ answerInput��5      $
��Left=�6'   $��22��6B   $��	29,84,0,0q�6N   $
 Wrap=�6a   $	��Top=�6u   $	��173��6�   �� 5   
   $��Answers:��6   $
��Left=�6#   $��	29,58,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5         ��Name$ answersBlock��5      $��
85,63,12,0q�6*   $
��None��6>   $
��Wrap=�6J   $��21��6^   $	��Top=�6j   �� 5   
   -   5        $ addAnswerButton��5      $	��Add��6*   $
��Left=�68   $��22��6S   $��
207,84,0,0q�6_   $	��Top=�6s   $��46��6�   6�   �� 5   
   -   5         ��Name$ 	typeInput��5      $
��Left=�6&   $��20��6A   $��
29,132,0,0q�6M   $	��Top=�6a   $	��173��6y   .@�5      �� $��Require��6   �� 5      $��Exclude��6   5      �� 5   
   $��Filter Type:��6   $
��Left=�6'   $��
29,106,0,0q�6B   $	��Top=�6V   5      5      