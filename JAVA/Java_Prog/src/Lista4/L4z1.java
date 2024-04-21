package Lista4;

import BadApple.BadApple;

import javax.swing.*;

import java.awt.*;
import java.util.*;
import java.util.List;

public class L4z1 extends JFrame {

    public L4z1() {
        setSize(1300, 1000);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Container Basket = getContentPane();
        Basket.setLayout(new GridLayout(2, 5));

        for (int i = 0; i < 10; i++)
            Basket.add(new BadApple(i + 1, 32 + ( i * 1 )));
        setVisible(true);

    }

}
