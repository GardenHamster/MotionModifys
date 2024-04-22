# MontionModifys

### 说明
- 用于批量修改Live2d motion.json，将参数命名方式从Cubism SDK2修改到SDK3

- 比如`PARAM_ANGLE_X`修改为`ParamAngleX`

``` json5
{
	"Version": 3,
	"Meta": {
		"Duration": 3,
		"Fps": 30.0,
		"FadeInTime": 0.5,
		"FadeOutTime": 0.5,
		"Loop": true,
		"AreBeziersRestricted": true,
		"CurveCount": 86,
		"TotalSegmentCount": 108,
		"TotalPointCount": 408,
		"UserDataCount": 0,
		"TotalUserDataSize": 0
	},
	"Curves": [
		{
			"Target": "Parameter",
			"Id": "PARAM_ANGLE_X",
			"Segments": [
				0,
				0,
				1,
				1,
				0,
				2,
				0,
				3,
				0
			]
		},
```

### 使用方法
点击打开文件，选择一个或多个`*.motions.json文件`，然后选择输出目录即可

