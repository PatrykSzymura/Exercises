package Lista1;

import Library.Inputs;
import Library.Outputs;

public class L1z1 {

    public L1z1() {
        int number_Of_Grades = Inputs.Int("Insert number of grades: ");
        float average = 0;

        for (int i = 0; i < number_Of_Grades; i++){
            average += Inputs.Int("Insert grade: ");
        }

        average /= number_Of_Grades;

        Outputs.ConsoleOut("Average: "+average);

        if (average >= 4.1){
            Outputs.ConsoleOut("Qualifies, average >= 4.1");
        }

    }
}
