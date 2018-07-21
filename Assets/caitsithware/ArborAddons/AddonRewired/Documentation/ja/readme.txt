-----------------------------------------------------
                  ArborAddonRewired
          Copyright (c) 2014-2018 Cait Sith Ware. All rights reserved.
          https://caitsithware.com/wordpress/
          support@caitsithware.com
-----------------------------------------------------

ArborAddonRewiredは、Arbor3でRewiredを使用するためのアドオンです。

# 開発環境

| Tools   | Version    |
|---------|------------|
| Unity   | 2017.4.7f1 |
| Arbor   | 3.2.0      |
| Rewired | 1.1.17.1   |

# アセットストア

## Arbor 3

https://www.assetstore.unity3d.com/#!/content/112239?aid=1101lGsc

## Rewired

https://www.assetstore.unity3d.com/#!/content/21676?aid=1101lGsc

# 主な流れ

1. Rewiredの準備

* HierarchyのCreateボタンから、「Create Other / Rewired / Input Manager」を選択してRewiredInputManagerを作成。
* RewiredInputManagerのInspectorの「Launch Rewired Editor」ボタンをクリックし、RewiredEditorウィンドウを開く。
* Players、Actions、各種Mapsを設定。

2. ArborFSMでの使用

* HierarchyのCreateボタンから、「Arbor / ArborFSM」を選択して、ArborFSMを作成。
* ArborFSMのInspectorの「Open Editor」ボタンをクリックし、ArborEditorウィンドウを開く。
* グラフビューを右クリックし「ステート作成」を選択。
* ステートのヘッダ部分の歯車アイコンをクリックし「挙動追加」を選択。
* 「Rewired/Transition/RewiredButtonDownTransition」を選択。
* 以下フィールドを入力
    * Player Name : RewiredInputManagerに登録しているPlayer名
    * Action Name : RewiredInputManagerに登録しているAction名
    * Axis Contribution : 判定する軸方向のタイプ。Anyの場合は負号に関係なく入力があれば遷移。
* On Button Downフィールドを他の場所へドラッグ＆ドロップし、「ステート作成」を選択。

3. 動作確認

* プレイボタンを押す。
* 設定したPlayer名とAction名によるボタンの入力を行う。
* ArborFSMでの遷移を確認。

# サンプルシーン 

サンプルシーンはプロジェクト内の以下のフォルダにあります。
Assets/caitsithware/ArborAddons/AddonRewired/Examples/

# 挙動リスト

## RewiredAnyButtonDownTransition

何らかのボタンを押下した瞬間に遷移する。

### プロパティ

| プロパティ名      | 内容                   |
|-------------------|------------------------|
| Player Name       | 入力を判定するPlayer名 |
| Axis Contribution | 判定する軸方向のタイプ |
| On Button Down    | 押下時の遷移           |

### AddBehaviourMenu名

Rewired/Transition/RewiredAnyButtonDownTransition

## RewiredAnyButtonTransition

何らかのボタンを押下している間、遷移する。

### プロパティ

| プロパティ名      | 内容                   |
|-------------------|------------------------|
| Player Name       | 入力を判定するPlayer名 |
| Axis Contribution | 判定する軸方向のタイプ |
| On Button         | 押下時の遷移           |

### AddBehaviourMenu名

Rewired/Transition/RewiredAnyButtonTransition

## RewiredAnyButtonUpTransition

何らかのボタンを離した瞬間に遷移する。

### プロパティ

| プロパティ名      | 内容                   |
|-------------------|------------------------|
| Player Name       | 入力を判定するPlayer名 |
| Axis Contribution | 判定する軸方向のタイプ |
| On Button Up      | 離された時の遷移       |

### AddBehaviourMenu名

Rewired/Transition/RewiredAnyButtonUpTransition

## RewiredAxis2DTransition

Axis2Dを入力した瞬間に遷移する。

### プロパティ

| プロパティ名       | 内容                       |
|--------------------|----------------------------|
| Player Name        | 入力を判定するPlayer名     |
| X Axis Action Name | 横軸入力を判定するAction名 |
| Y Axis Action Name | 縦軸入力を判定するAction名 |
| Output Axis Value  | Axis2Dの値を出力           |
| On Axis 2D         | Axis2Dが入力された時の遷移 |

### AddBehaviourMenu名

Rewired/Transition/RewiredAxis2DTransition

## RewiredAxisTransition

Axisを入力した瞬間に遷移する。

### プロパティ

| プロパティ名       | 内容                       |
|--------------------|----------------------------|
| Player Name        | 入力を判定するPlayer名     |
| Action Name        | 入力を判定するAction名     |
| Output Axis Value  | Axisの値を出力             |
| On Axis            | Axisが入力された時の遷移   |

### AddBehaviourMenu名

Rewired/Transition/RewiredAxisTransition

## RewiredButtonDownTransition

ボタンを押下した瞬間に遷移する。

### プロパティ

| プロパティ名       | 内容                       |
|--------------------|----------------------------|
| Player Name        | 入力を判定するPlayer名     |
| Action Name        | 入力を判定するAction名     |
| Axis Contribution  | 判定する軸方向のタイプ     |
| On Button Down     | 押下時の遷移               |

### AddBehaviourMenu名

Rewired/Transition/RewiredButtonDownTransition

## RewiredButtonTransition

ボタンを押下している間、遷移する。

### プロパティ

| プロパティ名       | 内容                       |
|--------------------|----------------------------|
| Player Name        | 入力を判定するPlayer名     |
| Action Name        | 入力を判定するAction名     |
| Axis Contribution  | 判定する軸方向のタイプ     |
| On Button          | 押下時の遷移               |

### AddBehaviourMenu名

Rewired/Transition/RewiredButtonTransition

## RewiredButtonUpTransition

ボタンを離した瞬間に遷移する。

### プロパティ

| プロパティ名       | 内容                       |
|--------------------|----------------------------|
| Player Name        | 入力を判定するPlayer名     |
| Action Name        | 入力を判定するAction名     |
| Axis Contribution  | 判定する軸方向のタイプ     |
| On Button Up       | 離した時の遷移             |

### AddBehaviourMenu名

Rewired/Transition/RewiredButtonUpTransition

# Copyright

Arbor 3 : Copyright (c) 2014-2018 Cait Sith Ware. All rights reserved.
Rewired : Copyright (c) 2018 Augie R. Maddox, Guavaman Enterprises. All rights reserved.