#include <iostream>
#include <vector>
#include <time.h>
#include <string>
#include <bits/stdc++.h>
#include <fstream>
 
using namespace std;
using vInt = vector<int>;

void saveToFile(double size,string type,double dur){
    ofstream outfile;
    outfile.open("plik.txt", ios::app);

    if (!outfile) {
        cerr << "Nie można otworzyć pliku" << endl;
    } else {
        outfile << size << " " << type << " " << dur << endl; 
        outfile.close();
    }
}

bool checker(){
    char ch = 0;
    cin >> ch;
    if (ch == 'T' || ch == 't')
        return true;
    else if (ch == 'N' || ch == 'n')
        return false; 
    else return false;  
}

void fillTab(vInt *tab){
    for (int i = 0; i < tab->size(); i++)
        tab->at(i) = (rand()%90)+10;

}

void display(vInt tab){
    int size = tab.size();
    for (int i = 0; i < size; i++) 
        cout << tab[i] << " ";
}

// zamienia a z b miejscami
void swap(int * a,int * b){ 
    int temp = *a;
          *a = *b;
          *b = temp;
}

//sortowanie bąbelkowe
void babelkowe(vInt *tab){
    int opt = 0,check = 0;
    auto count  = tab->size();
    for (int j = 0; j < count; j++)
        for (int i = 1; i < count; i++)
            if(tab->at(i) < tab->at(i-1)){ 
                swap(&tab->at(i), &tab->at(i-1));
                opt = 0;
            }else{
                if (opt==count) return;
                opt++;
            } 
}

void selection(vInt *tab,int start,int size){
    int min = start;
    if(start == size-1) return;

    for(int i = start;i < size;i++)
        if(tab->at(min) > tab->at(i))
            min = i;
    
    swap(&tab->at(start),&tab->at(min));
    
    selection(tab,start+1,size); 
}

void insertsort(vInt *tab){
    int i    = 1,
        size = tab->size();
    
    while (i < size)
    {
        int j = i;
        while (j > 0 && tab->at(j-1) > tab->at(j))
        {
            swap(&tab->at(j),&tab->at(j-1));
            j = j-1;
        }
        i=i+1;
    } 
}

void MergeSortedIntervals(vInt& v, int s, int m, int e) {
	vInt temp;

	int i, j;
	i = s;
	j = m + 1;

	while (i <= m && j <= e) {

		if (v[i] <= v[j]) {
			temp.push_back(v[i]);
			++i;
		}
		else {
			temp.push_back(v[j]);
			++j;
		}

	}

	while (i <= m) {
		temp.push_back(v[i]);
		++i;
	}

	while (j <= e) {
		temp.push_back(v[j]);
		++j;
	}

	for (int i = s; i <= e; ++i)
		v[i] = temp[i - s];

}

void MergeSort(vInt& v, int s, int e) {
	if (s < e) {
		int m = (s + e) / 2;
		MergeSort(v, s, m);
		MergeSort(v, m + 1, e);
		MergeSortedIntervals(v, s, m, e);
	}
}

void countSort(vInt& arr)
{
    int max = *max_element(arr.begin(), arr.end());
    int min = *min_element(arr.begin(), arr.end());
    int range = max - min + 1;
 
    vInt count(range), output(arr.size());
    for (int i = 0; i < arr.size(); i++)
        count[arr[i] - min]++;
 
    for (int i = 1; i < count.size(); i++)
        count[i] += count[i - 1];
 
    for (int i = arr.size() - 1; i >= 0; i--) {
        output[count[arr[i] - min] - 1] = arr[i];
        count[arr[i] - min]--;
    }
 
    for (int i = 0; i < arr.size(); i++)
        arr[i] = output[i];
}

void kopcuj(vInt& arr, int n, int i) {
    int max = i;
    int left = 2 * i + 1;
    int right = 2 * i + 2;

    if (left < n && arr[left] > arr[max]) 
        max = left;
    
    if (right < n && arr[right] > arr[max]) 
        max = right;

    if (max != i) {
        swap(arr[i], arr[max]);
        kopcuj(arr, n, max);
    }
}

void kopcowe(vInt& arr) {
    int n = arr.size();

    for (int i = n / 2 - 1; i >= 0; i--) {
        kopcuj(arr, n, i);
    }

    for (int i = n - 1; i >= 0; i--) {
        swap(arr[0], arr[i]);
        kopcuj(arr, i, 0);
    }
}

void kubelkowe(vInt& arr) {
    int n = arr.size();
    
    vector<vInt> buckets(n);

    for (int i = 0; i < n; i++) {
        int bucket_idx = arr[i] / n;
        buckets[bucket_idx].push_back(arr[i]);
    }

    for (int i = 0; i < n; i++) {
        (buckets[i].begin(), buckets[i].end());
    }

    int index = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < buckets[i].size(); j++) {
            arr[index++] = buckets[i][j];
        }
    }
}

void quicksort(vInt& arr, int left, int right) {
    if (left < right) {
        int pivotIndex = (left + right) / 2;
        int pivotValue = arr[pivotIndex];
        int i = left, j = right;

        while (i <= j) {
            while (arr[i] < pivotValue) {
                i++;
            }
            while (arr[j] > pivotValue) {
                j--;
            }
            if (i <= j) {
                swap(arr[i], arr[j]);
                i++;
                j--;
            }
        }

        quicksort(arr, left, j);
        quicksort(arr, i, right);
    }
}
