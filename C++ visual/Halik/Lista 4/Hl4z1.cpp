#include <iostream>
#include <time.h>
#include <string>
#include <vector>
#include "randomStruct.h"
using namespace std;


struct lista
{ 
    string  imie,
            nazwisko,
            PESEL;
    int     wiek;
    lista  *poprzednik,
           *nastepny;
};

using vista  = vector<lista>;

void printElement(lista *pierwszyEl){
    int i = 0;
    if(pierwszyEl !=NULL){
        while(pierwszyEl != NULL){
            cout << "|" << i << "|" << pierwszyEl->imie << "|" << pierwszyEl->nazwisko << "|" << pierwszyEl->PESEL << "|" << pierwszyEl->wiek << "|" << endl;
            pierwszyEl = pierwszyEl->nastepny;
            i++;
        }
        //cout << rozmiarKolejki;
    }else{
        cout << "pusty stos\n";
    }
}

int main(int argc, char const *argv[])
{
    
    return 0;
}
