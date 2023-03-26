#include <iostream>
#include <time.h>
using namespace std;

void line(int loop,string mark){
    if (loop >= 0){
        cout << mark;
        line(loop-1,mark);
    }else{ cout << endl; return;}
}

void zad1();
void zad2();
void zad3();
void zad4();
void zad5();
void zad6();

int silnia(int valueSilnia);

void gwiazdki(int x, int y);

int fibonacci(int limit);

int highest(int array[],int size, int high);
void fillArr(int arr[],int loop);
void displayArr(int arr[],int count);

int nwd(int num1, int num2);

void hanujka(int n, char z, char na,char pomoc);

void menu();

int main(){
    srand(time(NULL));
    
    //line(150,"=");
 
    menu();

   //line(150,"=");

}

void menu(){
    int zad = 0;

    line(150,"=");

    cout << "Wybierz zadanie z listy(1-6): ";
    cin >> zad;

    switch (zad)
    {
    case 1:
        line(150,"=");
        zad1();
        menu();
        break;
    case 2:
        line(150,"=");
        zad2();
        menu();
        break;
    case 3:
        line(150,"=");
        zad3();
        menu();
        break;
    case 4:
        line(150,"=");
        zad4();
        menu();
        break;
    case 5:
        line(150,"=");
        zad5();
        menu();
        break;
    case 6:
        line(150,"=");
        zad6();
        menu();
        break;
    default:
        break;
    }
}

/*  
    Zadanie 1.
    Napisz program wykorzystujący funkcję rekurencyjną do obliczenia wartość silni dla wprowadzonej z
    klawiatury liczby N. Liczba N może być liczbą całkowitą z przedziału <0,10>.
*/  
void zad1(){
    int numberInput = 0;
    cout << "Podaj liczbe by obliczyc silnie: ";
    cin  >> numberInput;
    if (numberInput > 10 && numberInput < 0){
        cout << "Liczba nie jest z przedziału <0,10> " << endl;
        zad1();
        return;
    }
    
    cout << "Silnia z " << numberInput << " to " << silnia(numberInput) << "\n";
};

int silnia(int valueSilnia){
    if(valueSilnia>0){return valueSilnia*silnia(valueSilnia-1);}
    else return 1;
}

/*    
    Zadanie 2.
    Napisz program rysujący obiekt z gwiazdek dla N wprowadzonego przez użytkownika z klawiatury.
    Rysowanie obiektu powinno odbywać się z wykorzystaniem funkcji rekurencyjnych. (w programie nie
    można użyć pętli !).
*/
void zad2(){
    int numberInput = 0;
    cout << "Podaj liczbe by narysowac trojkat: ";
    cin  >> numberInput;
    gwiazdki(numberInput-1,numberInput-1); 
};

void gwiazdki(int x, int y){
    if ( x >= 0 ){
        cout << "*";
        gwiazdki(x-1,y);  
    }else{
        cout << "\n";
        if (y >= 0 ){
            gwiazdki(y-1,y-1); 
        }else return;
    } ;
}

/*
    Zadanie 3.
    Napisz program wykorzystujący funkcję rekurencyjną do obliczenia N-tego elementu ciągu Fibonacciego.
    Wartość N ma być liczbą całkowitą podaną przez użytkownika z klawiatury.
*/
void zad3(){
    int numberInput = 0;
    cout << "Podaj liczbe w ciagu fibonacci-ego: ";
    cin  >> numberInput;
    cout << "Liczba w ciagu nr." << numberInput << " to " << fibonacci(numberInput) << "\n";
};

int fibonacci(int limit){
    if (limit <= 1){
        return limit;
    }
    return fibonacci(limit - 1) + fibonacci(limit - 2);
}

/*
    Zadanie 4.
    Napisz program wykorzystujący funkcję rekurencyjną, która przeszukuje zdefiniowaną (i wypełnioną
    losowymi wartościami z zakresu <0,100> ) tablicę jednowymiarową 50 elementową będącą parametrem
    wywołania funkcji, oraz zwraca informację o maksymalnym elemencie tablicy.
*/
void zad4(){
    int sizeArr      = 50,
        tab[sizeArr] = {0};
    cout << "Losowa tablica: " << endl;
    
    fillArr(tab,sizeArr);
    displayArr(tab,sizeArr);

    cout << endl << "Najwiekszy element z tablicy: " << highest(tab,50,0) << endl;
    
};

int highest(int array[],int size, int high){
    if (size >= 0)
    {
        if (array[size-1] > high)
        {
            high = array[size-1];
        }
       highest(array,size-1,high); 
    }else return high;
}

void fillArr(int arr[],int loop){
    //srand(time(NULL));
    if (loop >= 1){
        arr[loop-1] = rand() % 100;
        fillArr(arr,loop-1);
    }return;
    
}

void displayArr(int arr[],int count){
    if (count <= 0){
        return;}
    else{
        displayArr(arr,count-1);
        cout << " " << arr[count-1];
    } 
}

/* 
    Zadanie 5.
    Napisz program wykorzystujący funkcję rekurencyjną, która oblicza maksymalny wspólny dzielnik
    dwóch liczb wprowadzonych z klawiatury, będących parametrami wywołania funkcji. 
*/
void zad5(){
        int numberInput0 = 0;
        int numberInput1 = 0;
    cout << "Podaj liczby do obliczenia NWD: ";
    cin  >> numberInput0 >> numberInput1;
    cout << "NWD " << numberInput0 << " i " << numberInput1 << " to " << nwd(numberInput0,numberInput1) <<endl;
};

int nwd(int num1, int num2){
    if (num1 == 0)
        return num2;
    return nwd(num2 % num1, num1);
}

/* 
    Zadanie 6.
    Wieża Hanoi:
        Według legendy w pewnej świątyni buddyjskiej w Hanoi siedzą mnisi i przekładają 64 złote krążki z
        jednego stosu na drugi. Krążki są kolejno coraz mniejsze, a problem polega na tym, że podczas
        przekładania po jednym krążku nie można położyć krążka większego na mniejszy istnieje więc stos
        pomocniczy. Zgodnie z legendą w chwili położenia ostatniego krążka nastąpi koniec świata. Nie ma się
        jednak czego obawiać, gdyż nawet gdyby robili to w tempie jeden ruch na sekundę, to i tak nie zdążyliby
        przed zgaśnięciem naszego słońca. Inaczej mówiąc są 3 drążki A, B i C i danych jest n krążków
        umieszczonych jeden na drugim, w porządku rosnących średnic, na drążku A. Zadanie polega na
        przeniesieniu wszystkich krążków w na drążek B z wykorzystaniem ew. pomocniczego drążka C. Przy
        tym, zawsze musi być zachowana zasada: mniejszy krążek leży na większym (porządek rosnący).
        Problem ten jest dosyć złożony, ale łatwo jest sformułować dla niego rozwiązanie rekurencyjne: W celu
        przełożenia n krążków ze stosu A na B, należy najpierw przełożyć n-1 krążków ze stosu A na stos
        pomocniczy, przenieść n -ty największy krążek z A na B, po czym przełożyć n-1 krążków ze stosu
        pomocniczego na stos B. Napisz program, który dla zadanej liczby krążków n rozwiązuje problem wież
        Hanoi. 
*/
void zad6(){
    int numberInput = 0;
    
    cout << "Podaj liczbe krazkow do hanojki: ";
    cin  >> numberInput;
    hanujka(numberInput,'A','C','B');
};

void hanujka(int n, char z, char na,char pomoc)
{
    if (n == 0) {
        return;
    }
    hanujka(n - 1, z, pomoc, na);
    cout << "Dysk " << n << " z " << z << " na " << na << endl;
    hanujka(n - 1, pomoc, na, z);
}