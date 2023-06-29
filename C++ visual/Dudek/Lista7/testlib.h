#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;
using vInt = vector<int>;

void swap(int * a,int * b){ 
    int temp = *a;
          *a = *b;
          *b = temp;
}
 
//sortowanie przez wybór
void selection(vInt *tab,int start,int size){
    int min = start;
    if(start == size-1) return;

    for(int i = start;i < size;i++)
        if(tab->at(min) > tab->at(i))
            min = i;
    
    swap(&tab->at(start),&tab->at(min));
    
    selection(tab,start+1,size); 
}


class math{
    public:             
        static int minimalna(vInt ciag){
            int  min  = ciag[0];
            for (int i = 0; i < ciag.size(); i++)
                if(min > ciag[i])
                    min = ciag[i];
            return min;
        }
        
        static int maksymalna(vInt ciag){
            int  max  = ciag[0];
            for (int i = 0; i < ciag.size(); i++)
                if (max < ciag[i])
                    max = ciag[i];
            return  max;
        }

        static float srednia(vInt ciag){
            float sred  = 0;
            for  (int i = 0; i < ciag.size(); i++)
                  sred += ciag[i];
            return sred/ciag.size();
        }

        static int mediana(vInt *tab){
            int size = tab->size(),
            med  = 0;
            selection(tab,0,size);
            med = tab->at(size/2);
            return med;    
        }

        static int dominanta(vInt ciag){
            int maxCount = 0, dominanta = ciag[0], count = 1;
            for (int i = 1; i < ciag.size(); ++i) {
                if (ciag[i] == ciag[i - 1]) {
                    ++count;
                } else {
                    if (count > maxCount) {
                    maxCount = count;
                    dominanta = ciag[i - 1];
                    }
                    count = 1;
                }
            }
            if (count > maxCount) {
                dominanta = ciag.back();
            }

            return dominanta;
        }
     
};

