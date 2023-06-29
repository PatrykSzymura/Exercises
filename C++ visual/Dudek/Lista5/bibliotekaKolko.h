#include <iostream>
#include <time.h>
#include <vector>
#include <cmath>
#include <algorithm>

using namespace std;
using vInt = vector<vector<int>>;

//Funkcja rezerwuje miejsce na macierz 
//o określonych wymiarach 
vInt createPlansza(int rows, int cols) {
    // Tworzenie wektora wierszy
    vInt matrix(rows);
    
    // Dla każdego wiersza, tworzenie wektora kolumn o rozmiarze cols
    for (int i = 0; i < rows; i++) {
        matrix[i] = vector<int>(cols);
    }
    
    // Zwracanie utworzonej macierzy
    return matrix;
}

// funkcja wyswietla planszę
void displayPlansza(vInt plansza){
    system("cls");

    for (vector<int> x : plansza)
    {
        for (int y : x)
        {
           
            if      (y ==  1) cout << "|x" ;
            else if (y == -1) cout << "|o";
            else if (y ==  0) cout << "| "; 
            else cout << y;
        }
        cout << "|" << endl;
    } 
}

/*  Funkcja pyta się gracza czy chce zagrac ponownie
    zwraca:
    true  jeśli tak
    false jeśli nie
*/
bool czyPonownie(){
    char choice = 0;

    cout << "czy chcesz grać ponownie? T/N ";
    cin  >> choice;
    
    if      (choice == 'T' || choice == 't') return true;
    else if (choice == 'N' || choice == 'n') return false;
    else return false;
}

/*
    sprawdza czy użytkownik może postawić w danym
    miejscu znak. Zwraca: 
    TRUE  jeśli można, 
    FALSE jeśli nie można
*/
bool canIput(vInt plansza,int col,int row){
    if (row >= plansza.size() || col >= plansza.size()) return false;
    else if (plansza[col][row] != 0) return false;
    else return true; 
}

/* funkcja przyjmije jako argument nr tury i na
    jego bazie decyduje który gracz w danym momencie
    wykonuje ruch i wyświetla stosowny komunikat 
*/
int whoPlays(int turn){
    if      (turn % 2 == 0) {cout << "Gdzie chcesz dac x "; return  1;}
    else if (turn % 2 == 1) {cout << "Gdzie chcesz dac o "; return -1;}
    return 0;
}

/*
    funkcja przyjmuje jako argument macierz 
    typu vector<vector<int> i zwraca czy dany
    gracz spełnił warunek do wygrania gry
    Zwraca True lub False;
*/
bool winVertical(vInt plansza){
    int sum    = 0,
        size   = plansza.size(),
        checkX = 0,
        checkO = 0,
        warunek= size - 2;

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            //sum += plansza[i][j];
            if(plansza[i][j] == 1) checkX++;
            else checkX = 0;

            if(plansza[i][j] ==-1) checkO++;
            else checkO = 0;

            if      ((checkO ==3 || checkX == 3) && size == 3)             break;
            else if ((checkO == warunek || checkX == warunek) && size > 3) break;
        }
        //if      (abs(sum) == 3 && size == 3) break;
        //else if (abs(sum) == size - 2 && size > 3) break;
        if      ((checkO ==3 || checkX == 3) && size == 3)             break;
        else if ((checkO == warunek || checkX == warunek) && size > 3) break;
        checkO = 0;
        checkX = 0;       

        sum = 0;
    }
    //if (abs(sum) == 3 && size == 3) return true;
    //if (abs(sum) == size - 2 && size > 3) return true;
    if      ((checkO ==3 || checkX == 3) && size == 3)             return true;
    else if ((checkO == warunek || checkX == warunek) && size > 3) return true;
    else return false;
}


/*
    funkcja przyjmuje jako argument macierz 
    typu vector<vector<int> i zwraca czy dany
    gracz spełnił warunek do wygrania gry
    Zwraca True lub False;
*/
bool winHorizontal(vInt plansza){
    int sum    = 0,
        size   = plansza.size(),
        checkX = 0,
        checkO = 0,
        warunek= size - 2;

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            //sum += plansza[i][j];
            if(plansza[j][i] == 1) checkX++;
            else checkX = 0;

            if(plansza[j][i] ==-1) checkO++;
            else checkO = 0;

            if      ((checkO ==3 || checkX == 3) && size == 3)             break;
            else if ((checkO == warunek || checkX == warunek) && size > 3) break;
        }
        //if      (abs(sum) == 3 && size == 3) break;
        //else if (abs(sum) == size - 2 && size > 3) break;
        if      ((checkO ==3 || checkX == 3) && size == 3)             break;
        else if ((checkO == warunek || checkX == warunek) && size > 3) break;
        checkO = 0;
        checkX = 0;

        sum = 0;
    }
    //if (abs(sum) == 3 && size == 3) return true;
    //if (abs(sum) == size - 2 && size > 3) return true;
    if      ((checkO ==3 || checkX == 3) && size == 3)             return true;
    else if ((checkO == warunek || checkX == warunek) && size > 3) return true;
    else return false;
}


bool winDiagonal(vInt plansza){
    int size   = plansza.size(),
        checkX = 0,
        checkO = 0,
        warunek= size - 2;

    for (int i = 0; i < size; i++)
    {
        
        if(plansza[i][i] == 1) checkX++;
        else checkX = 0;

        if(plansza[i][i] ==-1) checkO++;
        else checkO = 0;

        if      ((checkO ==3 || checkX == 3) && size == 3)             break;
        else if ((checkO == warunek || checkX == warunek) && size > 3) break;    
    }
    if      ((checkO ==3 || checkX == 3) && size == 3)             return true;
    else if ((checkO == warunek || checkX == warunek) && size > 3) return true;
    
    checkX = 0;
    checkO = 0;
    
    for (int i = 0; i < size; i++)
    {
        
        if(plansza[i][size-1-i] == 1) checkX++;
        else checkX = 0;

        if(plansza[i][size-1-i] ==-1) checkO++;
        else checkO = 0;

        if      ((checkO ==3 || checkX == 3) && size == 3)             break;
        else if ((checkO == warunek || checkX == warunek) && size > 3) break;    
    }

    if      ((checkO ==3 || checkX == 3) && size == 3)             return true;
    else if ((checkO == warunek || checkX == warunek) && size > 3) return true;
    else return false;
}



// funkcja sprawdza czy jest miejsce na planczy na znak
// jesli nie ma miejsca zwraca true
bool remis(vInt plansza){
    int sum = 0;
    for(vector<int> x : plansza)
        for(int y : x) sum += abs(y);
    
    if (pow(plansza.size(),2) == sum) return true;
    else return false;
}

vInt botPlayer(vInt plansza,int turn){
    int x    = 0, 
        y    = 0,
        i    = 0,
        size = plansza.size();
    vInt temp;

        do{
            do
            {
                temp = plansza;
                x = rand()%size;
                y = rand()%size;
            } while (!canIput(plansza,x,y));
            i++;
            temp[x][y] = turn+1;
        } while(winDiagonal(temp) || winHorizontal(temp) || winVertical(temp) || remis(temp));
/*     }else if( turn > size - 2 && size > 3){
        do{
            do
            {
                temp = plansza;
                x = rand()%size;
                y = rand()%size;
            } while (!canIput(plansza,x,y));
            i++;
            temp[x][y] = turn+1;
        } while(winDiagonal(temp) || winHorizontal(temp) || winVertical(temp) || remis(temp)); */

    
    plansza[x][y] = whoPlays(turn);
    
    return plansza;
} 




void gamePlay2Players(int n,bool przekatne){
    int turn = 0,
        x    = 0,
        y    = 0,
        znak = 0;
    bool    winH,winV,rem,winD;
    vInt plansza = createPlansza(n,n);
    //plansza = {{0,1,1},{0,1,1},{1,0,1}};
    
    do
    {
        displayPlansza(plansza);
        do
        {
            znak = whoPlays(turn);
            cin >> x >> y;
        } while (!canIput(plansza,x,y));
        plansza[x][y] = znak;

        turn++;

        winH = winHorizontal(plansza);
        winV = winHorizontal(plansza);
        rem = remis(plansza);
        if(przekatne == true) winD = winDiagonal(plansza);
        else winD = false;
    }while ( !winD && !winH && !winV && !rem);
    //} while (!winH && !rem && !winV);

    displayPlansza(plansza);
    turn--;

    if(remis(plansza) == true && !winD && !winH && !winV)  cout << "remis    \n";
    else if (turn % 2 == 0)   {cout << "wygrana x\n";}
    else if (turn % 2 == 1)   {cout << "wygrana o\n";}
}

void gamePlaySingle(int n,bool przekatne){
    int turn = 0,
        x    = 0,
        y    = 0,
        znak = 0;
    bool    winH,winV,rem,winD;
    vInt plansza = createPlansza(n,n);
    //plansza = {{0,1,1},{0,1,1},{1,0,1}};
    
    do
    {
        displayPlansza(plansza);
        if(turn%2==1){
            do
            {
                znak = whoPlays(turn);
                cin >> x >> y;
            } while (!canIput(plansza,x,y));
            plansza[x][y] = znak;
        }else if(turn % 2 == 0){
            plansza = botPlayer(plansza,turn);
        }
        turn++;
        displayPlansza(plansza);
        
        cout << endl;
        winH = winHorizontal(plansza);
        winV = winHorizontal(plansza);
        rem = remis(plansza);
        if(przekatne == true) winD = winDiagonal(plansza);
        else winD = false;

    }while (!winDiagonal(plansza) && !winH && !winV && !rem);
    //} while (!winH && !rem && !winV);

    displayPlansza(plansza);
    turn--;

    if(remis(plansza) == true && !winD && !winH && !winV)  cout << "remis    \n";
    else if (turn % 2 == 0)   {cout << "wygrana x\n";}
    else if (turn % 2 == 1)   {cout << "wygrana o\n";}
}