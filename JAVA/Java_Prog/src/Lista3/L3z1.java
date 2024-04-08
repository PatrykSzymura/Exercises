package Lista3;

import Library.Outputs;


import javax.swing.*;
import java.io.*;
import java.util.*;

class Question implements Serializable{
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
    public static boolean fileExists(String fileName) {
        File file = new File(fileName);
        return file.exists();
    }

    public static void deleteFile(String fileName) {
        File file = new File(fileName);
        if (file.exists())
            file.delete();
    }

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

    public static void SaveResultBinary(String Result){
        try{
            DataOutputStream DatOutStr = new DataOutputStream(new FileOutputStream("wyniki.dat",true));
            DatOutStr.writeUTF(Result);
            DatOutStr.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public static List<String> ReadResultBinary() {
        List<String> Results = new ArrayList<>();
        try {
            DataInputStream DatInpStr = new DataInputStream(new FileInputStream("wyniki.dat"));

            // Loop until the end of the file is reached
            while (DatInpStr.available() > 0) {
                String tmp = DatInpStr.readUTF();
                Results.add(tmp);
                Outputs.ConsoleOut(tmp);
            }

            DatInpStr.close();
        } catch (IOException e) {
            //throw new RuntimeException(e);
        }
        return Results;
    }

    public static void SaveProgress(Object... Values){
        try{
            ObjectOutputStream ObjOutStr = new ObjectOutputStream(new FileOutputStream("Save.ser"));

            for(Object V : Values)
                ObjOutStr.writeObject(V);

            ObjOutStr.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static Object[] RestoreProgress() {
        List<Object> values = new ArrayList<>();
        try (ObjectInputStream ObjInpStr = new ObjectInputStream(new FileInputStream("Save.ser"))) {
            while (true) {
                try {
                    Object Obj = ObjInpStr.readObject();
                    values.add(Obj);
                } catch (EOFException e) {
                    // End of file reached
                    break;
                }
            }
        } catch (IOException | ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
        return values.toArray();
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

    public static void displayResults(List<String> list) {
        StringBuilder stringBuilder = new StringBuilder();
        for (String item : list) {
            stringBuilder.append(item).append("\n"); // Append each item with a newline character
        }
        String message = stringBuilder.toString();
        JOptionPane.showMessageDialog(null, message, "Students Results", JOptionPane.INFORMATION_MESSAGE);
    }
}

public class L3z1 implements Serializable{

    private List<Question> Quiz;
    private final String UserName;
    private int Score;
    private int CurrentQuestion = 0;

    public L3z1() {

        if (!FileHandler.fileExists("Save.ser")) {
            CsvToQuiz2();

            this.UserName = WindowHandler.UserLoginWindow("Write Your Name");

            if (!Objects.equals(this.UserName, "Admin"))
                StartQuiz();
            else
                WindowHandler.displayResults(FileHandler.ReadResultBinary());
        }else {
            Object[] RestoredData = FileHandler.RestoreProgress();
            this.UserName = (String) RestoredData[0];
            this.Score = (int) RestoredData[1];
            this.CurrentQuestion = (int) RestoredData[2];
            this.Quiz = (List<Question>) RestoredData[3];

            FileHandler.deleteFile("Save.ser");

            StartQuiz(true);
        }
    }

    private void StartQuiz(){
        for (Question Q : Quiz){
            int cho;
            String[] Answers = Q.GetShuffledAnswers();

            cho = WindowHandler.QuestionWindow(Q.GetQuestion(),Answers);

            this.Score += (Q.IsCorrectAnswer(Answers[cho])) ? 1 : 0;
            this.CurrentQuestion++;
            Outputs.ConsoleOut(STR."\{Q._QuestionNumber};\{Q.IsCorrectAnswer(Answers[cho])} \{GetScorePercent()}");

            FileHandler.SaveProgress(this.UserName,this.Score,this.CurrentQuestion,this.Quiz);
        }
        FileHandler.SaveResultBinary(STR."\{this.UserName} : \{GetScorePercent()}");
        FileHandler.deleteFile("Save.ser");
    }

    private void StartQuiz(boolean Resumed){
        for (int i = this.CurrentQuestion; i < this.Quiz.size(); i++){
            int cho;
            Question Q = this.Quiz.get(i);
            String[] Answers = Q.GetShuffledAnswers();

            cho = WindowHandler.QuestionWindow(Q.GetQuestion(),Answers);

            this.Score += (Q.IsCorrectAnswer(Answers[cho])) ? 1 : 0;

            Outputs.ConsoleOut(STR."\{Q._QuestionNumber};\{Q.IsCorrectAnswer(Answers[cho])} \{GetScorePercent()}");
            FileHandler.SaveProgress(this.UserName,this.Score,this.CurrentQuestion,this.Quiz);

        }
        FileHandler.SaveResultBinary(STR."\{this.UserName} : \{GetScorePercent()}");
        FileHandler.deleteFile("Save.ser");
    }

    private void CsvToQuiz2(){
        var QuestionList = FileHandler.readDataFromFile("QuestionDB.csv");
        this.Quiz = new ArrayList<>();
        for (var Q : QuestionList){
            Quiz.add(new Question(Q));
        }
    }

    private String GetScorePercent(){
        double tmp  = ((double) this.Score / this.Quiz.size()) * 100;
        return STR."\{(int) tmp}%";
    }


}
