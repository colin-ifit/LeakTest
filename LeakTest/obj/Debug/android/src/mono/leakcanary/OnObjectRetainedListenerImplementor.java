package mono.leakcanary;


public class OnObjectRetainedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		leakcanary.OnObjectRetainedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onObjectRetained:()V:GetOnObjectRetainedHandler:Leakcanary.IOnObjectRetainedListenerInvoker, LeakCanary.ObjectWatcher\n" +
			"";
		mono.android.Runtime.register ("Leakcanary.IOnObjectRetainedListenerImplementor, LeakCanary.ObjectWatcher", OnObjectRetainedListenerImplementor.class, __md_methods);
	}


	public OnObjectRetainedListenerImplementor ()
	{
		super ();
		if (getClass () == OnObjectRetainedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Leakcanary.IOnObjectRetainedListenerImplementor, LeakCanary.ObjectWatcher", "", this, new java.lang.Object[] {  });
	}


	public void onObjectRetained ()
	{
		n_onObjectRetained ();
	}

	private native void n_onObjectRetained ();

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
