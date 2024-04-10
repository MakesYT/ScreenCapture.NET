namespace ScreenCapture.NET.Tests;

public class CaptureTool
{
    static DX11ScreenCaptureService screenCaptureService ;
    private static WeakReference _weakReference;
    public static void Test()
    {
        screenCaptureService = new DX11ScreenCaptureService();
        foreach (var display in screenCaptureService.GetDisplays(screenCaptureService.GetGraphicsCards().First()))
        {
            var  screenCapture = screenCaptureService.GetScreenCapture(display);
            var fullscreen = screenCapture.RegisterCaptureZone(0, 0, screenCapture.Display.Width, screenCapture.Display.Height);
            while (!screenCapture.CaptureScreen()) { }
            using (fullscreen.Lock())
            {
                
            }
            _weakReference=new WeakReference(fullscreen);
        }
    }
    public static WeakReference Dispose()
    {
        screenCaptureService.Dispose();
        screenCaptureService = null;
        

        return _weakReference;




    }
}