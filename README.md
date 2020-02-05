# LeakCanary Test

This project was created to test and demonstrate how well LeakCanary works with Xamarin. There is a branch using LeakCanary 1.5.1.1 and a branch using LeakCanary 2.1.1.

This project demonstrates leaks within Activities and Fragments.

After using both versions of LeakCanary it seems they both worked just as well. They just reported the leaks a little differently. Mainly, version 1.5.1.1 has much more verbose logs that are not necessarily helpful however it seems to report on more leaks at once where 2.1.1 reports a leak, and waits for you to fix it before reporting another.

# Activity Leaks

I was able to cause a leak in an activity by not properly disposing event handlers and view references. This is demonstrated on the ThirdActivity. 

To trigger this leak, you must go to the `ThirdActivty` and then use the Android OS Back button to trigger the `OnDestroy()` method. The back button is required so that the Activity is actually destroyed.

Both versions of LeakCanary will reports a leak with `Button.mContext` however LeakCanary 1.5.1.1 will also report about another leak with `TextView.mContext.` . LeakCanary 2.1.1 will only report about the leak in the Textview once the Button leak has been resolved.

**LeakCanary 2.1.1**
```
Debug (3338) / LeakCanary: Signature: da39a3ee5e6b4bd3255bfef95601890afd879
Debug (3338) / LeakCanary: ┬───
Debug (3338) / LeakCanary: │ GC Root: Global variable in native code
Debug (3338) / LeakCanary: │
Debug (3338) / LeakCanary: ├─ android.widget.Button instance
Debug (3338) / LeakCanary: │    Leaking: YES (View.mContext references a destroyed activity)
Debug (3338) / LeakCanary: │    mContext instance of crc648ee606ad49166d9e.ThirdActivity with mDestroyed = true
Debug (3338) / LeakCanary: │    View#mParent is set
Debug (3338) / LeakCanary: │    View#mAttachInfo is null (view detached)
Debug (3338) / LeakCanary: │    View.mID = R.id.OpenPreviousActivityButtonClick
Debug (3338) / LeakCanary: │    View.mWindowAttachCount = 1
Debug (3338) / LeakCanary: │    ↓ Button.mContext
Debug (3338) / LeakCanary: ╰→ crc648ee606ad49166d9e.ThirdActivity instance
Debug (3338) / LeakCanary: ​     Leaking: YES (ObjectWatcher was watching this because crc648ee606ad49166d9e.ThirdActivity received Activity#onDestroy() callback and Activity#mDestroyed is true)
Debug (3338) / LeakCanary: ​     key = e1162699-49f5-4d75-8785-e79f8dca600e
Debug (3338) / LeakCanary: ​     watchDurationMillis = 3019
Debug (3338) / LeakCanary: ​     retainedDurationMillis = -1
Debug (3338) / LeakCanary: ====================================
```

This leak happens because we create references and event handlers but do not dispose of them in the `OnDestroy()` method. We also need to make sure to call `Dispose()` in the `OnDestroy()` method also. Otherwise you will get the following Leak

**LeakCanary 2.1.1**
```
Debug (10863) / LeakCanary: 66109 bytes retained by leaking objects
Debug (10863) / LeakCanary: Signature: da39a3ee5e6b4bd3255bfef95601890afd879
Debug (10863) / LeakCanary: ┬───
Debug (10863) / LeakCanary: │ GC Root: Global variable in native code
Debug (10863) / LeakCanary: │
Debug (10863) / LeakCanary: ╰→ crc648ee606ad49166d9e.SecondActivity instance
Debug (10863) / LeakCanary: ​     key = 15f231c1-6824-4e1f-8b9c-5a373085225a
Debug (10863) / LeakCanary: ​     watchDurationMillis = 6377
Debug (10863) / LeakCanary: ​     retainedDurationMillis = 1359
Debug (10863) / LeakCanary: ====================================

```
