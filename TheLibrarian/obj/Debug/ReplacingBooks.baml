   M S B A M L   `   `   `  ����G  CTheLibrarian, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TheLibrarianTheLibrarian  5   	   !    TheLibrarian.ReplacingBooks   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TheLibrarian     5   	     � Title$  ReplacingBooks��5   	    � WindowState$ 	Maximized=�6     � WindowStyle$
 None=�68   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      $	��250 �6    � ColumnDefinitions 5   
   �� 5      �� 5      ��5   
   �� 5       �� ImageSource$ \Images\libbg.png��6   .+�5   
   � -   5         �Name$ Instructions��5      $y�Hidden=�6%   $��2��69   $��2��6J   $��Center=�6^   
���   � J� Opacity$	 0.7Q�6�   $	��750��6�   $	��650��6�    K� ZIndex$ 1��6�   .+�5      �� $��Instructions��6   
�������$��Center=�6>   $	��Top=�6[   $��40��6s   �� 5      	 �� Orientation$	 Vertical=�6   $	��700��60   .+�5      �� $
��Wrap=�6   $����We desperately need your help!!                            All of our books here are sorted using the Dewey Decimal system, and right now, our librarian has her hands full!                            Can you help us sort the books on this bookshelf??��60   
�������
���   �$��24(�5    C   $��0,20,0,0q�6Q   $	��Top=�6c   $��Consolas)�6{   $	��200��6�   $	��600��6�   �� 5"      $
��Wrap=�6   $����On the top left of the screen you will see your number of attempts left, you only get 10! You will also see a timer that counts down from 30 to 0.                             Click on the start button, enter your username and once you click ok the game will begin! Sort the books in ascending order from left to right.��60   
�������
���   �$��24(�5$   C   $��0,10,0,0q�6Q   $��Bottom=�6c   $��Consolas)�6~   $	��250��6�   $	��600��6�   �� 5&      $
��Wrap=�6   $����The quicker you finish, and the less moves you make, the higher your score! But be sure to order the books correctly, or you won't get a score at all!!                            Play against some friends and check the scoreboard to find out who is the ultimate librarian!��60   
�������
���   �$��24(�5(   C   $��0,10,0,0q�6Q   $��Bottom=�6c   $��Consolas)�6~   $	��250��6�   $	��600��6�   5)      �� 5*      -   5        
 ��Name$
 CloseInstructions��5*      $��Close��60   $
��Left=�6A   $��Bottom=�6\   $��
10,572,0,0q�6w   6�   5+      �� 5.   
   -   5         ��Name$ 	BookShelf��5.      $	��Top=�5/   
   $��0��6"   $	��100��6/   $	��600��6E   $	��900��6R   $��Right=�6^   $��0,0,0,0q�50   
   
������ 
���E��$��10q�6N   ��51      �� 52      .R�53      �� $	 
Horizontal=�6!   55      ��57      �� 58      .R�5:      �� 
���E��$��3q�67   $	��570��6K    �� CornerRadius$ 3��6X   ���#8B4513._�5;      �� ��5<      �� 5=   "    �� 
TargetType" ��6(   .�5>   &   ��  �� Property �@�LayoutTransform �� Value 5?   *   �� 5@   .    �� Angle$ 90Q�6>   5B   '   �� 5C   &    � ��$ Center=�6J   �� 5D   &    � ��$ Center=�6L   5E   #   �� 5G      $	 Vertical=�6)   .+�5H      ��  �� TextAlignment$ Center=�61   $��30(�6H   $��Black"�6V    �� Padding$ 15q�6i   ��6    �� 6i   5I      5J      5K      5L      ��5N      �� 5O      " ��6   .�5P      -   5        �� 5T       �@J�	AllowDrop . 62   5U      5W      �� 5Z   
   -   5         ��Name$ stkPlayButtons��5Z      $	 
Horizontal=�6-   $��1��6F   $��1��6S   .+�5[      �� -   5        $
 btnStart��5[      $��Start��6'   $
��Left=�67   $	��Top=�6R   $��
50,10,50,0q�6j   6~   �� 5\      -   5        $
 btnClear��5\      $��Clear��6'   $	��Top=�67   $��
50,10,50,0q�6O   6c   �� 5]      -   5        $
 btnCheck��5]      $��Check��6'   $��Right=�67   $	��Top=�6S   $��
50,10,50,0q�6k   6   5^      �� 5a   
   -	   5        $ stkMenuButtons��5a      $
��Left=�6-   $��Bottom=�6H   $	 
Horizontal=�6c   $��0��6|   $��1��6�   .+�5b      �� -
   5        $
 btnMenu��5b      $��1��6&   $��0��63   $��	Main Menu��6C   $��10,0,0,0q�6o   �� 5c      -   5        $
 btnScoreBoard��5c      $��1��6,   $��0��69   $��View Scoreboard��6I   $��20,0,0,0q�6d   6v   �� 5d      -   5        $
 btnInstructions��5d      $��Instructions��6.   $
��Left=�6E   $��Bottom=�6`   $��20,0,0,0q�6{   6�   5e      �� 5h   
   .+�5i      �� $��Number of Attempts Left:��6   $��0��67   $��0��6D   $
��Left=�6T   $	��Top=�6o   
�������$��30(�6�   �� 5j      $��0��6.   $��0��6;   $��Black"�6K   $
��Left=�6_   $	��Top=�6z   
�������$��30(�6�   ��6   �� *Count+6�   �� 5k      -   5         ��Name$ timeRemaining��5k      $��0��6+   $��0��68   $��50��6H   $��Time Remaining:��6T   
�������$
��Left=�6�   $��SemiBold"�6�   $��30(�6�   $	��Top=�6�   �� 5l      -   5        $ 	countDown��5l      $��0��6'   $��0��64   $	��100��6D   $��30��6Q   $
��Left=�6^   
�������$��SemiBold"�6�   $��30(�6�   $	��Top=�6�   5m      � 5p   
   -   5        $ UserScoreBoard��5p      $y�Hidden=�6'   $��2��6;   $��2��6L   $��Center=�6`   
���   �$	 0.7Q�6�   $	��500��6�   $	��450��6�   .+�5q      �� $��User Score Board��6   
�������$��Center=�6B   $	��Top=�6_   $��40��6w   �� 5r      -   5        $��UserScoresListBox��5r   "   $��20q�6   
���   �$	��420��6N   ��5s      �� 5t      .R�5u      �� $	 
Horizontal=�6%   .+�5v      �� 
�������
���   �$��28(�6_   $��Consolas)�6m   ��6(   �� 6m   5w      5x      5z      �� 5{      -   5        $
 btnCloseScoreboard��5{      $��Close��61   $
��Left=�6B   $��Bottom=�6]   $��	10,0,20,0q�6x   6�   5|      � 5   
   -   5         �Name$ UsernamePopup��5      ��.  $��Center=�66   .��5�      �� 
���   �$��1q�6)   
���   �$	 0.7Q�6P   ._�5�      �� $��10q�6   .+�5�      �� $��Enter Username: ��6    
�������$��24(�6K   $��Consolas)�6Y   $��SemiBold"�6o   �� 5�      -   5         ��Name$ 
tbUsername��5�      �� 5�      -   5        $��OK��5�      6*   �� 5�      -   5        $��Cancel��5�      6.   5�      5�      5�      5�      5�      