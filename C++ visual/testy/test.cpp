#include <iostream>
#include <cstdlib>
#include <time.h>

using namespace std;

const int SIZE = 10;

void fillArray(int arr[]) {
     // inicjalizacja generatora liczb losowych
    for (int i = 0; i < SIZE; i++) {
        arr[i] = rand() % 100; // wypełnienie tablicy losowymi liczbami całkowitymi z zakresu 0-99
    }
}

int* findMin(int arr[]) {
    int* minPtr = &arr[0]; // inicjalizacja wskaźnika na pierwszy element tablicy
    for (int i = 1; i < SIZE; i++) {
        if (arr[i] < *minPtr) { // porównanie wartości aktualnego elementu z najmniejszą dotychczas znalezioną
            minPtr = &arr[i]; // jeśli aktualny element jest mniejszy, to ustaw wskaźnik na ten element
        }
    }
    return minPtr; // zwróć wskaźnik na najmniejszy element
}

int main() {
    srand(time(NULL));
    int arr[SIZE];
    int* ptrArr[SIZE];

    fillArray(arr); // wypełnienie tablicy losowymi liczbami całkowitymi

    for (int i = 0; i < SIZE; i++) {
        ptrArr[i] = findMin(arr); // znalezienie najmniejszego elementu i zapisanie jego wskaźnika w tablicy wskaźników
        //*ptrArr[i] = 100; // nadpisanie najmniejszego elementu w tablicy oryginalnej, aby nie był ponownie wybierany
    }

    cout << "Tablica oryginalna:" << endl;
    for (int i = 0; i < SIZE; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    cout << "Tablica wskaźników:" << endl;
    for (int i = 0; i < SIZE; i++) {
        cout << *ptrArr[i] << " ";
    }
    cout << endl;

    return 0;
}
