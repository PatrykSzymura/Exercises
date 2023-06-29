#include <iostream>
#include <fstream>
#include <vector>
#include <time.h>
#include "randomStruct.h"
using namespace std;

struct kolejka
{
    int id;
    string name,
           subname;
    kolejka *nastepny;
};

kolejka *pierwszy;
kolejka *ostatni;
int rozmiar = 0;

void display(kolejka *pierwszyElement){
    while (pierwszyElement != NULL)
    {
        cout << "|" << pierwszyElement->id << "|" << pierwszyElement->name << "|" << pierwszyElement->subname << "|" << endl;
        pierwszyElement = pierwszyElement->nastepny;
    }
}

void saveFile(kolejka *pierwszyElement){
    fstream plik;
    plik.open("plik", ios::out);
    while (pierwszyElement != NULL){
        plik << "|" << pierwszyElement->id << "|" << pierwszyElement->name << "|" << pierwszyElement->subname << "|" << endl;
        pierwszyElement = pierwszyElement->nastepny;
    }
    plik.close();
}

void dodajElement(kolejka **pierwszyElement,kolejka **ostatniElement){
    if(rozmiar == 10) return;
    kolejka *temp = new kolejka;
    temp->id = rozmiar;
    rozmiar++;
    temp->name = randomName();
    temp->subname = randomSubName();
    temp->nastepny = NULL;
    
    if(*pierwszyElement == NULL) *pierwszyElement = temp;
    if(*ostatniElement  == NULL) *ostatniElement  = temp;
    else{
        kolejka *temp2 = *ostatniElement;
        temp2->nastepny = temp;
        *ostatniElement = temp;
    } 
}

void usunElement(kolejka **pierwszyElement){
    kolejka *temp;
    if(*pierwszyElement != NULL){
        temp = *pierwszyElement;
        *pierwszyElement = (*pierwszyElement)->nastepny;
        delete temp;
        rozmiar--;
    }

    
}

void menu(){
    //cout << pierwszy << endl;
    int x = 0;
    if(pierwszy == NULL){
        cout << " _________________________ " << endl
             << "|      PUSTA KOLEJKA      |" << endl;
    }
    else
        display(pierwszy);
    cout << "|_________________________|" << endl
         << "|      KOLEJKA MENU       |" << endl
         << "|_________________________|" << endl
         << "|  1.Dodaj element        |" << endl
         << "|  2.Usun  element        |" << endl
         << "|  3.Zapisz do pliku      |" << endl
         << "|  4.Zamknij              |" << endl
         << "|_________________________|" << endl;
    cin >> x;
    
    switch (x)
    {
    case 1:
        dodajElement(&pierwszy,&ostatni);
        menu();
        break;
    case 2:
        usunElement(&pierwszy);
        menu();
    case 3:
        saveFile(pierwszy);
        menu();
    default:
        break;
    }
    
}

int main(int argc, char const *argv[])
{
    int rozmiar = 0;
    srand(time(NULL));
    pierwszy = NULL;
    ostatni  = NULL;
    menu();
    saveFile(pierwszy);
    
    return 0;
}

