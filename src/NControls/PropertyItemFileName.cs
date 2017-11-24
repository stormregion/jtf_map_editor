using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyItemFileName : PropertyItem
	{
		protected NFilePickerTextBox EditControl;

		protected int FileType;

		protected void EditControl_Enter(object sender, EventArgs e)
		{
		}

		protected void EditControl_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.Host.Focus();
				this.Host.InvalidateViewControl();
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.EditControl.Text = this.GetValue();
				this.Host.Focus();
				this.Host.InvalidateViewControl();
				e.Handled = true;
			}
		}

		protected void EditControl_Validated(object sender, EventArgs e)
		{
			this.SetValue(this.EditControl.Text);
			this.EditControl.Text = this.GetValue();
			if (this.IsDefault())
			{
				this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Bold);
			}
			else
			{
				this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Regular);
			}
		}

		protected void EditControl_MouseDown(object __unnamed000, MouseEventArgs e)
		{
			Point location = this.EditControl.Location;
			PropertyTreeCore host = this.Host;
			host.SelectedIndex = (int)((double)((float)location.Y / host.ItemHeight));
			this.Host.EnsureSelectedVisible();
		}

		protected unsafe virtual string GetValue()
		{
			uint num = (uint)(*(int*)this.Var);
			return new string((sbyte*)((num == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num));
		}

		protected unsafe virtual void SetValue(string value)
		{
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, value);
			bool flag;
			try
			{
				flag = (((<Module>.GBaseString<char>.Compare(this.Var, ptr, false) != 0) ? 1 : 0) != 0);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
			}
			if (flag)
			{
				<Module>.GBaseString<char>.=(this.Var, value);
				this.Host.RaiseItemChanged();
			}
		}

		public override void Refresh()
		{
			this.EditControl.Text = this.GetValue();
			this.EditControl.RaiseValidate();
			this.Host.RaiseItemChanged();
		}

		public PropertyItemFileName(int filetype)
		{
			try
			{
				this.FileType = filetype;
			}
			catch
			{
				base.{dtor}();
				throw;
			}
		}

		public override void UpdateControl(Rectangle bounds)
		{
			bounds.X++;
			bounds.Y++;
			bounds.Width -= 2;
			bounds.Height--;
			if (this.EditControl != null)
			{
				Point location = bounds.Location;
				this.EditControl.Location = location;
				Size size = bounds.Size;
				this.EditControl.Size = size;
			}
			else
			{
				NFilePickerTextBox nFilePickerTextBox = new NFilePickerTextBox(this.Host.ObjType, this.FileType);
				this.EditControl = nFilePickerTextBox;
				nFilePickerTextBox.BorderStyle = BorderStyle.None;
				Point location2 = bounds.Location;
				this.EditControl.Location = location2;
				Size size2 = bounds.Size;
				this.EditControl.Size = size2;
				this.EditControl.TabIndex = 1;
				this.EditControl.Text = this.GetValue();
				Color unValidatedColor = Color.FromKnownColor(KnownColor.Red);
				this.EditControl.UnValidatedColor = unValidatedColor;
				this.EditControl.SelectionLength = 0;
				if (this.IsDefault())
				{
					this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Bold);
				}
				else
				{
					this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Regular);
				}
				this.Host.Controls.Add(this.EditControl);
				this.EditControl.Enter += new EventHandler(this.EditControl_Enter);
				this.EditControl.KeyDown += new KeyEventHandler(this.EditControl_KeyDown);
				this.EditControl.Validated += new EventHandler(this.EditControl_Validated);
				this.EditControl.MouseDown += new MouseEventHandler(this.EditControl_MouseDown);
			}
		}

		public override void DestroyControl()
		{
			if (this.EditControl != null)
			{
				this.EditControl.Enter -= new EventHandler(this.EditControl_Enter);
				this.EditControl.KeyDown -= new KeyEventHandler(this.EditControl_KeyDown);
				this.EditControl.Validated -= new EventHandler(this.EditControl_Validated);
				this.EditControl.MouseDown -= new MouseEventHandler(this.EditControl_MouseDown);
				this.Host.Controls.Remove(this.EditControl);
				this.EditControl = null;
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool OnEnterPressed()
		{
			NFilePickerTextBox editControl = this.EditControl;
			if (editControl != null)
			{
				editControl.Focus();
				this.EditControl.SelectionLength = 0;
			}
			this.Host.InvalidateViewControl();
			return true;
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
