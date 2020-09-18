#define aaaa

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

#ifdef aaaav

#endif
namespace _1._Parallel
{
    
    public class Program
    {            
        public static void Main(string[] args)
        {
            // Banchmark Check
            var summary = BenchmarkRunner.Run<Test>();


            // // Test Result Check
            // var t = new Test();
            // t.FuncA();
            // Console.WriteLine("A  :  "+t.sumOList);            
            // t.FuncB();
            // Console.WriteLine("B  :  "+t.sumOList);
        }


    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MarkdownExporter]
    public class Test
    {
        [Params(1000, 10000000)]
        public int N = 10000;

        public int sumParallel_N = 0, sumOList = 0;

        [GlobalSetup]
        public void Setup()
        {
            sumParallel_N = 0;
            sumOList = 0;
            num = N / 8;
        }

        [GlobalCleanup]
        public void CleanUp()
        {
        }
        
        int [] sumResult = new int[8];             
        Task[] tasks = new Task[8];
        int num;        

        [Benchmark]
        public void FuncA(){
            sumOList = 0;
            for(int i = 0; i < 8; ++i)
            {
                int index = i;                    
                tasks[i] = Task.Run(()=>{
                    
                    int start = num * index;
                    int max = start + num;
                    for (int k = start; k < max; k++)
                    {
                        sumResult[index] += k;
                    }
                });
            }
            
            Task.WaitAll(tasks);
            
            for(int i = 0; i < sumResult.Length; ++i)
            {
                sumOList += sumResult[i];
            }
        }

        [Benchmark]
        public void FuncC()
        {
            sumOList = 0;
            Parallel.For(0, 8, _i=>{
                for(int i = 0; i < num; ++i)
                {
                    sumOList+=i;
                }
            });

        }

       [Benchmark]
        public void FuncB()
        {
            sumOList = 0;
            for(int i = 0; i < N; ++i)
            {
                sumOList+=i;                
            }
        }
    }            
    }
}