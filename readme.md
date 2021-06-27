# 意識が低いプロジェクトでも出来る、手動テストのカバレッジ測定(.NET)

[ソフトウェア品質を高める開発者テスト](https://www.amazon.co.jp/dp/4798165034)を読みました。
自分がやっているテスト手法は20年前から変わっていませんが、グローバルスタンダードからは周回遅れにされていることに気が付きました。

とはいえ、いきなり「`ユニットテスト`」しろ、「`コードカバレッジ`」計測しろといわれても、レガシーコードに手を入れる勇気も時間もありません。
また、新規開発も最近は少なく、手を動かすことができない現状です。

とはいえ多少なりとも効果を出せて、かつ継続できる方法はないかと色々考えてみました。
手動テストでカバレッジを測定し、後からユニットテストを少しずつ増やしながらカバレッジを統合できれば、漸進的にできるのではないかと。

## ①いつも通りに単体テスト(手動テスト)をしながら、カバレッジが測定できると嬉しい。⇒カバレッジ率と、分岐を確認しながらテストできる。
## ②手動テストでカバレッジ不足が見つかったら、テストケースを追加して再テストしたい。⇒カバレッジがマージできると嬉しい。
## ③ユニットテストを書いたら、手動テストのカバレッジ結果とマージ出来ると更に良い。⇒追加開発から、ユニットテストを始められる。


です。

そのためのプログラム[OpenCoverRunner](https://github.com/murasuke/OpenCoverRunner)を作成しました。①②③全て満たしています。


* カバレッジ測定からレポート生成までボタン一つで実行します(ツールのパスは起動時に検索するので、設定不要です)。
* テスト対象のプログラムをフォームにDrag＆Dropして「実行」します。テスト実施後、プログラムを終了すると「カバレッジ」のレポートが表示される仕組みです。

## 利点

* UnitTestがないレガシーコードのみで構成されたプロジェクトでも、手動テストをすれば分岐漏れが確認できます(C1カバレッジができていることをエビデンスとして残せる)。

* UnitTestも実行できます。手動テストの結果とマージされるため、新規開発分だけUnitTestを行い、古いソースの回帰テストは手動で行うことができます。

* プログラムを手動テストする毎に徐々にカバレッジをが上がり、テスト漏れがないかチェックすることができます。（数日にわたる手動テストでも、自動的にマージされます）

* 無駄なテストを省くことができます。C1カバレッジが確認できれば、それ以上テストする必要はないはずです（開発者テストの段階で）

* デバッグしながら、同時にカバレッジ率測定できます。(プロセスにアタッチしてデバッグ)

## 利用ツール

NuGetでインストールします。

インストールが面倒な場合[github.com/murasuke/OpenCoverRunner](https://github.com/murasuke/OpenCoverRunner)をCloneして、VS2017以降でビルドしてください（ビルド時に自動でインストールされます)

* [OpenCover](https://github.com/OpenCover/opencover) カバレッジ測定ツール(カバレッジ収集結果を.xmlファイルに保存)

* [ReportGenerator](ReportGenerator) レポート生成ツール(xmlからhtmlなど読みやすい形に成形)

  ※Visual Studioのカバレッジ測定ツールはEnterprise版が必要なため利用しません。

  ※UnitTest(MSTest、NUnit)も不要です（併用も可能)

## コマンドライン

### OpenCover
  
| 引数 | 説明 | 例 |
|-----------|------------|:------------|
| -target:<ターゲットパス>  | カバレッジ計測対象のexeパス |-target:"C:\TestTarget\bin\Debug\TestTarget.exe" |
|-output:<出力ファイル(xml)>|計測結果を保存するパス(xml)|-output:"C:\TestTarget\bin\Debug\results.xml" |
|-register[:user]|プロファイラへの登録で利用するユーザを指定。管理者権限がない場合、userを指定すれば良いようです|-register:user|

### ReportGenerator

| 引数 | 説明 | 例 |
|-----------|------------|------------|
|-reports:<OpenCover出力ファイル(xml)>  | OpenCoverで出力した測定結果ファイル(xml) |-reports:"C:\TestTarget\bin\Debug\results.xml" |
|--reporttypes:<出力タイプ>|Html,HtmlInline,MarkdownSummaryなど選択できます|-reporttypes:HtmlInline; |
|-targetdir:<出力先>|レポートファイル出力先|-targetdir:C:\TestTarget\bin\Debug\|


## ソリューション構成

* OpenCoverRunner   ・・・ソリューション
  * OpenCoverRunnerForm   ・・・OpenCoverRunner本体
  * ManualTestTarget  ・・・動作確認用サンプルプログラム(Windows フォーム)(手動テスト対象)
  * OpenCoverWebForm　・・・動作確認用サンプルプログラム(ASP.NET Webフォーム)
  * UnitTestProject　・・・ManualTestTargetのユニットテスト。Logicのみテストを行う(Formは対象外)

## 手順

* Comming soon....


## その他雑記(まとめ中)

* ✔コマンドラインから実行する必要があり、実行がとても面倒(引数が多く、バッチファイルにしても設定が大変)

  ⇒ カバレッジ測定をサポートする[WindowsFormプログラム](https://github.com/murasuke/OpenCoverRunner)を作成。プログラムのパスを設定して実行すれば、レポート生成まで行います。
* ✔MSTestと、手動テストを併用して、カバレッジのマージができるか確認する。
* ✔IIS(asp.net)のカバレッジ測定はできるか？設定はどうすればよいか？

  * ⇒IISExpressで可能だが制限がある(asp.net webforms)。pdbが見つからない。⇒pdf検索箇所を明示的に指定すれば解決
* ✔exeから読み込むdllも一緒にカバレッジ測定できるのか？
* -historydir:history を指定すると、過去との比較ができる？

* VS インストール調査
C:\Program Files (x86)\Microsoft Visual Studio\Installer> vswhere.exe -legacy -prerelease -format json

vswhere.exe は環境変数 %ProgramFiles% と %ProgramFiles(x86)% 双方の下の Microsoft Visual Studio\Installer から探す

```
vswhere.exe -latest -property productpath
C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe
```


https://kuttsun.blogspot.com/2017/12/opencover.html
