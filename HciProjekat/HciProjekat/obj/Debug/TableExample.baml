   M S B A M L   `   `   `  ����F  BHciProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HciProjekatHciProjekat  5   	   #    PrimerCas4.Table.TableExample   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1HciProjekatclr-namespace:HciProjekat     5   	     � Icon$  Mapa_sveta.jpg��5   	    � Title$ Prikaz spomenika��5   	   $��414.692��6"   $	��750��63    � 
ResizeMode$ NoResize=�6?   
�������.��5      �  J� RenderTransformOrigin$ 0.497,0.343&�6   $��0,0,0,-1q�6/    � RowDefinitions 5	   
   �� 5
      �� 5      $��0* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrMain��5         AutoGenerateColumns .     
IsReadOnly . $��0,0,169,131q�6z   ��6$   �� 	 �� Path$	 	Spomenici�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Oznaka��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Oznaka+  5      $ * 6%   $	 Ime��6/    6<   �� *Ime+  5      $ * 6%   $	 Tip��6/    6<   �� *Tip+  5      $ * 6%   $
 Opis��6/    6=   �� *Opis+  5      $ * 6%   $	 Era��6/    6<   �� *Era+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Ikonica��6)   $	 100 6:      
IsReadOnly .    CellTemplate 5      �� 5      .R�5      �� ��6$   �� *	Ikonica+5      5      5$      �� 5,   
   -   5        $��Izmeni spomenik��5,      $
��Left=�6+   $��47��6F   $��218,279,0,0q�6R   $	��Top=�6g   $	��138��6   $ 1.378,1.686&�6�   �� 5-   
   -   5        $��Izbrisi spomenik��5-      $
��Left=�6,   $��47��6G   $��387,279,0,0q�6S   $	��Top=�6h   $	��138��6�   $ 1.378,1.686&�6�   �� 5.   
   $��20(�6   $��Black"�6"   $
��Left=�65   $��30��6P   $��
575,10,0,0q�6\   $
��Wrap=�6p   $��Filtriranje:��6�   $	��Top=�6�   $	��132��6�   �� 5/   
   -   5        $��	tipSelect��5/      $
��Left=�6$   $��23��6?   $��
592,70,0,0q�6K   $	��Top=�6_   $	��132��6w   6�   �� 50   
   $
��Left=�6   $��20��6/   $��
595,45,0,0q�6;   $
��Wrap=�6O   $	��Tip��6c   $	��Top=�6n   $��62��6�   �� 51   
   $
��Left=�6   $��24��6/   $��596,121,0,0q�6;   $
��Wrap=�6P   $	��Ime��6d   $	��Top=�6o   $��82��6�   �� 52   
   -   5        $��txtIme��52   j   $
��Left=�6   $��27��6-   $��592,145,0,0q�69    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6x   $	��132��6�   6�   �� 53   
   -   5        $��Ponisti��53      $
��Left=�6$   $��36��6?   $��619,311,0,0q�6K   $	��Top=�6`   $	��105��6x   $ 0.385,-1.27&�6�   6�   �� 55   
   $��20(�6   $��Black"�6"   $
��Left=�65   $��30��6P   $��575,188,0,0q�6\   $
��Wrap=�6q   $��	Pretraga:��6�   $	��Top=�6�   $	��103��6�   �� 57   
   -   5        $��statusPrikazSpomenika��57      $��20(�62   $
��Bold"�6@   
��� � �$
��Left=�6e   $��43��6�   $��
21,334,0,0q�6�   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��523��6�   �� 58   
   -   5        $��Pretraga��58      $
��Left=�6$   $��35��6?   $��595,241,0,0q�6K   $	��Top=�6`   $	��105��6x   6�   5A      5C      