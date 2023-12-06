silnia(int):                                    ;Deklaracja funkcji silnia przyjmującej int jako argument.
        push    rbp                             ;Zapisuje wartość rejestru bazowego na stosie.
        mov     rbp, rsp                        ;Ustawia rejestru bazowy na aktualny wskaźnik stosu.
        sub     rsp, 16                         ;Rezerwuje miejsce na stosie.
        mov     DWORD PTR [rbp-4], edi          ;Zapisuje argument funkcji na stosie.
        cmp     DWORD PTR [rbp-4], 0            ;Porównuje argument z 0.
        jle     .L2                             ;Skacze do etykiety .L2, jeśli argument jest mniejszy lub równy 0.
        mov     eax, DWORD PTR [rbp-4]          ;Ładuje wartość argumentu do rejestru eax.
        sub     eax, 1                          ;Zmniejsza wartość eax o 1.
        mov     edi, eax                        ;Przenosi wartość eax do edi.
        call    silnia(int)                     ;Rekurencyjnie wywołuje funkcję silnia z nową wartością argumentu.
        imul    eax, DWORD PTR [rbp-4]          ;Mnoży wynik rekurencyjnego wywołania przez wartość argumentu i zapisuje wynik do eax.
        jmp     .L3                             ;Skok do etykiety .L3.
.L2:                                            ;Etykieta .L2, obsługująca przypadek, gdy argument jest mniejszy lub równy 0.            
        mov     eax, 1                          ;Ustawia eax na 1 (wartość silni dla 0 i 1).
.L3:                                            ;Etykieta .L3.
        leave                                   ;Odtwarza poprzednią wartość rejestru bazowego i przesuwa wskaźnik stosu.
        ret                                     ;Zwraca wartość z funkcji.
.LC0:                                           ;Etykieta dla stałej stringa.
        .string "Silnia z 5 to "                ;Deklaracja stałej stringa.
main:                                           ;Etykieta dla funkcji main.          
        push    rbp                             ;Zapisuje wartość rejestru bazowego na stosie.
        mov     rbp, rsp                        ;Ustawia rejestru bazowy na aktualny wskaźnik stosu.
        push    rbx                             ;Zapisuje wartość rejestru ogólnego rbx na stosie.
        sub     rsp, 8                          ;Rezerwuje miejsce na stosie.            
        mov     esi, OFFSET FLAT:.LC0           ;Ładuje adres stałej stringa do rejestru esi.
        mov     edi, OFFSET FLAT:_ZSt4cout      ;Ładuje adres obiektu cout do rejestru edi.
        call    std::basic_ostream<char, std::char_traits<char> >& std::operator<< <std::char_traits<char> >(std::basic_ostream<char, std::char_traits<char> >&, char const*);Wywołuje funkcję wypisującą na standardowe wyjście.
        mov     rbx, rax                        ;Zapisuje wynik wywołania do rejestru rbx.
        mov     edi, 5                          ;Ustawia wartość argumentu na 5.
        call    silnia(int)                     ;Wywołuje funkcję silnia z argumentem 5.
        mov     esi, eax                        ;Zapisuje wynik funkcji silnia do rejestru esi.
        mov     rdi, rbx                        ;Przenosi wartość rbx (adres obiektu cout) do rdi.
        call    std::basic_ostream<char, std::char_traits<char> >::operator<<(int);Wywołuje funkcję wypisującą wynik na standardowe wyjście.
        mov     eax, 0                          ;Ustawia wartość zwracaną przez funkcję main na 0.
        mov     rbx, QWORD PTR [rbp-8]          ;Ładuje wartość rejestru rbx ze stosu.
        leave                                   ;Odtwarza poprzednią wartość rejestru bazowego i przesuwa wskaźnik stosu.
        ret                                     ;Zwraca wartość z funkcji main.