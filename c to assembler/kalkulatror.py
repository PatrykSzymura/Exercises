def main():
    var1 = int(input("Number 1: "))
    var2 = int(input("Number 2: "))
    var3 = str(input("Action  : "))

    if   var3 == "+":
        resoult = var1 + var2
    elif var3 == "-":
        resoult = var1 - var2
    else:
        print("Invalid Input")
    print(f"Resoult : {var1} {var3} {var2} = {resoult}")

main()