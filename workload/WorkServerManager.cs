using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace workload
{
    class WorkServerManager
    {
        private readonly IList<WorkServer> servers;
        public WorkServerManager(int serverCount) {
            servers = new List<WorkServer>(serverCount);
            for (int i = 0; i < serverCount; i++)
                servers.Add(new WorkServer());
        }
       
        /// <summary>
        /// Запуск менеджера 
        /// </summary>
        public void Run() {
            while (true) {
                var str =Console.ReadLine();
                if ("exit".Equals(str))
                    return;

                var durables = str.Split(",");
                // Идем по порядку по каждому заданию, 
                foreach (var durable in durables) {
                    int res;
                    if (int.TryParse(durable, out res))
                        this.AddNewTask(new WorkTask(res));
                }
                PrintServerWorkLoads();
            }
        }

        private void PrintServerWorkLoads()
        {
            int i = 0;
            foreach (var server in servers) {
                Console.WriteLine($"{ ++i }: " + server.ToString());
            }
        }

        /// <summary>
        /// ищем самый разгруженный сервер и добавялем в него новое задание 
        /// </summary>
        /// <param name="workTask"></param>
        private void AddNewTask(WorkTask workTask)
        {
            var workloadMin = servers.Min(x => x.WorkLoad);
            var server = servers.Where(s => s.WorkLoad == workloadMin).First();
            server.Enqueue(workTask);
        }
    }
}
