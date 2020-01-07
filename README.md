# SuperSQL3DVS(デモ・実験用)
**概要**


**導入手順**


**操作説明**
移動
キーボードの矢印で移動。
↑ y軸正の方向に移動
↓ y軸負の方向に移動
→ x軸正の方向に移動
← x軸負の方向に移動
RightCommand or RightControl + ↑ z軸正の方向に移動
RightCommand or RightControl + ↓ z軸負の方向に移動
上記 + 右Shiftで移動が少し速くなる。

回転
矢印+LeftCommand or LeftControlでカメラが回転
LeftCommand or LeftControl + → y軸中心に時計回りに回転
LeftCommand or LeftControl + ← y軸中心に反時計回りに回転
LeftCommand or LeftControl + ↑ x軸中心に時計回りに回転
LeftCommand or LeftControl + ↓ x軸中心に反時計回りに回転

詳細表示
LeftCommand or LeftControl + オブジェクトにカーソルを重ねると詳細が表示されます

**クエリ**
generate Unity_dv
[null(c.name),
	[null((asc)c.day),Object("text", c.day, 10),
		color_gradient(
			rotate(filter(asset("Windmill", c.population/5000), c.name@{name="windmill_cityname"}, "checkbox"), 0, 0, c.wind * 10)@{target="Fan"}
			,
			"blue", 14.1, "red", 33.7, c.temperature
		)
	]%
		!Object("text",c.name,10)
],
%
[null(c.name),
	[null((asc)c.day),
		color_gradient(
			hop(scene(filter(Object("sphere", c.population/5000), c.name@{name="circle_cityname"}, "checkbox"), "wind", c.id),
				1, c.rain, "y"
			),
			"blue", 14.1, "red", 33.7, c.temperature
		)
	]◯
	!object("text", c.name, 50)
]%@{margin=200}
,
[null((asc)c.day),[position(move(move({object("text", c.name, 5)!color_gradient(move(scene(filter(object("sphere", c.population/10000), c.name@{name="map_cityname"}, "checkbox"), "wind", c.id), 0, c.population/10000, 0),"blue",14.1,"red",33.7,c.temperature)}, 0, c.day * 300, 0),
		c.longitude * 40, 0, c.latitude * 40), 0, 0, 0)]!
]#
from cities c where c.year = 2018 and c.month =8

**クエリ説明**

＊データは実験用の物です。実際の情報とは異なる物なのでご了承下さい。
