def piramidka(napis):
    dlugosc = len(napis)
    
    gwiazdki_boki = '*' * (2 * dlugosc - 1)
    
    dolna_czesc = gwiazdki_boki + '*'
    print(dolna_czesc) 

    przedostatni_wiersz = ' *' + ' ' * int(dlugosc - (dlugosc/3)*2) + napis + ' ' * int(dlugosc - (dlugosc/3)*2) + '*'
    print(przedostatni_wiersz)

    for i in range(dlugosc - 3, 0, -1):
        spacje = ' ' * (dlugosc - i - 1)
        gwiazdki = '*' + ' ' * (2 * i - 1) + '*' if i > 0 else '*'
        wiersz = spacje + gwiazdki
        print(wiersz)

tekst = input("Podaj tekst: ")
piramidka(tekst)

