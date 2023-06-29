#include <iostream>
#include <vector>
#include <time.h>
#include <chrono>
#include "CustomSort.h"

using namespace std;
using vInt = vector<int>;

int sizeVector = 30;

vInt tablica2;
 
void setVectorSize(vInt tab);

void testAll(vInt tablica,vInt tablica2){
    clock_t start;  
    clock_t end;
    double duration;

        tablica = tablica2;
    
        start = clock();
        babelkowe(&tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"bubble   ",duration);
     
        tablica = tablica2;
        
        start = clock();
        selection(&tablica,0,sizeVector);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"selection",duration);
        
        tablica = tablica2;
        
        start = clock();
        insertsort(&tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"insertion",duration);
        
        tablica = tablica2;
        
        start = clock();
        MergeSort(tablica, 0, sizeVector - 1);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"merge    ",duration);
     
        tablica = tablica2;
        
        start = clock();
        countSort(tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"counting ",duration);
        
        tablica = tablica2;
        
        start = clock();
        kopcowe(tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"heap",duration);
     
        tablica = tablica2;
        
        start = clock();
        kubelkowe(tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"bucket   ",duration);
     
        tablica = tablica2;
        
        start = clock();
        quicksort(tablica,0,sizeVector-1);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"quick    ",duration);
        
        
}

void menu(double last,vInt tablica){
    int choice = 0;
    clock_t start;  
    clock_t end;
    double duration;
    tablica = tablica2;
    cout << "_____________________________________" << endl
         << "|  rozmiar vectora:"<< sizeVector << "|" << endl
         << "|  ostatni czas trwania:            |" << endl;
    cout << "|" << last <<"s "<< endl;
    cout << "|___________________________________|" << endl
         << "| Wybierz Funkcje:                  |" << endl 
         << "|___________________________________|" << endl
         << "|  1. bubble sort                   |" << endl
         << "|  2. selection sort                |" << endl
         << "|  3. insertion sort                |" << endl
         << "|  4. merge sort                    |" << endl
         << "|  5. counting sort                 |" << endl
         << "|  6. heap sort                     |" << endl
         << "|  7. bucket sort                   |" << endl
         << "|  8. quick sort                    |" << endl
         << "|  9. zmien rozmiar vectora         |" << endl
         << "|  10.test all                      |" << endl
         << "|___________________________________|" << endl;
    cin  >> choice;

    switch (choice)
    {
    case 1:
        
        start = clock();
        babelkowe(&tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"bubble   ",duration);
        menu(duration,tablica);
        break;
    case 2:
        start = clock();
        selection(&tablica,0,sizeVector-1);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"selection",duration);
        menu(duration,tablica);
        break;
    case 3:
        start = clock();
        insertsort(&tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"insertion",duration);
        menu(duration,tablica);
        break;
    case 4:
        start = clock();
        MergeSort(tablica, 0, sizeVector - 1);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"merge    ",duration);
        menu(duration,tablica);
        break;
    case 5:
        start = clock();
        countSort(tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"counting ",duration);
        menu(duration,tablica);
        break;
    case 6:
        start = clock();
        kopcowe(tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"heap",duration);
        menu(duration,tablica);
        break;
    case 7:

        start = clock();
        kubelkowe(tablica);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"bucket   ",duration);
        menu(duration,tablica);
        break;
    case 8:
        start = clock();
        quicksort(tablica,0,sizeVector-1);
        end = clock();
        duration = double(end - start) / CLOCKS_PER_SEC;
        saveToFile(sizeVector,"quick    ",duration);
        menu(duration,tablica);
        break;
    case 9:
        setVectorSize(tablica);
        menu(duration,tablica);
        break;
    case 10:
        testAll(tablica,tablica2);
        menu(duration,tablica);
        break;
    case 11:
        display(tablica);
        menu(duration,tablica);
        break;
    default:
        break;
    }
}

void setVectorSize(vInt tab){
    cout << "_____________________________________" << endl
         << "| Wybierz rozmiar vectora           |" << endl
         << "|___________________________________|" << endl
         << "| 1.      30.000                    |" << endl 
         << "| 2.      50.000                    |" << endl 
         << "| 3.     100.000                    |" << endl
         << "| 4.     150.000                    |" << endl 
         << "| 5.     200.000                    |" << endl 
         << "| 6.     500.000                    |" << endl
         << "| 7.   1.000.000                    |" << endl
         << "| 8.   2.000.000                    |" << endl
         << "| 9.   5.000.000                    |" << endl
         << "| 10. 10.000.000                    |" << endl
         << "|___________________________________|" << endl;
    int choice = 0;
    
    cin  >> choice;

    switch (choice)
    {
    case 1:
        sizeVector = 30000;
        break;
    case 2:
        sizeVector = 50000;
        break;
    case 3:
        sizeVector = 100000;
        break;    
    case 4:
        sizeVector = 150000;
        break;
    case 5:
        sizeVector = 200000;
        break; 
    case 6:
        sizeVector = 500000;
        break;
    case 7:
        sizeVector = 1000000;
        break; 
    case 8:
        sizeVector = 2000000;
        break;
    case 9:
        sizeVector = 5000000;
        break;    
    case 10:
        sizeVector = 10000000;
        break;   
    default:
        sizeVector = 30;
        break;
    };

    tab.clear();
    tablica2.clear();
    tab.resize(sizeVector);
    tablica2.resize(sizeVector);

    for (int i = 0; i < sizeVector; i++)
        tab[i] = (rand()%90)+10;
    tablica2 = tab;
}

int main(int argc, char const *argv[])
{
    srand(time(NULL));
    vInt tablica;
    tablica.resize(sizeVector);
    for (int i = 0; i < sizeVector; i++)
        tablica[i] = (rand()%90)+10;
    menu(0,tablica);
    return 0;
}