# SuperSQL3DVS(デモ・実験用)
## 概要
本システムはSuperSQLとUnityとを組み合わせて, 簡潔なクエリ記述のみで3次元空間にデータ可視化を可能とする.  
SuperSQLについては[SuperSQL](https://github.com/ToyamaLab/NewSSQL)を参照.  

＊今回はデモ用のものなので, 事前にSuperSQLクエリから作成されたファイルを用いたデータ可視化を体験するものとなっている.

## 導入手順
- Unityのダウンロード  
 1. [Unity Hubダウンロードサイト](https://unity3d.com/jp/get-unity/download)からUnity Hubをダウンロード  
 1. 手順に従ってインストール  
 1. Unity Hubのインストールから最新版のUnity(Unity 2019.2.17f1)をインストール(時間がかかります)  
 ![For Image](https://user-images.githubusercontent.com/25918044/71969894-eb028100-324a-11ea-975a-3ea3c91c2ba8.png)

- 本システムの導入
 1. 右上のgit Clone or Downloadボタンからダウンロード
 1. zipファイルを解凍
 1. Unity Hubを開き、プロジェクトからリストに追加を選択
 1. ダウンロードしてきたプロジェクト(ディレクトリ)を開く(DataVisualization-master)
 1. 追加したプロジェクトを開く(最初は開くまでに時間がかかります。おやつを用意して気長にお待ちください)
 <img width="722" alt="スクリーンショット 2020-01-08 19 18 54" src="https://user-images.githubusercontent.com/25918044/71970310-c8bd3300-324b-11ea-853a-7fe9edc8b86a.png">

- 起動
 1. Unityの画面が開いたら、▷(スタート)ボタンをクリックで開始
 <img width="866" alt="スクリーンショット 2020-01-08 19 22 21" src="https://user-images.githubusercontent.com/25918044/71970561-45e8a800-324c-11ea-9ba5-5d3cc485655b.png">


## 操作説明  
**移動**  
キーボードの矢印で移動。  
- ↑ y軸正の方向に移動
- ↓ y軸負の方向に移動
- → x軸正の方向に移動
- ← x軸負の方向に移動
- RightCommand or RightControl + ↑ z軸正の方向に移動
- RightCommand or RightControl + ↓ z軸負の方向に移動  
上記 + 右Shiftで移動が少し速くなる。

**回転**  
- 矢印+LeftCommand or LeftControlでカメラが回転
- LeftCommand or LeftControl + → y軸中心に時計回りに回転
- LeftCommand or LeftControl + ← y軸中心に反時計回りに回転
- LeftCommand or LeftControl + ↑ x軸中心に時計回りに回転
- LeftCommand or LeftControl + ↓ x軸中心に反時計回りに回転

**詳細表示**  
- LeftCommand or LeftControl + オブジェクトにカーソルを重ねると詳細が表示されます

**シーン遷移**  
- クエリでscene関数がついているゲームオブジェクトをクリックすると, シーンが遷移します

**フィルタリング, カメラボタン**
- 画面右上プルダウンをクリックすると, フィルターとカメラボタンが利用できます
<img width="889" alt="スクリーンショット 2020-01-08 18 35 09" src="https://user-images.githubusercontent.com/25918044/71966866-b50ece00-3245-11ea-8b66-93b978690523.png">

## クエリ1
```
generate Unity_dv  
[null(c.name),  
	[null((asc)c.day),
		Object("text", c.day, 10),  
			color_gradient(  
				rotate(
					filter(
						asset("Windmill", c.population/5000), c.name@{name="windmill_cityname"}, "checkbox"
					), 0, 0, c.wind * 10
				)@{target="Fan"}, "blue", min[c.temperature], "red", max[c.temperature], c.temperature  
			)  
	]#  
	!Object("text",c.name,10)  
],  
%  
[null(c.name),  
	[null((asc)c.day),  
		color_gradient(  
			hop(
				scene(
					filter(
						Object("sphere", c.population/5000), c.name@{name="circle_cityname"}, "checkbox"
					), "wind", c.id
				),  
				1, c.rain, "y"  
			), "blue", min[c.temperature], "red", max[c.temperature], c.temperature  
		)  
	]◯  
	!object("text", c.name, 50)  
]%@{margin=200}  
,  
[null((asc)c.day),  
	[position(
		move(
			move({object("text", c.name, 5)!
				color_gradient(
					move(
						scene(
							filter(
								object("sphere", c.population/10000), c.name@{name="map_cityname"}, "checkbox"
							), "wind", c.id
						), 0, c.population/10000, 0
					), "blue", min[c.temperature], "red",33.7,c.temperature
				)}, 0, c.day * 300, 0
			), c.longitude * 40, 0, c.latitude * 40
		), 0, 0, 0
	)]!  
]%  
from cities c where c.year = 2018 and c.month =8  
```
## クエリ2
```
foreach c.id
generate Unity_dv
[Object("text", c.year, 10),
	[Object("text", c.month || "月", 10), 
		[null((asc)c.day), Object("text", c.day, 10), 
			color_gradient(
				rotate(asset("Windmill", c.population/5000), 0, 0, c.wind * 10)@{target="Fan"},
				"blue", 14.1, "red", 33.7, c.temperature
			)
		],
	]!
	!Object("text",c.name,10)
]%@{margin=200}
from cities c 
```
## クエリ説明  
1つめのクエリ例では気温, 人口等の情報を同様のチャンネルへの割り当てを行なったオブジェクト群を３種類のレイアウトで可視化する.  

＊データは実験用の物です。実際の情報とは異なる物なのでご了承下さい。
