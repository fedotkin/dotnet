# Chapter 12: Threading in C#[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Threading in C# and .NET
  * Starting Threads
    * Passing Data to New Threads
    * Using _ParameterizedThreadStart_
  * The IOU Pattern and Asynchronous Method Calls
  * States of a Thread
  * Terminating Threads
  * Halting Threads and Waking Sleeping Threads
  * Waiting for a Thread to Exit
  * Foreground and Background Threads
  * Thread-Local Storage
  * How Unmanaged Threads and COM Apartments Fit In
- Synchronizing Work Between Threads
  * Lightweight Synchronization with the _Interlocked_ Class
  * _SpinLock_ Class
  * _Monitor_ Class
    * Beware of Boxing
    * Pulse and Wait
  * Locking Objects
    * _ReaderWriterLock_
    * _ReaderWriterLockSlim_
    * _Mutex_
  * Semaphore
  * Events
  * Win32 Synchronization Objects and _WaitHandle_
- Using _ThreadPool_
  * Asynchronous Method Calls
  * Timers
- Concurrent Programming
  * _Task_ Class
  * _Parallel_ Class
  * Easy Entry to the Thread Pool
- Thread-Safe Collection Classes
- Summary
</details>

## Глава 12. Многопоточность в C#
<details>
  <summary><b>Оглавление</b></summary>

- Многопоточность в C# и .NET
  * Запуск потоков
  * Передача данных новым потокам
  * Использование _ParameterizedThreadStart_
  * Шаблон IOU и асинхронные вызовы методов
  * Состояния потока
  * Завершение потоков
  * Останавливающиеся и пробуждающиеся потоки
  * Ожидание завершения потока
  * Потоки переднего плана и фоновые потоки
  * Локальное хранилище потока
  * Как неуправляемые потоки и апартаменты COM приспособлены друг к другу
- Синхронизация работы между потоками
  * Легковесная синхронизация с помощью класса _Interlocked_
  * Класс _SpinLock_
  * Класс _Monitor_
  * Блокирующие объекты
  * Семафоры
  * События
  * Объекты синхронизации Win32 и _WaitHandle_
- Использование _ThreadPool_
  * Асинхронные вызовы методов
  * Таймеры
- Параллельное программирование
  * Класс _Task_
  * Класс _Parallel_
  * Простой вход в пул потоков
- Классы коллекций, безопасные в отношении потоков
- Резюме
</details>

---
## About
Chapter 12, “Threading in C#,”[^1] covers the tasks required in creating multithreaded applications in
the C# managed virtual execution environment. If you’re familiar with threading in the native Win32
environment, you’ll notice the significant differences. Moreover, the managed environment provides
much more infrastructure for making the job easier. You’ll see how delegates, through use of the I Owe
You (IOU) pattern, provide an excellent gateway into the process thread pool. Arguably, synchronization
is the most important concept when getting multiple threads to run concurrently. This chapter covers
the various synchronization facilities available to your applications. In today’s world, concurrency is at
the forefront because, rather than spending exorbitant amount of time and money to create faster
processors, the industry has gravitated to creating processors with multiple cores. Therefore, I introduce
the new Parallel Extensions and the Task Parallel Library (TPL) added to .NET 4.0.

## Abstract
The mere mention of multithreading can strike fear in the hearts of some programmers. For others, it
fires them up for a good challenge. No matter how you react to the subject, multithreading is an area
riddled with minefields. Unless you show due diligence, a threading bug can jump up and bite you—and
bite you in a place where you cannot seem to find it easily. Threading bugs can be among the hardest to
find and they are hard enough to find on a single-processor machine; add more processors and cores,
and the bugs can become even harder to find. In fact, some threading bugs don’t even rear their ugly
head until you run your application on a multiprocessor machine, because that’s the only way to get true
concurrent multithreading. For this reason, I always advise anyone developing a multithreaded
application to test, and test often, on a multiprocessor machine. Otherwise, you run the risk of sending
your product out the door with lurking threading bugs.

&nbsp;&nbsp;&nbsp; I remember it as if it were a meal ago: At a former employer of mine, we were soon to ship our gold
master to the manufacturer and have hundreds of thousands of disks made, and then someone finally
happened to test the application on a multiprocessor machine in the lab. Back in those days,
multiprocessor desktops were few and far between. Needless to say, a great lesson was learned across
the entire team, and a nasty bug was sniped before it got out the door.

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [12_threading](https://github.com/Apress/accelerated-csharp-2010/tree/master/12_threading)

### References
[^1]: Cite this chapter: [Threading in C#](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_12) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
