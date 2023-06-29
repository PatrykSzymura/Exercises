#include <iostream>
#include <fstream>
#include <time.h>
#include "randomStruct.h"
using namespace std;

struct kolejka
{
    string name,
           subname;
    kolejka *nastepny;
};

kolejka *kolejkaPierwszy;
kolejka *kolejkaOstatni;


void display(kolejka *pierwszyElement){
    while (pierwszyElement != NULL)
    {
        cout << pierwszyElement->name << " " << pierwszyElement->subname << endl;
        pierwszyElement = pierwszyElement->nastepny;
    }
}

void saveFile(kolejka *pierwszyElement){
    fstream file;
    file.open("plik", ios::out);
    while (pierwszyElement != NULL)
    {
        file << pierwszyElement->name << " " << pierwszyElement->subname << endl;
        pierwszyElement = pierwszyElement->nastepny;
    }
    file.close();
}

void add(kolejka **pierwszyElement, kolejka **ostaniElement){
    kolejka *temp = new kolejka;
    temp->name = randomName();
    temp->subname = randomSubName();
    temp->nastepny = NULL;
    

    if(*pierwszyElement == NULL) *pierwszyElement = temp;
    if(*ostaniElement   == NULL) *ostaniElement   = temp;
    else{
        kolejka *temp2 = *ostaniElement;
        temp2->nastepny = temp;
        *ostaniElement = temp;
    }
}

void usun(kolejka **pierwszyElement, kolejka **ostatniElement){
    if(pierwszyElement != NULL){
        kolejka *temp;
        temp = *pierwszyElement;
        *pierwszyElement = (*pierwszyElement)->nastepny;
        delete temp;
    }
}

int main()
{
    kolejkaPierwszy = NULL;
    kolejkaOstatni  = NULL;
    int x;
    do
    {
        if (kolejkaPierwszy == NULL) cout << "Pusta kolejka" << endl;
        display(kolejkaPierwszy);
        cout << " 1.dodaj \n 2.usun \n 3.zapisz \n 4.exit"<< endl;
        cin  >> x;

        switch (x)
        {
        case 1:
            add(&kolejkaPierwszy,&kolejkaOstatni);
            break;
        case 2:
            usun(&kolejkaPierwszy,&kolejkaOstatni);
            break;
        case 3:
            saveFile(kolejkaPierwszy);
            break;
        default:
            break;
        }
    } while (x != 4);
    
    return 0;
}
