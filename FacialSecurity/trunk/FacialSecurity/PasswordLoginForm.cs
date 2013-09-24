using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacialSecurity
{
	public partial class PasswordLoginForm : Form
	{
		public PasswordLoginForm()
		{
			InitializeComponent();
		}

		public string TextBoxPasswordContent
		{
			get { return textBoxPassword.Text; }
		}
	}
}
