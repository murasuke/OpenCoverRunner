# 意識が低いプロジェクトでも出来る、手動テストのカバレッジ測定



[ソフトウェア品質を高める開発者テスト](https://www.amazon.co.jp/dp/4798165034)を読みました。
自分がやっているテスト手法は20年前から変わっていませんが、グローバルスタンダードからは周回遅れにされていることに気が付きました。

とはいえ、いきなり「`ユニットテスト`」しろ、「`コードカバレッジ`」計測しろといわれても、新規開発は少ないですし、レガシーコードに手を入れる勇気も時間もありません。

というわけで、多少なりとも効果を出せて、かつ継続できる方法はないか考えたどり着いた答えは

## ・いつも通りに単体テスト(手動テスト)すればできる、カバレッジ測定(率と、分岐の確認ができる)
## ・カバレッジが足りなくても、後で追加テストをすれば、カバレッジがマージされる(カバレッジ率が向上する)
## ・ユニットテストも付け足せる（手動テストのカバレッジ結果とマージ)


です。

そのためのプログラム[OpenCoverRunner](https://github.com/murasuke/OpenCoverRunner)を作成しました。カバレッジ測定からレポート生成までボタン一つで実行します(毎回バッチファイルを修正する必要はありません)。テスト対象のプログラムをDebugビルドしてから、フォームにDrag＆Dropして「実行」。プログラムを終了すると「カバレッジ率」が表示されます。

## 利点

* UnitTestがないレガシーコードのみで構成されたプロジェクトでも、手動テストをすれば分岐漏れが確認できます(C1カバレッジができていることをエビデンスとして残せる)。

* UnitTestも実行できます。手動テストの結果とマージされるため、新規開発分だけUnitTestを行い、古いソースの回帰テストは手動で行うことができます。

* プログラムを手動テストする毎に徐々にカバレッジをが上がり、テスト漏れがないかチェックすることができます。（数日にわたる手動テストでも、自動的にマージされます）

* 無駄なテストを省くことができます。C1カバレッジが確認できれば、それ以上テストする必要はないはずです（開発者テストの段階で）

* デバッグしながら、同時にカバレッジ率測定できます。(プロセスにアタッチしてデバッグ)

## 利用ツール

NuGetでインストールします。

インストールが面倒な場合[github.com/murasuke/OpenCoverRunner](https://github.com/murasuke/OpenCoverRunner)をCloneして、VS2017以降でビルドしてください（ビルド時に自動でインストールされます)

* [opencover](https://github.com/OpenCover/opencover) カバレッジ測定ツール(カバレッジ収集結果を.xmlファイルに保存)

* [ReportGenerator](ReportGenerator) レポート生成ツール(xmlからhtmlなど読みやすい形に成形)

  ※Visual Studioのカバレッジ測定ツールはEnterprise版が必要なため利用しません。

  ※UnitTest(MSTest、NUnit)も不要です。


## ソリューション構成

* OpenCoverRunner   ・・・ソリューション
  * OpenCoverRunnerForm   ・・・OpenCover起動をサポートするフォーム
  * ManualTestTarget  ・・・手動テスト対象フォーム
  * UnitTestProject　・・・MSTestプロジェクト
## 手順

* Comming soon....


## TODO

* コマンドラインから実行する必要があり、実行がとても面倒(引数が多く、バッチファイルにしても設定が大変)

  ⇒ カバレッジ測定をサポートする[WindowsFormプログラム](https://github.com/murasuke/OpenCoverRunner)を作成。プログラムのパスを設定して実行すれば、レポート生成まで行います。
* MSTestと、手動テストを併用して、カバレッジのマージができるか確認する。
* IIS(asp.net)のカバレッジ測定はできるか？設定はどうすればよいか？
* exeから読み込むdllも一緒にカバレッジ測定できるのか？
* -historydir:history を指定すると、過去との比較ができる？

* VS インストール調査
C:\Program Files (x86)\Microsoft Visual Studio\Installer> vswhere.exe -legacy -prerelease -format json

vswhere.exe は環境変数 %ProgramFiles% と %ProgramFiles(x86)% 双方の下の Microsoft Visual Studio\Installer から探す

```
vswhere.exe -latest -property productpath
C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe
```


https://kuttsun.blogspot.com/2017/12/opencover.html

MSTestとOpenCoverの併用
