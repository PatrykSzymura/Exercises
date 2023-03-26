#include <vector>
#include <iostream>
#include <time.h>
using namespace std;
using vInt = vector<vector<int>>;

//Funkcja rezerwuje miejsce na macierz 
//o określonych wymiarach 
vInt createMatrix(int rows, int cols) {
    // Tworzenie wektora wierszy
    vInt matrix(rows);
    
    // Dla każdego wiersza, tworzenie wektora kolumn o rozmiarze cols
    for (int i = 0; i < rows; i++) {
        matrix[i] = vector<int>(cols);
    }
    
    // Zwracanie utworzonej macierzy
    return matrix;
}

//Wyświtla macierz
void displayMatrix(vInt tab){
    char krzyzyk = 'X',
         kolko   = 'O';
    for (vector<int> vect1D : tab)
    {
        for (int x : vect1D)
        {
             if (x == 1)
            {
                printf("|%2c ",krzyzyk);
            }
            else if(x == -1)
            {
                printf("|%2c ",kolko); 
            }else{
                //printf("|%2d ",x);
                printf("|   ");
            }
        }    
        cout << "|" << endl;
    }
}

/*
    Funkcja zwraca macierz wypełnioną losowo 
    lub przez użytkownika
    "random" - dla losowych
    "user" - dla podanych przez użytkownika
*/
vInt fillMatrix(vInt tab,string mode){
    int size  = tab.size();
    if(mode == "user"){
        int number = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                cin >> number;
                tab[i][j]  = number;
            }
        } 
    }else if (mode == "random")
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                tab[i][j]  = rand()%8+1;
            }
        }
    }
    return tab;
}

/*
    funkcja zwraca macierz będąco suma
    2 macierzy m1 i m2
*/
vInt addMatrix(vInt m1,vInt m2){
    int size = m1.size();

    vInt resultMatrix = createMatrix(size,size);

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            resultMatrix[i][j] = m1[i][j] + m2[i][j];
        }
    }
    return resultMatrix;
}

/*
    Zwraca macierz będącą różnica m1 i m2
*/
vInt subtractMatrix(vInt m1,vInt m2){
    int size = m1.size();
    vInt resultMatrix = createMatrix(size,size);
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            resultMatrix[i][j] = m1[i][j] - m2[i][j];
        }
        
    }
    return resultMatrix;
}

// Zwraca macierz będącą ilorazem m1 i m2
vInt multiplyMatrix(vInt m1,vInt m2){
    int size = m1.size(),
        temp = 0;
    vInt resultMatrix = createMatrix(size,size);
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            for (int k = 0; k < size; k++)
            {
                temp = temp + m1[i][k] * m2[k][j];
            }
            resultMatrix[i][j] = temp;
            temp = 0;
            //cout << temp << "\t";
        }
        //cout<< endl;
    }
    return resultMatrix;
}

// zwraca macierz z dopełnieniem do dop
vInt dopelnienie(vInt m1,int dop){
    int size = m1.size();
    vInt m2 = m1;
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            m2[i][j] = dop - m1[i][j];
        }
    } 
    return m2;
}

/*
    funkcja sprawdza czy ilość wystąpień jest wystarczjąca
    do wygranej danego znaku
        -1 dla wygranej 0
         1 dla wygranej X
         0 dla braku wygranej obu znaków
*/
int verifyCheckers(int sizePlansza,int x,int o){
    int who = 0;
    if(sizePlansza == 3){
        if      (x == 3 ) who =  1;
        else if (o == 3 ) who = -1;
        else              who =  0;
    }   else{
        if      (x >= sizePlansza-2 ) who =  1;
        else if (o >= sizePlansza-2 ) who = -1;
        else                          who =  0;   
    }
    return who;
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

/*
    Sprawdzenie ilosci wystapien w kolumnie X lub O dla rozmiarów planszy
    jeśli zgadza się ilość wystąpień pod rząd X lub O zwraca wartość -1 lub 1
       -1 dla wygranej 0
        1 dla wygranej X
        0 dla braku wygranej obu znaków
*/
int checkCol(vInt plansza){
    int sizePlansza = plansza.size(),
        who         = 0,
        checkerX    = 0,
        checker0    = 0;

    for (int nrCol = 0; nrCol < sizePlansza; nrCol++)
    {
        for (int j = 0; j < sizePlansza; j++)
        {
            //cout << "j:" << j << " nrCol:" << nrCol << " v:" << plansza[j][nrCol] << endl;
            // sprawdzanie X
            if(plansza[j][nrCol] == 1) checkerX++;
            else checkerX = 0;

            // sprawdzanie 0
            if(plansza[j][nrCol] ==-1) checker0++;
            else checker0 = 0; 
        }
    }
    /*
      Sprawdzenie ilosci wystapien w kolumnie X lub O dla rozmiarów planszy
      jeśli zgadza się ilość wystąpień pod rząd X lub O zwraca wartość -1 lub 1
       -1 dla wygranej 0
        1 dla wygranej X
        0 dla braku wygranej obu znaków
    */
    
    return verifyCheckers(sizePlansza,checkerX,checker0); 
}

/*
    Sprawdzenie ilosci wystapien w wierszu X lub O dla rozmiarów planszy
    jeśli zgadza się ilość wystąpień pod rząd X lub O zwraca wartość -1 lub 1
       -1 dla wygranej 0
        1 dla wygranej X
        0 dla braku wygranej obu znaków
*/
int checkRow(vInt plansza){
    int sizePlansza = plansza.size(),
        checkerX = 0,
        checker0 = 0,
        check = 0;

    for (int i = 0; i < sizePlansza; i++) {
        for (int j = 0; j < sizePlansza; j++) {

            // sprawdzanie X
            if(plansza[i][j] == 1) checkerX++;
            else checkerX = 0;

            // sprawdzanie 0
            if(plansza[i][j] ==-1) checker0++;
            else checker0 = 0;
        }

        check = verifyCheckers(sizePlansza,checkerX,checker0);

        if (check != 0) break;
    }
    return verifyCheckers(sizePlansza,checkerX,checker0);
}

/*
    Finkcja spradza kto wygrał grę
    Zwraca :
     -1 dla wugranej 0
      1 dla wygranej X
      0 dla nikogo
*/
int winGame(vInt plansza){
    int who = 0;    //tao

    switch (checkCol(plansza))
    {
        case -1:
            who = -1;
            break;
        case 1:
            who = 1;
            break;
    }

    if (who != 0) return who; // tao
    
    switch (checkRow(plansza)){    
        case -1:
            who = -1;
            break;
        case 1:
            who = 1;
            break;
    }

    if (who != 0) return who; // tao

    // dodac spradzanie po skosie
    
    return who;
}
