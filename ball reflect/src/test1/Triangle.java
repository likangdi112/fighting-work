package test1;
import java.awt.Color;
import java.awt.Graphics;
import java.io.Serializable;
import java.util.ArrayList;

import org.omg.PortableInterceptor.ClientRequestInterceptorOperations;
public class Triangle implements Serializable {
	  private int  size, xSpeed, ySpeed,times=0;
	  private java.util.List<Integer> xPos= new ArrayList<Integer>(), yPos= new ArrayList<Integer>();
	    private Color color;
	    
	    public Triangle(int xPos, int yPos, int size, int xSpeed, int ySpeed, Color color) {
	    	 super();
	         this.xPos.add(xPos);
	         this.yPos.add(yPos);
	         this.size = size;
	         this.xSpeed = xSpeed;
	         this.ySpeed = ySpeed;
	         this.color = color;
	        
	        
	      
	    }
	    public void cdrawTri(Graphics g,ClientFrame bf) {
	        for(int i=0;i<xPos.size();i++)
	          {
		    	if(xPos.get(i)+ size> bf.getWidth() - 4) xPos.set(i, bf.getWidth() - size - 4);
		        else if(xPos.get(i) < 4) xPos.set(i, 4);
		        if(yPos.get(i) < 4) yPos.set(i, 4);
		        else if(yPos.get(i) > bf.getHeight()) yPos.set(i, (int)(bf.getHeight() - size/2*Math.sqrt(3) - 4)) ;
		        g.setColor(color); 
		        int[] xp=new int[] {xPos.get(i)+size/2,xPos.get(i),xPos.get(i)+size};
		        int[] yp=new int[] {yPos.get(i),(int)(yPos.get(i)+size/2*Math.sqrt(3)),(int)(yPos.get(i)+size/2*Math.sqrt(3))};
		        g.fillPolygon(xp,yp,3);
		        g.setColor(color.black);
		        g.drawPolygon(xp,yp,3);
		        
	        }
	    }
	    public void drawTri(Graphics g,ServerFrame bf) {
	    	if(xPos.get(xPos.size()-1)+ size> bf.getWidth() - 4) xPos.set(xPos.size()-1, bf.getWidth() - size - 4);
	        else if(xPos.get(xPos.size()-1) < 4) xPos.set(xPos.size()-1, 4);
	        if(yPos.get(yPos.size()-1) < 4) yPos.set(yPos.size()-1, 4);
	        else if(yPos.get(yPos.size()-1) > bf.getHeight()) yPos.set(yPos.size()-1, (int)(bf.getHeight() - size/2*Math.sqrt(3) - 4)) ;
	        g.setColor(color);     
	        int[] xp=new int[] {xPos.get(xPos.size()-1)+size/2,xPos.get(xPos.size()-1),xPos.get(xPos.size()-1)+size};
	        int[] yp=new int[] {yPos.get(yPos.size()-1),(int)(yPos.get(yPos.size()-1)+size/2*Math.sqrt(3)),(int)(yPos.get(yPos.size()-1)+size/2*Math.sqrt(3))};
	        g.fillPolygon(xp,yp,3);   
	        g.setColor(color.black);
	        g.drawPolygon(xp,yp,3);
	    }
	    public void moveTri(ServerFrame bf) {
	    	if (xPos.get(xPos.size()-1)+ size + xSpeed > bf.getWidth() - 4 || xPos.get(xPos.size()-1) + xSpeed < 4)
	        {
	            xSpeed = -xSpeed;
	        }
	        if (yPos.get(yPos.size()-1) + ySpeed < 2 || yPos.get(yPos.size()-1)+(int)(size/2*Math.sqrt(3))> bf.getHeight() - 163)
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
