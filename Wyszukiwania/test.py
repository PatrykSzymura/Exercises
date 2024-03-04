from collections import defaultdict
import random
import math
import time


#<=================================Funkcja-pomocnicza=================================>
def random_pesel(lenght = 11):
    pesel = random.randint(0, lenght) 
    return pesel

#<============================Główna-klasa-z-Wyszukiwaniami===========================>
class Search:
    def __init__(self,data = []):
        self.data = data
        self.search = int(input("Czego potrzebujesz? "))
     
#<================================Wyszukiwanie-Liniowe================================>
#< Funkcja przyjmuje jako argument obiekt oraz tablicę. Pętla for wyszukuje w tablicy >
#< wartości szukanej, następnie jeśli ją znajdzie to przypisuje jej index do tablicy  >
#< 'index' następnie po zakończeniu petli for zwracana jest tablica z indexami.       >
#<====================================================================================>
    def line_Search(self, arr):
        index = []
        for i in range(len(arr)):
            if arr[i] == self.search:
                index.append(i)
        return index

#<================================Wyszukiwanie-Binarne================================>
#< Funkcja przyjmuje jako argument obiekt oraz tablicę która jest POSORTOWANA         >
#< Wyszukiwanie dzieli tablicę na pół i spardza czy element może się znaleść w lewej  >
#< lub prawej części tablicy i tak aż zostanie znaleziony szukany elemnent lub nie    >
#< będzie możliwe dzielenie tablicy na pół.                                           >
#<====================================================================================>  
    def binary_Search (self, arr):
        target = int(self.search)
        left = 0 
        right = len(arr) 
        index = 0 
        
        while left < right: 
            index = (left + right) // 2 
            if arr[index]==target: 
                return index 
            else: 
                if arr[index]<target: 
                    left = index+1 
                else: 
                    right = index 
                    
        return -1 
    
#<================================Wyszukiwanie-Skokowe================================>
#< Funkcja przyjmuje jako argument obiekt oraz tablicę która jest POSORTOWANA         >
#< Wyszukiwanie skokowe wyznacza sobie rozmiar skoku w tym przypadku pierwiastek      >
#< rozmiaru tablicy ( block ). Następnie sprawdza segmenty o rozmiarze block i jeśli  >
#< algorytm znajdzie segment w którym może się znaleść szukana wartość, wtedy         >
#< funkcja przesukuje segment liniowo i zwraca index pierwszego napotkanego elementu  >
#<====================================================================================>
    def jump_Search(self, arr):
        n = len(arr)
        block = int(math.sqrt(n))
        index = 0
        
        while arr[min(block, n) - 1] < self.search:
            index = block
            block += int(math.sqrt(n))
            if index >= n:
                return -1
        
        while arr[index] < self.search:
            index += 1
            if index == min(block, n):
                return -1
        
        if arr[index] == self.search:
            return index
        
        return -1
    
#<=================================Tworzenie-Kartoteki================================>
#< Funkcja przujmuje jako argument obiekt oraz tablicę. Petla for przebiega po        >
#< liście w obiekcie enumerate i przypisuje do słownika typu defaultdict(list)        >
#< wartości key oraz value do słownika gdzie key to klucz, value to index wartości    >
#<====================================================================================>  
    def create_File(self, arr):
        self.file = defaultdict(list)

        for index, value in enumerate(arr):
            self.file[value].append(index)

        return self.file

#<===============================Wyświetlanie-Kartoteki===============================>
#< Funckja wyswietla klucz kartoteki oraz tablicę przechowywującą indexy z pozycjami  >
#< klucza w tablicy                                                                   >
#<====================================================================================>  
    def display_File(self):
        print("Value       | Position")
        for key,values in self.file.items():
            print(f'{key} | {values}')

#<============================Wyszukiwanie-List-Prostych==============================>
#< Funkcja przujmuje jako argument obiekt w którym znajduje się kartoteka jako klucz  >
#< podajemy wyszukiwaną wartość , funkcja zwraca wartość słownika wtym przypaku listę >
#<====================================================================================>  
    def file_Search(self):
        return self.file[self.search]
    


#<================================Inicjalizacja-Listy=================================>
Array = [random_pesel(1000) for _ in range(int(input("podaj zakres: "))) ]

#<===========================Wyłowyanie-obiektu-i-funkcji=============================>
x = Search()

start0 = time.time()
(x.line_Search(Array))
end0 = time.time()
print(f' liniowe {end0 - start0}')

Array2 = Array
Array2.sort()

start1 = time.time()
x.binary_Search(Array2)
end1 = time.time()
print(f' binarne {end1 - start1}')

start2 = time.time()
x.jump_Search(Array2)
end2 = time.time()
print(f' skokowe {end2 - start2}')

start3 = time.time()
x.create_File(Array)
x.file_Search()
end3 = time.time()
print(f' inwersyjne + tworzenie kartoteki {end3 - start3}')

start4 = time.time()
x.file_Search()
end4 = time.time()
print(f' inwersyjne bez tworzenia kolejki {end4 - start4}')


