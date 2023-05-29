# Mulitithreading_StudyCody

<!--TOC-->
  - [<span id="Chapter1">第一章 线程基础</span>](#span-idchapter1-span)
    - [<span id="Chapter1_Recipe1">Recipe1 使用C#创建线程</span>](#span-idchapter1_recipe1recipe1-cspan)
    - [<span id="Chapter1_Recipe2">Recipe2 暂停线程</span>](#span-idchapter1_recipe2recipe2-span)
    - [<span id="Chapter1_Recipe3">Recipe3 线程等待</span>](#span-idchapter1_recipe3recipe3-span)
    - [<span id="Chapter1_Recipe4">Recipe4 终止线程</span>](#span-idchapter1_recipe4recipe4-span)
    - [<span id="Chapter1_Recipe5">Recipe5 检测线程状态</span>](#span-idchapter1_recipe5recipe5-span)
    - [<span id="Chapter1_Recipe6">Recipe6 线程优先级</span>](#span-idchapter1_recipe6recipe6-span)
    - [<span id="Chapter1_Recipe7">Recipe7 前台线程和后台线程</span>](#span-idchapter1_recipe7recipe7-span)
    - [<span id="Chapter1_Recipe8">Recipe8 向线程传递参数</span>](#span-idchapter1_recipe8recipe8-span)
    - [<span id="Chapter1_Recipe9">Recipe9 使用C#中的`lock`关键字</span>](#span-idchapter1_recipe9recipe9-clockspan)
    - [<span id="Chapter1_Recipe10">Recipe10 <font color="#FF0000">***</font>使用`Monitor`类锁定资源</span>](#span-idchapter1_recipe10recipe10-font-colorff0000fontmonitorspan)
    - [<span id="Chapter1_Recipe11">Recipe11 处理异常</span>](#span-idchapter1_recipe11recipe11-span)
  - [<span id="Chapter2">第二章 线程同步</span>](#span-idchapter2-span)
    - [Recipe1 执行基本的原子操作](#recipe1-)
    - [Recipe2 使用`Mutex`类](#recipe2-mutex)
    - [Recipe3 使用semaphoreSlim类](#recipe3-semaphoreslim)
    - [Recipe4 使用AutoResetEvent类](#recipe4-autoresetevent)
    - [Recipe5 使用ManualResetEventSlim类](#recipe5-manualreseteventslim)
    - [Recipe6 使用CountdownEvent类](#recipe6-countdownevent)
  - [<span id="Tips">知识点</span>](#span-idtipsspan)
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

> **`互斥`进程间同步的同步基元**<br/>
> 描述如何使用`Mutex`类来同步两个单独的程序<br/>
> `Mutex`是一种原始的同步方式，其只对一个线程授予对共享资源的独占访问

### Recipe3 使用semaphoreSlim类

> **`信号系统`对可同时访问资源或资源池的线程数加以限制的 System.Threading.Semaphore 的轻量替代**<br/>
> 展示semaphoreSlim类是如何作为semaphore类的轻量级版本。<br/>
> 该类限制了同时访问同一个资源的线程数量

### Recipe4 使用AutoResetEvent类

>当主程序启动时，定义了两个AutoResetEvent实例。<br/>
>其中一个是从子线程向主线程发信号，另一个实例是从主线程向子线程发信号。

>我们向AutoResetEvent构造方法传入false,定义了这两个实例的初始状态为unsignaled。<br/>
>这意味着任何线程调用这两个对象中的任何一个的WaitOne方法将阻塞，直到我们调用了Set方法。<br/>
>如果初始事件状态为true，那么AutoResetEvent实例的状态为signaled,如果线程调用了WaitOne方法则会被立即处理。<br/>
>然后事件状态自动变为unsignaled,所以需要再对该实例调用一次Set方法，以便让其他的线程对该实例调用WaitOne方法从而继续执行。

>然后我们创建了第二个线程，其会执行第一个操作10秒钟，然后等待从第二个线程发出的信号。<br/>
>该信号意味着第一个操作已经完成。<br/>
>现在第二个线程在等待主线程的限号。<br/>
>我们对主线程做了一些附加工作，并通过调用_mainEvent.Set方法发送了一个信号。<br/>
>然后等待从第二个线程发出的另一个信号。

>AutoResetEvent类采用的是内核时间模式，所以等待时间不能太长。<br/>
>使用ManualResetEventSlim类更好，因为它使用的是混合模式。

### Recipe5 使用ManualResetEventSlim类

> ManualResetEventSlim的整个工作方式有点像人群通过大门。<br/>
> AutoResetEvent事件像一个旋转门，一次只允许一人通过。<br/>
> ManualResetEventSlim是ManualResetEvent的混合版本，一直保持大门敞开直到手动调用Reset方法。<br/>
> 当调用_mainEvent.Set时，相当于打开了大门从而允许准备好的线程接收信号并继续工作。<br/>
> 然而线程3还处于睡眠状态，没有赶上时间。<br/>
> 当调用_mainEvent.Reset相当于关闭了大门。<br/>
> 最后一个线程已经准备好执行，但是不得不等待下一个信号，即要等待好几秒种。

### Recipe6 使用CountdownEvent类

>当主程序启动时，创建了一个CountdownEvent实例，在其构造函数中指定了当两个操作完成时会发出信号。<br/>
>然后我们启动了两个线程，当它们执行完成后会发出信号。<br/>
>一旦第二个线程完成，主线程会从等待CountdownEvent的状态中返回并继续执行。<br/>
>针对需要等待多个异步操作完成的情形，使用该方式是非常便利的。

>然而这有一个重大的缺点。<br/>
>如果调用_countdown。Signal()没达到指定的次数，那么_countdown.Wait()将一直等待。<br/>
>请确保使用CountdownEvent时，所有线程完成后都要调用Signal方法。

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

