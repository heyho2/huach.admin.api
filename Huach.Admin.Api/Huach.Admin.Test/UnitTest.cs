using System;
using Huach.Framework.Redis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Huach.Admin.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ModelsTool modelsInfo = new ModelsTool();
        }
        [TestMethod]
        public void TestRedis()
        {
            using (var service = new RedisStringService())
            {
                service.Set("RedisStringService_key1", "RedisStringService_value1");
                service.Get("RedisStringService_key1");
            }
        }
    }
}
