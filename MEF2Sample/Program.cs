using AddinContract;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace MEF2Sample
{

    class Program
    {
        static void Main(string[] args)
        {
            // 対象とする規約を設定するクラス
            var builder = new ConventionBuilder();

            // 規約を設定（IAddinContract インターフェイスを実装したものを対象とする）
            builder.ForTypesDerivedFrom<IAddinContract>().ExportInterfaces();

            // Addins フォルダーの DLL からアセンブリーを取得
            var assemblies = new DirectoryInfo("Addins").GetFiles("*.dll").Select(dll => Assembly.LoadFrom(dll.FullName));

            // 実際のアセンブリーから規約に当てはまるものを提供する host を作成
            var host = new ContainerConfiguration().WithAssemblies(assemblies, builder).CreateContainer();
            
            // host からインターフェイス実装したインスタンスを取得
            var addins = host.GetExports<IAddinContract>();

            foreach (var addin in addins)
            {
                WriteLine($"アドイン タイトル「{addin.AddinTitle}」");
                WriteLine($".ToString() を実行（型情報） ⇒ {addin}");
                addin.DoWork();
                WriteLine();
            }
            Console.ReadKey();
        }
    }
}
