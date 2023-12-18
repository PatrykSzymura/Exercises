import tkinter as tk
from bs4 import BeautifulSoup
import requests

class App:
    def __init__(self, root, url = ""):
        self.znacznik_var = tk.StringVar()

        # Dodaj pole tekstowe
        self.url_entry = tk.Entry(root,width=50)
        self.url_entry.pack()

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
        self.count_button = tk.Button(root, text="Policz słowa", command=self.count_Words)
        self.count_button.pack()

        self.url = self.url_entry.get()
        self.root = root
        self.dictionary = {}
        

    def get_Page_Content(self, url):
        response = requests.get(url)
        response.encoding = "utf-8"
        text = response.text
        return BeautifulSoup(text, 'html.parser')

    def count_Words(self):
        url = self.url_entry.get()
        znacznik = self.znacznik_var.get()
        strona = self.get_Page_Content(url)
        lista = strona.find_all(znacznik)

        for el in lista:
            slowa = el.text.split(" ")
            for slowo in slowa:
                slowo = slowo.strip("#!?.,-=%1234567890()@$^&*[]{}+ «»")
                if slowo == '' or len(slowo) < 4:
                    continue
                if slowo in self.dictionary:
                    self.dictionary[slowo] += 1
                else:
                    self.dictionary[slowo] = 1
        print("Słowa policzone!")
        print(self.dictionary)

url = "https://arc.pans.nysa.pl/~adam.dudek/python/"
root = tk.Tk()
aplikacja = App(root, url)
root.mainloop()
