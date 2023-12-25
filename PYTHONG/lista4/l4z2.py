import tkinter as tk
from bs4 import BeautifulSoup
import requests

class App:
    def __init__(self, url = ""):
        self.url  = url
        self.marker = str(input("Choose h1 h2 p ol:"))
        self.wordLimit = int(input("Min word len: "))
        self.dictionary = {}

        self.count_Words()
        print(self.min_Max())

        cho = input("Search for another element? y/n ").lower()
        if cho =="y":
            tmp = App(self.url) 
            del tmp       

    def get_Page_Content(self, url):
        response = requests.get(url)
        response.encoding = "utf-8"
        text = response.text
        return BeautifulSoup(text, 'html.parser')

    def count_Words(self):
        self.dictionary = {}
        url = self.url
        strona = self.get_Page_Content(url)
        lista = strona.find_all(self.marker)
        print(self.marker)

        for el in lista:
            slowa = el.text.split(" ")
            for slowo in slowa:
                slowo = slowo.strip("#!?.,-=%1234567890()@$^&*[]{}+ «»")
                if slowo == '' or len(slowo) < self.wordLimit:
                    continue
                if slowo in self.dictionary:
                    self.dictionary[slowo] += 1
                else:
                    self.dictionary[slowo] = 1
        print("Words Counted")


        

    def min_Max(self):
        sorted_Dictionary = sorted(self.dictionary.items(),key=lambda x:x[1])
        if len(sorted_Dictionary) == 0:
            return ["Brak elementu","Brak elementu"]
        elif len(sorted_Dictionary) ==1:
            return [f"Most Common {sorted_Dictionary[0][0]} : {sorted_Dictionary[0][1]}", f"Least common {sorted_Dictionary[0][0]} : {sorted_Dictionary[0][1]}"]
        else:
            return [f"Most Common {sorted_Dictionary[-1][0]} : {sorted_Dictionary[-1][1]}", f"Least common {sorted_Dictionary[1][0]} : {sorted_Dictionary[1][1]}"]

#url = "https://arc.pans.nysa.pl/~adam.dudek/python/"

aplikacja = App(url=str(input("Input URL: ")))
