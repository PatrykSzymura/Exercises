package Library;

import java.io.* ;

public class Inputs {
    public static int Int(String preText) {
        int input ;
        System.out.println(preText);
        InputStreamReader Input_Stream = new InputStreamReader(System.in);
        BufferedReader Input_Buffer = new BufferedReader(Input_Stream);

        try{
            input = Integer.parseInt(Input_Buffer.readLine());
        }
        catch (IOException e){
            e.printStackTrace();
            return -1;
        }
        return input;
    }

    public static  float Float(String preText) {
        float input ;
        System.out.println(preText);
        InputStreamReader Input_Stream = new InputStreamReader(System.in);
        BufferedReader Input_Buffer = new BufferedReader(Input_Stream);

        try{
            input = Float.parseFloat(Input_Buffer.readLine());
        }
        catch (IOException e){
            e.printStackTrace();
            return -1;
        }
        return input;
    }

    public static String String(String preText) {
        String input ;
        System.out.println(preText);
        InputStreamReader Input_Stream = new InputStreamReader(System.in);
        BufferedReader Input_Buffer = new BufferedReader(Input_Stream);

        try{
            input = (Input_Buffer.readLine());
        }
        catch (IOException e){
            e.printStackTrace();
            return "-1";
        }
        return input;
    }
}
