using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkStreamliner
{
    public interface IDateProvider
    {
        DateTime GetNow();
    }

    public class DateProvider : IDateProvider
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
