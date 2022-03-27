using AddinContract;
using static System.Console;

namespace AddinStandard
{
    public class AddinStandard : IAddinContract
    {
        public string AddinTitle => "アドイン .NET Standard";
        public void DoWork() => WriteLine("これは、.NET Standard 2.0 ターゲットの DLL 内に書かれた処理です。");
    }
}
