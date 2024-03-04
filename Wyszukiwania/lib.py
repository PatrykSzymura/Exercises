from collections import defaultdict

class Osoba(object):
    def __init__(self, i, n, p):
        self.imie = i
        self.nazwisko = n
        self.pesel = p

    def __str__(self):
        return self.imie, self.nazwisko, self.pesel
    
    def getDict(self):
        return {'imie': self.imie,
                'nazwisko': self.nazwisko,
                'pesel': self.pesel,
               }

    def getArr(self):
        return [self.imie, self.nazwisko, self.pesel]

lista_osob = [
    Osoba('Adam', 'Kozlowski', '92020110311'),
    Osoba('Bartosz', 'Romanowski', '86031211345'),
    # ... add the rest of the Osoba objects
]

name_dict = defaultdict(list)
surname_dict = defaultdict(list)
pesel_dict = defaultdict(list)

for index, osoba in enumerate(lista_osob):
    name_dict[osoba.imie].append(index)
    surname_dict[osoba.nazwisko].append(index)
    pesel_dict[osoba.pesel].append(index)

main_dict = {
    'Name': name_dict,
    'Surname': surname_dict,
    'Pesel': pesel_dict,
}

print(main_dict)
