# Mulitithreading_StudyCody



## 第一章 线程基础
> 线程会消耗大量的操作系统资源。多个线程共享一个物理处理器将导致操作系统忙于管理这些线程，而无法运行程序。

### Recipe1 使用C#创建线程
### Recipe2 暂停线程
### Recipe3 线程等待
### Recipe4 终止线程
### Recipe5 检测线程状态
### Recipe6 线程优先级
### Recipe7 前台线程和后台线程
### Recipe8 向线程传递参数
### Recipe9 使用C#中的`lock`关键字

> 当一个线程使用某些资源时，同事其他线程无法使用该资源。

### Recipe10 <font color="#FF0000">***</font>使用`Monitor`类锁定资源

>本节演示另一个常见的多线程错误，被称为死锁（deadlock）由于死锁将导致程序停止工作，使用`Monitor`类来避免死锁<br/>
>lock关键字则用于创建死锁

### Recipe11 处理异常
>在线程中始终使用`try-catch`代码块是非常重要的，因为不可能在线程代码之外来捕获异常

<br/>

## 第二章线程同步
> 讲述关于在多线程中使用共享资源的常用技术

### Recipe1 执行基本的原子操作

> 本节介绍如何对对象执行基本的原子操作，从而不用阻塞线程就可避免`竞争条件`


### 知识点

> 断电保护、算法、界面友好度、处理速度、控制功能

> <font color="#FF0000">***</font> 线程同步之排它锁/Monitor监视器类 https://www.cnblogs.com/tianma3798/p/6290712.html

> 上下文切换（context switch）  内核模式（kernel-mode）  用户模式（user-mode）  混合模式（hybrid）
