# MEF2 のサンプル .NET 6
- MEF は新旧、情報が入り乱れて錯綜しており、公式ドキュメントもあまり公開されておらず、正攻法がどれで、何が何だかよくわからないが、System.Composition 名前空間が軽量かつ新しいもののようなので、.NET 6 で作ってみました。
- https://github.com/microsoftarchive/mef のように、URL に archive の単語が見えているので、もうオワコンなのかと思いきや、そこには「.NET 4.5 と Windows ストア アプリ であれば、今や完全にサポートされている NuGet にある軽量の System.Composition パッケージをインストールできます」などと書かれており、だから archive なのかと納得できます。
- とはいえ、いや、それもいつの話だ？　との印象が拭えませんが、NuGet は System.ComponentModel.Composition も System.Composition も更新され続けています。 
- Visual Studio 内で使われているので、オワコンではないと思います。公式がなぜドキュメントを整えないのかよくわかりませんが。
- 時代的には System.ComponentModel.Composition は .NET Framework 4 時代の産物で、System.Composition は [公式ドキュメントによれば](https://docs.microsoft.com/en-us/previous-versions/dotnet/framework/mef/mef-for-net-for-windows-store-apps) Windows 8.x 用のストア アプリのために生まれたものっぽいです。
- System.Composition は[軽量版であり](https://github.com/microsoftarchive/mef/blob/master/Wiki/Home.md#status)、特別なカスタム属性もつけなくてもよいので、個人的な要件としては、インターフェイスを持つ DLL を動的に追加して使うことができればいいや、と思っているので、そこだけのサンプルを作成してみました。
- つまり、使う方のアプリケーションをビルドし直すことなしに、機能だけを別の DLL で作成しておいて、修正して動的に入れ替えたり、追加したりということがしたい。
- MEF2 という名称も曖昧で、MEF と書かれたり、色々錯綜しています。
- このサンプルでは、特別なカスタム属性を付けずに、動的に DLL を読んでインターフェイスを介して操作する方法を示します。

## 動き
- MEF2Sample\MEFSample\bin\Debug\net6.0\Addins に IAddinContract インターフェイスを実装したクラスを含む DLL を置いておくと、Program クラスがそれをインポートして実行します。
- Addin4, Addin6, AddinStandard それぞれのプロジェクトをビルドして作成した DLL が上記のフォルダー内に置いてあります。そこの DLL を削除したり、入れ替えたりすれば、ビルドしなおすことなく動きが変わります。
- FileSystemWatcher などでフォルダー内の変更イベントを拾えば、動的に機能を切り替えたりもできます。

## 後方互換性がある
- プロジェクト Contract と Addin4 は .NET Framework 4.8 で組んであります。
- プロジェクト MEFSample と Addin6 は .NET 6 で組んであります。
- プロジェクト AddinStandard は .NET Standard 2.0 で組んであります。

.NET 6 から古いアセンブリーを動かせるということです。

# このサンプルの解説
- アドイン側は単にインターフェイスの DLL を参照して実装しているだけです。[Export] など、特別なカスタム属性もつけていません。
- 利用側は、[Program.cs](MEF2Sample/Program.cs) に書いています。実質 5 行です。
- 利用側をビルドしなおすことなく、[Addins フォルダー](MEF2Sample/bin/Debug/net6.0/Addins)に置く DLL を変えるだけで挙動が変化します。

## 注意点
公式などドキュメントがなぜか圧倒的に少なく、これが正しいやり方とは限りませんが、動いているので公開します。

## 謝辞
フォーク元の ousttrue さんのサンプルを元に理解し、作成しています。感謝。
