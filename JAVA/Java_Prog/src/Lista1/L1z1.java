package Lista1;

import Library.Inputs;
import Library.Outputs;

public class L1z1 {

    public L1z1() {
        //int number_Of_Grades = Inputs.Int("Insert number of grades: ");
        int number_Of_Grades = 0;
        float average = 0;
        int in = 0;
        for (int i = 0; ; i++){
            in = Inputs.Int("Insert grade: ");

            if ( in == 0 ) { break; }
            number_Of_Grades += 1;
            average += in;
        }

        average /= number_Of_Grades;

        Outputs.ConsoleOut("Average: "+average);

        if (average >= 4.1){
            Outputs.ConsoleOut("Qualifies, average >= 4.1");
        }

    }
}
