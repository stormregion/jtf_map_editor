using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyItemFloat : PropertyItem
	{
		protected NFloatUpDown EditControl;

		protected float LowerBound;

		protected float UpperBound;

		protected float StepValue;

		protected float DefaultValue;

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
				this.EditControl.Value = this.GetValue();
				this.Host.Focus();
				this.Host.InvalidateViewControl();
				e.Handled = true;
			}
		}

		protected void EditControl_Validated(object sender, EventArgs e)
		{
			this.SetValue(this.EditControl.Value);
			if (this.IsDefault())
			{
				this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Regular);
			}
			else
			{
				this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Bold);
			}
		}

		protected void EditControl_MouseDown(object __unnamed000, MouseEventArgs e)
		{
			Point location = this.EditControl.Location;
			PropertyTreeCore host = this.Host;
			host.SelectedIndex = (int)((double)((float)location.Y / host.ItemHeight));
			this.Host.EnsureSelectedVisible();
		}

		protected unsafe virtual double GetValue()
		{
			switch (*(int*)this.Type)
			{
			case 8:
				return (double)(*(float*)this.Var);
			case 9:
				return (double)(*(float*)this.Var / *(float*)this.Host.Measures);
			case 10:
				return (double)(*(float*)this.Var / *(float*)(this.Host.Measures + 8 / sizeof(GMeasures)));
			case 11:
				return (double)(*(float*)this.Var / *(float*)(this.Host.Measures + 16 / sizeof(GMeasures)));
			case 12:
				return (double)(*(float*)this.Var / *(float*)(this.Host.Measures + 24 / sizeof(GMeasures)));
			case 13:
				return (double)(*(float*)this.Var / *(float*)(this.Host.Measures + 32 / sizeof(GMeasures)));
			case 14:
				return (double)(*(float*)this.Var / *(float*)(this.Host.Measures + 40 / sizeof(GMeasures)));
			case 15:
				return *(double*)this.Var;
			default:
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 874, (sbyte*)(&<Module>.??_C@_0CH@HHLOLGMI@NControls?3?3PropertyItemFloat?3?3Ge@));
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BJ@CIEPDBBG@Unsupported?5integer?5type?$AA@));
				return 0.0;
			}
		}

		protected unsafe virtual void SetValue(double value)
		{
			switch (*(int*)this.Type)
			{
			case 8:
				*(float*)this.Var = (float)value;
				break;
			case 9:
				*(float*)this.Var = *(float*)this.Host.Measures * (float)value;
				break;
			case 10:
				*(float*)this.Var = *(float*)(this.Host.Measures + 8 / sizeof(GMeasures)) * (float)value;
				break;
			case 11:
				*(float*)this.Var = *(float*)(this.Host.Measures + 16 / sizeof(GMeasures)) * (float)value;
				break;
			case 12:
				*(float*)this.Var = *(float*)(this.Host.Measures + 24 / sizeof(GMeasures)) * (float)value;
				break;
			case 13:
				*(float*)this.Var = *(float*)(this.Host.Measures + 32 / sizeof(GMeasures)) * (float)value;
				break;
			case 14:
				*(float*)this.Var = *(float*)(this.Host.Measures + 40 / sizeof(GMeasures)) * (float)value;
				break;
			case 15:
				*(float*)this.Var = (float)value;
				break;
			default:
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 907, (sbyte*)(&<Module>.??_C@_0CH@IGJCKFLF@NControls?3?3PropertyItemFloat?3?3Se@));
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BH@IHKGLKBB@Unsupported?5float?5type?$AA@));
				return;
			}
			base.raise_ItemChanged();
			this.Host.RaiseItemChanged();
		}

		public override void Refresh()
		{
			this.EditControl.Value = this.GetValue();
			this.EditControl.RaiseValidate();
			this.Host.RaiseItemChanged();
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
				NFloatUpDown nFloatUpDown = new NFloatUpDown();
				this.EditControl = nFloatUpDown;
				nFloatUpDown.BorderStyle = BorderStyle.None;
				Point location2 = bounds.Location;
				this.EditControl.Location = location2;
				Size size2 = bounds.Size;
				this.EditControl.Size = size2;
				this.EditControl.TabIndex = 1;
				this.EditControl.Value = this.GetValue();
				this.EditControl.LeftMargin = 1;
				this.EditControl.Minimum = (double)this.LowerBound;
				this.EditControl.Maximum = (double)this.UpperBound;
				this.EditControl.Increment = (double)this.StepValue;
				Color unValidatedColor = Color.FromKnownColor(KnownColor.Red);
				this.EditControl.UnValidatedColor = unValidatedColor;
				if (this.IsDefault())
				{
					this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Regular);
				}
				else
				{
					this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Bold);
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
			NFloatUpDown editControl = this.EditControl;
			if (editControl != null)
			{
				editControl.Focus();
				this.EditControl.SelectionLength = 0;
			}
			this.Host.InvalidateViewControl();
			return true;
		}

		public PropertyItemFloat(float default_value, float lower_bound, float upper_bound, float step_value)
		{
			try
			{
				this.LowerBound = lower_bound;
				this.UpperBound = upper_bound;
				this.StepValue = step_value;
				this.DefaultValue = default_value;
			}
			catch
			{
				base.{dtor}();
				throw;
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool IsDefault()
		{
			return false;
		}

		public override void SetDefault()
		{
			int @default = (int)this.Default;
			this.EditControl.Value = (double)@default;
			this.EditControl.RaiseValidate();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool HasDefaultOption()
		{
			return true;
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
