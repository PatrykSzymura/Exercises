#include <iostream>
#include <fstream>
#include "randomStruct.h"
#include <time.h>
using namespace std;


struct lista{ 
    string  imie,
            nazwisko,
            pesel;
    int wiek;
    lista *pop;
};

lista* poczatek;

void inicjalizacja(lista **poczatek){
    *poczatek = NULL;
}

//dodanie elementu na stos
void addElement(lista **previous){
    lista *temp = new lista;
    temp -> imie     = randomName();
    temp -> nazwisko = randomSubName();
    temp -> pesel    = "PESEL";
    temp -> wiek     = rand()%9;
    temp -> pop      = *previous;
    *previous = temp;

}

void delElement(lista **previous){
    if(*previous != NULL){
        lista *temp = *previous;
        *previous = (*previous)->pop;
        delete temp;
    }
}

void printElement(lista *previous){
    int i = 0;
    if(previous !=NULL){
        while(previous != NULL){
            printf("|%3d",i);
            cout << "|" << previous->imie << "|" << previous->nazwisko << "|" << previous->pesel << "|" << previous->wiek << "|" << previous->pop<< endl;
            previous = previous->pop;
            i++;
        }
    }else{
        cout << "pusty stos"<< endl;
    }
}

void writeToFile(lista *previous){
    int i = 0;
    if(previous !=NULL){
        fstream FileName;               
        FileName.open("Stos", ios::out);  
          
        if (!FileName){                 
            cout<<"Error";    
        }
        else{
            while(previous != NULL){
                FileName << "|" << i << "|" << previous->imie << "|" << previous->nazwisko << "|" << previous->pesel << "|" << previous->wiek << "|" << endl;
                previous = previous->pop;
                i++;
            }
            FileName.close();           
        }
    }
    else{
        cout << "pusty stos";
    }
}

void menu(){
    int choice = 0;
   
    printElement(poczatek);
    cout << " Wybierz Funkcje: " << endl 
         << "  1.Dodaj"           << endl
         << "  2.Usun"            << endl
//       << "  3.Wyswietl"        << endl
         << "  4.Zapisz"          << endl;
    cin  >> choice;

    switch (choice)
    {
    case 1:
        addElement(&poczatek);
        menu();
        break;
    case 2:
        delElement(&poczatek);
        menu();
        break;
    case 3:
        printElement(poczatek);
        menu();
        break;
    case 4:
        writeToFile(poczatek);
        menu();
        break;
    default:
        break;
    }
    system("cls");
}

int main(int argc, char const *argv[])
{
    srand(time(NULL));
    inicjalizacja(&poczatek);
    menu();

    return 0;
}
