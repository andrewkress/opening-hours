using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpeningHours.Models {


    public class OpenHour {
        public List<Monday> monday { get; set; }
        public List<Tuesday> tuesday { get; set; }
        public List<Wednesday> wednesday { get; set; }
        public List<Thursday> thursday { get; set; }
        public List<Friday> friday { get; set; }
        public List<Saturday> saturday { get; set; }
        public List<Sunday> sunday { get; set; }
    }

    public interface IDayConverter {
        public Day GetDay();
    }

    public class Monday : IDayConverter {
        public string type { get; set; }
        public int value { get; set; }

        public Day GetDay()
            => new Day() {
                Name = "Monday",
                Type = type,
                Value = value
            };
    }

    public class Tuesday : IDayConverter {
        public string type { get; set; }
        public int value { get; set; }

        public Day GetDay()
            => new Day() {
                Name = "Tuesday",
                Type = type,
                Value = value
        };
    }

    public class Wednesday : IDayConverter {
        public string type { get; set; }
        public int value { get; set; }

        public Day GetDay()
            => new Day() {
                Name = "Wednesday",
                Type = type,
                Value = value
        };
    }

    public class Thursday : IDayConverter {
        public string type { get; set; }
        public int value { get; set; }

        public Day GetDay()
            => new Day() {
                Name = "Thursday",
                Type = type,
                Value = value
        };
    }

    public class Friday : IDayConverter {
        public string type { get; set; }
        public int value { get; set; }

        public Day GetDay()
            => new Day() {
                Name = "Friday",
                Type = type,
                Value = value
        };
    }

    public class Saturday : IDayConverter {
        public string type { get; set; }
        public int value { get; set; }

        public Day GetDay()
            => new Day() {
                Name = "Saturday",
                Type = type,
                Value = value
        };
}

    public class Sunday : IDayConverter {
        public string type { get; set; }
        public int value { get; set; }

        public Day GetDay()
            => new Day() {
                Name = "Sunday",
                Type = type,
                Value = value
        };
}


}
