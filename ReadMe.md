| Projet | Statut |
| --- | --- |
| ID3iCore | [![Build status](https://ci.appveyor.com/api/projects/status/dsd0hvd632my2y8e?svg=true)](https://ci.appveyor.com/project/Shaenn/id3icore-8qh9v) |
| ID3iDate | [![Build status](https://ci.appveyor.com/api/projects/status/08am5ww7xiy1cm5a?svg=true)](https://ci.appveyor.com/project/Shaenn/id3idate-k8k5t) |
| ID3iRegex | [![Build status](https://ci.appveyor.com/api/projects/status/m1bdir11jmhd29yc?svg=true)](https://ci.appveyor.com/project/Shaenn/id3iregex-7x0ek) |
| ID3iHoliday | [![Build status](https://ci.appveyor.com/api/projects/status/n4vrppmsghwxvbg7?svg=true)](https://ci.appveyor.com/project/Shaenn/id3iholiday-d4l66) |

### Version
---
[![GitHub Release](https://img.shields.io/github/release/Shaenn/ID3iHoliday.svg?style=flat-square)](https://github.com/Shaenn/ID3iHoliday/releases)

# ID3iHoliday

ID3iHoliday is a Holiday Framework calculation for .Net.

### Assemblies
* ID3iHoliday.Core contains base class for building expression and parsing. 
* ID3iHoliday.Syntax contains expressions blocs, expressions composer and parsers for theses expressions composer.
* ID3iHoliday.Models contains class for objects, such as Country, Region, State, Rule, LongWeekEnd and SpecificDay.
* ID3iHoliday.Countries contains class for all country, states and regions whith all rules declarations.
* ID3iHoliday.Engine contains the "HolidaySystem" to get specific days.
* ID3iHoliday.Engine.Standard Is a Singleton for "HolidaySystem" and also register all countries.
* ID3iHoliday.Engine.Modularity is a Prism module who register the "HolidaySystem" in the UnityContainer.
* ID3iHoliday.Countries.Modularity is a project who contains all country's module declaration and registration in "HolidaySystem" through the UnityContainer.

### Types of Holidays
Currently the following type with their meaning are supported 

| Projet | Statut |
| --- | --- |
| Public | Public holiday |
| Bank | Bank holiday, banks and offices are closed |
| School | School holiday, schools are closed |
| Optional | Majority of people take a day offices |
| Observance | Optional festivity, no paid day off |

### Grammar
In order to construct specific day a grammar is available. 

#### Substitute a holiday if date falls on a certain weekday
Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/Substitute.xhtml

#### Observe the holiday as well as on a substitute day, if date falls on a certain weekday
Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/Observe.xhtml

#### Move to different weekday if date falls on a certain weekday
Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/Move.xhtml

#### Fixed day for a given year
Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/Specific.xhtml

#### Fixed day in a year
Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/Fix.xhtml

#### Movable Date based on Easter
Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/Catholic.xhtml

Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/Orthodox.xhtml

#### Move to different weekday from a given fixed Date
Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/Movable.xhtml

#### Move to a different weekday from a changed fixed Date
Grammar : https://shaenn.github.io/ID3iHoliday/Grammar/MovableFromMovable.xhtml

#### Full diagram
https://shaenn.github.io/ID3iHoliday/Grammar/Grammar.xhtml 

---
### Example :
#### Get All supported countries
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

var countriesAvailable = HolidaySystem.Instance.CountriesAvailable;
foreach (Country country in countriesAvailable)
{
	//Do something...
}
```

#### Get SpecificDays for a country
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

var specificDays = HolidaySystem.Instance.All(2018, "FR", RuleType.All);
foreach (SpecificDay day in specificDays)
{
	//Do something...
}
```

#### Get SpecificDays for a country between two dates
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

var specificDays = HolidaySystem.Instance.Between(On.January.The1st, On.June.The30th,"FR", RuleType.All);
foreach (SpecificDay day in specificDays)
{
	//Do something...
}
```

#### Check if date is Specific day for a country
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

var specificDay = HolidaySystem.Instance.Single(On.January.The1st,"FR", RuleType.All);
if (specificDay != null)
	//Do something...
```

#### Get Long week ends for a country
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

var longWeekEnds = HolidaySystem.Instance.LongWeekEnds(2018,"FR");
foreach (LongWeekEnd longWeekEnd in longWeekEnds)
{
    //Do something...
}
```

#### Get SpecificDays for a country and state
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

var specificDays = HolidaySystem.Instance.All(2018, "FR", "MQ", RuleType.All);
foreach (SpecificDay day in specificDays)
{
	//Do something...
}
```

#### Get SpecificDays for a country and state between two dates
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

specificDays = HolidaySystem.Instance.Between(On.January.The1st, On.June.The30th, "FR", "MQ", RuleType.All);
foreach (SpecificDay day in specificDays)
{
	//Do something...
}
```

#### Check if date is Specific day for a country and state
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

var specificDay = HolidaySystem.Instance.Single(On.January.The1st,"FR", "MQ", RuleType.All);
if (specificDay != null)
	//Do something...
```

#### Get Long week ends for a country and state
```cs
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;

var longWeekEnds = HolidaySystem.Instance.LongWeekEnds(2018, "FR", "MQ");
foreach (LongWeekEnd longWeekEnd in longWeekEnds)
{
    //Do something...
}
```
