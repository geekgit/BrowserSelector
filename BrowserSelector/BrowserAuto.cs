using System;
namespace BrowserSelector
{
	public class BrowserAuto : Browser
	{
		public BrowserAuto(string name) 
			: base(name, name, "", "")
		{
			
            
			string title = name;
			if(title.Length>1)
			{
				char t = title[0];
				char u = char.ToUpper(t);
				title = u + title.Substring(1);
			}
			this.Title = title;

			this.ExecWin = string.Format(@"{0}:\{1}\{2}.exe %1", "C", title, name);
            this.ExecLinux = string.Format(@"{0}/{1} %1", @"/usr/local/bin", name);
		}
	}
}
