#include <iostream>
using namespace std;

int silnia(int valueSilnia){
    if(valueSilnia>0){return valueSilnia*silnia(valueSilnia-1);}
    else return 1;
}

int main()
{
    cout <<"Silnia z 5 to "<< silnia(5);
    return 0;
}
