package test1;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.Random;
import java.util.regex.Pattern;

import javax.swing.*;
public class ClientListener  implements ActionListener,Runnable {
    /**
     * 声明监听器里的所有变量。
     * 需要注意何时更改 clearFlag 和 pauseFlag 的布尔值。 
     */
    private ClientFrame bf;
   

    /**
     * 监听器的构造函数。
     * @param bf BallFrame 类的实例。
     * @param ball 所有小球组成的列表。
     */
    public ClientListener(ClientFrame bf) {
        this.bf=bf;
        
        
        
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
         while(true)
         {
                bf.repaint();
                try {
                    Thread.sleep(30);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }}
    }
            
    /**
     * 该方法用来响应不同按钮的需求。
     */
    public void actionPerformed(ActionEvent event) {
        String command = event.getActionCommand();
        if (command.equals("监控圆形")) {
            
                startPlaying();
           
        }
        if (command.equals("监控正方形")) {
        	 
                 startPlaying1();
             
        }
        if (command.equals("监控三角形")) {
        	 
                 startPlaying2();
          
             
        }
        if (command.equals("取消监控圆形")) {
            
                deletePlaying();
           
        }
        if (command.equals("取消监控正方形")) {
        	 
        	deletePlaying1();
             
        }
        if (command.equals("取消监控三角形")) {
        	 
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
    	bf.c1++;
      
    }
    void startPlaying1() {  
    	bf.r1++;
  
    }
    void startPlaying2() {   
    	bf.t1++;
    
    }

    /**
     * 该方法用来响应 "Stop" 按钮。
     * 这个不需要重新绘制。
     * 用户无法再点击 "Stop" 按钮。
     */
    
      void deletePlaying()
    { bf.c1--;
  
    }
      void deletePlaying1()
      {   bf.r1--;
       
         
      }

      void deletePlaying2()
      {   bf.t1--;
       
          
      }


    /**
     * 该方法用来响应 "Continue" 按钮。
     * 需要设置 pauseFlag 的值用来一遍又一遍地重绘窗口。
     * 需要记住线程 "Playing" 仍在工作!
     * 用户无法再点击 "Continue" 按钮。
     */
 

    /**
     * 该方法用来响应 "Clear" 按钮。
     * 通过将线程声明为null来减少CPU的浪费。
     * 需要清空所有小球并重新绘制。
     * 用户无法再点击 "Clear" 或 "Stop" 或 "Continue" 按钮。
     */
 
    /**
     * 核查用户在文本框里的输入是否正确。
     * @param mass 小球的质量。
     * @param size 小球的直径。
     * @param xPos 小球在X轴的位置。
     * @param yPos 小球在Y轴的位置。
     * @return 返回核验结果。
     */
  
}