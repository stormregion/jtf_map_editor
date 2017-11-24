using NWorkshop;
using System;

namespace NControls
{
	public class PropertyItemScalarTrack : PropertyItemFloat
	{
		protected NCurveEditor CurveEditor;

		protected unsafe override double GetValue()
		{
			float num = *(*(*(int*)this.Var + 12) + 4);
			return (double)num;
		}

		protected override void SetValue(double value)
		{
		}

		public PropertyItemScalarTrack()
		{
			try
			{
				this.LowerBound = 1.17549435E-38f;
				this.UpperBound = 3.40282347E+38f;
				this.StepValue = 0.5f;
				this.DefaultValue = 0f;
			}
			catch
			{
				base.{dtor}();
				throw;
			}
		}

		public unsafe NCurveEditor GetTrackEditor()
		{
			NCurveEditor nCurveEditor = new NCurveEditor(*(int*)this.Var);
			this.CurveEditor = nCurveEditor;
			return nCurveEditor;
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
