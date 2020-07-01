package test1;

import java.awt.AWTError;
import java.awt.List;
import java.io.Serializable;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;

public class WatchImp extends UnicastRemoteObject implements WatchFace,Serializable {
	public ArrayList<Circle> ball = new ArrayList<Circle>(); 
    
	public ArrayList<Rectangle> rect = new ArrayList<Rectangle>();
	public ArrayList<Triangle> tri = new ArrayList<Triangle>();
   
	public  WatchImp( ArrayList<Circle> Ball,ArrayList<Rectangle> Rect,ArrayList<Triangle> Tri ) throws RemoteException{
            	  super();
            	  this.ball=Ball;
            	  this.rect=Rect;
            	  this.tri=Tri;
            	  
              }
	public  WatchImp() throws RemoteException{
  	  super();
	}

           public  ArrayList<Circle>   getWatchc(int c1)  throws RemoteException
           {		ArrayList<Circle> ball1 = new ArrayList<Circle>();
        	   if(c1>0&&c1<=ball.size()) {
        		   for(int i=0;i<c1;i++) 
        			   ball1.add(ball.get(i));
        		   }
        		   else if (c1>ball.size()) {
        			   ball1=ball;
        	   }
        	   return ball1;
        	   
           }
        	public  ArrayList<Rectangle>  getWatchr(int r1) throws RemoteException
        	 {   	ArrayList<Rectangle> rect1 = new ArrayList<Rectangle>();
      	   if(r1>0&&r1<=rect.size()) {
    		   for(int i=0;i<r1;i++) 
    			   rect1.add(rect.get(i));
    		   }
    		   else if (r1>rect.size()) {
    			   rect1=rect;
    	   }
    	   return rect1;
             }
        	public  ArrayList<Triangle>  getWatcht(int t1)  throws RemoteException
        	 {ArrayList<Triangle> tri1 = new ArrayList<Triangle>();
        	   if(t1>0&&t1<=tri.size()) {
        		   for(int i=0;i<t1;i++) 
        			   tri1.add(tri.get(i));
        		   }
        		   else if (t1>tri.size()) {
        			   tri1=tri;
        	   }
        	   return tri1;
             }
}
