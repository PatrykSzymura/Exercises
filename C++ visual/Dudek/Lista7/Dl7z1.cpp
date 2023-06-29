#include <iostream>
#include <vector>
#include <time.h>
#include <algorithm>
#include "testlib.h"

using namespace std;
using vInt = vector<int>;

int main(int argc, char const *argv[])
{
    srand(time(NULL));
    vInt tab;
    tab.resize(20);

    for (int i = 0; i < tab.size(); i++)
        tab[i] = (rand() % 90) + 10 ;

    for (int i = 0; i < tab.size(); i++)
        cout <<"|" << tab[i];
    
    cout << "\n";
    cout << "Minimalna: "<< math::minimalna(tab)  << endl
         << "Maxymalna: "<< math::maksymalna(tab) << endl
         << "Średnia  : "<< math::srednia(tab)    << endl
         << "Mediana  : "<< math::mediana(&tab)   << endl
         << "Dominanta: "<< math::dominanta(tab)  << endl;

        for (int i = 0; i < tab.size(); i++)
            cout <<"|" << tab[i];
    return 0;
} 
