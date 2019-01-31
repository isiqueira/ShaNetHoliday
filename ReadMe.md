| Projet | Statut |
| --- | --- |
| ShaNetCore | [![Build status](https://ci.appveyor.com/api/projects/status/4no2w45carvhi436?svg=true)](https://ci.appveyor.com/project/Shaenn/shanetcore) |
| ShaNetDate | [![Build status](https://ci.appveyor.com/api/projects/status/ux2vrytglctf1de8?svg=true)](https://ci.appveyor.com/project/Shaenn/shanetdate) [![Tests Status](https://img.shields.io/appveyor/tests/Shaenn/shanetdate.svg?logo=appveyor)](https://ci.appveyor.com/project/Shaenn/shanetdate/build/tests) |
| ShaNetRegex | [![Build status](https://ci.appveyor.com/api/projects/status/rlfeb9694fp2jdpm?svg=true)](https://ci.appveyor.com/project/Shaenn/shanetregex) |
| ShaNetDiagnostics | [![Build status](https://ci.appveyor.com/api/projects/status/3ybckfrgspx2li4g?svg=true)](https://ci.appveyor.com/project/Shaenn/shanetdiagnostics) [![Tests Status](https://img.shields.io/appveyor/tests/Shaenn/shanetdiagnostics.svg?logo=appveyor)](https://ci.appveyor.com/project/Shaenn/shanetdiagnostics/build/tests)|
| ShaNetHoliday | [![Build status](https://ci.appveyor.com/api/projects/status/mmlonfnqakshn7s2?svg=true)](https://ci.appveyor.com/project/Shaenn/shanetholiday) [![Tests Status](https://img.shields.io/appveyor/tests/Shaenn/shanetholiday.svg?logo=appveyor)](https://ci.appveyor.com/project/Shaenn/shanetholiday/build/tests) |

### Version
---
[![GitHub Release](https://img.shields.io/github/release/Shaenn/ShaNetHoliday.svg?style=flat-square)](https://github.com/Shaenn/ShaNetHoliday/releases)

### NuGet
---
[![NuGet](https://img.shields.io/nuget/v/ShaNetHoliday.Engine.Standard.svg)](https://www.nuget.org/packages/ShaNetHoliday.Engine.Standard/)
[![NuGet](https://img.shields.io/nuget/dt/ShaNetHoliday.Engine.Standard.svg)](https://www.nuget.org/packages/ShaNetHoliday.Engine.Standard/)

# ShaNetHoliday

ShaNetHoliday is a Holiday Framework calculation for .Net.

### Assemblies
* ShaNetHoliday.Core contains base class for building expression and parsing. 
* ShaNetHoliday.Syntax contains expressions blocs, expressions composer and parsers for theses expressions composer.
* ShaNetHoliday.Models contains class for objects, such as Country, Region, State, Rule, LongWeekEnd and SpecificDay.
* ShaNetHoliday.Countries contains class for all country, states and regions whith all rules declarations.
* ShaNetHoliday.Engine contains the "HolidaySystem" to get specific days.
* ShaNetHoliday.Engine.Standard Is a Singleton for "HolidaySystem" and also register all countries.
* ShaNetHoliday.Engine.Modularity is a Prism module who register the "HolidaySystem" in the UnityContainer.
* ShaNetHoliday.Countries.Modularity is a project who contains all country's module declaration and registration in "HolidaySystem" through the UnityContainer.

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

#### Substitute a holiday if date falls on a certain weekday.
#### Observe the holiday as well as on a substitute day, if date falls on a certain weekday.
#### Move to different weekday if date falls on a certain weekday.
#### Fixed day for a given year.
#### Fixed day in a year.
#### Movable Date based on Easter.
#### Move to different weekday from a given fixed Date.
#### Move to a different weekday from a changed fixed Date.
### Full diagram
https://shaenn.github.io/ShaNetHoliday/Grammar/Grammar.xhtml 

---
### Example :
#### Get All supported countries
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

var countriesAvailable = HolidaySystem.Instance.CountriesAvailable;
foreach (Country country in countriesAvailable)
{
	//Do something...
}
```

#### Get SpecificDays for a country
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

var specificDays = HolidaySystem.Instance.All(2018, "FR", RuleType.All);
foreach (SpecificDay day in specificDays)
{
	//Do something...
}
```

#### Get SpecificDays for a country between two dates
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

var specificDays = HolidaySystem.Instance.Between(On.January.The1st, On.June.The30th,"FR", RuleType.All);
foreach (SpecificDay day in specificDays)
{
	//Do something...
}
```

#### Check if date is Specific day for a country
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

var specificDay = HolidaySystem.Instance.Single(On.January.The1st,"FR", RuleType.All);
if (specificDay != null)
	//Do something...
```

#### Get Long week ends for a country
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

var longWeekEnds = HolidaySystem.Instance.LongWeekEnds(2018,"FR");
foreach (LongWeekEnd longWeekEnd in longWeekEnds)
{
    //Do something...
}
```

#### Get SpecificDays for a country and state
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

var specificDays = HolidaySystem.Instance.All(2018, "FR", "MQ", RuleType.All);
foreach (SpecificDay day in specificDays)
{
	//Do something...
}
```

#### Get SpecificDays for a country and state between two dates
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

specificDays = HolidaySystem.Instance.Between(On.January.The1st, On.June.The30th, "FR", "MQ", RuleType.All);
foreach (SpecificDay day in specificDays)
{
	//Do something...
}
```

#### Check if date is Specific day for a country and state
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

var specificDay = HolidaySystem.Instance.Single(On.January.The1st,"FR", "MQ", RuleType.All);
if (specificDay != null)
	//Do something...
```

#### Get Long week ends for a country and state
```cs
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

var longWeekEnds = HolidaySystem.Instance.LongWeekEnds(2018, "FR", "MQ");
foreach (LongWeekEnd longWeekEnd in longWeekEnds)
{
    //Do something...
}
```
