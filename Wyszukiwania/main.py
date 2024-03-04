from collections import defaultdict
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
    
 
lista_osob = [int(Osoba().random_pesel()) for _ in range(10)]
lista_osob_Sorted = lista_osob.sort()

 
class Search:
    def __init__( self, data = [] ):
        self.data = data
        self.search = input("Czego potrzebujesz? ")
    
    def line_Search( self, column = 0 ):
        index = []
        for i in range(len(self.data)):
            if self.data[i] == self.search:
                index.append(i)
        else: return index

    def binary_Search( self ):
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

print(f'Nie Posortowana: {lista_osob}')
print(f'Posortowana:     {lista_osob_Sorted}')


