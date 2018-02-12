using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; 

namespace SingletonPatternChecking
{
    class DummyMapperQualifierHelper
    {
        static object loc = new object();
        public static string BillMapper;

        private static List<string> MapperQualifiers = new List<string>();

        private static readonly DummyMapperQualifierHelper mqh = new DummyMapperQualifierHelper();

        private DummyMapperQualifierHelper() { }

        public static DummyMapperQualifierHelper GetInstance(string name,object loc)
        {
            //var billMapperService = DependencyResolver.Current.GetService<IBillMapperService>();
            lock (DummyMapperQualifierHelper.loc)
            {
                BillMapper = name;
                //var billMapper = billMapperService.GetBillMapperByMapperName(BillMapper);
                MapperQualifiers = new List<string> { name + "qualifierList" };
                
                Console.WriteLine("Bill Mapper Name {0} Thread Name : {1} Qualifire{2}",BillMapper,name, MapperQualifiers[0]);
            }
                Thread.Sleep(10000);
            Console.WriteLine("After lock and sleep assigned value in this class will change and reflect only last value but not passed ");
            Console.WriteLine("Bill Mapper Name {0}|| Thread Name : {1} || Qualifire {2}", BillMapper, name, MapperQualifiers[0]);
            return mqh;
            //}
        }

    }
}
