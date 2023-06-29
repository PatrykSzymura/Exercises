#include <iostream>

using namespace std;

struct drzewo
{
    int Value;
    drzewo *mniejsza;
    drzewo *wieksza;
    drzewo *poprzedni;
};

// Funkcja tworząca nowy węzeł drzewa
drzewo* NowyWezel(int value)
{
    drzewo* wezel = new drzewo();
    wezel->Value = value;
    wezel->mniejsza = NULL;
    wezel->wieksza = NULL;
    wezel->poprzedni = NULL;

    return wezel;
}

// Funkcja dodająca węzeł do drzewa
drzewo *DodajWezel(drzewo* korzen, int value)
{
    // Jeśli drzewo jest puste, tworzymy nowy korzeń
    if (korzen == NULL)
    {
        return NowyWezel(value);
    }

    // W przeciwnym wypadku dodajemy węzeł do drzewa
    if (value < korzen->Value)
    {
        korzen->mniejsza = DodajWezel(korzen->mniejsza, value);
        korzen->mniejsza->poprzedni = korzen;
    }
    else if (value > korzen->Value)
    {
        korzen->wieksza = DodajWezel(korzen->wieksza, value);
        korzen->wieksza->poprzedni = korzen;
    }

    return korzen;
}

// Funkcja usuwająca węzeł z drzewa
drzewo* UsunWezel(drzewo* korzen, int value)
{
    // Jeśli drzewo jest puste, zwracamy NULL
    if (korzen == NULL)
    {
        return NULL;
    }

    // Szukamy węzła do usunięcia
    if (value < korzen->Value)
    {
        korzen->mniejsza = UsunWezel(korzen->mniejsza, value);
    }
    else if (value > korzen->Value)
    {
        korzen->wieksza = UsunWezel(korzen->wieksza, value);
    }
    else
    {
        // Jeśli węzeł ma co najwyżej jedno dziecko, usuwamy go
        if (korzen->mniejsza == NULL)
        {
            drzewo* temp = korzen->wieksza;
            delete korzen;
            return temp;
        }
        else if (korzen->wieksza == NULL)
        {
            drzewo* temp = korzen->mniejsza;
            delete korzen;
            return temp;
        }

        // Jeśli węzeł ma dwoje dzieci, znajdujemy następnik inorder
        drzewo* temp = korzen->wieksza;
        while (temp && temp->mniejsza != NULL)
        {
            temp = temp->mniejsza;
        }

        // Zamieniamy wartość usuwanego węzła z wartością następnika inorder
        korzen->Value = temp->Value;

    // Usuwamy następnika inorder
    korzen->wieksza = UsunWezel(korzen->wieksza, temp->Value);
    }

    return korzen;
}

// Funkcja wyświetlająca drzewo metodą inorder
void Inorder(drzewo* korzen){
    if (korzen != NULL){
        Inorder(korzen->mniejsza);
        cout << korzen->Value << " ";
        Inorder(korzen->wieksza);
    }
}

// Funkcja wyświetlająca drzewo metodą postorder
void Postorder(drzewo* korzen){
    if (korzen != NULL){
        Postorder(korzen->mniejsza);
        Postorder(korzen->wieksza);
        cout << korzen->Value << " ";
    }
}

// Funkcja wyświetlająca drzewo metodą preorder
void Preorder(drzewo* korzen)
{
    if (korzen != NULL){
        cout << korzen->Value << " ";
        Preorder(korzen->mniejsza);
        Preorder(korzen->wieksza);
    }
}
void menu(drzewo* korzen){
    int choice = 0,
        value  = 0;
    cout << "_____________________________________" << endl;
    if(korzen == NULL)
    cout << "|          PUSTE DRZEWO             |" << endl;
    else{
    cout << "|" ;
        Inorder(korzen);
    cout << "|" << endl;
    }
    cout << "|___________________________________|" << endl
         << "| Wybierz Funkcje:                  |" << endl 
         << "|___________________________________|" << endl
         << "|  1. Dodaj liczbe                  |" << endl
         << "|  2. Usuń liczbe                   |" << endl
         << "|  3. Inorder                       |" << endl
         << "|  4. Postorder                     |" << endl
         << "|  5. Preorder                      |" << endl
         << "|___________________________________|" << endl;
    cin  >> choice;

    switch (choice)
    {
    case 1:
        cout << "Podaj liczbe: ";
        cin  >> value;
        korzen = DodajWezel(korzen, value);
        menu(korzen);
        break;
    case 2:
        cout << "Podaj liczbe: ";
        cin  >> value;
        korzen = UsunWezel(korzen, value);
        menu(korzen);
        break;
    case 3:
        cout << "Inorder: ";
        Inorder(korzen);
        cout << endl;
        menu(korzen);
        break;
    case 4:
        cout << "Postorder: ";
        Postorder(korzen);
        cout << endl;
        menu(korzen);
        break;
    case 5:
        cout << "Preorder: ";
        Preorder(korzen);
        cout << endl;
        menu(korzen);
        break;
    default:
        break;
    }
}

int main(int argc, char const *argv[])
{
    drzewo* korzen = NULL;
    menu(korzen);
    return 0;
}

