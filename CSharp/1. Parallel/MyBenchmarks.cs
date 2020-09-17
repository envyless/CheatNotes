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


namespace MyBenchmarks
{
    // public class Md5VsSha256
    // {
    //     private const int N = 10000;
    //     private readonly byte[] data;

    //     private readonly SHA256 sha256 = SHA256.Create();
    //     private readonly MD5 md5 = MD5.Create();

    //     public Md5VsSha256()
    //     {
    //         data = new byte[N];
    //         new Random(42).NextBytes(data);
    //     }

    //     [Benchmark]
    //     public byte[] Sha256() => sha256.ComputeHash(data);

    //     [Benchmark]
    //     public byte[] Md5() => md5.ComputeHash(data);
    // }

    public class Program
    {
        public static void MainA(string[] args)
        {
            //var summary = BenchmarkRunner.Run<Md5VsSha256>();
        }
    }


    //[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    //[SimpleJob(RuntimeMoniker.CoreRt30)]
    //[SimpleJob(RuntimeMoniker.Mono)]
    [RPlotExporter]
    public class Test
    {
        private SHA256 sha256 = SHA256.Create();
        private MD5 md5 = MD5.Create();
        private byte[] data;

        [Params(1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }
}