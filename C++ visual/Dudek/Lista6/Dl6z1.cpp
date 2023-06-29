#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include "Dl6z1.h"
#include "functions.h"
using namespace std;

void createPlansza(vector<pole*> &board);

void opisy(vector<pole*> &board){
    ifstream file("dane");

    if (file.is_open()) {
        string line;
        while (getline(file, line)) {
            size_t pozycja = line.find("#");
            if (pozycja != string::npos) {
                string name = line.substr(0, pozycja);
                string description = line.substr(pozycja + 1);
                
            }
        }

        file.close();
        cout << "Dane zostały wczytane z pliku.\n";
    } else {
        cerr << "Nie można otworzyć pliku do odczytu.\n";
    }

}

void menu(vector<pole*> b){
    cout << "||===============================||" << endl
         << "||           MONOPOLY            ||" << endl
         << "||===============================||" << endl
         << "||                               ||" << endl
         << "||           1.START             ||" << endl
         << "||       2.Pokaz Plansze         ||" << endl
         << "||                               ||" << endl
         << "||===============================||" << endl;
}

int main(int argc, char const *argv[])
{
    vector<pole*> plansza;
    plansza.resize(40);
    createPlansza(plansza);

    int x = 0;

    pole tmp;
    fstream test;
    test.open("dane");
    for (int i = 0; i < plansza.size(); i++)
        test << tmp.name << "#" << i-2 << "\n";
    test.close();

    //opisy(plansza);

    //menu(plansza);

    cin >> x;
    
    return 0;
}

void createPlansza(vector<pole*> &board){
    for(int i  = 0; i < board.size(); i++){
        if      (i == 0){
            start *field = new start;
            
            board[i] = field;
        }
        else if (i == 7 || i  == 22 || i == 36){
            chance *szansa = new chance;
            board[i] = szansa;
        }
        else if (czyMiasto(i))
        {
            miasto *city = new miasto;
            board[i] = city;
        }
        else 
        {
            chance *szansa = new chance;
            board[i] = szansa;
        } 
    }
}