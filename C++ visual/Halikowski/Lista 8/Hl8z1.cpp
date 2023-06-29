#include <iostream>
#include <fstream>
#include <string>
#include "randomStruct.h"

using namespace std;

struct Abonent {
    string imie;
    string nazwisko;
    string numerTelefonu;
};

struct Node {
    Abonent abonent;
    Node* left;
    Node* right;
    int height;
};

// Funkcja pomocnicza do obliczania wysokości wierzchołka
int getHeight(Node* node) {
    if (node == nullptr)
        return 0;
    return node->height;
}

// Funkcja pomocnicza do obliczania balansu wierzchołka
int getBalance(Node* node) {
    if (node == nullptr)
        return 0;
    return getHeight(node->left) - getHeight(node->right);
}

// Funkcja pomocnicza do utworzenia nowego wierzchołka
Node* createNode(Abonent abonent) {
    Node* newNode = new Node;
    newNode->abonent = abonent;
    newNode->left = nullptr;
    newNode->right = nullptr;
    newNode->height = 1;
    return newNode;
}

// Funkcja pomocnicza do rotacji w prawo
Node* rotateRight(Node* node) {
    Node* newRoot = node->left;
    Node* subtree = newRoot->right;

    newRoot->right = node;
    node->left = subtree;

    node->height = max(getHeight(node->left), getHeight(node->right)) + 1;
    newRoot->height = max(getHeight(newRoot->left), getHeight(newRoot->right)) + 1;

    return newRoot;
}

// Funkcja pomocnicza do rotacji w lewo
Node* rotateLeft(Node* node) {
    Node* newRoot = node->right;
    Node* subtree = newRoot->left;

    newRoot->left = node;
    node->right = subtree;

    node->height = max(getHeight(node->left), getHeight(node->right)) + 1;
    newRoot->height = max(getHeight(newRoot->left), getHeight(newRoot->right)) + 1;

    return newRoot;
}

// Funkcja do wstawiania abonenta do drzewa AVL
Node* insert(Node* root, Abonent abonent) {
    if (root == nullptr)
        return createNode(abonent);

    if (abonent.nazwisko < root->abonent.nazwisko)
        root->left = insert(root->left, abonent);
    else if (abonent.nazwisko > root->abonent.nazwisko)
        root->right = insert(root->right, abonent);
    else
        return root;

    root->height = 1 + max(getHeight(root->left), getHeight(root->right));

    int balance = getBalance(root);

    // Przypadki niezrównoważenia

    // Przypadek lewo-lewo
    if (balance > 1 && abonent.nazwisko < root->left->abonent.nazwisko)
        return rotateRight(root);

    // Przypadek prawo-prawo
    if (balance < -1 && abonent.nazwisko > root->right->abonent.nazwisko)
        return rotateLeft(root);

    // Przypadek lewo-prawo
    if (balance > 1 && abonent.nazwisko > root->left->abonent.nazwisko) {
        root->left = rotateLeft(root->left);
        return rotateRight(root);
    }

    // Przypadek prawo-lewo
    if (balance < -1 && abonent.nazwisko < root->right->abonent.nazwisko) {
        root->right = rotateRight(root->right);
        return rotateLeft(root);
    }

    return root;
}

// Funkcja pomocnicza do znalezienia najmniejszego wierzchołka w drzewie (najmniejszego elementu)
Node* findMinNode(Node* node) {
    Node* current = node;
    while (current->left != nullptr)
        current = current->left;
    return current;
}

// Funkcja do usuwania abonenta z drzewa AVL
Node* remove(Node* root, string nazwisko) {
    if (root == nullptr)
        return root;

    if (nazwisko < root->abonent.nazwisko)
        root->left = remove(root->left, nazwisko);
    else if (nazwisko > root->abonent.nazwisko)
        root->right = remove(root->right, nazwisko);
    else {
        if (root->left == nullptr || root->right == nullptr) {
            Node* temp = root->left ? root->left : root->right;

            if (temp == nullptr) {
                temp = root;
                root = nullptr;
            } else {
                *root = *temp;
            }

            delete temp;
        } else {
            Node* temp = findMinNode(root->right);
            root->abonent = temp->abonent;
            root->right = remove(root->right, temp->abonent.nazwisko);
        }
    }

    if (root == nullptr)
        return root;

    root->height = 1 + max(getHeight(root->left), getHeight(root->right));

    int balance = getBalance(root);

    // Przypadki niezrównoważenia

    // Przypadek lewo-lewo
    if (balance > 1 && getBalance(root->left) >= 0)
        return rotateRight(root);

    // Przypadek lewo-prawo
    if (balance > 1 && getBalance(root->left) < 0) {
        root->left = rotateLeft(root->left);
        return rotateRight(root);
    }

    // Przypadek prawo-prawo
    if (balance < -1 && getBalance(root->right) <= 0)
        return rotateLeft(root);

    // Przypadek prawo-lewo
    if (balance < -1 && getBalance(root->right) > 0) {
        root->right = rotateRight(root->right);
        return rotateLeft(root);
    }

    return root;
}

// Funkcja do wyszukiwania abonenta w drzewie AVL
Node* search(Node* root, string nazwisko) {
    if (root == nullptr || root->abonent.nazwisko == nazwisko)
        return root;

    if (nazwisko < root->abonent.nazwisko)
        return search(root->left, nazwisko);
    else
        return search(root->right, nazwisko);
}

// Funkcja pomocnicza do wyświetlania drzewa AVL (przechodzenie w porządku inorder)
void inorderTraversal(Node* root) {
    if (root == nullptr)
        return;

    inorderTraversal(root->left);
    cout << "||" << root->abonent.imie << "|" << root->abonent.nazwisko << "|";
    printf("%9d",root->abonent.numerTelefonu);
    cout << "||" << endl;
    inorderTraversal(root->right);
}

// Funkcja do zapisu drzewa AVL do pliku binarnego
void saveToFile(Node* root, ofstream& file) {
    if (root == nullptr)
        return;

    saveToFile(root->left, file);
    file.write(reinterpret_cast<const char*>(&root->abonent), sizeof(Abonent));
    saveToFile(root->right, file);
}

// Funkcja do odczytu drzewa AVL z pliku binarnego
Node* readFromFile(ifstream& file) {
    Abonent abonent;
    file.read(reinterpret_cast<char*>(&abonent), sizeof(Abonent));
    if (file.eof())
        return nullptr;
    Node* root = createNode(abonent);
    root->left = readFromFile(file);
    root->right = readFromFile(file);
    return root;
}

int main() {
    Node* root = nullptr;

    int choice;
    string nazwisko;

    while (true) {
        if(root != nullptr){
            cout << "||=========|=========|==========||" << endl
                 << "||Imie     |Nazwisko |nrTelefonu||" << endl;
            inorderTraversal(root);
        }
        else{
            cout << "||==============================||" << endl
                 << "||    Puste Drzewo              ||" << endl;
        }
                
        cout << "||==============================||" << endl
             << "||    1. Dodaj abonenta         ||" << endl
             << "||    2. Usuń abonenta          ||" << endl
             << "||    3. Edytuj abonenta        ||" << endl
             << "||    4. Zapisz do pliku        ||" << endl
             << "||    5. Odczytaj z pliku       ||" << endl
             << "||    7. Wyjście                ||" << endl
             << "||==============================||" << endl
             << "|| Wybierz opcję: ";
        cin  >> choice;
        cout << "||==============================||" << endl;
        

        switch (choice) {
            case 1: {
                Abonent abonent;
                abonent.imie     = randomName();
                abonent.nazwisko = randomSubName();
                cout << "Podaj numer telefonu abonenta: ";
                //cin >> abonent.numerTelefonu;
                root = insert(root, abonent);
                cout << "Abonent dodany." << endl;
                break;
            }
            case 2: {
                cout << "Podaj nazwisko abonenta do usunięcia: ";
                cin >> nazwisko;
                root = remove(root, nazwisko);
                cout << "Abonent usunięty." << endl;
                break;
            }
            case 3: {
                cout << "Podaj nazwisko abonenta do edycji: ";
                cin >> nazwisko;
                Node* foundNode = search(root, nazwisko);
                if (foundNode != nullptr) {
                    cout << "Podaj nowe nazwisko abonenta: ";
                    cin >> foundNode->abonent.nazwisko;
                    cout << "Podaj nowy numer telefonu abonenta: ";
                    cin >> foundNode->abonent.numerTelefonu;
                    cout << "Abonent zedytowany." << endl;
                } else {
                    cout << "Abonent o podanym nazwisku nie istnieje." << endl;
                }
                break;
            }

            case 4: {
                string fileName;
                cout << "Podaj nazwę pliku do zapisu: ";
                cin >> fileName;
                ofstream file(fileName, ios::binary);
                if (file) {
                    saveToFile(root, file);
                    file.close();
                    cout << "Zapisano do pliku." << endl;
                } else {
                    cout << "Nie można otworzyć pliku do zapisu." << endl;
                }
                break;
            }
            case 5: {
                string fileName;
                cout << "Podaj nazwę pliku do odczytu: ";
                cin >> fileName;
                ifstream file(fileName, ios::binary);
                if (file) {
                    root = readFromFile(file);
                    file.close();
                    cout << "Odczytano z pliku." << endl;
                } else {
                    cout << "Nie można otworzyć pliku do odczytu." << endl;
                }
                break;
            }
            case 6:
                cout << "Koniec programu." << endl;
                return 0;
            default:
                cout << "Niepoprawna opcja. Spróbuj ponownie." << endl;
        }
    }
}
