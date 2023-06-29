#include <iostream>
#include <string>
#include <vector>
#include <fstream>
using namespace std;

string colorText(const string& color, const string& text) {
    // Definicje kodów kolorów
    string colorCode;
    if (color == "red")
        colorCode = "\033[91m"; // Czerwony kolor
    else if (color == "darkred")
        colorCode = "\033[31m"; // Ciemno Czerwony kolor
    else if (color == "orange")
        colorCode = "\033[93m"; // Pomarańczowy kolor
    else if (color == "green")
        colorCode = "\033[32m"; // Zielony kolor
    else if (color == "blue")
        colorCode = "\033[34m"; // Niebieski kolor
    else
        colorCode = ""; // Domyślny kolor

    // Złożenie tekstu z kodem koloru i zwrócenie go
    return colorCode + text + "\033[0m"; // Przywrócenie domyślnego koloru
}

bool czyMiasto(int i){
    // zbior id pol ktore sa miastami
    vector<int> id = {1, 3, 6, 8, 9, 11, 13, 14, 16, 18, 19, 21, 23, 24, 26, 27, 29, 31, 32, 34, 37 , 39};
    for (int j = 0; j < id.size(); j++)
        // sprawdzenie czy na polu i powinno stac miasto
        if(i == id[j]) 
            return true;
    return false;  
}