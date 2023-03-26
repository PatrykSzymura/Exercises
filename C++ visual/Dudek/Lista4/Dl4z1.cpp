#include <iostream>
#include <time.h>
#include <vector>
#include "lista4aLib.h"
using namespace std;

int main(int argc, char const *argv[])
{
    srand(time(NULL));
    int search        = 0,
        szukane[2][2] = {0};
    vector<int> tablica;

    int n = 0;
    cout << "Podaj rozmiar tablicy struktur: ";
    cin  >> n;

    for (int i = 0; i < n; i++) {
        n = rand()%80+10;
        tablica.push_back(n);
    }

    findLowMax(tablica,szukane);
    displayArray(tablica);
    
    cout << endl << "Najmniejsza wartosc: " << szukane[0][0] << " pozycja: " << szukane[0][1];
    cout << endl << "Najwieksza  wartosc: " << szukane[1][0] << " pozycja: " << szukane[1][1];
    cout << endl << "    Srednia wartosc: " << averageValue(tablica);
    cout << endl << "      Podaj wartosc: ";
    cin  >> search;
    cout << "    Szukana wartosc: " << search << " pozycja: " << positionValue(tablica,search);
    return 0;
}

