using System;

namespace NControls
{
	public class PropertyItemWString : PropertyItemString
	{
		protected unsafe override string GetValue()
		{
			uint num = (uint)(*(int*)this.Var);
			return new string((char*)((num == 0u) ? <Module>.?EmptyString@?$GBaseString@_W@@1PB_WB : num));
		}

		protected unsafe override void SetValue(string value)
		{
			GBaseString<wchar_t> gBaseString<wchar_t>;
			GBaseString<wchar_t>* ptr = <Module>.GBaseString<wchar_t>.{ctor}(ref gBaseString<wchar_t>, value);
			bool flag;
			try
			{
				flag = (((<Module>.GBaseString<wchar_t>.Compare(this.Var, ptr, false) != 0) ? 1 : 0) != 0);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<wchar_t>.{dtor}), (void*)(&gBaseString<wchar_t>));
				throw;
			}
			if (gBaseString<wchar_t> != null)
			{
				<Module>.free(gBaseString<wchar_t>);
			}
			if (flag)
			{
				<Module>.GBaseString<wchar_t>.=(this.Var, value);
				this.Host.RaiseItemChanged();
			}
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
