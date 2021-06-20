# 意識が低いプロジェクトでも出来る、手動テストのカバレッジ測定

通常カバレッジ率を測定するのはUnitTestがある場合ですが、レガシーコードのみで構成されたプロジェクトの場合、色々な理由によってテストコードを追加することが難しいです。

せめて、自分が手動でテストしたコードでテスト漏れが(分岐を通っていない)がないか、正確にチェックするため「手動テストでカバレッジ率を計測」する手順を記載します。

手動でプログラムを操作してテストを行う場合、1回で全てテストができないため「カバレッジのマージ」を行う必要があります。その方法も説明します。



カバレッジのためのデータ収集(exeプログラムを操作すると、プログラムの実行した箇所をxmlファイルに書き出します。複数回実行した場合、実行結果をマージします)
```
C:\Users\t_nii\source\repos\OpenCoverTest\packages\OpenCover.4.7.1221\tools\OpenCover.Console.exe -target:"C:\Users\t_nii\source\repos\OpenCoverTest\WindowsFormsManualTest\bin\Debug\WindowsFormsManualTest.exe" -output:C:\Users\t_nii\source\repos\OpenCoverTest\WindowsFormsManualTest\bin\WindowsFormsManualTest.results.xml -mergeoutput -register:user
```


カバレッジレポート作成
```
C:\Users\t_nii\source\repos\OpenCoverTest\packages\ReportGenerator.4.8.10\tools\net47\ReportGenerator.exe -reports:C:\Users\t_nii\source\repos\OpenCoverTest\WindowsFormsManualTest\bin\WindowsFormsManualTest.*.xml -targetdir:C:\Users\t_nii\source\repos\OpenCoverTest\WindowsFormsManualTest\bin\html -sourcedirs:C:\Users\t_nii\source\repos\OpenCoverTest\WindowsFormsManualTest\ "-classfilters:-WindowsFormsManualTest.Properties.*"
```


## 特徴

* コードによる単体テストは不要。プログラムを操作しながら動作確認を行い、最後にカバレッジ率を確認できます。

* 複数回テストを行った場合、結果をマージします。カバレッジ率が足りない場合、もしくは分岐のテスト漏れがある場合、再度その部分だけテスト行えば、カバレッジ率がその分向上します。

* VisualStudioからアタッチすれば、デバッグしながら同時にカバレッジの測定も可能です。【要確認】

## 課題

* コマンドラインから実行する必要があり、実行がとても面倒

  ⇒ WindowsFormにプログラムのパスを設定すれば、実行、レポートの生成を行える用にする。
