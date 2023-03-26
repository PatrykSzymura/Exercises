#include <iostream>
#include <time.h>



using namespace std;

void    fillArray(int tab[],int size){
    int randomN = rand()%60+10;
    for (int i = 0; i < size; i++){ tab[i] = randomN + i; }
}

void displayArray(int tab[],int size){
    cout << " Pozycja -> |";

    for (int i = 0; i < size; i++){ printf("%2d|",i); }

    cout << endl << " Wartosc -> |";

    for (int i = 0; i < size; i++){ cout << tab[i] << "|"; }

    cout << endl;
}

auto   lowestValue(int tab[],int size,int getBack[2][2]){
    //int getBack[2][2];
    // najmniejszy element
    int lowest  = tab[size-1];
    
    for (int i = 0; i < size; i++) 
    {
        if (lowest > tab[i] ) {
            lowest  = tab[i];
            getBack[0][0] = lowest;
            getBack[0][1] = i;
        }
    }
    

    //najwiekszy element
    int highest  = tab[0];
    
    for (int i = 0; i < size; i++)
    {
        if (highest < tab[i] ) {
            highest = tab[i];
            getBack[1][0] = highest;
            getBack[1][1] = i;
        }
    }

    //return &getBack;
}



int positionValue(int tab[],int size,int search){
    for (int i = 0; i < size; i++)
    {
        if (search == tab[i])
        {
            return i;
        }
    }
}

int averageValue(int tab[],int size){
    int avg = 0;
    for (int i = 0; i < size; i++)
    {
        avg +=tab[i];
    }
    return avg/size;
}

int main(int argc, char const *argv[])
{
    srand(time(NULL));

    int tablica[15]   = {0},
        search        = 0,
        tabSize       = 15,
        szukane[2][2] = {0};

    fillArray(tablica,tabSize);
    displayArray(tablica,tabSize);
    
    lowestValue(tablica,tabSize,szukane);

    //cout << endl << szukane[0][0] << " " << szukane[0][1] << endl;
    //cout << endl << szukane[1][0] << " " << szukane[1][1] << endl;
    

    cout << endl << "Najmniejsza wartosc: " << szukane[0][0] << " pozycja: " << szukane[0][1];
    cout << endl << "Najwieksza  wartosc: " << szukane[1][0] << " pozycja: " << szukane[1][1];
    cout << endl << "    Srednia wartosc: " << averageValue(tablica,tabSize);
    cout << endl << "      Podaj wartosc: ";
    cin  >> search;
    cout << "    Szukana wartosc: " << search << " pozycja: " << positionValue(tablica,tabSize,search);
    return 0;
}

