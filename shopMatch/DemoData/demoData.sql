Insert into [Winkellijst].[Winkel]
([Winkelnaam], [Straat], [Huisnummer], [Stad])
Values('Delhaize','Logen','6','Geel');
Insert into [Winkellijst].[Afdeling]
([Naam], [Volgorde], [WinkelId])
Values ('Verse Producten',('1'),('1')),('Dranken',('2'),('1')),('Zuivel',('3'),('1')),('Diepvries',('4'),('1'));
Insert into [Winkellijst].[Product]
([Naam], [AfdelingId], [Beschrijving], [Prijs])
Values('Coca-Cola1.5','2','1.5L fles','1.63'),('Fanta','2','2L fles','1.63'),('El gato noir','2','1.5L fles uit het zuiden van Portugal','4.83'),('Limoen','1','Gaat geweldig bij cocktails','1.63'),('Ice-Tea','2','1.5L fles. Koude thee maar dan ook weer niet','1.63')