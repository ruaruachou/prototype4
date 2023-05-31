# prototype4：擂台弹球
 Challenge
 =  
 
 >## 本地坐标获取  
 1. 添加子物体FocalPoint，通过FocalPoint获取父物体Local坐标
>## 用Find方法，不需要public拖拽
 ```
    public class Enemy : MonoBehaviour

    private GameObject player;

    void Start()
    {
    player = GameObject.Find("Player");
    }
```
    
# Prototype
>## 用List<>遍历场上Enemy
1. 为每个敌人生成对应的跟踪子弹
    - 在Player中声明Enemy enemy，在Bullet中声明targetEnemy
    - 在Player中实例化Bullet，并使targetEnemy=enemy

>## 协程
1. 用协程控制buff持续时间
2. 用协程控制自动射击的间隔