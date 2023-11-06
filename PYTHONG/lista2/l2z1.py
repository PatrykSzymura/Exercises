import random

def initiationArray(array = []):
    maxRange = 15
    for i in range(maxRange):
        x = random.randrange(maxRange)
        array.append(x)
    return array

def findPos(value,list):
    pos = 0
    if value in list:
        pos = list.index(value)       
    else:
        pos = "Brak w zbiorze"
    ret = [value , pos]
    return ret

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



main()

