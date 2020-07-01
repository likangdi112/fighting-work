package test1;

/**
 * 这个类主要是用来设置小球的各种属性以及运动关系。
 * @author Hephaest
 * @version 2019/7/5
 * @since jdk_1.8.202
 */
import java.awt.Color;
import java.awt.Graphics;
import java.awt.List;
import java.io.Serializable;
import java.util.ArrayList;

public class Circle implements Serializable{

    /**
     * 声明小球的各种变量。
     */
  
	private int  size, xSpeed, ySpeed,times=0;
    private java.util.List<Integer> xPos= new ArrayList<Integer>(), yPos= new ArrayList<Integer>();
    private Color color;
  
    

    /**
     * 球类的构造函数。
     * @param xPos 小球在X轴上的位置。
     * @param yPos 小球在Y轴上的位置。
     * @param size 小球的直径长度。
     * @param xSpeed 小球在X轴上的分速度。
     * @param ySpeed 小球在Y轴上的分速度。
     * @param color 小球的颜色。
     * @param mass 小球的质量。
     * @param bf 当前小球所在的画板。
     */
    public Circle(int xPos, int yPos, int size, int xSpeed, int ySpeed, Color color) {
        super();
        this.xPos.add(xPos);
        this.yPos.add(yPos);
        this.size = size;
        this.xSpeed = xSpeed;
        this.ySpeed = ySpeed;
        this.color = color;
       
    }

    /**
     * 在画板上绘制小球。
     * @param g 当前小球。
     */
    public void cdrawBall(Graphics g,ClientFrame bf) {
        for(int i=0;i<xPos.size();i++)
          {
	    	if(xPos.get(i)+ size> bf.getWidth() - 4) xPos.set(i, bf.getWidth() - size - 4);
	        else if(xPos.get(i) < 4) xPos.set(i, 4);
	        if(yPos.get(i) < 4) yPos.set(i, 4);
	        else if(yPos.get(i) > bf.getHeight()) yPos.set(i, bf.getHeight() - size - 4) ;
	        g.setColor(color); 
	      
	        g.fillOval(xPos.get(i), yPos.get(i), size, size);  
	        g.setColor(color.black);
	        g.drawOval(xPos.get(i), yPos.get(i), size, size);
        }
    }
    public void drawBall(Graphics g,ServerFrame bf) {
    
    	if(xPos.get(xPos.size()-1)+ size> bf.getWidth() - 4) xPos.set(xPos.size()-1, bf.getWidth() - size - 4);
        else if(xPos.get(xPos.size()-1) < 4) xPos.set(xPos.size()-1, 4);
        if(yPos.get(yPos.size()-1) < 4) yPos.set(yPos.size()-1, 4);
        else if(yPos.get(yPos.size()-1) > bf.getHeight()) yPos.set(yPos.size()-1, bf.getHeight() - size - 4) ;
        g.setColor(color); 
      
        g.fillOval(xPos.get(xPos.size()-1), yPos.get(yPos.size()-1), size, size);  
        g.setColor(color.black);
        g.drawOval(xPos.get(xPos.size()-1), yPos.get(yPos.size()-1), size, size); 
  }

    /**
     * 该方法是用来判断下一秒小球的移动方向并计算当前小球的位置。
     * @param bf 当前小球所在的画板。
     */
  public void moveBall(ServerFrame bf) {
        
    	if (xPos.get(xPos.size()-1)+ size + xSpeed > bf.getWidth() - 4 || xPos.get(xPos.size()-1) + xSpeed < 4)
        {
            xSpeed = -xSpeed;
        }
        if (yPos.get(yPos.size()-1) + ySpeed < 2 || yPos.get(yPos.size()-1)+size > bf.getHeight() - 163)
        {
            ySpeed = - ySpeed;
        }
      
        times++;
        xPos.add(xPos.get(xPos.size()-1)+xSpeed) ;        
        yPos.add(yPos.get(yPos.size()-1)+ySpeed) ; 
        if(times>=5)
        {
        	xPos.remove(0);
        	yPos.remove(0);
        }
    }
 
  
    
   

}