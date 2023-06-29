#include <iostream>
#include <fstream>
#include <time.h>
#include "randomStruct.h"
using namespace std;

struct stos{
    string name,subname;
    stos *poprzedni;
};
stos *onTop;

void display(stos *element){
    while(element != NULL){
        cout << element->name << " " << element->subname << endl;
        element = element->poprzedni;
    }
}

void saveFile(stos *element){
    fstream file;
    file.open("plik", ios::out);
    while(element != NULL){
        file << element->name << " " << element->subname << endl;
        element = element->poprzedni;
    }
    file.close();
}

void add(stos **element){
    stos *temp = new stos;
    temp->name = randomName();
    temp->subname = randomSubName();
    
    temp->poprzedni = *element;
    *element = temp;
}

void usun(stos **element){
    if(element == NULL) return;
    stos *temp = (*element);
    *element = temp->poprzedni;
    delete temp;
}

int main(int argc, char const *argv[])
{
    onTop = NULL;
    int x;
    do
    {
        if (onTop == NULL)
        {
            cout << "Pusty stos" << endl;
        }
        display(onTop);

        cout << " 1.dodaj element \n 2.usun element \n 3.zapisz do pliku \n 4.wyjdz \n";
        cin  >> x;

        switch (x)
        {
        case 1:
            add(&onTop);
            break;
        case 2:
            usun(&onTop);
            break;
        case 3:
            saveFile(onTop);
        default:
            break;
        }
        
    } while (x!=4);
    


    return 0;
}
