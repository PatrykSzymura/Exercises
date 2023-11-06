import random

def randomName():
    name = [ "Jan", "Olaf", "Wieslaw", "Maria" , "Janina", "Julia","Geralt","Wesemir","Yennefer","Kamil","Donald","Lech","Dawid" ]
    return name[random.randrange(len(name))]

def randomPesel():
    return ''.join(random.choice('0123456789') for _ in range(11))

def randomSubName():
    subName = ["Kowalski" , "Kiepski" , "Boczek" , "Walaszek", "Bomba" , "Paleta","Riv","Smołka","Kaczyński","Trump","Tusk","Pasternak","Szyba","Buczek"]
    return subName[random.randrange(len(subName))]


def randomWorkPosition():
    workPosition = ["Grafik","Programista","Tester","Designer"]
    return workPosition[random.randrange(len(workPosition))]

def inputCheckRange(inputCho = 0,allowed_list = []):
    return inputCho in allowed_list

def menu():
    pass

def initiationArray(array = []):
    maxRange = int(input("Podaj rozmiar listy: "))
    for i in range(maxRange):
        x = random.randrange(maxRange)
        array.append(x)
    return array

