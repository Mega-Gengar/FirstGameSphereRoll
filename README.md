# FirstGameSphereRoll
 
# 第一款游戏：滚动小球

实现的功能：

1、创建物体，包括跑到、方块、小球。

方块要建立一个源物体样式，能够在变化的过程中，同时更改，比如颜色等等。

将摄像机挂在小球上面能够保证摄像头实时跟踪目标，也就是将摄像机对象拖拽到小球物体上面

2、小球滚动

在小球对象上创建一个脚本

```
float x = Input.GetAxis("Horizontal");//这里就是用控制器控制小球方向的
//这里是控制左右的，比如x = -1的时候就是向左运动，为1就是向右。最后一项是控制小球前进的。Tmie.deltaTime保证在所有设备上速度一致。
transform.Translate(x*turnSpeed*Time.deltaTime, 0, speed * Time.deltaTime);
```

3、碰撞系统

把Box Collider里面的Is Trigger勾上，这是触发器。

将方块上面创建一个脚本

```
//在里面创建函数
    private void OnTriggerEnter(Collider other) //这是用于碰撞检测的
    {
        Debug.Log(other.name + "你喷到我来"); //这是用来调试的
        if (other.name == "Player") //这是保证物体碰到Player对象（也就是球）时，将速度置为0，
        {
            Time.timeScale = 0;
        }
    }
```

将球体里面Rigidbody的Is Kinematic给勾上，这里如果打开Rigidbody不勾选会导致球体下沉。

4、游戏左右边界

在Player脚本里面设置边界

```
    if (Input.GetKeyDown(KeyCode.R)){ //这里用来判定每次触发R键的时候，从新开始，回到第一幕。
        SceneManager.LoadScene(0);
        Time.timeScale = 1; //不给时间他会一直为0
        return;
    }
    float x = Input.GetAxis("Horizontal");
    transform.Translate(x*turnSpeed*Time.deltaTime, 0, speed * Time.deltaTime);

    if(transform.position.x<-2.5||transform.position.x>2.5)  //跑到边界判断
    {
        transform.Translate(0, -4 * speed * Time.deltaTime,0);
    }
    if (transform.position.y < -20) //掉下去的高度到达一定值，会让小球停下。
    {
        Debug.Log("掉下去了");
        Time.timeScale = 0;
    }
```

5、结束关卡

添加一个正方体在终点，覆盖范围，将物体的Mesh Render关闭就在游戏中看不到了，并设置碰撞也就是钩上Is Trigger。

添加一个Panel画板对象，他会默认创建一个Canvas的父类对象。然后在panel里面添加TEX对象，你在这个对象上面添加文字内容，并调整大小。

最后设置正方体的脚本

```
    private void Start() //最开始的时候将它的激活关闭
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel").gameObject.SetActive(false); 
    }
    private void OnTriggerEnter(Collider other) //碰到时打开
    {
        GameObject canvas = GameObject.Find("Canvas"); //他首先寻找Canvas对象。
        canvas.transform.Find("Panel").gameObject.SetActive(true);  //在该对象上面查找Panel的gameobject对象去激活那个幕布TEXT。
    }
```

