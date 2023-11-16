from module import importFromFile 
from module import menu

class Pole:

    def __init__(self,id,nazwa) :

        self.id = id
        self.nazwa = nazwa

    def __str__(self):
        return " id = {} \n nazwa = {}".format(self.id,self.nazwa)

class PoleKupne(Pole):

    def __init__(self, id, nazwa,cenaKupna):
        self.cenaKupna = cenaKupna
        super().__init__(id, nazwa)

    def __str__(self):
        return super().__str__()+"\n cena kupna = {}".format(self.cenaKupna)
    
class PoleKolej(PoleKupne):

    def __init__(self, id, nazwa, cenaKupna,mnoznik):
        self.mnoznik = mnoznik
        super().__init__(id, nazwa, cenaKupna)

    def __str__(self):
        return super().__str__()+" oplata za postoj = {}".format(str(self.ustalOplate()))
    
    def ustalOplate(self):
        return self.cenaKupna*self.mnoznik
    
for i in range(0,10):
    print(i)