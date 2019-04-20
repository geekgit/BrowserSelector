using System;
using System.Collections;
using System.Text;
using System.Threading;
using Gtk;

namespace BrowserSelector
{
    class MainClass
    {
		static ArrayList Browsers = new ArrayList();
		static ArrayList BrowserButtons = new ArrayList();
		static MainWindow mainWin = null;
		static VBox vbox_main = null;
		static VBox vbox_buttons = null;
		static HBox hbox_buttons=null;
		static TextView tv = null;
		static TextView url_tv = null;
        public static void BrowsersInit()
		{
			Browser Firefox = new BrowserAuto("firefox");
			Firefox.ExecLinux = @"/usr/bin/firefox %1";
            Browser Chromium = new BrowserAuto("chromium");
			Chromium.ExecLinux = @"/usr/bin/chromium-browser %1";
			Browser Chrome = new BrowserAuto("chrome");
			Chrome.ExecLinux = @"/usr/bin/google-chrome %1";
			Browser Opera = new BrowserAuto("opera");
			Browser Safari = new BrowserAuto("safari");
			Browser SeaMonkey = new BrowserAuto("seamonkey");
			SeaMonkey.Title = "SeaMonkey";
			Browser YandexBrowser = new BrowserAuto("yandexbrowser");
			YandexBrowser.Title = "Яндекс.Браузер";
			Browser Maxthon = new BrowserAuto("maxthon");
			Browser IE = new BrowserAuto("IE");

            Browsers.Add(Firefox);
            Browsers.Add(Chromium);
			Browsers.Add(Chrome);
			Browsers.Add(Opera);
			Browsers.Add(Safari);
			Browsers.Add(SeaMonkey);
			Browsers.Add(YandexBrowser);
		}
        public static string SysInfo()
		{
			StringBuilder sb = new StringBuilder();
            
			sb.AppendFormat("OS: {0} {1}", Environment.OSVersion.Platform, Environment.NewLine);
			sb.AppendFormat("64 bit process: {0} {1}", Environment.Is64BitProcess, Environment.NewLine);
			sb.AppendFormat("64 bit OS: {0} {1}", Environment.Is64BitOperatingSystem, Environment.NewLine);
			sb.AppendFormat("Timezone: {0} {1}", TimeZone.CurrentTimeZone.StandardName, Environment.NewLine);
			sb.AppendFormat("Culture: {0} {1}", Thread.CurrentThread.CurrentCulture.ToString(), Environment.NewLine);
            
			return sb.ToString();
           
		}
        public static void ShowMessage(string text)
		{
			Window window = mainWin;
			if (window != null)
			{
				MessageDialog message = new MessageDialog(window, DialogFlags.DestroyWithParent,
														 MessageType.Info, ButtonsType.Close, text);
				message.Run();
				message.Destroy();
			}				
		}
        public static void Main(string[] args)
        {
			
			BrowsersInit();
            Application.Init();
			mainWin = new MainWindow();
			mainWin.Title = "Browser Selector";
            mainWin.Show();
			url_tv = new TextView();


			vbox_main = new VBox();

			mainWin.Add(vbox_main);
			vbox_main.Show();
			vbox_main.Add(url_tv);
			url_tv.Show();
			url_tv.Editable = false;
			hbox_buttons = new HBox();
			vbox_main.Add(hbox_buttons);
			hbox_buttons.Show();
			vbox_buttons = new VBox();



			tv = new TextView();
			if(args.Length>0)
			{
				string args_j = string.Join(" ", args);
				url_tv.Buffer.Text = args_j;
			}
			else
			{
				url_tv.Buffer.Text = "about:blank";
			}
			tv.Buffer.Text = SysInfo();
			hbox_buttons.Add(tv);
			tv.Show();
			tv.Editable = false;
            
			hbox_buttons.Add(vbox_buttons);
			vbox_buttons.Show();
			foreach(Browser browser in Browsers)
			{
				Button button = new Button();
				button.Label = browser.Title;
				vbox_buttons.Add(button);
				button.Show();
				BrowserButtons.Add(button);
				browser.GTKWidget = button;
			}
           
			foreach(Browser browser in Browsers)
			{
				bool flag = browser.CheckLinux();
                if(!flag)
				{
					Button button = (Button)browser.GTKWidget;
					button.Sensitive = false;
				}
			}
            Application.Run();
        }
    }
}
