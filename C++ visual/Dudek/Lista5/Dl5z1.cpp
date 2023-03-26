#include <iostream>
#include <time.h>
#include <vector>
#include "lista5bLib.h"

using namespace std;

void game2Players(int sizePlansza){
    vInt plansza = createMatrix(sizePlansza,sizePlansza);
    int i   = 0,
        col = 0,
        row = 0,
        insert = 0,
        whoWins = 0;
    do
    {
        displayMatrix(plansza);
        do
        {
        cout << "Gdzie chcesz dać ";

        if      (i % 2 == 0){ cout << "X ? ";insert =  1;}
        else if (i % 2 == 1){ cout << "O ? ";insert = -1;}
        cin >> col >> row;  
        cout << plansza[row][col]<< endl; 

        } while (!canIput(plansza,row,col));// jeśli nie moge postawić spytaj się ponownie
        plansza[row][col] = insert;
        i++;
    } while (0 == winGame(plansza));
    displayMatrix(plansza);
    whoWins = winGame(plansza);  
    if      (whoWins == -1) cout << "wygrana O";
    else if (whoWins ==  1) cout << "wygrana X";
    else                    cout << "nikt nie wygral " << whoWins;
}

int main(int argc, char const *argv[])
{
    srand(time(NULL));
    game2Players(5);

    
    return 0;
}
