#include <iostream>
#include <fstream>
#include <time.h>
using namespace std;

void createFiles(int who, char list ,int amount){
    fstream newFile; 

    char fName[10] = "0l0z0.cpp";
    fName[2] = list;

    if (who == 1)
        fName[0] = 'H';
    else
        fName[0] = 'D';

    for (int i = 1; i <= amount; i++)
    {
        fName[4] = 48+i;
        newFile.open(fName,ios::out);
    }
    
}

int main(int argc, char const *argv[])
{
    int choice,
        amout;
    char list;
    cout << " ===Wykladowca=== \n  [1]_HALIK_[1] \n  [2]_DUDEK_[2] \n";
    cin  >> choice;
    cout << " ======Lista=====\n";
    cin  >> list;
    cout << " ===IloscZadan===\n";
    cin  >> amout;

    createFiles(choice,list,amout);

    return 0;
}