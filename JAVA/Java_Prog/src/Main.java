import Lista1.L1z2;
import Lista1.L1z1;
import Lista2.L2z1;
import Lista3.L3z1;
import Lista4.L4z1;

import javax.swing.*;

public class Main {
    public static void main(String[] args) {
        Run(4);
    }
    public static void Run(int Task){
        Task = (Task == 0) ? Task + 1 : Task;
        Task = (Task > 0) ? Task : (Task * (-1));

        switch (Task){
            case 1:
                break;
            case 2:
                L2z1 lista2 =new L2z1();
                break;
            case 3:
                L3z1 Lista3 = new L3z1();
                break;
            case 4:
                L4z1 Lista4 = new L4z1();
        }

    }
}
