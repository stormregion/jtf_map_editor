using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ScriptEditorWindow
{
	public class InPlaceEditing_TextBox : TextBox
	{
		public event EventHandler EditingCancel
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.EditingCancel = Delegate.Combine(this.EditingCancel, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.EditingCancel = Delegate.Remove(this.EditingCancel, value);
			}
		}

		public event EventHandler EditingReady
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.EditingReady = Delegate.Combine(this.EditingReady, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.EditingReady = Delegate.Remove(this.EditingReady, value);
			}
		}

		public override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style = -1870659584;
				createParams.ExStyle = 0;
				return createParams;
			}
		}

		public InPlaceEditing_TextBox()
		{
			this.EditingReady = null;
			this.EditingCancel = null;
			this.Multiline = false;
		}

		protected override void Finalize()
		{
			base.Finalize();
		}

		public override void OnMouseDown(MouseEventArgs e)
		{
			if (e.X >= 0)
			{
				Size size = base.Size;
				if (e.X < size.Width && e.Y >= 0)
				{
					Size size2 = base.Size;
					if (e.Y < size2.Height)
					{
						return;
					}
				}
			}
			this.raise_EditingCancel(this, new EventArgs());
		}

		public override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.raise_EditingReady(this, new EventArgs());
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.raise_EditingCancel(this, new EventArgs());
			}
			else
			{
				base.OnKeyDown(e);
			}
		}

		protected void raise_EditingReady(object i1, EventArgs i2)
		{
			EventHandler editingReady = this.EditingReady;
			if (editingReady != null)
			{
				editingReady(i1, i2);
			}
		}

		protected void raise_EditingCancel(object i1, EventArgs i2)
		{
			EventHandler editingCancel = this.EditingCancel;
			if (editingCancel != null)
			{
				editingCancel(i1, i2);
			}
		}

		public void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
