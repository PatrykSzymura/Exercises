#include <iostream>
#include <vector>
#include <algorithm>
#include <time.h>
using namespace std;

typedef struct tosoba
{
    int  id,
         wiek;
    string imie,
           nazwisko;
}tosoba;

bool compareName(const tosoba &person1, const tosoba &person2)
{
    if(person2.nazwisko > person1.nazwisko)
        return 1;
    if(person2.nazwisko == person1.nazwisko)
    {
        if(person2.imie > person1.imie)
            return 1;
    }
    return 0;
}

void fillStruct(vector<tosoba> *arr){
   int count = 0;
   for ( int i  = 0 ; i < arr->size(); i++)
   {
    cout << "Podaj dane osoby nr." << count+1 << endl;

    arr->at(i).id  = count;
    count++;
    
    cout << "imie: ";
    cin  >> arr->at(i).imie;
    cout << "nazwisko: ";
    cin  >> arr->at(i).nazwisko;
    cout << "wiek: ";
    cin  >> arr->at(i).wiek;
   }
} 

void displayStruct(vector<tosoba> *arr){

    //cout << "id" << "|" << "imie" << "|" << "nazwisko" << "|" << "wiek" << "|"<< endl;
    for (tosoba i : *arr)
    {
        cout << i.id << "|" << i.imie << "|" << i.nazwisko << "|" << i.wiek << "|" << endl;
    }
}

int main(int argc, char const *argv[])
{
    int n = 0;
    cout << "Podaj rozmiar tablicy struktur: ";
    cin  >> n;

    tosoba temp;
           temp.wiek = -1;
    vector<tosoba> baza2;
    for (int i = 0; i < n; i++)
    {
        baza2.push_back(temp);
    }
    
    
    fillStruct(&baza2);
    displayStruct(&baza2);
    
    sort(baza2.begin(),baza2.end(),&compareName);
    displayStruct(&baza2);
    
    baza2.clear();
}
