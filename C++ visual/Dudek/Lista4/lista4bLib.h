#include <vector>
#include <iostream>
#include <time.h>
using namespace std;
using vInt = vector<vector<int>>;

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

void displayMatrix(vInt tab){
    for (vector<int> vect1D : tab)
    {
        for (int x : vect1D)
        {
            printf("|%3d",x);
        }    
        cout << "|" << endl;
    }
}

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
