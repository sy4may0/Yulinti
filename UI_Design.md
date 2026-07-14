# Yulinti UI 設計思想 / コーディング規約

対象: `Officia/Velum`（View層） と `Auctoritas/Senatus`（Presenter層）。
UIを新規追加・改修する際の共通ルール（コーディング規約）としてまとめる。

---

## 1. 全体アーキテクチャ（レイヤー分割）

このUIは **MVP (Model-View-Presenter) + コールバック仲介** の構成。役割ごとにレイヤーが厳密に分かれている。

```text
[Anchora] ──UIDocument提供──▶ [Velum (View)]  ◀──操作──┐
                                    │                    │
                          Executare(Usus)  PonoPermissionemUsus 等
                                    ▼                    │
                              [Operatio]  ──コールバック仲介──▶ [Praeco (Presenter)]
                                                             │
                                          ┌──────────────────┼───────────────────┐
                                       [Turris]          [CuratorVela]        [他Praeco]
                                    (ドメイン/サービス)   (全View統括)        (Confirmatio等)
                                          │
                              [Senator] ──全Praecoを集約Tick── [Faber] ──DI登録
```

| レイヤー | 名前空間 | Unity依存 | 責務 |
|---|---|---|---|
| View | `Yulinti.Officia.Velum` | **依存OK** | `VisualElement`操作、表示/非表示、イベント配線、テキスト・状態反映のみ |
| Presenter | `Yulinti.Auctoritas.Senatus` | **非依存** | ロジック、ドメイン呼び出し(`Turris`)、画面遷移、状態判定 |
| 契約 | `*.Contractus` | 非依存 | View⇔Presenter間のインターフェース・Enum |
| 仲介 | `Operatio`(Senatus内) | 非依存 | View→Presenter の一方向コールバックを`Action`で橋渡し |

> **核心ルール: Velum（View）はロジックを一切持たない。判断は必ず Praeco（Presenter）側。**

---

## 2. 命名規約（ラテン語ドメイン語彙）

プロジェクト全体がラテン語ベースの統一命名。UIに関わる主要語彙を覚えておくと読み書きできる。

| 語 | 意味 | 役割 |
|---|---|---|
| `Velum` | 幕 | View本体 |
| `Praeco` | 告知者 | Presenter |
| `Operatio` | 操作 | View→Presenterコールバック仲介 |
| `Senator`/`Senatus` | 元老院 | 全Praecoの集約Tick |
| `Faber` | 職人 | DIコンポジション（Factory） |
| `Curator` | 管理者 | `CuratorVela`＝全View統括 |
| `Anchora` | 錨 | Unityシーン内参照ホルダー(`UIDocument`提供) |
| `Turris` | 塔 | 常駐サービス(ドメイン/インフラ) |
| `Usus` | 用途 | ボタン等のアクション種別Enum |
| `Radix` | 根 | `DontDestroyOnLoad`常駐を示す接尾辞 |

動詞:

| 語 | 意味 | 役割 |
|---|---|---|
| `Incipere` | 始める | 初期化ライフサイクル |
| `Liberare` | 解放する | 破棄ライフサイクル |
| `Demittere` | 下ろす | UIを**表示**する |
| `Tollere` | 上げる/除く | UIを**非表示**にする |
| `Activare`/`Deactivare` | 有効/無効 | `display` Flex/None の内部切替 |
| `Ponere`(`Pono`) | 置く | 状態設定(`PonoPermissionemUsus`) |
| `Executare` | 実行 | コールバック発火 |
| `Carnifex` | 処刑人 | 致命エラー(即停止) |
| `Notarius` | 記録者 | ログ出力 |
| `Interpretatio` | 翻訳 | ローカライズ(`LegoTextus`) |

命名は基本 `{役割}{機能名}` の形（例: `VelumIndexusPrincipalis`, `PraecoSalsamenti`, `OperatioPortus`）。
private メソッドは camelCase（`premereExi`）、public は PascalCase。フィールドは `_camelCase`。

---

## 3. Velum（View）の規約

`VelumIndexusPrincipalis` / `VelumPortus` / `VelumSalsamenti` が典型例。

### 3.1 実装すべきインターフェースの型

```csharp
internal sealed class VelumIndexusPrincipalis
    : IVelum, IVelumIndexusPrincipalis, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
```

- `IVelum` … `Activare()`/`Deactivare()`（内部の表示制御 契約）
- `IVelum{機能名}`（Contractus公開） … Presenterから呼ぶ操作 (`Demittere{X}`, `Tollere{X}`, `PonoPermissionemUsus`)
- `IVelumIncipabilis` / `IVelumLiberabilis` … ライフサイクル（`Incipere`/`Liberare`）
- `IVelumTerminabilis` … `TollereFinem()`（`CuratorVela`による全消し対象になる）
- **常駐(DontDestroyOnLoad)の場合は `~Radicis` 版**（`VelumMonitionis`/`VelumConfirmationis`）

### 3.2 クラスは必ず `internal sealed`

実装はすべて `internal sealed`。外部公開は `Contractus` のインターフェースのみ。

### 3.3 コンストラクタDIの定番4点セット

```csharp
public VelumIndexusPrincipalis(
    IAnchoraVelumIndexusPrincipalis anchoraVelumIndexusPrincipalis, // UIDocument取得元（Unityシーン参照）
    ITurrisInterpretationis turrisInterpretationis,                 // ローカライズ
    ApplicatorSoniVeli applicatorSoniVeli,                          // UI効果音の付与/除去
    IOperatioIndexusPrincipalis operatioIndexusPrincipalis          // 押下を流す先（唯一のPresenterへの窓口）
) { ... }
```

### 3.4 `Incipere()` の定型手順（この順序を守る）

1. `_anchora.UIDocument` から `UIDocument` を取得
2. ルート/パネルの `VisualElement` を `Q<>("id")` で取得
3. 各 `Button`/`Label` を `Q<>()` で取得
4. `Label.text = _turrisInterpretationis.LegoTextus(IDTextus.XXX)` で**必ずローカライズ経由**（テキスト直書き禁止）
5. `ActivareCB()` でイベント配線

### 3.5 表示/非表示は2階層に分ける

- `Activare()`/`Deactivare()` … `style.display = Flex/None` の**低レベル**操作（`IVelum`）
- `Demittere{X}()`/`Tollere{X}()` … Presenterが呼ぶ**公開API**（内部で Activare/Deactivare を呼ぶ）

### 3.6 イベント配線は「解除してから登録」の冪等パターン（必須）

```csharp
private void ActivareCB() {
    _buttonLudusNovus.clicked -= premereLudusNovus;
    _buttonLudusNovus.clicked += premereLudusNovus;
    // ...
}
private void DeactivareCB() {
    _buttonLudusNovus.clicked -= premereLudusNovus; // -= のみ
    // ...
}
```

`ActivareCB()` で `-=` してから `+=`（二重登録防止）、`DeactivareCB()` で `-=` のみ。
`Liberare()` は `rootVisualElement == null` を早期リターンでガードしてから `DeactivareCB()`→`Tollere{X}()`。

### 3.7 押下ハンドラは Operatio に流すだけ

```csharp
private void premereExi() {
    _operatioIndexusPrincipalis.Executare(UsusIndexusPrincipalis.Exi);
}
```

View内で分岐やドメイン処理をしない。`Usus`列挙値を渡すだけ。

### 3.8 状態反映は `PonoPermissionemUsus(Usus, bool)` に集約

`Usus`列挙で対象を特定し `SetEnabled` する単一窓口。Presenterはこれ経由でのみボタン活殺を指示。

### 3.9 ListView など複雑Viewの追加ルール（`VelumSalsamenti`）

- `IReadOnlyList` は ListView が扱えないため内部 `List` バッファに詰め替え → `itemsSource` に設定 → `Rebuild()`
- `makeItem`/`bindItem` でテンプレート(`FormaArticulusSalsamenti`)から生成、`AddToClassList` でスタイル付与、`userData` に GUID 保持
- 選択状態(`_focusGuid`)を持ち、`selectionChanged` で更新 → `AppricareStatusUsus()` でボタン活殺
- ※State自体（選択GUID）は保持するが、「そのGUIDで何をするか」はPresenterに委譲

---

## 4. Praeco（Presenter）の規約

`PraecoIndexusPrincipalis` / `PraecoPortus` / `PraecoSalsamenti` が典型。

### 4.1 実装すべき型

```csharp
internal sealed class PraecoIndexusPrincipalis
    : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
```

- `IPraeco`（マーカー）+ `IPraecoIncipabilis`/`IPraecoLiberabilis`（`Senator`が集約するためのTick）
- 常駐は `~Radicis` 版（`PraecoConfirmationis`など）
- こちらも `internal sealed`

### 4.2 コンストラクタで Operatio にコールバック登録

```csharp
_operatioIndexusPrincipalis.Initiare(
    revocatio: Executare,
    adRenovareStatumSalsamenti: AdRenovareStatumSalsamenti
);
```

自分の `Executare` を `Operatio` へ登録。`Liberare()` では `_operatio.Purgare()` で必ず解除。

### 4.3 ライフサイクル

- `Incipere()` → `_ = Demittere();`（**fire-and-forget**。`Task.Run`は使わずUnityメインスレッドのコンテキストで継続させる）
- `Demittere()` が async起点。**try/catchで必ず囲う**

### 4.4 `Executare(Usus)` はディスパッチャに徹する

```csharp
private void Executare(UsusIndexusPrincipalis usus) {
    if (usus == UsusIndexusPrincipalis.LudusNovus) {
        _ = PremereLudusNovus();
    } else if (usus == UsusIndexusPrincipalis.PergeLudum) {
        _ = PremerePergeLudum();
    }
    // ... if-else if で Usus ごとに Premere{X} へ振り分け（switchではなくif連鎖で統一）
}
```

### 4.5 再入防止パターン（必須イディオム）

連打・二重実行を防ぐため、各 `Premere{X}` は次の型を守る。

```csharp
private async Task PremereLudusNovus() {
    try {
        if (!ConareUsus()) {
            return;
        }
        // ... 本処理（await含む） ...
    } catch (OperationCanceledException) {
        // キャンセルしてよい。何もしない。
    } catch (Exception e) {
        Carnifex.Intermissio(e);
    } finally {
        LiberareUsus();
    }
}
```

- `ConareUsus()` … `_estActivumUsus`をfalseにして入場（既にfalseなら`return`）
- `LiberareUsus()` … `finally`で必ず`true`に戻す
- **例外方針**: `OperationCanceledException`は握りつぶす／その他は`Carnifex.Intermissio(e)`（致命扱いで停止）
- ただし起点の`Demittere()`だけはキャンセルも異常とみなし、`OperationCanceledException`も`Carnifex`で落とす

### 4.6 CancellationToken の取得元は固定

`_ostiumSignumCancellationisLegibile.Signum` から取る（自前生成しない）。`Turris`呼び出しに必ず渡す。

### 4.7 画面遷移の定型

```csharp
_curatorVela.TollereVelaOmnium();          // 遷移前に必ず全UIを閉じる
_turrisMundus.AdMundum(IDMundi.MundusPortus);
```

---

## 5. Operatio（View→Presenter コールバック仲介）

ViewがPresenterを直接知らないための薄い仲介役。`Action`を保持するだけ。

```csharp
public void Executare(UsusIndexusPrincipalis usus) {
    _revocatio?.Invoke(usus);
}
```

規約:

- Viewは`IOperatio{X}`（`Executare`のみの公開契約）を注入され、Presenterは具象クラスを注入されて`Initiare`/`Purgare`する
- `Initiare(Action...)`で登録、`Purgare()`でnull化、`Executare`は`?.Invoke`
- **逆方向通知**が必要なときは`IOperatioInterna{X}`を別途定義（例: `PraecoSalsamenti`が`RenovareStatumSalsamenti()`で親`PraecoIndexusPrincipalis`にセーブ状態更新を通知）。1つの`Operatio`が公開契約(`IOperatio~`)と内部契約(`IOperatioInterna~`)の両方を実装する

これにより **View↔Presenter の相互直接参照を回避**し、循環依存を断つ。

---

## 6. 集約・統括・DI

### 6.1 Senator … 全Praecoの一括Tick

```csharp
public void Incipere() {
    foreach (IPraecoIncipabilis praeco in _praecosIncipabilis) {
        praeco.Incipere();
    }
}
```

VContainerが`IPraecoIncipabilis[]`/`IPraecoLiberabilis[]`を自動収集し、`Senator`が全部まとめて`Incipere`/`Liberare`。
常駐用は`SenatorRadicis`（`~Radicis`型）。

### 6.2 CuratorVela … 全View一括非表示

`IReadOnlyList<IVelumTerminabilis>`を受け、`TollereVelaOmnium()`で全UIを閉じる。
**責務は「全View非表示」だけに限定**（最低限のものだけにする）。

### 6.3 Faber … シーン単位のDIコンポジションルート

```csharp
public static void Initio(IContainerBuilder builder) {
    builder.Register<CuratorVela>(Lifetime.Singleton);
    builder.Register<OperatioIndexusPrincipalis>(Lifetime.Singleton)
        .AsSelf()
        .AsImplementedInterfaces();
    builder.Register<PraecoIndexusPrincipalis>(Lifetime.Singleton)
        .AsSelf()
        .AsImplementedInterfaces();
    builder.Register<ISenator, Senator>(Lifetime.Singleton);
}
```

規約:

- `FaberSenatus{シーン名}` の `static Initio(IContainerBuilder)` に登録を集約
- 全部 `Lifetime.Singleton`
- Praeco/Operatioは `.AsSelf().AsImplementedInterfaces()`（具象注入も、Senatorへの`IPraeco~[]`収集も両立させる）
- シーンごとにFaberを分け、常駐系は`FaberSenatusRadicis`（`CuratorVela`不要＝閉じないため）

---

## 7. 共通ダイアログ（Confirmationis / Monitionis）の並行制御

確認/警告ダイアログは常駐(`~Radicis`)で、**Queue + SemaphoreSlim + 常駐ワーカー**により直列化される（同時に2つ出さない）。

```csharp
while (!cancellationToken.IsCancellationRequested) {
    await _semaphoreConfirmationis.WaitAsync(cancellationToken);
    if (_queueConfirmationis.TryDequeue(out OnusConfirmationis onus)) {
        await DemittereConfirmationis(onus);
    }
}
```

規約・イディオム:

- 呼び出し要求は`Onus{X}`（不変オブジェクト）にまとめて`Enqueue`→`Release`
- 「閉じ待ち」は`TaskCompletionSource<bool>`で表現し、ボタン押下で`TrySetResult`
- ボタンコールバックは`Interlocked.Exchange(ref istPremere, 1)`で**1回だけ**発火保証
- キャンセルは`onus.Ct.Register(() => tcs.TrySetCanceled())`
- API二種:
  - `DemittereAsync(...)` … `await`で結果`bool`を取れる（非同期呼び出し元向け・推奨）
  - `Demittere(...)` … fire-and-forget（同期呼び出し元向け、結果は`Action`で受ける）
- `Liberare()`では現在分＋キュー全部を`TrySetCanceled`。**`SemaphoreSlim`はDisposeしない**（ワーカーが`WaitAsync`中の可能性→GC任せ。これは常駐前提のときのみ許される）

---

## 8. まとめ: 新しいUIを1画面追加するときの手順（規約テンプレート）

1. `*.Contractus` に `IVelum{X}`（View公開API）、`IOperatio{X}`、`Usus{X}` Enum を定義
2. `Officia/Velum` に `internal sealed class Velum{X} : IVelum, IVelum{X}, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis` を実装
   - `Anchora`/`Interpretatio`/`ApplicatorSoniVeli`/`IOperatio{X}` を注入
   - `Incipere`(Q取得→ローカライズ→`ActivareCB`)、`Demittere/Tollere`、`PonoPermissionemUsus`、`premereX`(→`Executare`)、`Liberare`
   - イベントは`-=`→`+=`の冪等配線
3. `Auctoritas/Senatus/Operatio` に `Operatio{X}`（`Initiare`/`Purgare`/`Executare`）を実装
4. `Auctoritas/Senatus/Praeco` に `internal sealed class Praeco{X} : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis`
   - コンストラクタで`_operatio.Initiare(Executare)`
   - `Incipere`→`_ = Demittere()`、`Executare`ディスパッチャ、各`Premere{X}`は `ConareUsus`/try-catch(`Carnifex`)/`finally LiberareUsus` パターン
   - 遷移時は`TollereVelaOmnium()`→`AdMundum`
5. `Faber` に `.AsSelf().AsImplementedInterfaces()` で登録
6. 常駐UIなら全て `~Radicis` 型 + `FaberSenatusRadicis` に登録

---

## 補足: 名前空間体系について

ワークスペースルール(`.cursor/rules/yulinti.mdc`)の名前空間説明は `Yulinti.Regnum / Unity / Exercitus` 体系で書かれているが、
実コードは `Yulinti.Auctoritas / Officia / ImperiumDelegatum` 体系に移行済み。
役割の対応の目安:

- `Officia` ≒ Unityインフラ層（旧 `Unity`）
- `Auctoritas` ≒ ドメイン/アプリ層（旧 `Exercitus`）

規約文書やルールを更新する際はこの点を合わせておくこと。
