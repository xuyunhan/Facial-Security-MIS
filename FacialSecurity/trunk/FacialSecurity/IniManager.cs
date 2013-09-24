using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FacialSecurity

{
	public class CIniManager
	{
		private readonly string _inipath;//配置文件包括文件名和后缀的全路径
														//，readonly成员只能在构造函数中被初始化

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder retVal,int size,string filePath);
		
		/// <summary>
		/// 构造方法
		/// </summary>
		/// <param name="iniPath">文件路径</param>
		public CIniManager(string iniPath)
		{
			_inipath = iniPath;
		}
		
		/// <summary>
		/// 写入INI文件
		/// </summary>
		/// <param name="section">项目名称(如 [TypeName] )</param>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		public void IniWriteValue(string section,string key,string value)
		{
			WritePrivateProfileString(section,key,value,this._inipath);
		}
		
		/// <summary>
		/// 读出INI文件
		/// </summary>
		/// <param name="section">项目名称(如 [TypeName] )</param>
		/// <param name="key">键</param>
		public string IniReadValue(string section, string key)
		{
			var temp = new StringBuilder(500);
			var i = GetPrivateProfileString(section//section名
															,key//key名
															,""//若前两个值不存在则用这个给temp
															,temp//section中key对应的value存放到temp
															,500//缓存大小
															,this._inipath);//配置文件包括文件名和后缀的全路径
			return temp.ToString();
		}
	
		/// <summary>
		///  验证文件是否存在
		/// </summary>
		/// <returns>布尔值</returns>
		public bool ExistIniFile()
		{
			return File.Exists(_inipath);
		}
	}
}
