package Library;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JLabel;

class test {
    public static void main() {
        final JFrame frame = new JFrame("Parent");

        final JButton button = new JButton("Open child!");
        button.addActionListener(e -> {
            final JDialog child = new JDialog(frame, true); //Here you are creating the modal dialog...
            child.setDefaultCloseOperation(JDialog.DISPOSE_ON_CLOSE); //The dialog is going to be disposed when you close it.
            child.getContentPane().add(new JLabel("Close me...", JLabel.CENTER));
            child.pack();
            child.setLocationRelativeTo(frame);
            child.setVisible(true);
        });

        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.getContentPane().add(button);
        frame.pack();
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }
}
public class Tester {
    public Tester(){
        new test();
    }
}
