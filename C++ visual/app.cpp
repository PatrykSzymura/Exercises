#include <iostream>
#include <time.h>
#include <stdlib.h>

int main(){
    int array[105];
    for (int i = 0; i < 105; ++i)
        array[i] = i + 1;
        std::mt19937_64 mt;
        std::shuffle(std::begin(array), std::end(array), mt);
    for (int i = 0; i < 100; ++i)
        std::cout << array[i] << '\n';
}