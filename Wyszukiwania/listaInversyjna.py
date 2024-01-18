import math
import random

class Osoba():

    def __init__(self):
        self.imie = self.random_name()
        self.nazwisko = self.random_subname()
        self.pesel = self.random_pesel()

    def __str__(self):
        return self.imie, self.nazwisko, self.pesel
    
    def getArr(self):
        return [self.imie, self.nazwisko, self.pesel]
    
    def getDict(self):
        return {'imie': self.imie,
                'nazwisko': self.nazwisko,
                'pesel': self.pesel,
               }

    def random_name(self):
        names = ["Jan", "Olaf", "Wieslaw", "Maria", "Janina", "Julia", "Geralt", "Wesemir", "Yennefer", "Kamil", "Donald", "Lech", "Dawid"]
        return random.choice(names)

    def random_subname(self):
        subnames = ["Kowalski", "Kiepski", "Boczek", "Walaszek", "Bomba", "Paleta", "Riv", "Smołka", "Kaczyński", "Trump", "Tusk", "Pasternak", "Szyba", "Buczek"]
        return random.choice(subnames)

    def random_pesel(self):
        pesel = ''.join(str(random.randint(0, 9)) for _ in range(11))
        return pesel

lista = [Osoba() for _ in range(10)]

# def min(a, b):
#     return a if a < b else b


# def search_jump(lista, find):
#     n  = len(lista)
#     block = int(math.sqrt(n))
#     index = 0
    
#     while lista[min(block, n) - 1] < find:
#         index = block
#         block += int(math.sqrt(n))
#         if index >= n:
#             return -1
    
#     while lista[index] < find:
#         index += 1
#         if index == min(block, n):
#             return -1
    
#     if lista[index] == find:
#         return index
    
#     return -1

# x = [3,3,5456,78,90,0,6,4,2,1,4,5,7,9,0,3]
# x.sort()
# print(x)
# print(search_jump(x,len(x),90))

def search_jump(lista, find_pesel):
    n = len(lista)
    block = int(math.sqrt(n))
    index = 0
    
    while lista[min(block, n) - 1].pesel < find_pesel:
        index = block
        block += int(math.sqrt(n))
        if index >= n:
            return -1
    
    while lista[index].pesel < find_pesel:
        index += 1
        if index == min(block, n):
            return -1
    
    if lista[index].pesel == find_pesel:
        return index
    
    return -1

# Test the search_jump function with a list of Osoba objects
lista_osob = [Osoba() for _ in range(10)]
random_pesel_to_find = lista_osob[random.randint(0, 9)].pesel
result_index = search_jump(lista_osob, random_pesel_to_find)

if result_index != -1:
    print(f"Found at index {result_index}: {lista_osob[result_index].getDict()}")
else:
    print("Not found.")