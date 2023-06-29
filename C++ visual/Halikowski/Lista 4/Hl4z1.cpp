#include <iostream>
#include <fstream>
#include <time.h>
#include <algorithm>
#include <vector>
#include "randomStruct.h"

using namespace std;


struct lista
{ 
    string  imie,
            nazwisko,
            PESEL;
    int     wiek;
    lista  *poprzednik,
           *nastepny;
};

using vista = vector<lista>;

lista* koniec;
lista* poczatek;
int rozmiarKolejki = 0 ;

void inicjalizacja(lista **ostatni, lista **pierwszy){
    *ostatni  = NULL;
    *pierwszy = NULL;
}

void menu();

void addElement(lista **nastepny,lista **pierwszy){
    rozmiarKolejki++;

    lista *temp = new lista;

    temp->imie           = randomName();
    temp->nazwisko       = randomSubName();
    temp->PESEL          = "PESEL";
    temp->wiek           = rand()%10+10000;
    temp->nastepny       = NULL;
    temp->poprzednik     = *nastepny;

    if (*pierwszy == NULL){*pierwszy  = temp;}
    if (*nastepny == NULL){*nastepny  = temp;}
    else{
        
        lista *temp2     = *nastepny;
        temp2->nastepny  = temp;
        *nastepny        = temp;
    }
}

void printSelectedElement(lista *aktualny){

    lista *aktualny = poczatek;
    while (aktualny != nullptr) {
        cout << "Imię: "        << aktualny->imie       << endl;
        cout << "Nazwisko: "    << aktualny->nazwisko   << endl;
        cout << "PESEL: "       << aktualny->PESEL      << endl;
        cout << "Wiek: "        << aktualny->wiek       << endl 
             << endl;
        aktualny = aktualny->nastepny;
    }
}

void printElement(lista *pierwszyEl){
    int i = 0;
    if(pierwszyEl !=NULL){
        cout << "_____________________________________" << endl
             << "|ID |Imie     |Nazwisko |PESEL|Wiek |" << endl
             << "|___|_________|_________|_____|_____|" << endl;
        while(pierwszyEl != NULL){
            printf("|%3d",i);
            cout << "|" << pierwszyEl->imie 
                 << "|" << pierwszyEl->nazwisko 
                 << "|" << pierwszyEl->PESEL 
                 << "|" << pierwszyEl->wiek 
                 << "|" << endl
                 << "|___|_________|_________|_____|_____|" << endl;
            pierwszyEl = pierwszyEl->nastepny;
            i++;
        }
        //cout << rozmiarKolejki;
    }else{
        cout << "_____________________________________" << endl
             << "|            PUSTY STOS             |" << endl 
             << "|___________________________________|" << endl;;
    }
}

void removeSelected(lista *&poczatek, string nazwisko) {
    lista *tempElement = poczatek;
    while (tempElement != NULL) {
        if (tempElement->nazwisko == nazwisko) {
            if (tempElement->poprzednik != NULL) {
                tempElement->poprzednik->nastepny = tempElement->nastepny;
            }
            if (tempElement->nastepny != NULL) {
                tempElement->nastepny->poprzednik = tempElement->poprzednik;
            }
            if (tempElement == poczatek) {
                poczatek = tempElement->nastepny;
            }
            delete tempElement;
            return;
        }
        tempElement = tempElement->nastepny;
    }
    rozmiarKolejki--;
}

void removeAllSelected(lista *&poczatek, string nazwisko){
    for (int i = 0; i < rozmiarKolejki; i++)
        removeSelected(poczatek,nazwisko);
}

void editSelected(lista *poczatek, int choice) {
    lista *tempElement = poczatek;
    for(int i = 0; i < choice; i++)
        tempElement = tempElement->nastepny;

    cout << "Podaj nowe imię: ";
    cin  >> tempElement->imie;
    cout << "Podaj nowe nazwisko: ";
    cin  >> tempElement->nazwisko;
    cout << "Podaj nowy numer PESEL: ";
    cin  >> tempElement->PESEL;
    cout << "Podaj nowy wiek: ";
    cin  >> tempElement->wiek;
}

void saveToFile(lista *poczatek, string nazwa_pliku) {
    ofstream plik(nazwa_pliku);
    lista *aktualny = poczatek;
    while (aktualny != nullptr) {
        plik << aktualny->imie << "," << aktualny->nazwisko << "," << aktualny->PESEL << "," << aktualny->wiek << endl;
        aktualny = aktualny->nastepny;
    }
    plik.close();
}

int main(int argc, char const *argv[])
{
    srand(time(NULL)); 
    inicjalizacja(&poczatek,&koniec);
    menu();
    return 0;
}


void menu(){
    int choice = 0;
    cout << flush;
    printElement(poczatek);
    
    cout << "| Wybierz Funkcje:                  |" << endl 
         << "|___________________________________|" << endl
         << "|  1.Dodaj                          |" << endl
         << "|  2.Usun 1 z nazwiskiem            |" << endl
         << "|  3.Usun wzystkie z nazwiskiem     |" << endl
         << "|  4.Edytuj element                 |" << endl
         << "|  5.Zapisz do pliku                |" << endl
         << "|___________________________________|" << endl;
    cin  >> choice;

    string name  = randomSubName();

    switch (choice)
    {
    case 1:
        addElement(&koniec,&poczatek);
        menu();
        break;
    case 2:
        cout << name << endl;
        removeSelected(poczatek,name);
        menu();
        break;
    case 3:
        cout << name << endl;
        removeAllSelected(poczatek,name);
        menu();
        break;
    case 4:
        cout << "Podaj ID: " << endl;
        cin  >> choice;
        editSelected(*&poczatek,choice);
        menu();
        break;
    case 5:
        saveToFile(poczatek,"file");
        menu();
    default:
        break;
    }
}