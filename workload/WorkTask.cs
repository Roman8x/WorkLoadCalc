using System;
using System.Collections.Generic;
using System.Text;

namespace workload
{
    /// <summary>
    /// Задача 
    /// </summary>
    public class WorkTask //
    {
        public WorkTask(int duration) {
            Duration = duration;
        }
        /// <summary>
        /// Длительность задачи
        /// </summary>
        public int Duration { get; private  set; }
    }
}
