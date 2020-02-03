package mono.shark;


public class OnHprofRecordListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		shark.OnHprofRecordListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onHprofRecord:(JLshark/HprofRecord;)V:GetOnHprofRecord_JLshark_HprofRecord_Handler:Shark.IOnHprofRecordListenerInvoker, SharkHprof\n" +
			"";
		mono.android.Runtime.register ("Shark.IOnHprofRecordListenerImplementor, SharkHprof", OnHprofRecordListenerImplementor.class, __md_methods);
	}


	public OnHprofRecordListenerImplementor ()
	{
		super ();
		if (getClass () == OnHprofRecordListenerImplementor.class)
			mono.android.TypeManager.Activate ("Shark.IOnHprofRecordListenerImplementor, SharkHprof", "", this, new java.lang.Object[] {  });
	}


	public void onHprofRecord (long p0, shark.HprofRecord p1)
	{
		n_onHprofRecord (p0, p1);
	}

	private native void n_onHprofRecord (long p0, shark.HprofRecord p1);

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
