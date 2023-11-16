def importFromFile(dir):
    file = open(dir,"r", encoding="utf-8")
    list = file.read().splitlines()
    file.close()
    return list

def menu():
    print("#"*10)
    