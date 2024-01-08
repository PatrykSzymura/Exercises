#include <stdio.h>
#include <string.h>

int main() {
    int var1, var2, resoult;
    char var3[10];

    printf("Number 1: ");
    scanf("%d", &var1);
    printf("Number 2: ");
    scanf("%d", &var2);
    printf("Action  : ");
    scanf("%s", var3);

    if (strcmp(var3, "+") == 0) {
        resoult = var1 + var2;
    } else if (strcmp(var3, "-") == 0) {
        resoult = var1 - var2;
    } else {
        printf("Invalid Input\n");
        return 0;
    }

    printf("Resoult : %d %s %d = %d\n", var1, var3, var2, resoult);

    return 0;
}