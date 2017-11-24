using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ScriptEditorWindow
{
	public class InPlaceEditing_ListBox : ListBox
	{
		public event EventHandler SelectionCancel
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.SelectionCancel = Delegate.Combine(this.SelectionCancel, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.SelectionCancel = Delegate.Remove(this.SelectionCancel, value);
			}
		}

		public event EventHandler SelectionReady
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.SelectionReady = Delegate.Combine(this.SelectionReady, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.SelectionReady = Delegate.Remove(this.SelectionReady, value);
			}
		}

		public override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style = -1868562432;
				createParams.ExStyle = 0;
				return createParams;
			}
		}

		public InPlaceEditing_ListBox()
		{
			this.SelectionReady = null;
			this.SelectionCancel = null;
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
						this.raise_SelectionReady(this, new EventArgs());
						return;
					}
				}
			}
			this.raise_SelectionCancel(this, new EventArgs());
		}

		public override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.raise_SelectionReady(this, new EventArgs());
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.raise_SelectionCancel(this, new EventArgs());
			}
			else
			{
				base.OnKeyDown(e);
			}
		}

		protected void raise_SelectionReady(object i1, EventArgs i2)
		{
			EventHandler selectionReady = this.SelectionReady;
			if (selectionReady != null)
			{
				selectionReady(i1, i2);
			}
		}

		protected void raise_SelectionCancel(object i1, EventArgs i2)
		{
			EventHandler selectionCancel = this.SelectionCancel;
			if (selectionCancel != null)
			{
				selectionCancel(i1, i2);
			}
		}

		public void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
