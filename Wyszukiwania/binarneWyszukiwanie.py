class Klasa:
    def __init__(self):
        number_Of_Grades = int(input("Podaj liczbe ocen: "))
        self.sum = 0
        for i in range(number_Of_Grades):
            self.sum += int(input("Podaj ocene: "))
        print(f"Średnia: {self.sum/number_Of_Grades}")

Klasa()