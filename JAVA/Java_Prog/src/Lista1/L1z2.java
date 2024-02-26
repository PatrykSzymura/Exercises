package Lista1;

import Library.Inputs;
import Library.Outputs;

public class L1z2 {
    public L1z2(){
        int   n         = Inputs.Int("Insert Value:");
        int   factorial = 1;
        float sequence  = 0;

        for (int i = 1; i <= n; i++){
            if (i%2==1) sequence += (float) 1 / ( i + n );
            else        sequence -= (float) 1 / ( i + n );
        }

        for (; n > 0; n--){
            factorial *= n;
        }

        Outputs.ConsoleOut("Factorial: "       + factorial);
        Outputs.ConsoleOut("Sum of Sequence: " + sequence);
    }
}
