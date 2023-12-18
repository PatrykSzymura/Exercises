import requests
from bs4 import BeautifulSoup

def get_Web(url, tag):
    try:
        website = requests.get(url)
        website.encoding ='utf-8'
        parsed_Website = BeautifulSoup(website.text,'html.parser')
        
        if tag == "<h1>":
            print(parsed_Website.h1)
        elif tag == "<h2>":
            print(parsed_Website.h2)
        elif tag == "<p>":
            print(parsed_Website.p)
        elif tag == "ol":
            print(parsed_Website.ol)
        else:
            return None


    except requests.exceptions.RequestException as e:
        return f"Błąd podczas pobierania strony: {str(e)}"

if __name__ == "__main__":
    #url = input("Podaj adres strony internetowej: ")
    url = "https://arc.pans.nysa.pl/~adam.dudek/python/"
    tag = input("Choose tag: <h1>,<h2>,<p>,<ol> :").lower()
    
    result = get_Web(url, tag)


