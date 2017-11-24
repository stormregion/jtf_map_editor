using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyItemInteger : PropertyItem
	{
		protected NNumericUpDown EditControl;

		protected long LowerBound;

		protected long UpperBound;

		protected long StepValue;

		protected long DefaultValue;

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

		protected void EditControl_ValueChanged(object sender, EventArgs e)
		{
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

		protected void EditControl_MouseDown(object sender, MouseEventArgs e)
		{
			Point location = this.EditControl.Location;
			PropertyTreeCore host = this.Host;
			host.SelectedIndex = (int)((double)((float)location.Y / host.ItemHeight));
			this.Host.EnsureSelectedVisible();
		}

		protected unsafe virtual long GetValue()
		{
			switch (*(int*)this.Type)
			{
			case 2:
				return (long)(*(sbyte*)this.Var);
			case 3:
				return (long)((ulong)(*(byte*)this.Var));
			case 4:
				return (long)(*(short*)this.Var);
			case 5:
				return (long)((ulong)(*(ushort*)this.Var));
			case 6:
				return (long)(*(int*)this.Var);
			case 7:
				return (long)((ulong)(*(int*)this.Var));
			default:
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 593, (sbyte*)(&<Module>.??_C@_0CJ@GECMPENI@NControls?3?3PropertyItemInteger?3?3@));
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BJ@CIEPDBBG@Unsupported?5integer?5type?$AA@));
				return 0L;
			}
		}

		protected unsafe virtual void SetValue(long ival)
		{
			switch (*(int*)this.Type)
			{
			case 2:
			{
				void* var = this.Var;
				if ((long)(*(sbyte*)var) == ival)
				{
					return;
				}
				*(byte*)var = (byte)((int)ival);
				break;
			}
			case 3:
			{
				void* var = this.Var;
				if ((ulong)(*(byte*)var) == (ulong)ival)
				{
					return;
				}
				*(byte*)var = (byte)((int)ival);
				break;
			}
			case 4:
			{
				void* var = this.Var;
				if ((long)(*(short*)var) == ival)
				{
					return;
				}
				*(short*)var = (short)((int)ival);
				break;
			}
			case 5:
			{
				void* var = this.Var;
				if ((ulong)(*(ushort*)var) == (ulong)ival)
				{
					return;
				}
				*(short*)var = (short)((int)ival);
				break;
			}
			case 6:
			{
				void* var = this.Var;
				if ((long)(*(int*)var) == ival)
				{
					return;
				}
				*(int*)var = (int)ival;
				break;
			}
			case 7:
			{
				void* var = this.Var;
				if ((ulong)(*(int*)var) == (ulong)ival)
				{
					return;
				}
				*(int*)var = (int)ival;
				break;
			}
			default:
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 685, (sbyte*)(&<Module>.??_C@_0CJ@JFAAOHKF@NControls?3?3PropertyItemInteger?3?3@));
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BJ@CIEPDBBG@Unsupported?5integer?5type?$AA@));
				return;
			}
			this.Host.RaiseItemChanged();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		protected unsafe bool StringToInt64(string value, long* ival)
		{
			long num = 1L;
			GBaseString<char> gBaseString<char>;
			<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, value);
			try
			{
				if (*(ref gBaseString<char> + 4) != 0)
				{
					while (0 < *(ref gBaseString<char> + 4))
					{
						if (*gBaseString<char> == 32)
						{
							if (1 >= *(ref gBaseString<char> + 4))
							{
								<Module>.free(gBaseString<char>);
								gBaseString<char> = 0;
								*(ref gBaseString<char> + 4) = 0;
								goto IL_199;
							}
							int num2 = *(ref gBaseString<char> + 4) - 1;
							sbyte* ptr = <Module>.malloc((uint)(num2 + 1));
							cpblk(ptr, gBaseString<char> + 1, num2);
							*(byte*)(ptr + num2 / sizeof(sbyte)) = 0;
							<Module>.free(gBaseString<char>);
							gBaseString<char> = ptr;
							*(ref gBaseString<char> + 4) = num2;
							if (num2 == 0)
							{
								goto IL_199;
							}
						}
						else
						{
							IL_A5:
							if (*(ref gBaseString<char> + 4) != 0)
							{
								while (-1 >= -(*(ref gBaseString<char> + 4)))
								{
									if (*(gBaseString<char> + *(ref gBaseString<char> + 4) - 1) == 32)
									{
										<Module>.GBaseString<char>.Crop(ref gBaseString<char>, 0, *(ref gBaseString<char> + 4) - 1);
										if (*(ref gBaseString<char> + 4) == 0)
										{
											goto IL_199;
										}
									}
									else
									{
										IL_103:
										if (*(ref gBaseString<char> + 4) == 0)
										{
											goto IL_199;
										}
										if (0 >= *(ref gBaseString<char> + 4))
										{
											<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
											<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), 0);
											goto IL_199;
										}
										if (*gBaseString<char> != 45)
										{
											goto IL_199;
										}
										num = -1L;
										if (1 < *(ref gBaseString<char> + 4))
										{
											int num3 = *(ref gBaseString<char> + 4) - 1;
											sbyte* ptr2 = <Module>.malloc((uint)(num3 + 1));
											cpblk(ptr2, gBaseString<char> + 1, num3);
											*(byte*)(ptr2 + num3 / sizeof(sbyte)) = 0;
											<Module>.free(gBaseString<char>);
											gBaseString<char> = ptr2;
											*(ref gBaseString<char> + 4) = num3;
											goto IL_199;
										}
										<Module>.free(gBaseString<char>);
										gBaseString<char> = 0;
										*(ref gBaseString<char> + 4) = 0;
										goto IL_199;
									}
								}
								<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
								<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), -1);
								goto IL_103;
							}
							goto IL_199;
						}
					}
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
					<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), 0);
					goto IL_A5;
				}
				IL_199:
				*ival = 0L;
				int num4 = 0;
				if (0 >= *(ref gBaseString<char> + 4))
				{
					goto IL_32B;
				}
				while (true)
				{
					sbyte* ptr3;
					if (num4 >= 0)
					{
						if (num4 >= *(ref gBaseString<char> + 4))
						{
							break;
						}
						ptr3 = gBaseString<char> + num4;
					}
					else
					{
						if (num4 < -(*(ref gBaseString<char> + 4)))
						{
							break;
						}
						ptr3 = *(ref gBaseString<char> + 4) + gBaseString<char> + num4;
					}
					if (*ptr3 < 48)
					{
						goto Block_22;
					}
					sbyte* ptr4;
					if (num4 >= 0)
					{
						if (num4 >= *(ref gBaseString<char> + 4))
						{
							goto IL_2BD;
						}
						ptr4 = gBaseString<char> + num4;
					}
					else
					{
						if (num4 < -(*(ref gBaseString<char> + 4)))
						{
							goto IL_2BD;
						}
						ptr4 = *(ref gBaseString<char> + 4) + gBaseString<char> + num4;
					}
					if (*ptr4 > 57)
					{
						goto Block_26;
					}
					sbyte* ptr5;
					if (num4 >= 0)
					{
						if (num4 >= *(ref gBaseString<char> + 4))
						{
							goto IL_29E;
						}
						ptr5 = gBaseString<char> + num4;
					}
					else
					{
						if (num4 < -(*(ref gBaseString<char> + 4)))
						{
							goto IL_29E;
						}
						ptr5 = *(ref gBaseString<char> + 4) + gBaseString<char> + num4;
					}
					*ival = (long)(*ptr5 - 48) + *ival * 10L;
					long num5 = *ival * num;
					if (num5 > this.UpperBound)
					{
						goto Block_30;
					}
					if (num5 < this.LowerBound)
					{
						goto Block_31;
					}
					num4++;
					if (num4 >= *(ref gBaseString<char> + 4))
					{
						goto Block_32;
					}
				}
				goto IL_2FB;
				Block_22:
				Block_26:
				goto IL_2EC;
				Block_30:
				Block_31:
				Block_32:
				goto IL_32B;
				IL_29E:
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), num4);
				IL_2BD:
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), num4);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			IL_2EC:
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
			}
			return false;
			IL_2FB:
			try
			{
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
				int num4;
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), num4);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			IL_32B:
			try
			{
				*ival *= num;
				long upperBound = this.UpperBound;
				if (*ival > upperBound)
				{
					*ival = upperBound;
				}
				long lowerBound = this.LowerBound;
				if (*ival < lowerBound)
				{
					*ival = lowerBound;
				}
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
			return true;
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
				NNumericUpDown nNumericUpDown = new NNumericUpDown();
				this.EditControl = nNumericUpDown;
				nNumericUpDown.BorderStyle = BorderStyle.None;
				Point location2 = bounds.Location;
				this.EditControl.Location = location2;
				Size size2 = bounds.Size;
				this.EditControl.Size = size2;
				this.EditControl.TabIndex = 1;
				this.EditControl.Value = this.GetValue();
				this.EditControl.LeftMargin = 1;
				this.EditControl.Minimum = this.LowerBound;
				this.EditControl.Maximum = this.UpperBound;
				this.EditControl.Increment = this.StepValue;
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
			NNumericUpDown editControl = this.EditControl;
			if (editControl != null)
			{
				editControl.Focus();
				this.EditControl.SelectionLength = 0;
			}
			this.Host.InvalidateViewControl();
			return true;
		}

		public PropertyItemInteger(long default_value, long lower_bound, long upper_bound, long step_value)
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
		public unsafe override bool IsDefault()
		{
			switch (*(int*)this.Type)
			{
			case 2:
				return ((*(sbyte*)this.Var == (sbyte)this.Default) ? 1 : 0) != 0;
			case 3:
				return ((*(byte*)this.Var == (byte)this.Default) ? 1 : 0) != 0;
			case 4:
				return ((*(short*)this.Var == (short)this.Default) ? 1 : 0) != 0;
			case 5:
				return ((*(ushort*)this.Var == (ushort)this.Default) ? 1 : 0) != 0;
			case 6:
				return ((*(int*)this.Var == (int)this.Default) ? 1 : 0) != 0;
			case 7:
				return ((*(int*)this.Var == (int)this.Default) ? 1 : 0) != 0;
			default:
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 711, (sbyte*)(&<Module>.??_C@_0CK@PECOOCJM@NControls?3?3PropertyItemInteger?3?3@));
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BJ@CIEPDBBG@Unsupported?5integer?5type?$AA@));
				return false;
			}
		}

		public override void SetDefault()
		{
			this.EditControl.Value = (long)this.Default;
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
