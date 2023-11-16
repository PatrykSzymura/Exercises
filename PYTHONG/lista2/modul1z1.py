def findPos(value,list):
    pos = 0
    if value in list:
        pos = list.index(value)       
    else:
        pos = "Brak w zbiorze"
    ret = [value , pos]
    return ret