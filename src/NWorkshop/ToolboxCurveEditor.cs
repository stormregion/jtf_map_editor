using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxCurveEditor : Form
	{
		private NCurveEditor curveeditor;

		private unsafe GEditorWorld* propWorld;

		private unsafe GBaseString<char>* FormCaption;

		private float MinValue;

		private float MaxValue;

		private int CurveType;

		private int CurveIndex;

		private Container components;

		public unsafe ToolboxCurveEditor(int curvetype, int curveindex, GEditorWorld* world, GBaseString<char>* caption, float minvalue, float maxvalue)
		{
			this.propWorld = world;
			this.CurveType = curvetype;
			this.CurveIndex = curveindex;
			this.FormCaption = caption;
			this.MinValue = minvalue;
			this.MaxValue = maxvalue;
			this.InitializeComponent();
			this.CreateCurveEditor();
			uint num = (uint)(*(int*)this.FormCaption);
			sbyte* value;
			if (num != 0u)
			{
				value = num;
			}
			else
			{
				value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
			}
			this.Text = new string((sbyte*)value);
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

		private unsafe void CreateCurveEditor()
		{
			GKeyLimit gKeyLimit = 1f;
			*(ref gKeyLimit + 4) = this.MinValue;
			*(ref gKeyLimit + 8) = this.MaxValue;
			int curveType = this.CurveType;
			if (curveType != 0)
			{
				if (curveType != 1)
				{
					if (curveType == 2)
					{
						this.curveeditor = new NCurveEditor(<Module>.GEditorWorld.GetCameraCurveRollCurve(this.propWorld, this.CurveIndex), ref gKeyLimit);
					}
				}
				else
				{
					this.curveeditor = new NCurveEditor(<Module>.GEditorWorld.GetCameraCurveFOVCurve(this.propWorld, this.CurveIndex), ref gKeyLimit);
				}
			}
			else
			{
				this.curveeditor = new NCurveEditor(<Module>.GEditorWorld.GetCameraCurveTimeCurve(this.propWorld, this.CurveIndex), ref gKeyLimit);
			}
			base.SuspendLayout();
			base.Controls.Add(this.curveeditor);
			base.ResumeLayout(false);
			this.curveeditor.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		}

		private void InitializeComponent()
		{
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(650, 500);
			base.ClientSize = clientSize;
			base.Name = "ToolboxCurveEditor";
		}
	}
}
