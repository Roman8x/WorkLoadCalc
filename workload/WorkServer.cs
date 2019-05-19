using System;
using System.Collections.Generic;
using System.Text;

namespace workload
{
    /// <summary>
    /// Сервер для распределения нагрузки
    /// </summary>
    class WorkServer
    {
        /// <summary>
        /// Очередь задач
        /// </summary>
        private readonly Queue<WorkTask> queue = new Queue<WorkTask>();

        /// <summary>
        /// Общая нагрузка на сервер
        /// </summary>
        private int workLoad = 0;

        /// <summary>
        /// добавляет элемент в конец очереди
        /// </summary>
        public void Enqueue(WorkTask task) {
            workLoad += task.Duration;
            queue.Enqueue(task);
        }

        /// <summary>
        /// Общая нагрузка  на сервер
        /// </summary>
        public int WorkLoad { get { return workLoad; }}

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var task in queue) {
                sb.Append("|");
                sb.Append(new string ('_' , task.Duration));
            }
            sb.Append("|");
            return sb.ToString();
        }
    }
}