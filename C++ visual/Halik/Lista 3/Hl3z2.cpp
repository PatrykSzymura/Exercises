#include <iostream>
#include <fstream>
#include <time.h>
#include <algorithm>
#include <vector>

using namespace std;


struct lista
{ 
    string  imie,
            nazwisko,
            PESEL;
    int wiek;
    lista *nast;
};

using vista = vector<lista>;

lista* ostatni;
lista* pierwszy;
int rozmiarKolejki = 0 ;

void inicjalizacja(lista **ostatni, int *rozmiar){
    *ostatni = NULL;
    *rozmiar = 0;
}

//dodanie elementu do kolejki
void addElement(lista **nastepny,lista **pierwszy){
    rozmiarKolejki++;
    lista *temp = new lista;
    string //name,
        nazwisko;
    temp->imie     = "name";
    cin >> nazwisko;
    temp->nazwisko = nazwisko;
    temp->PESEL    = "PESEL";
    temp->wiek     =  rand()%10+rozmiarKolejki;
    temp->nast     = NULL;
    if (*pierwszy == NULL){*pierwszy  = temp;}
    if (*nastepny == NULL){*nastepny  = temp;}
    else{
        lista *temp2 = *nastepny;
        temp2->nast = temp;
        *nastepny = temp;
    }
}

//wyswietlanie kolejki
void printElement(lista *pierwszyEl){
    int i = 0;
    if(pierwszyEl !=NULL){
        while(pierwszyEl != NULL){
            cout << "|" << i << "|" << pierwszyEl->imie << "|" << pierwszyEl->nazwisko << "|" << pierwszyEl->PESEL << "|" << pierwszyEl->wiek << "|" << endl;
            pierwszyEl = pierwszyEl->nast;
            i++;
        }
        //cout << rozmiarKolejki;
    }else{
        cout << "pusty stos\n";
    }
}

void delElement(lista **nastepnyEl){
    if(*nastepnyEl != NULL){
        lista *temp = *nastepnyEl;
        *nastepnyEl = (*nastepnyEl)->nast;
        delete temp;
        rozmiarKolejki--;
    }
}

vista listToArr(lista *nastepnyEl){
    vista listArr;
    listArr.resize(rozmiarKolejki);

    for (int i = 0; i < rozmiarKolejki; i++)
    {
        listArr[i] = *nastepnyEl;
        nastepnyEl = nastepnyEl->nast;
    }
    

    //cout << endl << "rozmiar Kolejki: " << rozmiarKolejki << " rozmiar vektora: " << listArr.size() << endl;
    return listArr;
} 

bool wiek(const lista& a, const lista& b) {
    return a.wiek < b.wiek;
}

void writeToFile(lista *adres){
    vista temp  = listToArr(adres);
    fstream fileName;
    fileName.open("Lista.txt", ios::out);

    sort(temp.begin(), temp.end(),wiek);

    if (!fileName) { cout << "spadlem z rowerka"; }
    else{
        for (int i = 0; i < rozmiarKolejki; i++)
        {
            fileName << "|" << i << "|" << temp[i].imie << "|" << temp[i].nazwisko << "|" << temp[i].PESEL << "|" << temp[i].wiek << "|" << endl;
        }
    }
}

void menu();

int main(int argc, char const *argv[])
{
    srand(time(NULL));
    inicjalizacja(&pierwszy ,&rozmiarKolejki);
    menu();
    return 0;
}

void menu(){
    int choice = 0;
    printElement(pierwszy);
    
    cout << " Wybierz Funkcje: "  << endl 
         << "  1.Dodaj"           << endl
         << "  2.Usun"            << endl
//       << "  3.Wyswietl"        << endl
         << "  4.Zapisz"          << endl;
    cin  >> choice;

    switch (choice)
    {
    case 1:
        addElement(&ostatni,&pierwszy);
        menu();
        break;
    case 2:
        delElement(&pierwszy);
        menu();
        break;
    case 3:
        printElement(pierwszy);
        menu();
        break;
    case 4:
        writeToFile(pierwszy);
        menu();
        break;
    default:
        break;
    }
}