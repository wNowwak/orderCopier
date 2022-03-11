## OrderCopier

Program służy do kopiowania konkretnego zamówienia pomiedzy platformą ecommerce BaseLinker. Aby skorzystać z programu nalezy skonfigurować plik config.xml.
W pliku config.xml znajdują się nastepujące pola:
<fromBL> w tym kluczu umieszcza się token konta BaseLinker, z którego chcemy skopiować zamówienie.
<toBL>  w tym kluczu umieszcza się token konta BaseLinker, do którego chcemy skopiować zamówienie.
<orderID> klucz, którego wartość określa jakie zamówienie zostanie skopiowane do docelowego BaseLinker.
<destinationStatus> status zamówienia, w którym będzie umieszczone zamówienie.
<dataType> opcja do wyboru jaką datę dodania ma mieć zamówienie. Wpisując opcję "original" data dodania zamóweinia będzie datą dodania oryginalnego zamówienia. Inna wartość skutkuje 
dodaniem zamówienia z datą taką jak w momencie uruchomienia.
