# ドメイン駆動設計

- 設計にそのまま使えるモデルを使って、知識の整理や意図の伝達もする
- 設計、知識の整理、意図の伝達の３つの用途に役に立つ１つのモデルを見つけ成長させていく

値オブジェクト、集約

- 複雑な業務ロジックを独立した構成要素として分離する
- アプリケーションの他の構成要素を業務ロジックを表現した構成要素に依存させる

## 正誤表
341
リスト14.8の上から4行目
```cs
誤	public UserGetInteractor(IUserGetPresenter presenter) 
{

正	public StubUserGetInteractor(IUserGetPresenter presenter)  
{
```

## Reference
- [正誤表](https://www.shoeisha.co.jp/book/detail/9784798150727#errata)
- [Git Hub samples](https://github.com/nrslib/itddd)