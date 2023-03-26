#include <vector>
#include <iostream>
#include <time.h>
#include "lista4bLib.h"
using namespace std;
using vInt = vector<vector<int>>;

void menu(vInt tab1, vInt tab2){

    int n = 0,choice = 0;

    cout << "Podaj rozmiar macierzy: ";
    cin  >> n;

    tab1 = createMatrix(n,n);         //zadeklarowanie miejca na macierz o rozmiarach n*n
    tab2 = createMatrix(n,n);
    cout << "podaj macierz1";
    tab1 = fillMatrix(tab1,"user");
    cout << "opcje:\n 1.dodaj\n 2.odejmowania\n 3.mnorzenie\n 4.dopelnij\n";
    cin  >> choice;
    switch (choice)
    {
    case 1:
        cout << "podaj macierz2";
        tab2 = fillMatrix(tab2,"user");
        cout << endl<< "dodawanie :" << endl;
        tab1 = addMatrix(tab1,tab2);
        displayMatrix(tab1);
        menu(tab1,tab2);
        system("pause");
        break;
    case 2:
        cout << "podaj macierz2";
        tab2 = fillMatrix(tab2,"user");
        cout << endl<< "odejmowanie :" << endl;
        tab1 = subtractMatrix(tab1,tab2);
        displayMatrix(tab1);
        menu(tab1,tab2);
        system("pause");
        break;
    case 3:
        cout << "podaj macierz2";
        tab2 = fillMatrix(tab2,"user");
        cout << endl<< "mnozenie :" << endl;
        tab1 = multiplyMatrix(tab1,tab2);
        displayMatrix(tab1);
        menu(tab1,tab2);
        system("pause");
        break;
    case 4:
        cout << endl << "podaj liczbe dopelnienia: ";
        int a = 0;
        cin  >> a;
        cout << endl << "dopelnienie: " << endl;

        tab1  = dopelnienie(tab1,a);
        displayMatrix(tab1);
        menu(tab1,tab2);
        system("pause");
        break;

    }

}

int main(int argc, char const *argv[])
{   
    vInt macierz1,
         macierz2;
    srand(time(NULL));
    menu(macierz1,macierz2);
    return 0;
}