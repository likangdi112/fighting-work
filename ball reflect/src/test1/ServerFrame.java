package test1;

/**
 * 该类主要用于绘制GUI。
 * @author Hephaest
 * @version 2019/7/5
 * @since jdk_1.8.202
 */
import java.awt.FlowLayout;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.RenderingHints;
import java.nio.file.Watchable;
import java.rmi.Naming;
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



public class ServerFrame extends JFrame {
    private ArrayList<Circle> ball = new ArrayList<Circle>(); 
    
    private ArrayList<Rectangle> rect = new ArrayList<Rectangle>();
    private ArrayList<Triangle> tri = new ArrayList<Triangle>();
    private Image img;
    private Graphics2D graph;
    private WatchImp obj;
/**
     * JPanel 用于一行一行的放置文本框和按钮
     */
    JPanel row1 = new JPanel();
    JLabel color = new JLabel("color", JLabel.RIGHT);
    JTextField colorText, xSpeedText, xPositionText, sizeText, ySpeedText, yPositionText;
    JLabel xSpeed = new JLabel("xSpeed:", JLabel.RIGHT);
    JLabel xPosition = new JLabel("xPosition:", JLabel.RIGHT);
    JLabel size = new JLabel("size:", JLabel.RIGHT);
    JLabel ySpeed = new JLabel("ySpeed:", JLabel.RIGHT);
    JLabel yPosition = new JLabel("yPosition:", JLabel.RIGHT);

    JPanel row2 = new JPanel();
  
    JButton playc = new JButton("添加圆形");
    JButton playr = new JButton("添加正方形");
    JButton playt = new JButton("添加三角形");
    JButton deletec = new JButton("删除圆形");
    JButton deleter = new JButton("删除正方形");
    JButton deletet = new JButton("删除三角形");
    
    /**
     * BallFrame 类的构造函数。
     */
    public ServerFrame()
    {
        super("ShapeDemo");
        setSize(600, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        //使第一个模块都是文本框。
        row1.setLayout(new GridLayout(2, 3, 10, 10));

        //把文本框和标签加到row1。
        row1.add(color);
        colorText = new JTextField("100,100,100");
        row1.add(colorText);
        row1.add(xSpeed);
        xSpeedText = new JTextField("4");
        row1.add(xSpeedText);
        row1.add(xPosition);
        xPositionText = new JTextField("4");
        row1.add(xPositionText);
        row1.add(size);
        sizeText = new JTextField("50");
        row1.add(sizeText);
        row1.add(ySpeed);
        ySpeedText = new JTextField("4");
        row1.add(ySpeedText);
        row1.add(yPosition);
        yPositionText = new JTextField("0");
        row1.add(yPositionText);
        add(row1,"North");

        //使按钮居中。
        FlowLayout layout3 = new FlowLayout(FlowLayout.CENTER, 10, 10);
        row2.setLayout(layout3);
        row2.add(playc);
        row2.add(playr);
        row2.add(playt);
        row2.add(deletec);
        row2.add(deleter);
        row2.add(deletet);
      
        add(row2);
        
        setResizable(false);
        setVisible(true);
    }

    //主函数。
    public static void main(String[] args) throws RemoteException  {
    	
        ServerFrame.setLookAndFeel();
        ServerFrame bf = new ServerFrame();
        LocateRegistry.createRegistry(1099);  
     
        
        bf.UI();
        
        
    }

    /**
     * 添加监听器。
     */
    public void UI() {                               
        Listener lis = new Listener(this, ball,rect,tri);
        
      
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
            myBall.drawBall(graph,this);
            
            myBall.moveBall(this);
        }
        for (int i = 0; i < rect.size(); i++) {
            Rectangle myRect = rect.get(i);
            myRect.drawRect(graph,this);
          
            myRect.moveRect(this);
        }
        for (int i = 0; i < tri.size(); i++) {
            Triangle myTri = tri.get(i);
            myTri.drawTri(graph,this);
         
            myTri.moveTri(this);
        }
        try {
			 
			obj=new WatchImp(ball,rect,tri);
			Naming.rebind("rmi://localhost:1099/get", obj);
			
			  
		}catch(Exception e) {
			e.printStackTrace();
		}
     
        
        
        g.drawImage(img, 0, 150, this);
    }
    
}
