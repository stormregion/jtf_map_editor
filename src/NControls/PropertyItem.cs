using GRTTI;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyItem
	{
		public delegate void ListOpHandler(int arrayidx);

		public delegate void CopyPasteHandler(PropertyItem item);

		public delegate void __Delegate_ItemChanged();

		protected string Name;

		protected unsafe GClass* Type;

		protected unsafe void* Var;

		protected unsafe GClass* ParentType;

		protected unsafe void* ParentVar;

		protected string Description;

		protected uint Default;

		protected uint Minimum;

		protected uint Maximum;

		protected uint Step;

		protected string MeasureString;

		protected ContextMenu DefaultMenu;

		protected ContextMenu EditMenu;

		public int Index;

		public int ArrayIndex;

		public int IndentDepth;

		public PropertyTreeCore Host;

		public bool Expanded;

		public event PropertyItem.__Delegate_ItemChanged ItemChanged
		{
			add
			{
				this.ItemChanged = Delegate.Combine(this.ItemChanged, value);
			}
			remove
			{
				this.ItemChanged = Delegate.Remove(this.ItemChanged, value);
			}
		}

		public event PropertyItem.CopyPasteHandler Paste
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Paste = Delegate.Combine(this.Paste, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Paste = Delegate.Remove(this.Paste, value);
			}
		}

		public event PropertyItem.CopyPasteHandler Copy
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Copy = Delegate.Combine(this.Copy, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Copy = Delegate.Remove(this.Copy, value);
			}
		}

		public event PropertyItem.ListOpHandler MoveDown
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.MoveDown = Delegate.Combine(this.MoveDown, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.MoveDown = Delegate.Remove(this.MoveDown, value);
			}
		}

		public event PropertyItem.ListOpHandler MoveUp
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.MoveUp = Delegate.Combine(this.MoveUp, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.MoveUp = Delegate.Remove(this.MoveUp, value);
			}
		}

		public event PropertyItem.ListOpHandler Insert
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Insert = Delegate.Combine(this.Insert, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Insert = Delegate.Remove(this.Insert, value);
			}
		}

		public event PropertyItem.ListOpHandler Remove
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Remove = Delegate.Combine(this.Remove, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Remove = Delegate.Remove(this.Remove, value);
			}
		}

		public PropertyItem()
		{
			this.ItemChanged = null;
			this.Remove = null;
			this.Insert = null;
			this.MoveUp = null;
			this.MoveDown = null;
			this.Copy = null;
			this.Paste = null;
			this.DefaultMenu = new ContextMenu();
			MenuItem menuItem = new MenuItem("Reset to default");
			menuItem.Click += new EventHandler(this.OnDefault);
			this.DefaultMenu.MenuItems.Add(menuItem);
			if (this.HasDefaultOption())
			{
				menuItem.Enabled = true;
			}
			else
			{
				menuItem.Enabled = false;
			}
			this.EditMenu = new ContextMenu();
			MenuItem menuItem2 = new MenuItem("Copy");
			menuItem2.Click += new EventHandler(this.OnCopy);
			this.EditMenu.MenuItems.Add(menuItem2);
			MenuItem menuItem3 = new MenuItem("Paste");
			menuItem3.Click += new EventHandler(this.OnPaste);
			this.EditMenu.MenuItems.Add(menuItem3);
		}

		public unsafe int IdentifyType()
		{
			return *(int*)this.Type;
		}

		public unsafe void SaveToBuffer(GStream* st)
		{
			<Module>.GRTTI.SaveVariablesAsText(st, this.Type, this.Var, ref <Module>.Measures);
		}

		public unsafe void LoadFromBuffer(GStream* st)
		{
			<Module>.GRTTI.LoadVariablesAsText(st, this.Type, this.Var, ref <Module>.Measures);
		}

		public virtual void Refresh()
		{
		}

		public virtual void UpdateControl(Rectangle bounds)
		{
		}

		public virtual void DestroyControl()
		{
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public virtual bool OnEnterPressed()
		{
			return false;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public virtual bool CanBeExpanded()
		{
			return false;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public virtual bool ShouldBeExpanded()
		{
			return this.CanBeExpanded();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool IsExpanded()
		{
			return this.Expanded;
		}

		public virtual ArrayList Expand()
		{
			return null;
		}

		protected override void Finalize()
		{
			this.DestroyControl();
		}

		public virtual string GetName()
		{
			return this.Name;
		}

		public virtual string GetNameWithMeasure()
		{
			return this.GetName() + " " + this.MeasureString;
		}

		public virtual string GetDescription()
		{
			return this.Description;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public virtual bool IsDefault()
		{
			return false;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public virtual bool HasDefaultOption()
		{
			return false;
		}

		public Menu GetContextMenu()
		{
			return this.DefaultMenu;
		}

		public Menu GetEditContextMenu()
		{
			return this.EditMenu;
		}

		public void OnDefault(object sender, EventArgs e)
		{
			this.SetDefault();
		}

		public void OnCopy(object sender, EventArgs e)
		{
			PropertyItem.CopyPasteHandler copy = this.Copy;
			if (copy != null)
			{
				copy(this);
			}
		}

		public void OnPaste(object sender, EventArgs e)
		{
			PropertyItem.CopyPasteHandler paste = this.Paste;
			if (paste != null)
			{
				paste(this);
			}
		}

		public void InjectMenu(MenuItem menuitem)
		{
			this.DefaultMenu.MenuItems.Add(menuitem);
		}

		public virtual void SetDefault()
		{
		}

		public void OnInsert(object sender, EventArgs e)
		{
			PropertyItem.ListOpHandler insert = this.Insert;
			if (insert != null)
			{
				insert(this.ArrayIndex);
			}
		}

		public void OnRemove(object sender, EventArgs e)
		{
			PropertyItem.ListOpHandler remove = this.Remove;
			if (remove != null)
			{
				remove(this.ArrayIndex);
			}
		}

		public void OnMoveUp(object sender, EventArgs e)
		{
			PropertyItem.ListOpHandler moveUp = this.MoveUp;
			if (moveUp != null)
			{
				moveUp(this.ArrayIndex);
			}
		}

		public void OnMoveDown(object sender, EventArgs e)
		{
			PropertyItem.ListOpHandler moveDown = this.MoveDown;
			if (moveDown != null)
			{
				moveDown(this.ArrayIndex);
			}
		}

		public unsafe static PropertyItem MakeProperty(string name, sbyte* description, GClass* type, void* var, uint default_value, uint min_value, uint max_value, uint step_value)
		{
			PropertyItem propertyItem;
			switch (*(int*)type)
			{
			case 1:
				propertyItem = new PropertyItemBoolean();
				break;
			case 2:
				propertyItem = new PropertyItemInteger((long)default_value, (long)min_value, (long)max_value, (long)step_value);
				break;
			case 3:
				propertyItem = new PropertyItemInteger((long)default_value, (long)min_value, (long)max_value, (long)step_value);
				break;
			case 4:
				propertyItem = new PropertyItemInteger((long)default_value, (long)min_value, (long)max_value, (long)step_value);
				break;
			case 5:
				propertyItem = new PropertyItemInteger((long)default_value, (long)min_value, (long)max_value, (long)step_value);
				break;
			case 6:
				propertyItem = new PropertyItemInteger(default_value, min_value, max_value, step_value);
				break;
			case 7:
				propertyItem = new PropertyItemInteger((long)default_value, (long)min_value, (long)max_value, (long)step_value);
				break;
			case 8:
				propertyItem = new PropertyItemFloat(default_value, min_value, max_value, step_value);
				break;
			case 9:
				propertyItem = new PropertyItemFloat(default_value, min_value, max_value, step_value);
				propertyItem.MeasureString = "<m>";
				break;
			case 10:
				propertyItem = new PropertyItemFloat(default_value, min_value, max_value, step_value);
				propertyItem.MeasureString = "<cm>";
				break;
			case 11:
				propertyItem = new PropertyItemFloat(default_value, min_value, max_value, step_value);
				propertyItem.MeasureString = "<s>";
				break;
			case 12:
				propertyItem = new PropertyItemFloat(default_value, min_value, max_value, step_value);
				propertyItem.MeasureString = "<km/h>";
				break;
			case 13:
				propertyItem = new PropertyItemFloat(default_value, min_value, max_value, step_value);
				propertyItem.MeasureString = "<deg>";
				break;
			case 14:
				propertyItem = new PropertyItemFloat(default_value, min_value, max_value, step_value);
				propertyItem.MeasureString = "<deg/s>";
				break;
			case 15:
				propertyItem = new PropertyItemFloat(default_value, min_value, max_value, step_value);
				break;
			case 16:
			case 17:
			case 19:
			case 20:
			case 22:
				propertyItem = new PropertyItemVector();
				break;
			case 18:
			case 21:
			case 23:
			case 24:
				goto IL_3EC;
			case 25:
				propertyItem = new PropertyItemString();
				break;
			case 26:
				propertyItem = new PropertyItemWString();
				break;
			case 27:
				propertyItem = new PropertyItemFileName(27);
				break;
			case 28:
				propertyItem = new PropertyItemFileName(28);
				break;
			case 29:
				propertyItem = new PropertyItemFileName(29);
				break;
			case 30:
				propertyItem = new PropertyItemFileName(30);
				break;
			case 31:
				propertyItem = new PropertyItemFileName(31);
				break;
			case 32:
				propertyItem = new PropertyItemFileName(32);
				break;
			case 33:
				propertyItem = new PropertyItemFileName(33);
				break;
			case 34:
				propertyItem = new PropertyItemFileName(34);
				break;
			case 35:
				propertyItem = new PropertyItemFileName(35);
				break;
			case 36:
				propertyItem = new PropertyItemFileName(36);
				break;
			case 37:
				propertyItem = new PropertyItemFileName(37);
				break;
			case 38:
				propertyItem = new PropertyItemStruct();
				break;
			case 39:
				propertyItem = new PropertyItemEnum();
				break;
			case 40:
			{
				int num = *(int*)(type + 52 / sizeof(GClass));
				if (*num != 38)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 133, (sbyte*)(&<Module>.??_C@_0CG@JPCBOHFL@NControls?3?3PropertyItem?3?3MakePro@));
					<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0DE@GGGDDGPM@Pointer?5is?5only?5supported?5with?5s@));
				}
				sbyte* ptr = ref <Module>.??_C@_0O@DPNPBEBH@GPCurveScalar?$AA@;
				int num2 = *(num + 4);
				sbyte b = *num2;
				sbyte b2 = 71;
				if (b >= 71)
				{
					while (b <= b2)
					{
						if (b == 0)
						{
							propertyItem = new PropertyItemScalarTrack();
							goto IL_396;
						}
						num2++;
						ptr++;
						b = *num2;
						b2 = *ptr;
						if (b < b2)
						{
							break;
						}
					}
				}
				propertyItem = new PropertyItemPointerTo();
				break;
			}
			case 41:
				propertyItem = new PropertyItemArray();
				break;
			case 42:
				propertyItem = new PropertyItemDArray();
				break;
			default:
				goto IL_3EC;
			}
			IL_396:
			propertyItem.Name = name;
			propertyItem.Description = new string((sbyte*)description);
			propertyItem.Type = type;
			propertyItem.Var = var;
			propertyItem.Default = default_value;
			propertyItem.Minimum = min_value;
			propertyItem.Maximum = max_value;
			propertyItem.Step = step_value;
			if (propertyItem.MeasureString == null)
			{
				propertyItem.MeasureString = "";
			}
			return propertyItem;
			IL_3EC:
			<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 141, (sbyte*)(&<Module>.??_C@_0CG@JPCBOHFL@NControls?3?3PropertyItem?3?3MakePro@));
			<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BB@FMKGMNNA@Unsupported?5type?$AA@));
			return null;
		}

		protected void raise_ItemChanged()
		{
			PropertyItem.__Delegate_ItemChanged itemChanged = this.ItemChanged;
			if (itemChanged != null)
			{
				itemChanged();
			}
		}

		protected void raise_Remove(int i1)
		{
			PropertyItem.ListOpHandler remove = this.Remove;
			if (remove != null)
			{
				remove(i1);
			}
		}

		protected void raise_Insert(int i1)
		{
			PropertyItem.ListOpHandler insert = this.Insert;
			if (insert != null)
			{
				insert(i1);
			}
		}

		protected void raise_MoveUp(int i1)
		{
			PropertyItem.ListOpHandler moveUp = this.MoveUp;
			if (moveUp != null)
			{
				moveUp(i1);
			}
		}

		protected void raise_MoveDown(int i1)
		{
			PropertyItem.ListOpHandler moveDown = this.MoveDown;
			if (moveDown != null)
			{
				moveDown(i1);
			}
		}

		protected void raise_Copy(PropertyItem i1)
		{
			PropertyItem.CopyPasteHandler copy = this.Copy;
			if (copy != null)
			{
				copy(i1);
			}
		}

		protected void raise_Paste(PropertyItem i1)
		{
			PropertyItem.CopyPasteHandler paste = this.Paste;
			if (paste != null)
			{
				paste(i1);
			}
		}

		public void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
