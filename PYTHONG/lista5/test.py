import tkinter as tk
from bs4 import BeautifulSoup
import requests

class App:
    def __init__(self, root, url = ""):
        self.znacznik_var = tk.StringVar()
        self.dictionary = {}
        self.word_Len = 0

        # Dodaj pole tekstowe
        self.url_entry = tk.Entry(root,width=50)
        self.url_entry.pack()

        self.slider = tk.Scale(root,from_=4,to=20,orient="horizontal" ,command = self.set_Word_Len)
        self.slider.pack()


        # Dodaj przyciski radiowe
        self.h1_button = tk.Radiobutton(root, text="h1", variable=self.znacznik_var, value="h1")
        self.h1_button.pack()
        self.h2_button = tk.Radiobutton(root, text="h2", variable=self.znacznik_var, value="h2")
        self.h2_button.pack()
        self.p_button = tk.Radiobutton(root, text="p", variable=self.znacznik_var, value="p")
        self.p_button.pack()
        self.ol_button = tk.Radiobutton(root, text="ol", variable=self.znacznik_var, value="ol")
        self.ol_button.pack()


        # Dodaj przycisk do uruchomienia funkcji count_Words
        self.count_button = tk.Button(root, text="Count Words", command=self.count_Words)
        self.count_button.pack()
        self.ress = tk.Label(root,text='')
        self.ress.pack()

        self.url = self.url_entry.get()
        self.root = root
        
    def set_Word_Len(self,value):
        self.word_Len = value
        return value

    def get_Page_Content(self, url):
        response = requests.get(url)
        response.encoding = "utf-8"
        text = response.text
        return BeautifulSoup(text, 'html.parser')

    def count_Words(self):
        self.dictionary = {}
        url = self.url_entry.get()
        znacznik = self.znacznik_var.get()
        strona = self.get_Page_Content(url)
        lista = strona.find_all(znacznik)

        for el in lista:
            slowa = el.text.split(" ")
            for slowo in slowa:
                slowo = slowo.strip("#!?.,-=%1234567890()@$^&*[]{}+ «»")
                if slowo == '' or len(slowo) < int(self.word_Len):
                    continue
                if slowo in self.dictionary:
                    self.dictionary[slowo] += 1
                else:
                    self.dictionary[slowo] = 1
        print("Słowa policzone!")
        print(self.dictionary)
        x = self.ress
        x.config(text=f"{self.min_Max()[0]}\n{self.min_Max()[1]}")

        

    def min_Max(self):
        sorted_Dictionary = sorted(self.dictionary.items(),key=lambda x:x[1])
        if len(sorted_Dictionary) == 0:
            return ["Brak elementu","Brak elementu"]
        elif len(sorted_Dictionary) ==1:
            return [f"Most Common {sorted_Dictionary[0][0]} : {sorted_Dictionary[0][1]}", f"Least common {sorted_Dictionary[0][0]} : {sorted_Dictionary[0][1]}"]
        else:
            return [f"Most Common {sorted_Dictionary[-1][0]} : {sorted_Dictionary[-1][1]}", f"Least common {sorted_Dictionary[1][0]} : {sorted_Dictionary[1][1]}"]

#url = "https://arc.pans.nysa.pl/~adam.dudek/python/"
root = tk.Tk()
aplikacja = App(root)
root.mainloop()
