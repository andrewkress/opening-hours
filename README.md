# Opening Hours Web API

### To Install and Run

- git clone https://github.com/andrewkress/opening-hours.git
- cd opening-hours
- dotnet restore
- dotnet build
- dotnet run --project OpeningHours\OpeningHours.csproj
- post json data in body to:
  - https://localhost:5001/OpenHour
  - http://localhost:5000/OpenHour

### Assumptions and other thoughts

I assumed that the data is passed in a sorted order.  If this is not the case, the hours will not properly print.  If necessary an .OrderBy statement can be added when converting from the json format to the object format.

I would prefer the json to be formatted a little differently.  Instead of having the format as:
```
{
  "monday" : [
    {
      "type" : "open",
      "value" : 32400
    },
    {
      "type" : "close",
      "value" : 72000
    }
  ],
....
}
```

I would format it having a day attribute to facilitate easier json deserialization and being able to create the lists I have with less converting:

```
{
  "day" : "monday",
  "hours" :
  [
    {
      "type" : "open",
      "value" : 32400
    },
    {
      "type" : "close",
      "value" : 72000
    }
  ],
....
}
```

which would allow fewer classes to deserialize simply such as:
```
public class OpenHour {
    public string day { get; set; }
    public List<Hour> hours { get; set; }
}

public class Hour {
    public string type { get; set; }
    public int value { get; set; }
}
```