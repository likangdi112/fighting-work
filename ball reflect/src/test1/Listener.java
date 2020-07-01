package test1;
/**
 * 此类是用于监听 BallFrame GUI 的文字输入和按监听的。
 * 用户可以输入参数然后点击按钮"Play"或者在画板中指定区域单机鼠标生成小球。  
 * @author Hephaest
 * @version 2019/7/5
 * @since jdk_1.8.202
 */
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.Random;
import java.util.regex.Pattern;

import javax.swing.*;

public class Listener  implements ActionListener,Runnable {
    /**
     * 声明监听器里的所有变量。
     * 需要注意何时更改 clearFlag 和 pauseFlag 的布尔值。 
     */
    private ServerFrame bf;
    
   
    private ArrayList<Circle> ball;
  
    private ArrayList<Rectangle> rect ; 
    private ArrayList<Triangle> tri ;
    

    /**
     * 监听器的构造函数。
     * @param bf BallFrame 类的实例。
     * @param ball 所有小球组成的列表。
     */
    public Listener(ServerFrame bf, ArrayList<Circle> ball,ArrayList<Rectangle> rect,ArrayList<Triangle> tri) {
        this.bf = bf;
        this.ball = ball;
        this.rect=rect;
        this.tri=tri;
        
    }

    /**
     * 每次点击小球时，只能直到生成小球的初始位置，但是它的速度分量都是随机数。
     */
 

    @Override
    /**
     * 该方法是 Runnable 的重写。 
     * 如果用户选择暂停的话，需要停止画板刷新和新的绘制。
     */
    public void run() {
        while (true) {
            
                bf.repaint();
                try {
                    Thread.sleep(30);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            
        }
    }
            
    /**
     * 该方法用来响应不同按钮的需求。
     */
    public void actionPerformed(ActionEvent event) {
        String command = event.getActionCommand();
        if (command.equals("添加圆形")) {
           
                startPlaying();
            
        }
        if (command.equals("添加正方形")) {
        	 
                 startPlaying1();
             
        }
        if (command.equals("添加三角形")) {
        	 
                 startPlaying2();
          
             
        }
        if (command.equals("删除圆形")) {
            
                deletePlaying();
           
        }
        if (command.equals("删除正方形")) {
        	 
        	deletePlaying1();
             
        }
        if (command.equals("删除三角形")) {
        	 
        	deletePlaying2();
          
             
        }
    
    }

    /**
     * 该方法用来响应 "Reset" 按钮。
     * 每个文本框都设置默认值。
     * 重置完后无法再点击 "Reset" 或 "Continue"。
     */


    /**
     * 该方法用来响应 "Play" 按钮。
     * 需要创建一个新的进程并设置 clearFlag 为 false, 这样 run() 函数可以正常运行。
     * 运行完后无法再点击 "play" again 或 "Continue"。
     */
    void startPlaying() {   
      
      
     
        String xP = bf.xPositionText.getText();
        int x = Integer.parseInt(xP);
        String yP = bf.yPositionText.getText();
        int y = Integer.parseInt(yP);
        String Size = bf.sizeText.getText();
        int size = Integer.parseInt(Size);
        String Xspeed = bf.xSpeedText.getText();
        int xspeed = Integer.parseInt(Xspeed);
        String Yspeed = bf.ySpeedText.getText();
        int yspeed = Integer.parseInt(Yspeed);
        String color = bf.colorText.getText();
       String[] s1=color.split(",");
       int a=Integer.parseInt(s1[0]);
       int b=Integer.parseInt(s1[1]);
       int c=Integer.parseInt(s1[2]);
       
        Circle myball = new Circle(x, y, size, xspeed,yspeed, 
                new Color(a, b, c));
        ball.add(myball);
        bf.repaint();
    }
    void startPlaying1() {  
    	
     
      
      
        String xP = bf.xPositionText.getText();
        int x = Integer.parseInt(xP);
        String yP = bf.yPositionText.getText();
        int y = Integer.parseInt(yP);
        String Size = bf.sizeText.getText();
        int size = Integer.parseInt(Size);
        String Xspeed = bf.xSpeedText.getText();
        int xspeed = Integer.parseInt(Xspeed);
        String Yspeed = bf.ySpeedText.getText();
        int yspeed = Integer.parseInt(Yspeed);
        String color = bf.colorText.getText();
       String[] s1=color.split(",");
       int a=Integer.parseInt(s1[0]);
       int b=Integer.parseInt(s1[1]);
       int c=Integer.parseInt(s1[2]);
        
        Rectangle myRect = new Rectangle(x, y, size, xspeed,yspeed, 
                new Color(a, b, c));
       rect.add(myRect);
       bf.repaint();
    }
    void startPlaying2() {   
       
       
    
        String xP = bf.xPositionText.getText();
        int x = Integer.parseInt(xP);
        String yP = bf.yPositionText.getText();
        int y = Integer.parseInt(yP);
        String Size = bf.sizeText.getText();
        int size = Integer.parseInt(Size);
        String Xspeed = bf.xSpeedText.getText();
        int xspeed = Integer.parseInt(Xspeed);
        String Yspeed = bf.ySpeedText.getText();
        int yspeed = Integer.parseInt(Yspeed);
        String color = bf.colorText.getText();
       String[] s1=color.split(",");
       int a=Integer.parseInt(s1[0]);
       int b=Integer.parseInt(s1[1]);
       int c=Integer.parseInt(s1[2]);
       
        Triangle myTri = new Triangle(x, y, size, xspeed,yspeed, 
                new Color(a, b, c));
       tri.add(myTri);
       bf.repaint();
    }

    /**
     * 该方法用来响应 "Stop" 按钮。
     * 这个不需要重新绘制。
     * 用户无法再点击 "Stop" 按钮。
     */
   
      void deletePlaying()
    {
       
        ball.remove(ball.size()-1);
        bf.repaint();
    }
      void deletePlaying1()
      {
         
          rect.remove(rect.size()-1);
          bf.repaint();
      }

      void deletePlaying2()
      {
        
          tri.remove(tri.size()-1);
          bf.repaint();
      }


   
    /**
     * 核查用户在文本框里的输入是否正确。
     * @param mass 小球的质量。
     * @param size 小球的直径。
     * @param xPos 小球在X轴的位置。
     * @param yPos 小球在Y轴的位置。
     * @return 返回核验结果。
     */
 
}