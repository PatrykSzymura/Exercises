#include <iostream>
#include <vector>
#include <time.h>
using namespace std;

int main(){
    srand(time(NULL));

    int    n = 4,temp  = 0;
    int    *adressInt    = new int;
    double *adressDouble = new double;
    float  *adressfloat  = new float;
    vector<int> adressIntTab;
    for (int i = 0; i < n; i++)
    {
      adressIntTab.push_back(temp);
    }
    

    *adressInt    = rand() % 100;
    *adressDouble = rand() % 100;
    *adressfloat  = rand() % 100;
    cout <<  adressInt << " " <<  adressDouble << " " <<  adressfloat << " " << endl;
    cout << *adressInt << " " << *adressDouble << " " << *adressfloat << " " << endl;

    //*adressTab
    

  return 0;
}