package Lista1;

import Library.Outputs;

public class L1z3 {

}

class UTWOR{
    private String Title, Author;
    private int  Duration;

    public void setAuthor(String author) {
        Author = author;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public void setDuration(int duration) {
        Duration = duration;
    }

    public String getAuthor() {
        return Author;
    }

    public String getTitle() {
        return Title;
    }

    public int getDuration() {
        return Duration;
    }

    public void showAll(){
        Outputs.ConsoleOut(STR."Title: \{Title} Author: \{Author} Duration (s): \{Duration}");
    }


}
class KOLEKCJA_PLYT{}

class CD{
    private String Album_Title, Author_Surname, Label;
    private int Relese_Year;
    private float Disk_Price;

    public CD(){

    }
}
