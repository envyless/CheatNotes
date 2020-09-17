using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Security.Cryptography;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace _1._Parallel
{
    
    public class Program
    {
        public static TimeSpan Time(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
        static int sumOfListA = 0;
        static int N = 10000000;
        public static void FuncA(){      
            // for(int i = 0; i < N; ++i)
            // {
            //     Task.Run(()=>{
            //         sumOfListA += i;
            //      });  
            // }
            sumOfListA = 0;
            int num = N / 8;            
            Parallel.For(0, 8, _i=>{
                int start = _i * num;
                int max = start + num;
                for(int i = start; i < max; ++i)
                    sumOfListA++;
            }); 
        }

        public static void FuncB()
        {
            sumOfListA = 0;
            for(int i = 0; i < N; ++i)
            {
                sumOfListA++;                
            }
        }
        
        public static void Main(string[] args)
        {
            var time = Time(FuncB);            
            Console.WriteLine("result : "+time.TotalMilliseconds); 
            //var summary = BenchmarkRunner.Run<Test>();
        }


    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    //[SimpleJob(RuntimeMoniker.CoreRt30)]
    //[SimpleJob(RuntimeMoniker.Mono)]
    [MarkdownExporter]
    public class Test
    {
        [Params(1000, 1000000)]
        public int N;

        int sumOfListA = 0, sumOfListB = 0,sumOfListC = 0, sumOfListD = 0;

        [GlobalSetup]
        public void Setup()
        {
            sumOfListA = 0;
            sumOfListB = 0;
        }

        [GlobalCleanup]
        public void CleanUp()
        {
            Console.WriteLine("sumOfList : "+sumOfListA);
            Console.WriteLine("sumOfList : "+sumOfListB);
        }

        [Benchmark]
        public void FuncA(){            
            Parallel.For(0, N, _i=>{
                sumOfListA+=_i;
            });           
        }

        [Benchmark]
        public void FuncB()
        {
            for(int i = 0; i < N; ++i)
            {
                sumOfListB+=i;                
            }
        }
    }            
    }
}