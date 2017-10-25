 /*----ConstEnum---*/
/*----常量枚举类----*/


//底层事件注册
public class BroadEvent {

	public const string EFFECT_EVENT = "EFFECT_EVENT";//buff

	public const string GAMESTART_EVENT = "GAMESTART_EVENT"; //游戏外控制，用于控制开始界面跳转到游戏界面的事件

	public const string PAUSE_EVENT = "PAUSE_EVENT";//暂停游戏 游戏内控制

	public const string GREENCAPDATA_EVENT = "GREENCAPDATA_EVENT";//绿帽子派发
}

//buff
public class Effect {

	public const int Belive_Effect = 101;//信任感倍增，扣除对方一顶绿帽子

	public const int Drink_Beer = 151; // 喝到啤酒，方向键相反
}

//分配绿帽子
public class GreenCap {

	public const int Give_Male = 0;//给男人一顶绿帽子

	public const int Give_Famale = 1;//给女人一顶绿帽子
}

//游戏内控制参数
public class Pause {

	public const bool Game_Start = true;//开始游戏
	
	public const bool Game_Pause = false;//暂停游戏
}

