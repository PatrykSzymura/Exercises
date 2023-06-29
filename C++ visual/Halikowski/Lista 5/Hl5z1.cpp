#include <iostream>
#include <vector>
#include <time.h>
#include "listaBib.h"

using namespace std;

lista* koniec; 
lista* poczatek;
int rozmiarKolejki = 0;

/* void editElement(lista *pierwszyEl, string nazwisko) {
    if(pierwszyEl !=NULL){
        while(pierwszyEl != NULL){
            if (pierwszyEl->nazwisko == nazwisko) cout << "xd";
            cout << pierwszyEl->nazwisko << " " << nazwisko << endl;
            pierwszyEl = pierwszyEl->nastepny;
            
        }
    }else{
        cout << "ERROR-PUSTY-STOS" << endl;
    }
} */

void menu();

void inicjalizacja(lista **ostatni, lista **pierwszy){
    *ostatni  = NULL;
    *pierwszy = NULL;
}

int main(int argc, char const *argv[])
{
    srand(time(NULL));
    inicjalizacja(&koniec,&poczatek);
    menu();
    return 0;
}

void menu(){
    int choice = 0;
    string nameChoice;
    cout << flush;
    printElement(poczatek);
    
    cout << "| Wybierz Funkcje:                  |" << endl 
         << "|___________________________________|" << endl
         << "|  1.Dodaj                          |" << endl
         << "|  2.Dodaj ze sprawdzeniem powtorki |" << endl
         << "|  3.Usun 1 z nazwiskiem            |" << endl
         << "|  4.Usun wzystkie z nazwiskiem     |" << endl
         << "|  5.Edytuj element                 |" << endl
         << "|  6.Zapisz do pliku                |" << endl
         << "|  7.Wypisz plik                    |" << endl
         << "|___________________________________|" << endl;
    cin  >> choice;

    string name  = randomSubName();

    switch (choice)
    {
    case 1:
        addElement(&poczatek,&koniec);
        menu();
        break;
    case 2:
        addElementCheck(&poczatek,&koniec);
        menu();
        break;
    case 3:
        cout << name << endl;
        removeSelected(&poczatek,name);
        menu();
        break;
    case 4:
        cout << name << endl;
        removeAllSelected(&poczatek,name);
        menu();
        break;
    case 5:
        cout << "Podaj index " << endl;
        cin  >> choice;
        editSelected(poczatek,choice);
        menu();
        break;
    case 6:
        saveToFile(poczatek,"file.txt");
        menu();
    case 7:
        fromFile("file.txt");
        menu();
    default:
        break;
    }
}
