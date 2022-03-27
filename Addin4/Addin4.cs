using AddinContract;
using static System.Console;

namespace Addin4
{
    public class Addin4 : IAddinContract
    {
        public string AddinTitle => "アドイン 4";
        public void DoWork() => WriteLine("これは、.NET Framework 4.8 ターゲットの DLL 内に書かれた処理です。");
    }
}
