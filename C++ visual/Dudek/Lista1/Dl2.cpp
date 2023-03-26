#include <iostream>
#include <string>
#include <cmath>
/*
    1. doluz stozek sciety
    2.ignoruj z poza zakresu 1-6 i nie używa sloty
    3.pusty czy pelny
    4.
*/
using namespace std;

void line(int loop,string mark){
    if (loop >= 0){
        cout << mark;
        line(loop-1,mark);
    }else{ cout << endl; return;}
}

void kula();
void prostopadloscian();
void stozek();
void scienty();

void zad1();
void zad2();
void zad3();
void zad4();

void menu();

int main(){
    
    menu();
    //zad4();
}
void menu(){
    int zad = 0;

        line(150,"=");

        cout << "Wybierz zadanie z listy(1-4): ";
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
        default:
            break;
    }
}

/* 
    Zadanie 1 (6 pkt.)
    Napisz program obliczający i drukujący na ekranie objętości i pola powierzchni następujących brył:
    a) kuli
    b) prostopadłościanu
    c) stożka
    (Pamiętaj, że użytkownik decyduje o wyborze bryły, a o niezbędne wymiary (i tylko niezbędne)
    program pyta później) 
*/

void zad1(){
    cout << "podaj bryle \n A. kula \n B. prostopadloscian \n C. stozek \n D.stozek scienty \n";
    string answerType;
    cin >> answerType;

    if      (answerType == "A" || answerType == "a"){kula();}
    else if (answerType == "B" || answerType == "b"){prostopadloscian();}
    else if (answerType == "C" || answerType == "c"){stozek();}
    else if (answerType == "D" || answerType == "d"){scienty();}
    else  {cout << "nie podano bryły" << endl; zad1();}

    return;
}

void kula(){
    float pole     = 0,
          objetosc = 0,
          r        = 0;
    cout << "Podaj r kuli: ";
    cin >> r; 

    objetosc = 4   * 3.14 * (r*r);
    pole     = 4/3 * 3.14 * (r*r*r);
    
    cout << "Pole Kuli: " << pole << endl << "Objetosc Kuli: " << objetosc << endl;
    
}

void prostopadloscian(){
    float pole     = 0,
          objetosc = 0,
          a        = 0,
          b        = 0,
          c        = 0;
    cout << "Podaj krawedzie prostopadloscianu " << endl;
    cin  >> a >> b >> c;
    
    objetosc = a*b*c;
    pole     = 2*(a*b) + 2*(a*c) + 2*(b*c);

    cout << "Pole Prostopadloscianu: " << pole << endl << "Objetosc Prostopadloscianu: " << objetosc << endl;
}

void scienty(){
    float pole     = 0,
          objetosc = 0,
          r        = 0,
          h        = 0,
          R        = 0,
          l        = 0;  
    cout << "Podaj r , R , h stozka scietego: ";
    cin >> r >> R >> h;

    l = sqrt(h*h+pow(R-r,2));
    pole = 3.14*(R+r)*l + 3.14*(R*R+r*r);
    objetosc = (3.14/3)*h*(R*R+R*r+r*r);

    cout << "Pole Stozka: " << pole << endl << "Objetosc Stozka: " << objetosc << endl;

}

void stozek(){
        float pole     = 0,
          objetosc = 0,
          r        = 0,
          h        = 0;
    cout << "Podaj r i h stozka: ";
    cin >> r >> h;

    pole = 3.14*r*r;
    objetosc = (3.14*r*r*h)/3;

    cout << "Pole Stozka: " << pole << endl << "Objetosc Stozka: " << objetosc << endl;
}

/* 
    Zadanie 2 (6 pkt.)
    Napisz program, który pyta o oceny z kilku różnych przedmiotów danego studenta, a następnie liczy
    średnią tych ocen. Sprawdź ponadto, czy studentowi o takiej średniej przysługuje stypendium
    naukowe (jeśli średnia > 4.1). Należy zapytać użytkownika ile ocen chce podać. 
*/

void zad2(){
    float answerAmount,answerSum = 0;
    float answerAvg;
    
    cout << "Podaj ilosc ocen: ";
    cin >> answerAmount;

    for (int i = 0; i < answerAmount; i++)
    {   
        int answerNum = 0;
        cin >> answerNum;
        if (answerNum > 0 && answerNum < 7 )
        {
            answerSum+=answerNum;
        }else i--;        
    }
    answerAvg = answerSum/answerAmount;
    
    cout << "Srednia ocen: " << answerAvg << "\n";

    if (answerAvg >= 4.1){ cout << "Przyznano stypendium naukowe";}
    else                 { cout << "Nieprzyznano Stypendium. Srednia ponizej 4,1";}
}

/* 
    Zadanie 3 (8 pkt.)
    Napisz program, który drukuje piramidkę postaci:
      *
     * *
    * * *
    Głębokość piramidki podaje użytkownik 
*/
void zad3(){
    int z =0 ;
    cout << "podaj wielkosc piramidki";
    cin  >> z;
    //cout << "Storzek pelny czy pusty [1|0]";
    for (int i = z; i >= 0; i--)
    {
        for (int j = 0; j <= z; j++)
        {
            if (j>i){
                cout << "*";
             cout << " ";}
            
        }
        cout <<endl;
    }
}

/* 
    Zadanie 4 (10 pkt.)
    Napisz program, który umożliwi podanie ciągu znaków - jakiegoś zdania a następnie:
    - policzy wszystkich ilość liter, ilość liter z pominięciem spacji, ilość liter z pominięciem
      podanego przez użytkownika znaku
    - wypisze wszystkie wyrazy w zdaniu na ekranie
    - podzieli zdanie w oparciu o podany przez użytkownika znak (np. przecinek), a wynik podziału
      wpisze do dynamicznie powiększanej tablicy napisów (nie korzystamy tutaj z możliwości
      nowego C++, tylko w ramach przypomnienia poprzedniego semestru ręcznie alokujemy
      pamięć na taką konstrukcję). 
*/


void zad4(){
    string text;
    int varSpaceCount = 0,
        varChoiceCharCount = 0;
    char choiceChar;

    cout << "Podaj ciag znakow: ";
    getline(cin,text); 
    cout << "Podaj znak wykluczony z ciagu: ";
    scanf("%c",&choiceChar);

    for (int i = 0; i < text.size(); i++)
    {
        if      (text[i] >= 65 && text[i] <= 90) {varSpaceCount++;}
        else if (text[i] >= 97 && text[i] <= 122){varSpaceCount++;}

        if      (text[i] >= 65 && text[i] <= 90  && text[i] != choiceChar){varChoiceCharCount++;}
        else if (text[i] >= 97 && text[i] <= 122 && text[i] != choiceChar){varChoiceCharCount++;} 
    }

    cout << "Dlugosc bez spacji: " << varSpaceCount << endl;
    cout << "Dlugosc bez " << choiceChar << ": " << varChoiceCharCount << endl;

    for (int i = 0; i < text.size(); i++)
    {
        if      (text[i] >= 65 && text[i] <= 90) {cout << text[i];}
        else if (text[i] >= 97 && text[i] <= 122){cout << text[i];}
        else cout << endl;
    }
}