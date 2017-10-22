using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class Watcher
    {
        private DateTime _startTime;
        private DateTime _endTime;

        public long Milliseconds => _endTime.Subtract(_startTime).Milliseconds;

        public void Start()
        {
            _startTime = DateTime.Now;
        }

        public void End()
        {
            _endTime = DateTime.Now;
        }
    }
}
