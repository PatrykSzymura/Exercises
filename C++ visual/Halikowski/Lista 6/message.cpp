#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

struct lista
{ string imie;
string nazwisko;
string PESEL;
int wiek;
lista *pop;
lista *nast;
};

void inicjalizacja(lista **nast,lista **pop){
    *nast = NULL;
    *pop = NULL;
}

void dodawanie(lista **pocz,lista **kon){
    lista *temp = new lista;
    cout << "Imie: ";
    cin >> temp->imie;
    cout << "Nazwisko: ";
    cin >> temp->nazwisko;
    cout << "PESEL: ";
    cin >> temp->PESEL;
    cout << "Wiek: ";
    cin >> temp->wiek;
    temp->nast=NULL;
    if (*pocz == NULL){                                 //jesli lista jest pusta
        temp->pop = NULL;
        *pocz = temp;
        *kon = temp;
    } else if ((*pocz)->nazwisko > temp->nazwisko){     //poczatek
        temp->pop = NULL;
        temp->nast = *pocz;
        (*pocz)->pop = temp;
        *pocz = temp;
    } else {                                            //koniec
        lista *aktualny = *pocz;
        while (aktualny->nast != NULL && aktualny->nast->nazwisko < temp->nazwisko){
            aktualny = aktualny->nast;
        }
        temp->pop = aktualny;
        temp->nast = aktualny->nast;
        if (aktualny->nast != NULL){
            aktualny->nast->pop = temp;
        } else {
            *kon = temp;
        }
        aktualny->nast = temp;
    }
}

void dodawanieS(lista **pocz, lista **kon){
    lista *temp = new lista;
    cout << "Imie: ";
    cin >> temp->imie;
    cout << "Nazwisko: ";
    cin >> temp->nazwisko;
    cout << "PESEL: ";
    cin >> temp->PESEL;
    cout << "Wiek: ";
    cin >> temp->wiek;
    temp->nast = NULL;
    temp->pop = *kon;

    lista *aktualny = *pocz;
    while (aktualny != NULL) {
        if (aktualny->nazwisko == temp->nazwisko) {
            cout << "Element o takim nazwisku juz istnieje w liscie" << endl;
            return;
        }
        aktualny = aktualny->nast;
        return;
    }

    if (*pocz == NULL){                                 //jesli lista jest pusta
        temp->pop = NULL;
        *pocz = temp;
        *kon = temp;
    } else if ((*pocz)->nazwisko > temp->nazwisko){     //poczatek
        temp->pop = NULL;
        temp->nast = *pocz;
        (*pocz)->pop = temp;
        *pocz = temp;
    } else {                                            //koniec
        lista *aktualny = *pocz;
        while (aktualny->nast != NULL && aktualny->nast->nazwisko < temp->nazwisko){
            aktualny = aktualny->nast;
        }
        temp->pop = aktualny;
        temp->nast = aktualny->nast;
        if (aktualny->nast != NULL){
            aktualny->nast->pop = temp;
        } else {
            *kon = temp;
        }
        aktualny->nast = temp;
    }
}

void usuwanie(lista **pocz, lista **kon){
    string nazwisko;
    cout << "Podaj nazwisko do usuniecia: ";
    cin >> nazwisko;
    lista *temp = *pocz;
    if (temp->nazwisko == nazwisko) {
        *pocz = temp->nast;
        if (*pocz != NULL) {
            (*pocz)->pop = NULL;
        } else {
            *kon = NULL;
        }
        delete temp;
        cout << "Usunieto pierwszy element z nazwiskiem: " << nazwisko << endl;
        return;
    }
    while (temp != NULL && temp->nazwisko != nazwisko) {
        temp = temp->nast;
    }
    if (temp == NULL) {
        cout << "Nie znaleziono elementu o podanym nazwisku" <<endl;
        return;
    }
    lista *poprzedni = temp->pop;
    lista *nastepny = temp->nast;
    poprzedni->nast = nastepny;
    if (nastepny != NULL) {
        nastepny->pop = poprzedni;
    } else {
        *kon = poprzedni;
    }
    delete temp;
}

void usuwanieA(lista **pocz, lista **kon){
    string nazwisko;
    cout << "Podaj nazwisko do usuniecia: ";
    cin >> nazwisko;
    lista *temp = *pocz;
    while (temp != NULL) {
        if (temp->nazwisko == nazwisko) {
            if (temp == *pocz) {
                *pocz = temp->nast;
                if (*pocz != NULL) {
                    (*pocz)->pop = NULL;
                } else {
                    *kon = NULL;
                }
                delete temp;
                temp = *pocz;
            } else {
                lista *poprzedni = temp->pop;
                lista *nastepny = temp->nast;
                poprzedni->nast = nastepny;
                if (nastepny != NULL) {
                    nastepny->pop = poprzedni;
                } else {
                    *kon = poprzedni;
                }
                lista *do_usuniecia = temp;
                temp = nastepny;
                delete do_usuniecia;
            }
        } else {
            temp = temp->nast;
        }
    }
}

void edytuj(lista *pocz) {
    int nr_osoby;
    cout << "Podaj numer osoby, ktora chcesz edytowac: ";
    cin >> nr_osoby;

    int licznik = 1;
    while (pocz != NULL) {
        if (licznik == nr_osoby) {
            cout << "Aktualne dane: " << endl;
            cout << "Imie: " << pocz->imie << endl;
            cout << "Nazwisko: " << pocz->nazwisko << endl;
            cout << "PESEL: " << pocz->PESEL << endl;
            cout << "Wiek: " << pocz->wiek << endl;

            cout << "Podaj nowe dane: " << endl;
            cout << "Imie: ";
            cin >> pocz->imie;
            cout << "Nazwisko: ";
            cin >> pocz->nazwisko;
            cout << "PESEL: ";
            cin >> pocz->PESEL;
            cout << "Wiek: ";
            cin >> pocz->wiek;

            cout << "Dane zostaly zaktualizowane." << endl;
            return;
        }
        pocz = pocz->nast;
        licznik++;
    }
    cout << "Nie znaleziono osoby o podanym numerze." << endl;
}

void zapisz(lista *pocz){
    int wybor;
    cout << "Wybierz klucz zapisu:"<<endl <<"1. Wszystko"<<endl<<"2. O podanym nazwisku"<<endl<<"3. Wszystkie z wiekiem rownym lub wiekszym od 18"<<endl;
    cin >> wybor;
    string nazwisko;
    if(wybor ==2){
        cout << "Podaj nazwisko do zapisu: ";
        cin >> nazwisko;
    }
    ofstream plik("zapis.txt");
    if (plik.is_open()) {
        while (pocz != NULL) {
            if (wybor == 1 || (wybor == 2 && pocz->nazwisko == nazwisko) || (wybor == 3 && pocz->wiek >= 18)) {
                plik << pocz->imie << "," << pocz->nazwisko << "," << pocz->PESEL << "," << pocz->wiek << endl;
            }
            pocz = pocz->nast;
        }
        plik.close();
        cout << "Lista zostala zapisana w pliku 'zapis.txt'." << endl;
    } else {
        cout << "Nie udalo sie otworzyc pliku." << endl;
    }
}

void wyswietlenie(lista *pocz){
    if(pocz!=NULL){
    while(pocz!=NULL){
    cout << pocz->imie << " " << pocz->nazwisko << " " << pocz->PESEL << " " << pocz->wiek << endl;
    pocz=pocz->nast;}}
    else{cout<< "Pusto"<<endl;}
    return;
}

void zpliku() {
     ifstream plik("zapis.txt");
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

void menu(lista *pocz,lista *kon){
    
    int wybor;
    cout << "1. Dodawanie elementu" <<endl;
    cout << "2. Dodanie elementu ze sprawdzeniem" << endl;
    cout << "3. Usuniecie pierwszego elementu zgodnego z kluczem" << endl;
    cout << "4. Usuniecie wszystkich elementow zgodnego z kluczek" <<endl;
    cout << "5. Edycja wybranego elementu" <<endl;
    cout << "6. Zapisanie w pliku wedlug wybranego klucza" <<endl;
    cout << "7. Wypisanie" <<endl;
    cout << "8. Odczytanie pliku" <<endl;
    cin >> wybor;
    switch(wybor){
        case 1:
            dodawanie(&pocz,&kon);
            menu(pocz,kon);
        break;
        case 2:
            dodawanieS(&pocz,&kon);
            menu(pocz,kon);
        break;
        case 3:
            usuwanie(&pocz,&kon);
            menu(pocz,kon);
        break;
        case 4:
            usuwanieA(&pocz,&kon);
            menu(pocz,kon);
            break;
        case 5:
            edytuj(pocz);
            menu(pocz,kon);
            break;
        case 6:
            zapisz(pocz);
            menu(pocz,kon);
        case 7:
            wyswietlenie(pocz);
            menu(pocz,kon);
        break;
        case 8:
            zpliku();
            menu(pocz,kon);
        break;
    }
}

int main(){
    lista *pocz = NULL;
    lista *kon = NULL;

    inicjalizacja(&pocz,&kon);
    menu(pocz,kon);

    return 0;
}