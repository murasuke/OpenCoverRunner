# OpenCoverを簡単に利用するためのアプリケーションを作成する

1. WindowsForm
1. .net 4.7(.net coreはサポートしない)
1. 画面に手動テスト対象のexeをドロップダウンすると、自動的にパスを検索して設定ファイルに書き込む
1. 次回以降は設定ファイルから読み込む？（exeファイル毎に設定を分ける?)
1. 検索の優先度はローカルの package -> レジストリ -> 一般的なインストール先 -> 見つからない場合は手動設定
1. .xmlファイルと、Reportはとりあえずbin直下？それともobj直下？それとも、OpenCoverフォルダ作って入れる？

