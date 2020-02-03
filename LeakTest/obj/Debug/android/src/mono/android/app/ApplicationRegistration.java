package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("LeakTest.MainApplication, LeakTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc648ee606ad49166d9e.MainApplication.class, crc648ee606ad49166d9e.MainApplication.__md_methods);
		
	}
}
