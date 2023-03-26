#include <iostream>
#include <time.h>
#include <vector>

using namespace std;

void displayArray(vector<int> tab){
    cout << " Pozycja -> |";
    int size = tab.size();
    for (int i = 0; i < size; i++){ printf("%2d|",i); }

    cout << endl << " Wartosc -> |";

    for (int i = 0; i < size; i++){ cout << tab[i] << "|"; }

    cout << endl;
}

int findLowMax(vector<int> arr,int getBack[2][2]){

    int sizeV    = arr.size(),
        lowest   = arr[0],
        highest  = arr[0];

    for (int i = 0; i < sizeV; i++) 
    {
        if (lowest  > arr[i] ) {
            lowest  = arr[i];
            getBack[0][0] = lowest;
            getBack[0][1] = i;
        }
        if (highest < arr[i] ) {
            highest = arr[i];
            getBack[1][0] = highest;
            getBack[1][1] = i;
        }
    } 
}

int positionValue(vector<int> tab,int search){
    int size = tab.size();
    for (int i = 0; i < size; i++)
    {
        if (search == tab[i])
        {
            return i;
        }
    }
}

int averageValue(vector<int> tab){
    int avg = 0,
        size = tab.size();
    for (int i = 0; i < size; i++)
    {
        avg +=tab[i];
    }
    return avg/size;
}

