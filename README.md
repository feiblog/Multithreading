# Mulitithreading_StudyCody

<!--TOC-->
  - [第一章 线程基础](#Chapter1)
    - [Recipe1 使用C#创建线程](#Chapter1_Recipe1)
    - [Recipe2 暂停线程](#Chapter1_Recipe2)
    - [Recipe3 线程等待](#Chapter1_Recipe3)
    - [Recipe4 终止线程](#Chapter1_Recipe4)
    - [Recipe5 检测线程状态](#Chapter1_Recipe5)
    - [Recipe6 线程优先级](#Chapter1_Recipe6)
    - [Recipe7 前台线程和后台线程](#Chapter1_Recipe7)
    - [Recipe8 向线程传递参数](#Chapter1_Recipe8)
    - [Recipe9 使用C#中的`lock`关键字](#Chapter1_Recipe9)
    - [Recipe10 <font color="#FF0000">***</font>使用`Monitor`类锁定资源](#Chapter1_Recipe10)
    - [Recipe11 处理异常](#Chapter1_Recipe11)
  - [第二章线程同步](#Chapter2)
    - [Recipe1 执行基本的原子操作](#recipe1-)
    - [Recipe2 使用`Mutex`类](#recipe2-)
   - [知识点](#)
<!--/TOC-->

## <span id="Chapter1">第一章 线程基础</span>
> 线程会消耗大量的操作系统资源。多个线程共享一个物理处理器将导致操作系统忙于管理这些线程，而无法运行程序。

### <span id="Chapter1_Recipe1">Recipe1 使用C#创建线程</span>
### <span id="Chapter1_Recipe2">Recipe2 暂停线程</span>
### <span id="Chapter1_Recipe3">Recipe3 线程等待</span>
### <span id="Chapter1_Recipe4">Recipe4 终止线程</span>
### <span id="Chapter1_Recipe5">Recipe5 检测线程状态</span>
### <span id="Chapter1_Recipe6">Recipe6 线程优先级</span>
### <span id="Chapter1_Recipe7">Recipe7 前台线程和后台线程</span>
### <span id="Chapter1_Recipe8">Recipe8 向线程传递参数</span>
### <span id="Chapter1_Recipe9">Recipe9 使用C#中的`lock`关键字</span>

> 当一个线程使用某些资源时，同事其他线程无法使用该资源。

### <span id="Chapter1_Recipe10">Recipe10 <font color="#FF0000">***</font>使用`Monitor`类锁定资源</span>

>本节演示另一个常见的多线程错误，被称为死锁（deadlock）由于死锁将导致程序停止工作，使用`Monitor`类来避免死锁<br/>
>lock关键字则用于创建死锁

### <span id="Chapter1_Recipe11">Recipe11 处理异常</span>
>在线程中始终使用`try-catch`代码块是非常重要的，因为不可能在线程代码之外来捕获异常

<br/>

## <span id="Chapter2">第二章 线程同步</span>
> 讲述关于在多线程中使用共享资源的常用技术

### Recipe1 执行基本的原子操作

> 本节介绍如何对对象执行基本的原子操作，从而不用阻塞线程就可避免`竞争条件`

### Recipe2 使用`Mutex`类

> 描述如何使用`Mutex`类来同步两个单独的程序<br/>
> `Mutex`是一种原始的同步方式，其只对一个线程授予对共享资源的独占访问



<br/>

## <span id="Tips">知识点</span>

> 断电保护、算法、界面友好度、处理速度、控制功能

> `abstract`可以用来修饰类,方法,属性,索引器和时间,这里不包括字段. 使用abstrac修饰的类,该类只能作为其他类的基类,不能实例化,而且abstract修饰的成员在派生类中必须全部实现,不允许部分实现,否则编译异常

>`override`重写，是在子类中重写父类中的方法，两个函数的函数特征（函数名、参数类型与个数）相同。用于扩展或修改继承的方法、属性、索引器或事件的抽象或虚拟实现。提供从基类继承的成员的新实现，而通过override声明重写的方法称为基方法。

>`virtual`虚方法，

> <font color="#FF0000">***</font> 线程同步之排它锁/Monitor监视器类 https://www.cnblogs.com/tianma3798/p/6290712.html

> <font color="#FF0000">***</font> `原子操作` 指不会被线程调度机制打断的操作，这种操作一旦开始，就一直运行到结束。 https://blog.csdn.net/weixin_44228698/article/details/108524804

> 上下文切换（context switch）　　内核模式（kernel-mode）　　用户模式（user-mode）　　混合模式（hybrid）

> `Interlocked` 为多个线程共享的变量提供原子操作

<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>

