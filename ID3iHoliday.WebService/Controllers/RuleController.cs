using ID3iCore;
using ID3iHoliday.Core.Models;
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;
using ID3iHoliday.WebService.Models.Light;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix("Api/Rules")]
    public class RuleController : ApiController
    {
        private RuleModelLight GetRule(ExpressionElement expression, Dictionary<Langue, string> names, RuleType type, bool isEnable)
        {
            return new RuleModelLight()
            {
                Expression = expression.Expression,
                Type = type.ToString(),
                Name = string.Join(" | ", names.Select(z => $"{z.Key.Description()} : {z.Value}")),
                IsEnable = isEnable
            };
        }
        private RuleModelLight GetStateRule(Country country, Rule rule, RuleType ruleType, bool isEnable)
        {
            var names = rule.Names.IsEmpty() ? country.Rules.FirstOrDefault(x => x.Key == rule.Key).Names : rule.Names;
            var type = ruleType == RuleType.All ? country.Rules.FirstOrDefault(x => x.Key == rule.Key).Type : ruleType;

            if (rule.Overrides == Overrides.None)
                return GetRule(rule.Expression, rule.Names, type, isEnable);
            else if (rule.Overrides.HasFlag(Overrides.Expression))
                return GetRule(rule.Expression, names, type, isEnable);
            else if (rule.Overrides.HasFlag(Overrides.IsEnable))
                return GetRule(country.Rules.FirstOrDefault(x => x.Key == rule.Key).Expression, country.Rules.FirstOrDefault(x => x.Key == rule.Key).Names, type, isEnable);
            else
                return GetRule(country.Rules.FirstOrDefault(x => x.Key == rule.Key).Expression, country.Rules.FirstOrDefault(x => x.Key == rule.Key).Names, type, isEnable);
        }
        private RuleModelLight GetRegionRule(Country country, State state, Rule rule)
        {
            if (rule.Overrides == Overrides.None)
                return GetRule(rule.Expression, rule.Names, rule.Type, rule.IsEnable);
            else if (rule.Overrides.HasFlag(Overrides.Expression))
                return GetStateRule(country, rule, rule.Type, rule.IsEnable);
            else if (rule.Overrides.HasFlag(Overrides.IsEnable))
                return GetStateRule(country, state.Rules.FirstOrDefault(x => x.Key == rule.Key), rule.Type, rule.IsEnable);
            else
                return GetStateRule(country, state.Rules.FirstOrDefault(x => x.Key == rule.Key), rule.Type, rule.IsEnable);
        }

        private CountryModelLight Get(Country country)
        {
            CountryModelLight countryModel = new CountryModelLight() { Name = country.DefaultName };

            if (country.Rules.IsNotNullAndNotEmpty())
                countryModel.Rules = new List<RuleModelLight>();
            country.Rules.ForEach(y => { countryModel.Rules.Add(GetRule(y.Expression, y.Names, y.Type, y.IsEnable)); });

            if (country.States.IsNotNullAndNotEmpty())
                countryModel.States = new List<StateModelLight>();
            country.States?.ForEach(y =>
            {
                StateModelLight state = new StateModelLight() { Name = y.DefaultName };

                if (y.Rules.IsNotNullAndNotEmpty())
                    state.Rules = new List<RuleModelLight>();
                y.Rules.ForEach(z => { state.Rules.Add(GetStateRule(country, z, z.Type, z.IsEnable)); });

                if (y.Regions.IsNotNullAndNotEmpty())
                    state.Regions = new List<RegionModelLight>();
                y.Regions?.ForEach(z =>
                {
                    RegionModelLight region = new RegionModelLight() { Name = z.DefaultName };

                    if (z.Rules.IsNotNullAndNotEmpty())
                        region.Rules = new List<RuleModelLight>();
                    z.Rules.ForEach(aa => { region.Rules.Add(GetRegionRule(country, y, aa)); });
                    state.Regions.Add(region);
                });
                countryModel.States.Add(state);
            });
            return countryModel;
        }

        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var lst = new List<CountryModelLight>();
            HolidaySystem.Instance.CountriesAvailable.Where(x => x.Code != null).ToList().ForEach(x =>
            {
                lst.Add(Get(x));
            });
            return Ok(lst);
        }

        [HttpGet, Route("{code}")]
        public IHttpActionResult Get(string code)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.FirstOrDefault(x => x.Code == code);
            if (result == null)
                return NotFound();
            return Ok(Get(result));
        }
    }
}
