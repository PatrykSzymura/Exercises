#include <iostream>
#include <time.h>
using namespace std;

int main(int argc, char const *argv[])
{
    // zmien pododejscie na ile czekamy i otzrymujemy wartosc
    float   value = 0,
            proc  = 0,
            time  = 0,
            wait  = 0,
            i     = 0,
            kStart= 0;

    cout << "kwota poczatkowa: ";            
    cin  >> value;

    

    cout << "procent w skali roku: ";     
    cin  >> proc;
    cout << "ilosc kapitalizacji w roku: ";      
    cin  >> time;


    
    for( i = 1; i <= time; i ++){
        value += value*((proc/100)/time);
    
    }
    cout << value;
    //cout << "kwota " << wait << "zl zostanie osiagnieta w czasie " << i<< " miesiecy" << endl;

    return 0;
}
