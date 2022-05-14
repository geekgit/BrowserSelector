using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using Gtk;

namespace BrowserSelector
{
	public class Browser
	{
		//exec format: browser.exe %1
		//exec format: /usr/local/bin/browser %1
		private string _name;
		private string _title;
		private string _exec_win;
		private string _exec_linux;
		private Widget _gtk_widget;
		public Widget GTKWidget
		{
			get
			{
				return _gtk_widget;
			}
			set
			{
				_gtk_widget = value;
			}
		}
        public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
		public string ExecWin
        {
            get
            {
				return _exec_win;
            }
            set
            {
				_exec_win = value;
            }
        }
		public string ExecLinux
        {
            get
            {
                return _exec_linux;
            }
            set
            {
                _exec_linux = value;
            }
        }
		public Browser(string NameArg, string TitleArg, string ExecWinArg, string ExecLinuxArg)
		{
			this._name = NameArg;
			this._title = TitleArg;
			this._exec_win = ExecWinArg;
			this._exec_linux = ExecLinuxArg;
		}
        public bool CheckLinux()
		{
			string filename = GetExecLinux();
			if(File.Exists(filename))
			{
				//TODO: check rights
				return true;
			}
			else
			{
				//TODO: print error?
				return false;
			}
		}
        public string GetExecLinux()
		{
			string result = "";
			string exec = _exec_linux;
			string[] cmd = exec.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			if (cmd.Length > 0)
			{
				string cmd0 = cmd[0];
				result = cmd0;
			}
			return result;         
		}
        public void LaunchUrlLinux(string url)
		{
			string exec = _exec_linux.Replace(@"%1",'"'+url+'"');
			string[] cmd = exec.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			if(cmd.Length>0)
			{
				string cmd0 = cmd[0];
				if(cmd.Length>1)
				{
					ArrayList args = new ArrayList();
					for (int i = 1; i < cmd.Length;++i)
					{
						args.Add(cmd[i]);
					}
					string[] args_s = (string[])args.ToArray(typeof(string));

					Process proc = new Process();
					proc.StartInfo.FileName = cmd0;
					proc.StartInfo.Arguments = string.Join(" ", args_s);
					proc.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                    proc.Start();
				}
			}
		}
    
	}
}