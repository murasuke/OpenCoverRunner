# 意識が低いプロジェクトでも出来る、手動テストのカバレッジ測定



[ソフトウェア品質を高める開発者テスト](https://www.amazon.co.jp/dp/4798165034)を読みました。
自分がやっているテスト手法は20年前から変わっていませんが、グローバルスタンダードは全く違うことをしているという事実にいまさら気が付いたわけです。

とはいえ、いきなり「`ユニットテスト`」しろ、「`コードカバレッジ`」計測しろといわれても、新規開発が少ない今日この頃、とても敷居が高い。

というわけで、多少なりとも効果を出せて、かつ継続できる方法はないか考えたどり着いた答えは

## ■単体テスト(手動テスト)でできる、カバレッジ測定(しかも追加でテストをすれば、その分のカバレッジ率は累計される)

です。

そのためのプログラム[OpenCoverRunner](https://github.com/murasuke/OpenCoverRunner)を作成しました。テスト対象のプログラムをDebugビルドしてから、フォームにDrag＆Dropして「実行」ボタンを押して手動テストを行い、プログラムを終了すると「カバレッジ率」が表示されます。

## 利点

* UnitTestがないレガシーコードのみで構成されたプロジェクトでも、手動テストをすれば分岐漏れが確認できます(C1カバレッジができていることをエビデンスとして残せる)。

* 【まだやり方考案中】機能追加したところだけ、新規にUnitTestを追加。古いソースは手動テストを行い、カバレッジをマージする【できるはず】

* 人間のやるテストなので、数日に渡る場合もあります。プログラムをテストする毎に徐々にカバレッジをが上がり、テスト漏れがないかチェックすることができます。

* 無駄なテストを省くことができます。無駄な組み合わせテスト、膨大なテストパターンを省く証拠として利用できるのではないでしょうか？

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




https://kuttsun.blogspot.com/2017/12/opencover.html

MSTestとOpenCoverの併用