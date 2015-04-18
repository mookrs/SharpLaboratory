using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        private static bool _hasDone = false;
        private static bool _hasDoneInLock = false;
        private static object _lock = new object();

        static void Main(string[] args)
        {
            new Thread(Go).Start();     // .NET 1.0 开始就有的 
            Task.Factory.StartNew(Go);  // .NET 4.0 引入了 TPL
            Task.Run(new Action(Go));   // .NET 4.5 新增的 Run 方法

            Thread.Sleep(1000);
            Console.WriteLine("*****************************");

            // 线程 ID
            Console.WriteLine("我是主线程：Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
            ThreadPool.QueueUserWorkItem(GoGo);

            Thread.Sleep(1000);
            Console.WriteLine("*****************************");

            // 传参数
            new Thread(() => { GoGoGo("arg1", "arg2", "arg3"); }).Start();
            Task.Run(() => { GoGoGo("arg1", "arg2", "arg3"); });

            Thread.Sleep(1000);
            Console.WriteLine("*****************************");

            // 线程安全问题
            new Thread(Done).Start();
            new Thread(Done).Start();

            Thread.Sleep(1000);
            Console.WriteLine("*****************************");

            // 独占锁
            new Thread(DoneInLock).Start();
            new Thread(DoneInLock).Start();

            Thread.Sleep(1000);
            Console.WriteLine("*****************************");

            // 捕获其他线程的异常
            try
            {
                var task = Task.Run(new Action(MakeException));
                task.Wait(); // 在调用了这句话之后，主线程才能捕获 task 里面的异常
            }
            catch (Exception)
            {
                Console.WriteLine("Exception! (Wait)");
            }
            try
            {
                // 对于有返回值的Task, 接收了它的返回值就不需要再调用Wait方法了
                var task2 = Task.Run(() => GetNameMakeException());
                var name = task2.Result;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception! (Return Value)");
            }

            Thread.Sleep(1000);
            Console.WriteLine("*****************************");

            // 测试 Await
            Console.WriteLine("我是主线程：Thread Id {0}\n", Thread.CurrentThread.ManagedThreadId);
            AsyncWrapper();

            Thread.Sleep(5000);
            Console.WriteLine("*****************************");

            // 用 GetAwaiter().OnCompleted 返回结果
            var task3 = Task.Run(() => GetNameWithOnCompleted());
            task3.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("我是哪个线程? Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
                var name = task3.Result;
                Console.WriteLine("GetNameWithouAwait() name is: " + name);
            });
            Console.WriteLine("代码不阻塞，继续执行");

            Console.WriteLine("全部执行结束");
            Console.ReadKey();
        }

        public static void Go()
        {
            Console.WriteLine("我是另一个线程");
        }

        public static void GoGo(object data)
        {
            Console.WriteLine("我是另一个线程：Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public static void GoGoGo(string arg1, string arg2, string arg3)
        {
            Console.WriteLine("我是另一个线程：Thread Id {0}, 参数：{1}, {2}, {3}", Thread.CurrentThread.ManagedThreadId,
                arg1, arg2, arg3);
        }

        public static void Done()
        {
            if (!_hasDone)
            {
                Console.WriteLine("Done"); // 线程不安全
                _hasDone = true;
            }
        }

        public static void DoneInLock()
        {
            lock (_lock)
            {
                if (!_hasDoneInLock)
                {
                    Console.WriteLine("Done");  // 独占锁
                    _hasDoneInLock = true;
                }
            }
        }

        public static void MakeException()
        {
            throw new NullReferenceException();
        }

        public static string GetNameMakeException()
        {
            throw new NullReferenceException();
        }

        public static string GetString()
        {
            Console.Write("Async thread is: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            return "I've return.";
        }

        public static async Task AsyncWrapper()
        {
            Console.WriteLine("Before calling GetNameAsync(), Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            var nameAwait = await GetNameAsync();   // 用了 await，下面阻塞
            Console.WriteLine("End calling GetNameAsync().（用了await）\n");


            Console.WriteLine("Before calling GetNameAsync(), Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            var nameAsync = GetNameAsync();   // 没用 await，下面继续执行
            Console.WriteLine("End calling GetNameAsync().（没用await）");
            Console.WriteLine("Get result from GetNameAsync: {0}", await nameAsync);
        }

        public static async Task<string> GetNameAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("GetNameAsync() Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
                return "John";
            });
        }

        static string GetNameWithOnCompleted()
        {
            Console.WriteLine("我是另一个线程：Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            return "Jay";
        }
    }
}
