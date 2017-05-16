# Issue Log

## English

### ToDo

### Doing

### Done

* 170510_01 - Data range issue
  > Desc: I tried to make some more generic code by arguments input, but in some cases it may exceed the data range during operation.
  >> Try1:  Created corresponding types for Int32, Int64, UInt64 etc as needed using Generic or preprocessor.<br/>
  >> __Result1: Readability is too bad.__<br/>
  >> Try2: All changed to UINT64.<br/>
  >> __Result2: It will work without major problems, and will be decided according to the algorithm added later.__<br/>

* 170515_01 - Naming and Path Problems
  > Desc: It is not good to see naming and relationship from the solution, because it is not clear, and it is possible to repeatedly write Util type classes due to project distinction.
  >> Try1: Consolidated into one solution, one project.<br/>
  >> __Result1: One project is too big, and not clear still.__<br/>
  >> Try2: Create Util classes into DLL, and distincate project. Finally, the name changed in Try1 is maintained.<br/>
  >> __Result2: Not bad. :D__<br/>
  
  
## 日本語

### ToDo

### Doing

### Done

* 170510_01 - データ範囲の問題
  > 内容：引数を入力されて、より一般的なコードを作成しようとしましたが、場合によってはデータタイプの範囲を超えることもあります。
  >> 試し1：Genericまたはプリプロセッサを使用して、Int32、Int64、UInt64などに変換できるタイプを作成しました。<br/>
  >> __結果1：読みやすさが悪いです。__<br/>
  >> 試し2：すべてUINT64に変更しました。<br/>
  >> __結果2：あまり問題なく動作し、後で追加されるアルゴリズムに従って決定します。__<br/>
  
* 170515_01 - 命名とパスの問題
  > 内容：ソリューションの段階から名称との関係を明確にしていなかったせいで、見た目が悪いし、プロジェクトを区別した事で、Util型クラスを繰り返して作成する可能性がでました。
  >> 試し1：1つのプロジェクトに統合して管理して見ました。<br/>
  >> __結果1：プロジェクトがあまりに大きくなり、相変わらず明確しなかったです。__<br/>
  >> 試し2：Utilをライブラリ化して、その他は従来のようにプロジェクトを区別し、Try1で変更した名称を維持しました。<br/>
  >> __結果2：かなり悪くなかったので、新しくしました。__<br/>
