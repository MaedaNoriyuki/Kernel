﻿using System;
using System.Diagnostics;

namespace App
{
    class Data
    {
        public DateTime time { get; set; }
        public double date01 { get; set; }
        public double date02 { get; set; }
        public double date03 { get; set; }
        public double date04 { get; set; }
        public double date05 { get; set; }
        public double date06 { get; set; }
        public double date07 { get; set; }
        public double date08 { get; set; }
        public double date09 { get; set; }
        public double date10 { get; set; }
    }
    class Sample
    {
        static void Main()
        {
            //1日分のデータを作成
            Console.WriteLine("データの作成中");
            List<Data> data = new List<Data>();
            var dataDict = new Dictionary<DateTime,Data>();
            var sortList = new SortedList<DateTime,Data>();
            var sortDict = new SortedDictionary<DateTime,Data>();
            var startTime = new DateTime(2021,12,24,0,0,0);       //開始時間
            Random rad = new Random();
            for(var i=0;i<60*60*24*10;i++)
            {
                data.Add(new Data(){
                    time=startTime,
                    date01=rad.NextDouble(),
                    date02=rad.NextDouble(),
                    date03=rad.NextDouble(),
                    date04=rad.NextDouble(),
                    date05=rad.NextDouble(),
                    date06=rad.NextDouble(),
                    date07=rad.NextDouble(),
                    date08=rad.NextDouble(),
                    date09=rad.NextDouble(),
                    date10=rad.NextDouble(),
                });
                dataDict.Add(startTime,new Data(){
                    date01=rad.NextDouble(),
                    date02=rad.NextDouble(),
                    date03=rad.NextDouble(),
                    date04=rad.NextDouble(),
                    date05=rad.NextDouble(),
                    date06=rad.NextDouble(),
                    date07=rad.NextDouble(),
                    date08=rad.NextDouble(),
                    date09=rad.NextDouble(),
                    date10=rad.NextDouble(),
                });
                sortList.Add(startTime,new Data(){
                    date01=rad.NextDouble(),
                    date02=rad.NextDouble(),
                    date03=rad.NextDouble(),
                    date04=rad.NextDouble(),
                    date05=rad.NextDouble(),
                    date06=rad.NextDouble(),
                    date07=rad.NextDouble(),
                    date08=rad.NextDouble(),
                    date09=rad.NextDouble(),
                    date10=rad.NextDouble(),
                });
                sortDict.Add(startTime,new Data(){
                    date01=rad.NextDouble(),
                    date02=rad.NextDouble(),
                    date03=rad.NextDouble(),
                    date04=rad.NextDouble(),
                    date05=rad.NextDouble(),
                    date06=rad.NextDouble(),
                    date07=rad.NextDouble(),
                    date08=rad.NextDouble(),
                    date09=rad.NextDouble(),
                    date10=rad.NextDouble(),
                });
                startTime = startTime.AddSeconds(1);
            }

            Console.WriteLine("抽出する日時を決定");
            List<DateTime> ansList = new List<DateTime>();
            for(var i=0;i<10000;i++)
            {

                ansList.Add(new DateTime(2021,12,24,rad.Next(0,23),rad.Next(0,59),rad.Next(0,59)));
            }

            Console.WriteLine("索引の実施");
            double total = 0;
            var sp = new System.Diagnostics.Stopwatch();
            sp.Start();
            for(var i=0;i<10000;i++)
            {
                var value = data.FirstOrDefault(n=>n.time == ansList[i]);
                total += value == null ? 0 : (double)(value.date01);
            }
            sp.Stop();
            Console.WriteLine(total);
            
            Console.WriteLine($"List型{sp.Elapsed.Seconds}[s]{sp.Elapsed.Milliseconds}[ms]");
            sp.Restart();
            for(var i=0;i<10000;i++)
            {
                var value = dataDict.FirstOrDefault(n=>n.Key == ansList[i]);
                total += value.Value == null ? 0 : (double)(value.Value.date01);
            }
            sp.Stop();
            Console.WriteLine(total);
            
            Console.WriteLine($"Dict型{sp.Elapsed.Seconds}[s]{sp.Elapsed.Milliseconds}[ms]");

            sp.Restart();
            for(var i=0;i<10000;i++)
            {
                //keyが無い場合には、例外発生
                total +=  (double)(dataDict[ansList[i]] == null ? 0: dataDict[ansList[i]].date01);
            }
            sp.Stop();
            Console.WriteLine(total);
            Console.WriteLine($"Dict型{sp.Elapsed.Seconds}[s]{sp.Elapsed.Milliseconds}[ms]");

            sp.Restart();
            for(var i=0;i<10000;i++)
            {
                total +=  (double)(sortList[ansList[i]] == null ? 0: dataDict[ansList[i]].date01);
            }
            sp.Stop();
            Console.WriteLine(total);
            Console.WriteLine($"sorttedList型{sp.Elapsed.Seconds}[s]{sp.Elapsed.Milliseconds}[ms]");

            sp.Restart();
            for(var i=0;i<10000;i++)
            {
                total +=  (double)(sortDict[ansList[i]] == null ? 0: dataDict[ansList[i]].date01);
            }
            sp.Stop();
            Console.WriteLine(total);
            Console.WriteLine($"sorttedDict型{sp.Elapsed.Seconds}[s]{sp.Elapsed.Milliseconds}[ms]");


            Console.ReadLine();
        }
    }
}