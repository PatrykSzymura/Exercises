import random
from modul1z1 import findPos
from modul2z1 import whichSort
def initiationArray(array = []):
    maxRange = 15
    for i in range(maxRange):
        x = random.randrange(maxRange)
        array.append(x)
    return array




def main():
    a = []
    a = initiationArray()

    print("="*60)
    print("Lista:")
    print(a)
    print("="*60)
    
    temp = findPos(min(a),a)
    print("minimalna:  {} pozycja: {}".format(temp[0],temp[1]))

    temp = findPos(max(a),a)
    print("maksymalna: {} pozycja: {}".format(temp[0],temp[1]))

    print("="*60)

    temp = findPos(int(input("Podaj szukaną wartość: ")),a)
    print("Szukana:    {} pozycja: {}".format(temp[0],temp[1]))

    #dodaj posortowana dla wyboru
    cho  = int(input("Jak ma być posortwana\n1.rosnąco\n2.malejąco\n"))
    print("Lista posortowana:\n{}".format(whichSort(cho,a)))



main()

