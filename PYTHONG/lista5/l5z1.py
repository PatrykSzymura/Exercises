import tkinter as tk
from bs4 import BeautifulSoup
import requests

class App:
    def __init__(self,root,url):
        self.url = url
        self.root = root
        self.dictionary = {}

    def get_Page_Content(url):
        response = requests.get(url)
        response.encoding = "utf-8"
        text = response.text
        
        return BeautifulSoup(text, 'html.parser')

    def count_Words(self, url, znacznik,):
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

    def search_In_Links(self, url ,znacznik, dict = {}):
        html = self.get_Page_Content(url)
        links = html.find_all('a')
        for link in links:
            href:str = link.attrs['href']
            if href.find("http") != -1:
                pass
            elif len(href) > 1 and href[0] == '/':
                href = url+href
            elif len(href) > 1 and href[0] != '/':
                href = url+'/'+href
        self.count_Words(href, znacznik, dict)
        print(f"Słowa w podlinku {href} policzone!")

url = "https://arc.pans.nysa.pl/~adam.dudek/python/"

root = tk.Tk()
aplikacja = App(root,url)
