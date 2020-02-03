package mono.leakcanary;


public class OnHeapAnalyzedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		leakcanary.OnHeapAnalyzedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onHeapAnalyzed:(Lshark/HeapAnalysis;)V:GetOnHeapAnalyzed_Lshark_HeapAnalysis_Handler:Leakcanary.IOnHeapAnalyzedListenerInvoker, LeakCanary.Android.Core\n" +
			"";
		mono.android.Runtime.register ("Leakcanary.IOnHeapAnalyzedListenerImplementor, LeakCanary.Android.Core", OnHeapAnalyzedListenerImplementor.class, __md_methods);
	}


	public OnHeapAnalyzedListenerImplementor ()
	{
		super ();
		if (getClass () == OnHeapAnalyzedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Leakcanary.IOnHeapAnalyzedListenerImplementor, LeakCanary.Android.Core", "", this, new java.lang.Object[] {  });
	}


	public void onHeapAnalyzed (shark.HeapAnalysis p0)
	{
		n_onHeapAnalyzed (p0);
	}

	private native void n_onHeapAnalyzed (shark.HeapAnalysis p0);

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
