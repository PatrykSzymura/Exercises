#include <iostream>
#include <string>

using namespace std;

struct lista{ 
    string imie,
           nazwisko,
           PESEL;
    int    wiek;
    lista *pop,
          *nast;
};

void inicjalizacja(lista **nast, lista **pop){ // wype�niamy nast i pop aby m�c rozpocz�� jakiekolwiek dzia�anie na liscie!
    *nast = NULL;
    *pop = NULL;
}

void Dodawanie(lista **poczatek, lista **koniec){
    lista *tym = new lista;
    int ile = 0;
    cout << "------------------------------------" << endl;
    cout << "|         Dodawanie osoby          |" << endl;
    cout << "------------------------------------" << endl;
    cout << "Imie: ";
    tym ->imie = "ediuofaj";
    //cin >> tym->imie;
    cout << "Nazwisko: ";
    //cin >> tym->nazwisko;
    tym ->nazwisko = "ediuofaj";
    cout << "PESEL: ";
    //cin >> tym->PESEL;
    tym ->PESEL = "ediuofaj";
    cout << "Wiek: ";
    //cin >> tym->wiek;
    tym ->wiek = 6;
    cout << "------------------------------------" << endl;
    cout << "        Dodawanie wykonane!         " << endl;
    cout << "------------------------------------" << endl;

    if (*poczatek == NULL){*poczatek  = tym;}
    if (*koniec == NULL){*koniec  = tym;}
    else{
        
        lista *temp2     = *koniec;
        temp2->nast  = tym;
        *koniec        = tym;
    }
}

void Usuwanie_Pierwszego(lista **poczatek, lista **koniec){

    string nazwisko;
    cout << "---------------------------------------" << endl;
    cout << "| Usuwanie 1 osoby z danym nazwiskiem |" << endl;
    cout << "---------------------------------------" << endl;
    cout << "Napisz Nazwisko: ";
    cin >> nazwisko;
    lista *tym = *poczatek; // chcemy by� na pocz�tku listy bo usuwamy pierwsze od g�ry nazwisko z wyznaczonym s�owem od u�ytkownika

    while (tym != NULL && tym->nazwisko != nazwisko) {
        tym = tym->nast;
    }

    if(tym == NULL){
     cout << "---------------------------------------" << endl;
     cout << "|        Nie znaleziono nazwiska!     |" << endl;
     cout << "---------------------------------------" << endl;
     return;
    }

    if(tym->nazwisko == nazwisko){ // je�li b�d� takie same nazwiska to co�...

        if(tym == *poczatek){
            *poczatek = tym->nast;
        }
        else if(tym == *koniec){
            *koniec = tym->pop;
        }
        else if(tym->pop == NULL && tym->nast == NULL){
            *poczatek = NULL;
            *koniec = NULL;
        }
        else{
            tym->pop->nast = tym->nast;
            tym->nast->pop = tym->pop;
        }
        delete tym;
    cout << "---------------------------------------" << endl;
    cout << "|          Usuwanie wykonane!         |" << endl;
    cout << "---------------------------------------" << endl;

  }
    
    return;
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
            pierwszyEl = pierwszyEl->nast;
            i++;
        }
        //cout << rozmiarKolejki;
    }else{
        cout << "_____________________________________" << endl
             << "|            PUSTY STOS             |" << endl 
             << "|___________________________________|" << endl;;
    }
}

void Wypisywanie(lista *poczatek){

        cout << "------------------------------------" << endl;
        cout << "|           Elementy listy         |" << endl;
        cout << "------------------------------------" << endl;
     while(poczatek!=NULL){
        cout << "Imie -> " << poczatek->imie <<endl;
        cout << "Nazwisko -> " << poczatek->nazwisko <<endl;
        cout << "PESEL -> " << poczatek->PESEL <<endl;
        cout << "Wiek -> " << poczatek->wiek <<endl;
        cout << "------------------------------------" << endl;
        poczatek = poczatek -> nast;
    }

        cout << "|      Wypisywanie zakonczone!     |" << endl;
        cout << "------------------------------------" << endl;
    cout << endl;
}
int main()
{
    lista *poczatek = NULL;
    lista *koniec = NULL;
    
    

    int menu = 0;
    int wybor = 0;

    do{

    cout << "------------------------------------------------------------" << endl;
    cout << "|                           MENU:                          |" << endl;
    cout << "------------------------------------------------------------" << endl;
    cout << "| 1/ Dodawanie elementu                                    |" << endl;
    cout << "| 2/ Usuwanie pierwszego elementu o danym nazwisku z listy |" << endl;
    cout << "| 3/ Usuwanie wszystkich elementow o danym nazwisku        |" << endl;
    cout << "| 4/ Wyszukiwanie elementu listy o podanym kluczu          |" << endl;
    cout << "| 5/ Wypisanie zawartosci listy na ekran                   |" << endl;
    cout << "| 6/ Edytyowanie wybrany element listy dwukierounkowej     |" << endl;
    cout << "| 7/ Zapisywanie elementow listy do pliku tekstowego       |" << endl;
    cout << "------------------------------------------------------------" << endl;
    cout << "Wypisz liczbe: ";
    cin >> menu;
    cout << endl;

    switch(menu){
    case 1:
        Dodawanie(&poczatek, &koniec);
        break;
    case 2:
        Usuwanie_Pierwszego(&poczatek, &koniec);
        break;
    case 5:
        printElement(poczatek);
    }

    cout << "Czy chcesz ponownie skorzystac z programu?" << endl;
    cout << "1/ TAK" << endl;
    cout << "2/ NIE" << endl;
    cout << "Wybor: ";
    cin  >> wybor;
    }while(wybor == 1);

    return 0;
}