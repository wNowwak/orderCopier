## OrderCopier

Program służy do kopiowania konkretnego zamówienia pomiedzy platformą ecommerce BaseLinker. Aby skorzystać z programu nalezy skonfigurować plik config.xml.
W pliku config.xml znajdują się nastepujące pola:



#1 <fromBL> w tym kluczu umieszcza się token konta BaseLinker, z którego chcemy skopiować zamówienie.

#2 <toBL>  w tym kluczu umieszcza się token konta BaseLinker, do którego chcemy skopiować zamówienie.

#3 <orderID> klucz, którego wartość określa jakie zamówienie zostanie skopiowane do docelowego BaseLinker.

#4 <destinationStatus> status zamówienia, w którym będzie umieszczone zamówienie.

#5 <dataType> opcja do wyboru jaką datę dodania ma mieć zamówienie. Wpisując opcję "original" data dodania zamóweinia będzie datą dodania oryginalnego zamówienia, wartość "specific" spowoduje pobranie daty z pola <specyficData> w formacie yyyy-mm-dd. Inna wartość skutkuje dodaniem zamówienia z datą taką jak w momencie uruchomienia.
