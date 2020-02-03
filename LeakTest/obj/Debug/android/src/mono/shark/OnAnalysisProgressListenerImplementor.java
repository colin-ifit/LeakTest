package mono.shark;


public class OnAnalysisProgressListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		shark.OnAnalysisProgressListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnalysisProgress:(Lshark/OnAnalysisProgressListener$Step;)V:GetOnAnalysisProgress_Lshark_OnAnalysisProgressListener_Step_Handler:Shark.IOnAnalysisProgressListenerInvoker, Shark\n" +
			"";
		mono.android.Runtime.register ("Shark.IOnAnalysisProgressListenerImplementor, Shark", OnAnalysisProgressListenerImplementor.class, __md_methods);
	}


	public OnAnalysisProgressListenerImplementor ()
	{
		super ();
		if (getClass () == OnAnalysisProgressListenerImplementor.class)
			mono.android.TypeManager.Activate ("Shark.IOnAnalysisProgressListenerImplementor, Shark", "", this, new java.lang.Object[] {  });
	}


	public void onAnalysisProgress (shark.OnAnalysisProgressListener.Step p0)
	{
		n_onAnalysisProgress (p0);
	}

	private native void n_onAnalysisProgress (shark.OnAnalysisProgressListener.Step p0);

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
