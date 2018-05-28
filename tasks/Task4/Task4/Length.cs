using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Length
    {
        public Length(decimal duration, string unit)
        {
            Duration = duration;
            Unit = unit;
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        public decimal Duration { get; }

        /// <summary>
        /// Amount's currency.
        /// </summary>
        public string Unit { get; }
    }
}
