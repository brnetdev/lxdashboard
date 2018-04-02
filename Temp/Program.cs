using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceContracts = Assembly.Load("LxDashboard.BE.Contracts").GetTypes().Where(t=> t.IsInterface && t.GetCustomAttributes().Any(a=>a is ServiceContractAttribute));
            serviceContracts.ToList().ForEach(s => 
            {
                var attr = (ServiceContractAttribute)s.GetCustomAttribute(typeof(ServiceContractAttribute));
                Console.WriteLine($"Name: {attr.Name}");
                Console.WriteLine($"Config name: {attr.ConfigurationName}");
                Console.WriteLine($"Interface: {s.Name}\n");

                var methods = s.GetMethods();
                foreach(var method in methods)
                {
                    Console.Write($"{method.ReturnType.ToString()} {method.Name}(");
                    //Console.WriteLine(method.Name);
                    var strParams = string.Empty;
                    method.GetParameters().ToList().ForEach(p=>
                    {
                        strParams += $"{p.ParameterType.ToString()} {p.Name}, ";
                    });
                    strParams = strParams.Remove(strParams.Length - 2);
                    Console.Write(strParams);
                    Console.WriteLine(")");

                    var strArgs = string.Empty;
                    method.GetParameters().ToList().ForEach(p =>
                    {
                        strArgs += $"{p.Name}, ";
                    });
                    strArgs = strArgs.Remove(strArgs.Length - 2);

                    if (method.ReturnType == typeof(void))
                    {

                        Console.WriteLine($"Channel.{method.Name}({strArgs})");
                    }

                }
                
            });

            Console.ReadLine();

        }
    }
}
