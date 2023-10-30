import math

def kula():
    print("podaj dane: ")
    r = int(input("r: "))
    pi = math.pi
    
    obj = 4 * pi * (r*r)
    pole  = 4/3 * pi * (r*r*r)

    print("Pole :{} Objetosc: {}",pole,obj)

def prostopadloscian():
    print("podaj dane: ")
    a = int(input("a: "))
    b = int(input("b: "))
    c = int(input("c: "))

    obj = a*b*c
    pole = 2*(a*b) + 2*(a*c) + 2*(b*c)

    print("Pole :{} Objetosc: {}", pole,obj)

def stozek():
    print("podaj dane: ")
    r = int(input("r: "))
    h = int(input("h: "))

    pole = math.pi*r*r
    obj  = (pole*h)/3

    print("Pole :{} Objetosc: {}",pole,obj)

def scienty():
    print("podaj dane: ")
    r = int(input("r: "))
    h = int(input("h: "))
    R = int(input("R: "))

    l = math.sqrt(h*h+math.pow(R-r,2))
    pole = math.pi*(R+r)*l + math.pi*(R*R+r*r)
    obj  = (math.pi/3)*h*(R*R+R*r+r*r)

    print("Pole :{} Objetosc: {}",pole,obj)


def zad1():
    print("Podaj nr bryly \n 1.kula \n 2.prostopadloscian \n 3.stozek \n 4.stozek sciety")
    cho = input("wybor: ")
    print(cho)
    if   cho == '1':
        kula()
        return
    elif cho == '2':
        prostopadloscian()
        return
    elif cho == '3':
        stozek()
        return
    elif cho == '4':
        scienty()
        return
    else :
        print("zly numer")
        zad1()

def zad2():
    ile = int(input("ilosc ocen: "))
    wynik = 0

    for x in range(0,ile):
        ocena = int(input("ocena: "))
        if (ocena > 0 and ocena < 7):
            wynik += ocena
        else:
            print("ocena spoza zakresu 1-6")
            x-1
    srednia = wynik/ile 
    print("srednia wynosi ",srednia)

def zad3():
    inp  = input("podaj tekst: ")
    var = len(inp)+2
    

    for rows in range(1, var-1):
    
        for columns in range(0, var-rows):
            print(" ",end="")
    
        for columns in range(0, rows):
            if columns == 0 : 
                print("*", end="")
            else:
                print(" ",end="")

        for columns in range(1, rows):
            if columns == rows-1 : 
                print("*", end="")
            else:
                print(" ",end="")
        print()
    if len(inp) % 2 == 0:
        print(" *",inp," *")
    else:
        print(" *",inp,"*")
    for i in range(0, len(inp)*2+3):
        print("*",end="")    

def zad4():
    x = "Ala ma kota, a kot ma Alę"
    dl = len(x)
    print("Dlugosc zdania: ",dl)
    y = str(input("Podaj znak: "))
    print(x.split(y))
    
def menu():
    print("Menu")
    print("1.Zad 1")
    print("2.Zad 2")
    print("3.Zad 3")
    print("4.EXIT")
    cho = int(input("wybor: "))

    if cho == 1:
        zad1()
        menu()
    elif cho == 2:
        zad2()
        menu()
    elif cho == 3:
        zad3()
        menu()
    elif cho == 4:
        zad4()
        menu()
    else:
        exit
menu()




