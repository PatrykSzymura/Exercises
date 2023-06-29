#include <iostream>
#include <vector>
#include <algorithm>
#include <time.h>
using namespace std;

void fillArr(int arr[],int sizeArr){
    for (int i = 0; i < sizeArr; i++)
    {
        arr[i] = rand()%80+10;
    }
}

void displayArr(int arr[],int sizeArr){
    for (int i = 0; i < sizeArr; i++)
    {
        cout << "|" << arr[i];
    }
    cout << "| \n";
}
void displayArrPointer(int *arr[],int sizeArr){
    for (int i = 0; i < sizeArr; i++)
    {
        cout << "|" << *arr[i];
    }
    cout << "| \n";
}

void sortPointer(int arr[], int *arrPointer[],int size){
    int index = 0,
        max = 0;
    for (int i = 0; i < size; i++)
    {
        if(max < arr[i]){max = arr[i];}
    }

    for (int i = 0; i < size*size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            if (arr[j] == i)
            {
               arrPointer[index] = &arr[j];
               index++;
            } 
        }
    }
}




int main(int argc, char const *argv[])
{
    srand(time(NULL));
    int size = 10,
        arr1[size];
    int *arrPointers[size];

    fillArr     (arr1,size);
    cout << "oryginalna :  ";
    displayArr  (arr1,size);
    

    
    sortPointer(arr1,arrPointers,size);
    cout << "posortowana : ";
    displayArrPointer  (arrPointers,size);


    return 0;
}
