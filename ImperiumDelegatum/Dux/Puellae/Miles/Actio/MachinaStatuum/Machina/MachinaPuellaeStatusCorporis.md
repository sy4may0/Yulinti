# MachinaPuellaeStatusCorporis

## 概要
このクラスは以下を担当する。

- 現在ステート (`_idStatusActualis`) の保持
- 次ステート予約 (`_idStatusProximus`) の保持
- フェーズ進行 (`Incipalis / Intrans / Transeo / TranseoDesinere / Exiens`)
- アニメーション状態とブロック条件に応じた遷移制御

---

## 用語

### 現在ステート
- `_idStatusActualis`
- 現在実行中のステートID
- 実際に切り替わるのは `MutareIntrans()` のみ

### 次ステート
- `_idStatusProximus`
- 入力や条件で予約された次ステートID
- `Nihil` は予約なし
- 一度予約されたら `MutareIntrans()` 実行まで上書きしない

### アニメーション状態
- `Exhibens`: 再生中
- `ExhibensIterans`: ループ再生中
- `Desinens`: 停止中 / 再生終了

### ブロック条件
現在ステートが、各フェーズ中にどこまで遷移を禁止するかを表す。

- `EstInterdictaIntrare`
- `EstInterdictaTransere`
- `EstInterdictaExire`

意味:
- `Intrare` 中に次ステートへ割り込み可能か
- `Transere` 中に次ステートへ割り込み可能か
- `Exire` 中に次ステートへ割り込み可能か

---

## フェーズ一覧

### Incipalis
遷移開始点。
次ステートを見て `MutareIntrans()` へ進む。

### Intrans
開始アニメーションフェーズ。
`Intrare()` 実行後、開始アニメーション完了待ちを行う。

### Transeo
本体アニメーションフェーズ。
`Transere()` 実行後、本体アニメーション完了待ちを行う。

### TranseoDesinere
本体フェーズの停止維持版。
`IdAnimationisTransere == Desinere` のとき入る。
入力が来るまでここで維持する。

### Exiens
終了アニメーションフェーズ。
`Exire()` 実行後、終了アニメーション完了待ちを行う。

---

## 特殊ルール

### 1. フェーズスキップ
- `IDPuellaeAnimationis.Nihil` は「そのフェーズのアニメーション無し」
- この場合、そのフェーズは即時スキップされる

### 2. 停止維持
- `IDPuellaeAnimationis.Desinere` は `Transere` のみ有効
- `Intrare / Exire` では無効
- `Transere == Desinere` の場合は `TranseoDesinere` に入る

### 3. 現在ステートの更新箇所
- `_idStatusActualis` を変更してよいのは `MutareIntrans()` のみ

---

## 遷移フロー概要

通常系:

1. `Incipalis`
2. `MutareIntrans()`
3. `Intrans`
4. `MutareTranseo()`
5. `Transeo`
6. `MutareExiens()`
7. `Exiens`
8. `MutareIncipalis()`
9. 次フレームで再び `Incipalis`

---

## フェーズ別遷移表

## Intrans

| 条件 | 遷移先 |
|---|---|
| 次ステートなし かつ 再生中 | 維持 |
| 次ステートあり かつ 再生中 かつ `EstInterdictaIntrare` | 維持 |
| 次ステートあり かつ 再生中 かつ `!EstInterdictaIntrare && EstInterdictaTransere` | `Transeo` |
| 次ステートあり かつ 再生中 かつ `!EstInterdictaIntrare && EstInterdictaExire` | `Exiens` |
| 次ステートあり かつ 再生中 かつ 上記以外 | `Incipalis` |
| 次ステートあり かつ 停止中 かつ `EstInterdictaTransere` | `Transeo` |
| 次ステートあり かつ 停止中 かつ `EstInterdictaExire` | `Exiens` |
| 次ステートあり かつ 停止中 かつ 上記以外 | `Incipalis` |
| 次ステートなし かつ 停止中 | `Transeo` |

## Transeo

| 条件 | 遷移先 |
|---|---|
| 次ステートなし かつ 再生中/ループ中 | 維持 |
| 次ステートあり かつ 再生中/ループ中 かつ `EstInterdictaTransere` | 維持 |
| 次ステートあり かつ 再生中/ループ中 かつ `!EstInterdictaTransere && EstInterdictaExire` | `Exiens` |
| 次ステートあり かつ 再生中/ループ中 かつ 上記以外 | `Incipalis` |
| 次ステートあり かつ 停止中 かつ `EstInterdictaExire` | `Exiens` |
| 次ステートあり かつ 停止中 かつ 上記以外 | `Incipalis` |
| 次ステートなし かつ 停止中 | `Exiens` |

## TranseoDesinere

| 条件 | 遷移先 |
|---|---|
| 次ステートなし | 維持 |
| 次ステートあり かつ `EstInterdictaExire` | `Exiens` |
| 次ステートあり かつ 上記以外 | `Incipalis` |

## Exiens

| 条件 | 遷移先 |
|---|---|
| 次ステートなし かつ 再生中 | 維持 |
| 次ステートあり かつ 再生中 かつ `EstInterdictaExire` | 維持 |
| 次ステートあり かつ 再生中 かつ 上記以外 | `Incipalis` |
| 次ステートあり かつ 停止中 | `Incipalis` |
| 次ステートなし かつ 停止中 | `Incipalis` |

---

## 実装上の注意

### 判定対象
ブロック条件は **現在ステート** に属する。
したがって `EstInterdictaIntrare / Transere / Exire` の判定には
常に `_idStatusActualis` のステート設定を使う。

### 次ステート予約
`_idStatusProximus` は一度予約されたら `MutareIntrans()` まで固定する。

### 設定エラー
- `Intrare == Desinere` は無効
- `Exire == Desinere` は無効
- 必要であれば設定ロード時点で弾く

---

## レビュー観点

このクラスを見るときは、コードを直接追う前に以下を確認する。

1. 遷移表とコードの条件順が一致しているか
2. `_idStatusActualis` と `_idStatusProximus` を取り違えていないか
3. `Nihil` と `Desinere` の意味が崩れていないか
4. 通常系 (`入力なし`) が必ず
   `Intrans -> Transeo -> Exiens -> Incipalis`
   になるか