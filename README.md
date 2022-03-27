# MEF2 のサンプル .NET 6
MEF は新旧、情報が入り乱れて錯綜しており、何が何だかよくわからないが、System.Composition 名前空間を使用するのが一番新しいもののようなので、古いものを排して .NET 6 で作ってみました。

## 動き
MEF2Sample\MEFSample\bin\Debug\net6.0\Addins に IAddinContract インターフェイスを実装したクラスを含む DLL を置いておくと、Program クラスがそれをインポートして実行します。

## 後方互換性がある
- プロジェクト Contract と Addin4 は .NET Framework 4.8 で組んであります。
- プロジェクト MEFSample と Addin6 は .NET 6 で組んであります。
- プロジェクト AddinStandard は .NET Standard 2.0 で組んであります。

.NET 6 から古いアセンブリーを動かせるようです。

# このサンプルの解説
- アドイン側は単にインターフェイスの DLL を参照して実装するだけです。
- 利用側は、[Program.cs](MEF2Sample/Program.cs) に書いています。実質 5 行です。

## 注意点
正しいやり方とは限りませんが、動いているので公開します。

## 謝辞
フォーク元の ousttrue さんのサンプルを元に理解し、作成しています。感謝。
