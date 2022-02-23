using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace DictionarySuperComplex
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var modelList = new List<BaseService>();

            var students1 = new Dictionary<Guid, int>()
            {
                {Guid.NewGuid(),1 },
                {Guid.NewGuid(),2 },
                {Guid.NewGuid(),3 }
            };

            var students2 = new Dictionary<Guid, int>()
            {
                {Guid.NewGuid(),4 },
                {Guid.NewGuid(),5 },
                {Guid.NewGuid(),6 }
            };

            var students3 = new Dictionary<Guid, int>()
            {
                {Guid.NewGuid(),7 },
                {Guid.NewGuid(),8 },
                {Guid.NewGuid(),9 }
            };

            var model1 = new BaseService();
            var model2 = new BaseService();
            var model3 = new BaseService();

            model1.DirectionCost = students1;
            model2.DirectionCost = students2;
            model3.DirectionCost = students3;

            model1.ServiceType = ServiceType.Move;
            model2.ServiceType = ServiceType.Luggage;
            model3.ServiceType = ServiceType.Other;

            modelList.Add(model1);
            modelList.Add(model2);
            modelList.Add(model3);

            //var results = modelList.Select(x => x.DirectionCost.Values); // здесь у тебя получится список нодов

            //var results = modelList.SelectMany(x => x.DirectionCost.Values); //заходим в результат каждого нода сразу, минуя сам нод

            //var results = modelList.Select(x => x.DirectionCost.Values.Where(egw=>egw>2)); // выведет значения каждого нода, который больше 2

            //var results = modelList.Where(egw => egw.DirectionCost.Values.(e => e> 2));


            
            //Not enough:
            var final0 = modelList
                .Select(x =>
                x.DirectionCost.FirstOrDefault(el => el.Value == x.DirectionCost.Values.Min()));

            foreach (var element in final0)
            {
                var jsonString = JsonConvert.SerializeObject(element);

                Console.WriteLine(jsonString);
            }

            Console.WriteLine();


            //Ok1:
            var final1 = modelList.Select(
                o => new {
                    serviceType = o.ServiceType,directionCost = o.DirectionCost
                        .OrderBy(d => d.Value)
                        .First()
                }
            );

            foreach (var element in final1)
            {
                var jsonString = JsonConvert.SerializeObject(element);

                Console.WriteLine(jsonString);
            }

            Console.WriteLine();

            //Ok2:
            var final2 = modelList.Select(
                o => new
                {
                    serviceType = o.ServiceType,
                    directionCost = o.DirectionCost
                        .FirstOrDefault(el => el.Value == o.DirectionCost.Values.Min())
                }
            );

            foreach (var element in final2)
            {
                var jsonString = JsonConvert.SerializeObject(element);

                Console.WriteLine(jsonString);
            }
        }
    }
    
    public class BaseService 
    {
        public ServiceType ServiceType { get; set; }
        public Dictionary<Guid, int> DirectionCost { get; set; }
    }

    public enum ServiceType
    {
        Move = 0,
        Store = 1,
        Other = 2,
        Luggage = 3
    }
}
