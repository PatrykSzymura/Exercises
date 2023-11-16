import random

def generuj_pesel():
    return ''.join(random.choice('0123456789') for i in range(11))

def importFromFile(dir):
    file = open(dir,"r", encoding="utf-8")
    list = file.read().splitlines()
    file.close()
    return list

def createSeed(limit):
    x = []
    for i in range(5):
        x.append(random.randrange(limit))
    return x

def saveToFile(dir,content):
    file = open(dir,"a",encoding="utf-8")
    file.write(content)
    file.close

def genderCheck(str):
    if str[-1] == 'a' or str[-1] == 'y' or str[-1] =='e':
        return 'f'
    else:
        return 'm'
    
def ageCheck(str):
    return str[2:4]



def main():

    imiona      = importFromFile("daneImiona.txt")
    nazwiska    = importFromFile("dane-nazwiska")
    miasta      = importFromFile("dane-miasta")
    panstwa     = importFromFile("dane-panstwa")
    ulice       = importFromFile("dane-ulice")
    table = []
    row   = []

    cho = int(input("Podaj Ilość danych do pliku: "))
    seed = []

    for i in range(cho):
        seed = createSeed(20)
        line = []
        pesel = str(generuj_pesel())

        line = imiona[seed[0]] +";"+ nazwiska[seed[1]] +";"+ pesel +";"+ ulice[seed[2]] +";"+ str(random.randrange(50)) +";"+ miasta[seed[3]] +";"+ panstwa[seed[4]] +"\n"
        row = [imiona[seed[0]], nazwiska[seed[1]], pesel, ulice[seed[2]],str(random.randrange(50)),miasta[seed[3]], panstwa[seed[4]]]
        
        table.append(row)
        saveToFile("wynikowe.csv",line)
    inpt = int(input("starszy niż: "))
    for i in range(cho):
        if inpt<=int(ageCheck(table[i][2])):
            if genderCheck(table[i][0])=='f':
                pron = 'Pani '
            else:
                pron = 'Pan '
            print(pron+table[i][0]+" "+table[i][1])
    

        

main()
#sprwadz wiek na podstawie 4 liczb peselu i spawdzenie płci

