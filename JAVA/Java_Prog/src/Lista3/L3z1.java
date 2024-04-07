package Lista3;

import Library.Outputs;

import javax.swing.*;
import java.io.*;
import java.util.*;

class Question {
    public   int _QuestionNumber = 0;
    private final String _Question ;
    private final String Answer;
    private final List<String> Dummies;
    public final int numOfAnswers;

    public Question(String _Question,String Answer,String... Dummies){
        this._Question = _Question;
        this.Answer = Answer;
        this.Dummies = new ArrayList<>();
        this.numOfAnswers = 1 + Dummies.length;
        Collections.addAll(this.Dummies, Dummies);
    }

    public Question(String[] Data){
        String[] tmp = new String[Data.length];
        //Outputs.ConsoleOut(Data[Data.length - 1]);

        this._QuestionNumber = Integer.parseInt(Data[0]);
        this._Question = Data[1];
        this.Dummies = new ArrayList<>();
        int CorrectAnswerIndex = 1 + Integer.parseInt(Data[Data.length - 1]);
        this.Answer = Data[CorrectAnswerIndex];

        String[] ans = new String[Data.length - 4];

        int z = 0;
        for(int i = 2; i < Data.length - 1; i++){
            if (!IsCorrectAnswer(Data[i])){
                ans[z] = Data[i];
                z++;
            }
            //Outputs.ConsoleOut(Data[i]);
        }
        Collections.addAll(this.Dummies, ans);
        this.numOfAnswers = 1 + this.Dummies.size();
        //Outputs.ConsoleOut("___");
    }

    public boolean IsCorrectAnswer(String Answer){
        return Objects.equals(this.Answer, Answer);
    }

    public String[] GetShuffledAnswers() {
        List<String> Shuffled = new ArrayList<>();
        Shuffled.add(this.Answer);
        Shuffled.addAll(this.Dummies);
        Collections.shuffle(Shuffled);
        return Shuffled.toArray(new String[0]);
    }

    public String GetQuestion(){
        return STR."\{this._Question}";
    }

}

class FileHandler {
    public static void saveQuizToFile(String fileName, List<Question> Quiz) {
        try (BufferedWriter writer = new BufferedWriter(new FileWriter(fileName))) {
            int num = 0;
            for (Question Q : Quiz) {
                StringBuilder line = new StringBuilder();

                line.append(STR."\{num};");
                line.append(STR."\{Q.GetQuestion()};");

                int x = 1;
                boolean isfound = false;
                for (var a : Q.GetShuffledAnswers()){
                    if (Q.IsCorrectAnswer(a)){
                        isfound = true;
                    }else{
                        if (!isfound) x++;
                    }
                    line.append(STR."\{a};");
                }
                line.append(STR."\{x}");

                writer.write(line.toString());
                writer.newLine();
                num++;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static List<String[]> readDataFromFile(String fileName) {
        List<String[]> data = new ArrayList<>();
        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String[] rowData = line.split(";");
                data.add(rowData);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return data;
    }
}

class WindowHandler{

    public static int QuestionWindow(String WBody, String... WButtons){

        // Return the index of the selected button
        return JOptionPane.showOptionDialog(
                null,                // parent component
                WBody,              // message
                "Question",         // title
                JOptionPane.DEFAULT_OPTION,  // option type
                JOptionPane.QUESTION_MESSAGE, // message type
                null,               // icon (default)
                WButtons,           // options (buttons)
                WButtons[0]);
    }
    public static String UserLoginWindow(String message) {
        return JOptionPane.showInputDialog(null, message);
    }
}

public class L3z1 implements Serializable{

    private List<Question> Quiz;
    private String UserName;

    public L3z1() {
        // Load state from the previous session
        L3z1 previousState = loadState();

        // If previous state exists and the user name matches, use it; otherwise initialize the quiz
        if (previousState != null && previousState.UserName != null &&
                previousState.UserName.equals(WindowHandler.UserLoginWindow("Write Your Name"))) {
            this.Quiz = previousState.Quiz;
        } else {
            CsvToQuiz2();
        }

        // Set the UserName
        this.UserName = WindowHandler.UserLoginWindow("Write Your Name");

        StartQuiz();
    }


    public L3z1(int x) {
        CsvToQuiz2();
        //Collections.shuffle(Quiz);
        //FileHandler.saveQuizToFile("text.txt",Quiz);
        this.UserName = WindowHandler.UserLoginWindow("Write Your Name");
        StartQuiz();

        //Outputs.ConsoleOut("text");
    }

    private void StartQuiz(){
        for (Question Q : Quiz){
            int cho;
            String[] Answers = Q.GetShuffledAnswers();
            cho = WindowHandler.QuestionWindow(Q.GetQuestion(),Answers);

            Outputs.ConsoleOut(STR."\{Q._QuestionNumber};\{Q.IsCorrectAnswer(Answers[cho])}");
            saveState(this); // zapisanie stanu aplikacji co pytanie
        }
    }

    private void CsvToQuiz(){
        var x = FileHandler.readDataFromFile("QuestionDB.csv");
        this.Quiz = new ArrayList<>();
        for(var xd : x){
            assert false;
            Quiz.add(new Question(xd[1],xd[2],xd[3],xd[4],xd[5]));
        }
        //Outputs.ConsoleOut("text");
    }

    private void CsvToQuiz2(){
        var QuestionList = FileHandler.readDataFromFile("QuestionDB.csv");
        this.Quiz = new ArrayList<>();
        for (var Q : QuestionList){
            Quiz.add(new Question(Q));
        }
    }

    private static void saveState(L3z1 state) {
        try (FileOutputStream fileOut = new FileOutputStream("state.ser");
             ObjectOutputStream out = new ObjectOutputStream(fileOut)) {
            out.writeObject(state);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static L3z1 loadState() {
        L3z1 state = null;
        try (FileInputStream fileIn = new FileInputStream("state.ser");
             ObjectInputStream in = new ObjectInputStream(fileIn)) {
            state = (L3z1) in.readObject();
        } catch (IOException | ClassNotFoundException e) {
            // If file does not exist or class not found, return null
        }
        return state;
    }
}
