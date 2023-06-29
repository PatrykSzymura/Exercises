#include <iostream>
#include <fstream>
#include <vector>
#include <time.h>
#include "randomStruct.h"
 
struct lista{ 
    string  imie,
            nazwisko,
            PESEL;
    int     wiek;
    lista  *poprzednik,
           *nastepny;
};

extern lista* koniec;
extern lista* poczatek;
extern int rozmiarKolejki;

bool checker(){
    char ch = 0;
    cin >> ch;
    if (ch == 'T' || ch == 't')
        return true;
    else if (ch == 'N' || ch == 'n')
        return false; 
    else return false;  
}

void addElement(lista **pocz,lista **koniec){
    lista *temp = new lista;

    temp->imie           = randomName();
    temp->nazwisko       = randomSubName();
    temp->PESEL          = "PESEL";
    temp->wiek           = rand()%10+10000;

    temp->nastepny=NULL;

    if (*pocz == NULL){                                 
        temp->poprzednik = NULL;
                   *pocz = temp;
                   *koniec  = temp;
    }else if ((*pocz)->nazwisko > temp->nazwisko){     
        temp->poprzednik = NULL;
        temp->nastepny   = *pocz;
        (*pocz)->poprzednik = temp;
        *pocz = temp;
    } else {                                            
        lista *aktualny = *pocz;
        
        while (aktualny->nastepny != NULL && aktualny->nastepny->nazwisko < temp->nazwisko)
            aktualny = aktualny->nastepny;
        

        temp->poprzednik = aktualny;
        temp->nastepny   = aktualny->nastepny;
        if (aktualny->nastepny != NULL)
            aktualny->nastepny->poprzednik = temp;
        else 
            *koniec = temp;
        
        aktualny->nastepny = temp;
    }
}

bool checkExist(lista *pierwszyEl,lista newElement){
    if(pierwszyEl !=NULL){
        while(pierwszyEl != NULL){
            if (pierwszyEl->imie  == newElement.imie  && pierwszyEl->nazwisko == newElement.nazwisko && 
                pierwszyEl->PESEL == newElement.PESEL && pierwszyEl->wiek     == newElement.wiek)
                return true;
            pierwszyEl = pierwszyEl->nastepny;
        }
          return false;
    }else return false;
}

void addElementCheck(lista **pocz,lista **koniec){
    lista *temp = new lista;

    temp->imie           = randomName();
    temp->nazwisko       = randomSubName();
    temp->PESEL          = "PESEL";
    temp->wiek           = 2;

    if(checkExist(poczatek,*temp)==true) cout << "jest taki element" << endl;

    temp->nastepny=NULL;

    if (*pocz == NULL){                                 
        temp->poprzednik = NULL;
                   *pocz = temp;
                   *koniec  = temp;
    }else if ((*pocz)->nazwisko > temp->nazwisko){     
        temp->poprzednik = NULL;
        temp->nastepny   = *pocz;
        (*pocz)->poprzednik = temp;
        *pocz = temp;
    } else {                                            
        lista *aktualny = *pocz;
        
        while (aktualny->nastepny != NULL && aktualny->nastepny->nazwisko < temp->nazwisko)
            aktualny = aktualny->nastepny;
        

        temp->poprzednik = aktualny;
        temp->nastepny   = aktualny->nastepny;
        if (aktualny->nastepny != NULL)
            aktualny->nastepny->poprzednik = temp;
        else 
            *koniec = temp;
        
        aktualny->nastepny = temp;
    }
}



bool removeSelected(lista **poczatek, string nazwisko) {
    lista *tempElement = *poczatek;
    while (tempElement != NULL) {
        if (tempElement->nazwisko == nazwisko) {
            if (tempElement->poprzednik != NULL) {
                tempElement->poprzednik->nastepny = tempElement->nastepny;
            }
            if (tempElement->nastepny != NULL) {
                tempElement->nastepny->poprzednik = tempElement->poprzednik;
            }
            if (tempElement == *poczatek) {
                *poczatek = tempElement->nastepny;
            }
            delete tempElement;
            rozmiarKolejki--;
            return true;
        }
        tempElement = tempElement->nastepny;
    }
    return false;
}

void removeAllSelected(lista **poczatek, string nazwisko) {
    bool removed = true;
    while (removed) {
        removed = removeSelected(poczatek, nazwisko);
    }
}

void saveToFile(lista *poczatek, string nazwa_pliku) {
    ofstream plik(nazwa_pliku);
    lista *aktualny = poczatek;
    string nazw;
    bool age = false,subName = false;

    cout << "Czy chcesz zapisac osoby <=18lat? t/n";
    age = checker();
    cout << "Czy chcesz zapisac osoby o danym nazwisku t/n";
    subName = checker();
    if(subName == true){
        cout << "podaj nazwisko";
        cin >> nazw;
    }
        
    while (aktualny != NULL) {
        if((subName == true && aktualny->nazwisko == nazw) || (age == true && aktualny->wiek >= 18)) {
            plik << aktualny->imie << "," << aktualny->nazwisko << "," << aktualny->PESEL << "," << aktualny->wiek << endl;
        }
        aktualny = aktualny->nastepny;
    }
    plik.close();
}

void editSelected(lista *poczatek, int choice) {
    int licznik = 1;
    while (poczatek != NULL) {
        if (licznik == choice) {
            cout << "Aktualne dane: " << endl;
            cout << "Imie: " << poczatek->imie << endl;
            cout << "Nazwisko: " << poczatek->nazwisko << endl;
            cout << "PESEL: " << poczatek->PESEL << endl;
            cout << "Wiek: " << poczatek->wiek << endl;

            cout << "Podaj nowe dane: " << endl;
            cout << "Imie: ";
            cin >> poczatek->imie;
            cout << "Nazwisko: ";
            cin >> poczatek->nazwisko;
            cout << "PESEL: ";
            cin >> poczatek->PESEL;
            cout << "Wiek: ";
            cin >> poczatek->wiek;

            cout << "Dane zostaly zaktualizowane." << endl;
            return;
        }
        poczatek = poczatek->nastepny;
        licznik++;
    }
    cout << "Error brad takiego indexu" << endl;
}

void fromFile(string fName) {
     ifstream plik(fName);
    if (plik.is_open()) {
        string linia;
        while (getline(plik, linia)) {
            cout << linia << endl;
        }
        plik.close();
    } else {
        cout << "Nie udalo sie otworzyc pliku." << endl;
    }
}
void printElement(lista *pierwszyEl){
    int i = 0;
    if(pierwszyEl !=NULL){
        cout << " ___________________________________ " << endl
             << "|ID |Imie     |Nazwisko |PESEL|Wiek |" << endl
             << "|___|_________|_________|_____|_____|" << endl;
        while(pierwszyEl != NULL){
            printf( "|%3d",i);
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