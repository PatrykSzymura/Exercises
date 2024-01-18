import random
class Osoba(object):

    def __init__(self):
        self.imie = self.random_name()
        self.nazwisko = self.random_subname()
        self.pesel = self.random_pesel()

    def __str__(self):
        return self.imie, self.nazwisko, self.pesel
    
    def getDict(self):
        return {'imie': self.imie,
                'nazwisko': self.nazwisko,
                'pesel': self.pesel,
               }

    def getArr(self):
        return [self.imie, self.nazwisko, self.pesel]

    def random_name(self):
        names = ["Jan", "Olaf", "Wieslaw", "Maria", "Janina", "Julia", "Geralt", "Wesemir", "Yennefer", "Kamil", "Donald", "Lech", "Dawid"]
        return random.choice(names)

    def random_subname(self):
        subnames = ["Kowalski", "Kiepski", "Boczek", "Walaszek", "Bomba", "Paleta", "Riv", "Smołka", "Kaczyński", "Trump", "Tusk", "Pasternak", "Szyba", "Buczek"]
        return random.choice(subnames)

    def random_pesel(self):
        pesel = ''.join(str(random.randint(0, 9)) for _ in range(11))
        return pesel
    
 
lista_osob = []
 
lista_osob.append(Osoba('Adam',        'Kozlowski',    '92020110311') )
lista_osob.append(Osoba('Bartosz',     'Romanowski',   '86031211345') )
lista_osob.append(Osoba('Maksymilian', 'Roztocki',     '90051699089') )
lista_osob.append(Osoba('Oskar',       'Nowak',        '94111489654') )
lista_osob.append(Osoba('Adam',        'Nowak',        '67060991234') )
lista_osob.append(Osoba('Maciej',      'Narzondek',    '97071996025') )
lista_osob.append(Osoba('Maciej',      'Kozlowski',    '87091789761') )
lista_osob.append(Osoba('Roman',       'Proton',       '89010323334') )
lista_osob.append(Osoba('Olgiert',     'Romanowski',   '76070998001') )
lista_osob.append(Osoba('Maciejka',    'Kozlowski',    '87091789761') )
 
class Search:
    def __init__(self,data = []):
        self.data = data
        self.search = input("Czego potrzebujesz? ")
        self.arr = self.convert()

    def convert(self):
        result = [int(self.data[_].getArr()[2]) for _ in range(len(self.data))]
        result.sort()
        return result
    
    def line_Search(self, column = 0):
        index = []
        if len(self.data[0].getArr()) > column:
            for i in range(len(self.data)):
                if self.data[i].getArr()[column].lower() == self.search.lower():
                    index.append(i)
            if len(index) == 0:
                self.line_Search(column+1)
            else: return index
        else: return index

    def binary_Search (self):
        target = int(self.search)
        left = 0 
        right = len(self.arr) 
        index = 0 
        
        while left < right: 
            index = (left + right) // 2 
            if self.arr[index]==target: 
                return index 
            else: 
                if self.arr[index]<target: 
                    left = index+1 
                else: 
                    right = index 
                    
        return -1 

