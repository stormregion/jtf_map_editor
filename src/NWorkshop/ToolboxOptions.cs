using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxOptions : UserControl
	{
		public delegate void __Delegate_OptionsChanged();

		private Container components;

		private Button btnCleanup;

		private TreeView treeResources;

		private PropertyTree OptionsPropertyTree;

		public event ToolboxOptions.__Delegate_OptionsChanged OptionsChanged
		{
			add
			{
				this.OptionsChanged = Delegate.Combine(this.OptionsChanged, value);
			}
			remove
			{
				this.OptionsChanged = Delegate.Remove(this.OptionsChanged, value);
			}
		}

		public ToolboxOptions()
		{
			this.OptionsChanged = null;
			this.InitializeComponent();
			PropertyTree propertyTree = new PropertyTree(0, NewAssetPicker.ObjectType.OptionsEditor, null);
			this.OptionsPropertyTree = propertyTree;
			propertyTree.Dock = DockStyle.Top;
			Point location = new Point(0, 0);
			this.OptionsPropertyTree.Location = location;
			this.OptionsPropertyTree.Name = "OptionsPropertyTree";
			Size size = new Size(200, 300);
			this.OptionsPropertyTree.Size = size;
			this.OptionsPropertyTree.TabIndex = 0;
			this.OptionsPropertyTree.Text = "OptionsPropertyTree";
			this.OptionsPropertyTree.ItemChanged += new PropertyTree.__Delegate_ItemChanged(this.OptionsPropertyTree_ItemChanged);
			base.Controls.Add(this.OptionsPropertyTree);
		}

		public unsafe override void Refresh()
		{
			GMeasures gMeasures;
			this.OptionsPropertyTree.SetVariable(null, null, <Module>.GMeasures.{ctor}(ref gMeasures, 1f, 1f));
			GMeasures gMeasures2;
			this.OptionsPropertyTree.SetVariable(&<Module>.GRTT_WorkshopOptions.Class_GViewOptions, ref <Module>.Options + 68, <Module>.GMeasures.{ctor}(ref gMeasures2, 1f, 1f));
		}

		private unsafe void AddNodes(TreeNodeCollection parent, GResourceStat* rstat)
		{
			int num = 0;
			int num2 = *(int*)(rstat + 16 / sizeof(GResourceStat));
			if (0 < num2)
			{
				int num3 = 0;
				do
				{
					int num4 = num3 + *(int*)(rstat + 12 / sizeof(GResourceStat));
					GResourceStat* ptr = num4;
					uint num5 = (uint)(*num4);
					sbyte* ptr2;
					if (num5 != 0u)
					{
						ptr2 = num5;
					}
					else
					{
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr3 = <Module>.Format(&gBaseString<char>, (sbyte*)(&<Module>.??_C@_0O@EGKHGIFB@?$CFs?5?$CI?$CF1?42f?5MB?$CJ?$AA@), ptr2, *(ptr + 8) * 9.5367431640625E-07);
					int index;
					try
					{
						uint num6 = (uint)(*(int*)ptr3);
						sbyte* value;
						if (num6 != 0u)
						{
							value = num6;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						index = parent.Add(new TreeNode(new string((sbyte*)value)));
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
						throw;
					}
					if (gBaseString<char> != null)
					{
						<Module>.free(gBaseString<char>);
						gBaseString<char> = 0;
					}
					GResourceStat* rstat2 = *(int*)(rstat + 12 / sizeof(GResourceStat)) + num3;
					this.AddNodes(parent[index].Nodes, rstat2);
					num++;
					num3 += 24;
				}
				while (num < *(int*)(rstat + 16 / sizeof(GResourceStat)));
			}
		}

		public unsafe void RefreshResourceTree()
		{
			this.treeResources.BeginUpdate();
			this.treeResources.Nodes.Clear();
			GIEngine* expr_20 = <Module>.IEngine;
			GResourceStat* ptr = calli(GResourceStat* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_20, *(*(int*)expr_20 + 92));
			uint num = (uint)(*(int*)ptr);
			sbyte* ptr2;
			if (num != 0u)
			{
				ptr2 = num;
			}
			else
			{
				ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
			}
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr3 = <Module>.Format(&gBaseString<char>, (sbyte*)(&<Module>.??_C@_0O@EGKHGIFB@?$CFs?5?$CI?$CF1?42f?5MB?$CJ?$AA@), ptr2, *(int*)(ptr + 8 / sizeof(GResourceStat)) * 9.5367431640625E-07);
			int index;
			try
			{
				uint num2 = (uint)(*(int*)ptr3);
				sbyte* value;
				if (num2 != 0u)
				{
					value = num2;
				}
				else
				{
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				index = this.treeResources.Nodes.Add(new TreeNode(new string((sbyte*)value)));
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
			this.AddNodes(this.treeResources.Nodes[index].Nodes, ptr);
			GResourceStat* pThis = ptr;
			try
			{
				<Module>.GArray<GResourceStat>.{dtor}(ptr + 12 / sizeof(GResourceStat));
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)pThis);
				throw;
			}
			uint num3 = (uint)(*(int*)ptr);
			if (num3 != 0u)
			{
				<Module>.free(num3);
				*(int*)ptr = 0;
			}
			<Module>.delete((void*)ptr);
			GIEngine* expr_109 = <Module>.IEngine;
			GResourceStat* ptr4 = calli(GResourceStat* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_109, *(*(int*)expr_109 + 200));
			uint num4 = (uint)(*(int*)ptr4);
			sbyte* ptr5;
			if (num4 != 0u)
			{
				ptr5 = num4;
			}
			else
			{
				ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
			}
			GBaseString<char> gBaseString<char>2;
			GBaseString<char>* ptr6 = <Module>.Format(&gBaseString<char>2, (sbyte*)(&<Module>.??_C@_0O@EGKHGIFB@?$CFs?5?$CI?$CF1?42f?5MB?$CJ?$AA@), ptr5, *(int*)(ptr4 + 8 / sizeof(GResourceStat)) * 9.5367431640625E-07);
			int index2;
			try
			{
				uint num5 = (uint)(*(int*)ptr6);
				sbyte* value2;
				if (num5 != 0u)
				{
					value2 = num5;
				}
				else
				{
					value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				index2 = this.treeResources.Nodes.Add(new TreeNode(new string((sbyte*)value2)));
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			if (gBaseString<char>2 != null)
			{
				<Module>.free(gBaseString<char>2);
			}
			this.AddNodes(this.treeResources.Nodes[index2].Nodes, ptr4);
			GResourceStat* pThis2 = ptr4;
			try
			{
				<Module>.GArray<GResourceStat>.{dtor}(ptr4 + 12 / sizeof(GResourceStat));
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)pThis2);
				throw;
			}
			uint num6 = (uint)(*(int*)ptr4);
			if (num6 != 0u)
			{
				<Module>.free(num6);
				*(int*)ptr4 = 0;
			}
			<Module>.delete((void*)ptr4);
			this.treeResources.EndUpdate();
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				Container container = this.components;
				if (container != null)
				{
					container.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.btnCleanup = new Button();
			this.treeResources = new TreeView();
			base.SuspendLayout();
			this.btnCleanup.Dock = DockStyle.Top;
			Point location = new Point(0, 0);
			this.btnCleanup.Location = location;
			this.btnCleanup.Name = "btnCleanup";
			Size size = new Size(300, 24);
			this.btnCleanup.Size = size;
			this.btnCleanup.TabIndex = 1;
			this.btnCleanup.Text = "Dispose unused resources";
			this.btnCleanup.Click += new EventHandler(this.btnCleanup_Click);
			this.treeResources.Dock = DockStyle.Fill;
			this.treeResources.ImageIndex = -1;
			Point location2 = new Point(0, 0);
			this.treeResources.Location = location2;
			this.treeResources.Name = "treeResources";
			this.treeResources.SelectedImageIndex = -1;
			Size size2 = new Size(300, 600);
			this.treeResources.Size = size2;
			this.treeResources.TabIndex = 0;
			base.Controls.Add(this.treeResources);
			base.Controls.Add(this.btnCleanup);
			base.Name = "ToolboxOptions";
			Size size3 = new Size(300, 600);
			base.Size = size3;
			base.ResumeLayout(false);
		}

		private void OptionsPropertyTree_ItemChanged()
		{
			this.raise_OptionsChanged();
		}

		private unsafe void btnCleanup_Click(object sender, EventArgs e)
		{
			<Module>.GUnitRegistry.UnloadUnusedUnitResources(<Module>.UnitRegistry);
			GIEngine* expr_0F = <Module>.IEngine;
			object arg_1A_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_0F, *(*(int*)expr_0F + 72));
			this.RefreshResourceTree();
		}

		protected void raise_OptionsChanged()
		{
			ToolboxOptions.__Delegate_OptionsChanged optionsChanged = this.OptionsChanged;
			if (optionsChanged != null)
			{
				optionsChanged();
			}
		}
	}
}
