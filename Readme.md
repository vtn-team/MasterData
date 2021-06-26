# 課題

(Must)
- データ構造の違いと、なぜそうしているかを考えて、MasterDataのReadme.mdに記載しよう。  
- ScriptableObjectのデータを作って、そのデータをCardViewに表示してみよう  

※リストビューで選択できなくても構いません。データを表示するだけでよいです。  

(Try)
- スプレッドシートのデータ管理を参考に、同じ挙動をさせよう。

※スブレッドシートでやってた時と同じ動作になるようにしてみてください  
※データはローカルにあって構いません  
※クラスは自由に修正してかまいません。ただし、データ設計(変数の数、型、クラス名など)は修正しないでください  


# 提出
課題用のブランチを作成しましょう。  
ブランチの作成方法は授業で解説します。  
名前は  
```[クラス]/[自分の名前]```  
という名前で作成しましょう  

例)  
```ps20a/k.mitarai```

ブランチにコミットして、pushしましょう。  


# 説明資料/参考文献
https://vtn-team.github.io/adventure-cube/EducationText/データ設計/01-マスターデータとExcel.html  
https://vtn-team.github.io/adventure-cube/EducationText/データ設計/02-ScriptableObject.html  
https://vtn-team.github.io/adventure-cube/EducationText/データ設計/03-リレーション.html  
https://vtn-team.github.io/adventure-cube/EducationText/テクニック/01-スプレッドシートをJsonで受け取る.html  

# 回答補足
## (Must)データ構造の違いについて
なぜシートが分かれていると思いますか？  

回答：  JSONで一度に読み込む量を減らして、一回の処理を借るこするため。

一緒になっているクラスと、別れているクラス、どちらの方がやりやすいと思いましたか？  

回答：  一人で制作するならScriptableObjectの方が楽だが、チーム制作の場合はスプレットシートを使用して分担した方が効率がいいと思った。


## 課題をどこまでやれましたか？
例) Tryまでやった  
例) Mustだけやった  
例) わからなかった  

回答：Mustだけやった

## 質問内容があれば記述してください
回答：今回のGameManagerのコードは、実際の現場だと可読性の高いコードになるのでしょうか？

もし、このレベルで読めない方がヤバいのであれば、まだまだだなと思ったので聞いてみました。
