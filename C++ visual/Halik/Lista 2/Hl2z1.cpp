#include <iostream>
#include <time.h>
using namespace std;

void fillArr(int arr[],int loop);

int main()
{
    srand(time(NULL));
    int arr[10] = {0};

    fillArr(arr,10);

    for (int i = 0; i < 10; i++)
    {
        cout << *(&(arr[0])+i) << " ";
    }
    cout << endl;
    for (int i = 0; i < 10; i++)
    {
        cout << arr[i] <<" ";
    }
    
  return 0;
}

void fillArr(int arr[],int loop){
    //srand(time(NULL));
    if (loop >= 1){
        arr[loop-1] = rand() % 100;
        fillArr(arr,loop-1);
    }return;
    
}
