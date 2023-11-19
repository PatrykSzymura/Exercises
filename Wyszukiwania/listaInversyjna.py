class kartoteka:
    def __init__(self,name,keyword,container):
        self.name       = name      #nazwa kolumny
        self.keyword    = keyword   #wartosc kolumny
        self.container  = container #lista z id elementow
    def __str__(self):
        string  = "Nazwa kartoteki: {}\n Slowo Kluczowe: {}\n Zawartosc : {}".format(self.name,self.keyword,self.container)
        return string

def importFromFile(dir):
    file = open(dir,"r", encoding="utf-8")
    list = file.read().splitlines()
    file.close()
    return list

def createKartoteka(fileName):
    
    print(list)
def listaInv():
    pass
def searchInv(*keywords):
    pass
def displayListInv(list):
    pass

createKartoteka("wynikowe.csv")