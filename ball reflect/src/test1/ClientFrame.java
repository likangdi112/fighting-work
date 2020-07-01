package test1;

import java.awt.FlowLayout;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.RenderingHints;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.UIManager;

import org.w3c.dom.css.RGBColor;



public class ClientFrame extends JFrame {
	public ArrayList<Circle> ball = new ArrayList<Circle>(); 
    public int c1=0,r1=0,t1=0;
    public ArrayList<Rectangle> rect = new ArrayList<Rectangle>();
    public ArrayList<Triangle> tri = new ArrayList<Triangle>();
    public Image img;
    public Graphics2D graph;
    public WatchFace obj;
/**
     * JPanel 用于一行一行的放置文本框和按钮
     */
    JPanel row1 = new JPanel();
 

    JPanel row2 = new JPanel();
   
    JButton playc = new JButton("监控圆形");
    JButton playr = new JButton("监控正方形");
    JButton playt = new JButton("监控三角形");
    JButton deletec = new JButton("取消监控圆形");
    JButton deleter = new JButton("取消监控正方形");
    JButton deletet = new JButton("取消监控三角形");
  

    /**
     * BallFrame 类的构造函数。
     */
    public ClientFrame()
    {
        super("ShapeDemo");
        setSize(600, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        //使第一个模块都是文本框。
        row1.setLayout(new GridLayout(2, 3, 10, 10));

       //把文本框和标签加到row1。
        row1.add(playc);
      
      row1.add(playr);
      
       row1.add(playt);
       
        row1.add(deletec);
   
       row1.add(deleter);
   
        row1.add(deletet);
   
      add(row1,"North");

        //使按钮居中。
        FlowLayout layout3 = new FlowLayout(FlowLayout.CENTER, 10, 10);
        //row2.setLayout(layout3);
        //row2.add(playc);
        //row2.add(playr);
      //  row2.add(playt);
       // row2.add(deletec);
       // row2.add(deleter);
      //  row2.add(deletet);
       // row2.add(Continue);
       // row2.add(clear);
        add(row2);
        
        setResizable(false);
        setVisible(true);
    }

    //主函数。
    public static void main(String[] args) {
        ClientFrame.setLookAndFeel();
        
        ClientFrame bf = new ClientFrame();
   
        bf.UI();
    }

    /**
     * 添加监听器。
     */
    public void UI() {                               
    	ClientListener lis = new ClientListener(this);    
      
        playc.addActionListener(lis);
        playr.addActionListener(lis);
        playt.addActionListener(lis);
        deletec.addActionListener(lis);
        deleter.addActionListener(lis);
        deletet.addActionListener(lis);
       
        Thread current = new Thread(lis);     
        current.start();                        

    }

    /**
     * 这种方法是为了确保跨操作系统能够显示窗口。
     */
    private static void setLookAndFeel() {
        try {
            UIManager.setLookAndFeel(
                "com.sun.java.swing.plaf.nimbus.NimbusLookAndFeel"
            );
        } catch (Exception exc) {
            // 忽略。
        }
    }

    /**
     * 该方法是用于重绘不同区域的画布。
     */
    public void paint(Graphics g) {
        // Panel需要被重绘，不然无法显示。
    	try {
        	obj =(WatchFace)Naming.lookup("rmi://localhost:1099/get");
        	
       
        	 ball=obj.getWatchc(c1);
		rect=obj.getWatchr(r1);
		tri=obj.getWatcht(t1);
		       
		}catch(Exception e) {
			System.out.println(e.getMessage());
			e.printStackTrace();
		}
    	
    	
        row1.repaint(0,0,this.getWidth(), 80);
        row2.repaint(0,0,this.getWidth(), 42);
        img = this.createImage(this.getWidth(), this.getHeight());
        graph = (Graphics2D)img.getGraphics();
        //渲染使无锯齿。
        graph.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        graph.setBackground(getBackground());
     
        //遍历更新每一个小球的运动情况。
      
        for (int i = 0; i < ball.size(); i++) {
            Circle myBall = ball.get(i);
            myBall.cdrawBall(graph,this);
      
           
        }
        for (int i = 0; i < rect.size(); i++) {
            Rectangle myRect = rect.get(i);
            myRect.cdrawRect(graph,this);
          
           
        }
        for (int i = 0; i < tri.size(); i++) {
            Triangle myTri = tri.get(i);
            myTri.cdrawTri(graph,this);
            
           
        }
        g.drawImage(img, 0, 150, this);
        
        
    }
    
}
