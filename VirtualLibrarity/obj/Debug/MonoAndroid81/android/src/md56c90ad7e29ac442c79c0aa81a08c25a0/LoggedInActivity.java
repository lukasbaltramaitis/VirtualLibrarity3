package md56c90ad7e29ac442c79c0aa81a08c25a0;


public class LoggedInActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("VirtualLibrarity.LoggedInActivity, VirtualLibrarity", LoggedInActivity.class, __md_methods);
	}


	public LoggedInActivity ()
	{
		super ();
		if (getClass () == LoggedInActivity.class)
			mono.android.TypeManager.Activate ("VirtualLibrarity.LoggedInActivity, VirtualLibrarity", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
