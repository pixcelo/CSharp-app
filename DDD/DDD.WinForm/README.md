# DDD

## アーキテクチャ

WindowsForms 構成

- WinForm View(画面), ViewModel(画面ロジック)
- Infrastructure(アプリケーションの外側との接触部分)
- Domain(ビジネスロジック)
- Test(xUnit)

Domainはどこも参照しない

他のプロジェクトはビジネスロジックを外から参照する

## データベース
SQLite (System.Data.SQLite)