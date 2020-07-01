package test1;

import java.awt.List;
import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

public interface WatchFace extends Remote{

	ArrayList<Circle>   getWatchc(int c1) throws RemoteException;
	ArrayList<Rectangle>  getWatchr(int r1) throws RemoteException;
	ArrayList<Triangle>    getWatcht(int t1) throws RemoteException;
}
