using ShaNetCore.Either;
using ShaNetHoliday.WebService.Models;
using ShaNetHoliday.WebService.Models.Light;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static ShaNetHttpClient.Dynamic.Conv;

namespace ShaNetHoliday.WebService.Client
{
    public partial class HolidayWrapper
    {
        public dynamic DynamicClient { get; set; }

        public HolidayWrapper()
        {
            Configuration.HolidayConfig.CheckConsistency();

            DynamicClient = new ShaNetHttpClient.Dynamic.Client( Configuration.HolidayConfig.Conf.BaseApiUrl );
        }

        public Either<HttpStatusCode, List<CountryModel>> Countries()
            => As<HttpStatusCode, List<CountryModel>>( DynamicClient.Countries.Get().Result );

        public Either<HttpStatusCode, CountryModel> Country( string code )
            => As<HttpStatusCode, CountryModel>( DynamicClient.Countries.Get( code ).Result );

        public Either<HttpStatusCode, List<SpecificDayModel>> CountryDays( string code, int year, string rule, string calendar )
            => As<HttpStatusCode, List<SpecificDayModel>>( DynamicClient.Countries.Resource( code ).Days.Query( new { year, rule, calendar } ).Get().Result );

        public Either<HttpStatusCode, List<StateModel>> States( string code )
            => As<HttpStatusCode, List<StateModel>>( DynamicClient.Countries.Resource( code ).States.Get().Result );

        public Either<HttpStatusCode, StateModel> State( string code )
            => As<HttpStatusCode, StateModel>( DynamicClient.States.Resource( code ).Get().Result );

        public Either<HttpStatusCode, List<RegionModel>> Regions( string code )
            => As<HttpStatusCode, List<RegionModel>>( DynamicClient.States.Resource( code ).Regions.Get().Result );

        public Either<HttpStatusCode, List<SpecificDayModel>> StateDays( string code, int year, string rule, string calendar )
            => As<HttpStatusCode, List<SpecificDayModel>>( DynamicClient.States.Resource( code ).Days.Query( new { year, rule, calendar } ).Get().Result );

        public Either<HttpStatusCode, RegionModel> Region( string code )
            => As<HttpStatusCode, RegionModel>( DynamicClient.Regions.Resource( code ).Get().Result );

        public Either<HttpStatusCode, List<SpecificDayModel>> RegionDays( string code, int year, string rule, string calendar )
            => As<HttpStatusCode, List<SpecificDayModel>>( DynamicClient.Regions.Resource( code ).Days.Query( new { year, rule, calendar } ).Get().Result );

        public Either<HttpStatusCode, List<SpecificDayModel>> Days( int year, string ccode, string scode, string rcode, string rule, string calendar )
            => As<HttpStatusCode, List<SpecificDayModel>>( DynamicClient.Days.Resource( year ).Query( new { ccode, scode, rcode, rule, calendar } ).Get().Result );

        public Either<HttpStatusCode, List<LongWeekEndModel>> LongWeekEnds( int year, string ccode, string scode, string rcode, string rule, string calendar )
            => As<HttpStatusCode, List<LongWeekEndModel>>( DynamicClient.LongWeekEnds.Resource( year ).Query( new { ccode, scode, rcode, rule, calendar } ).Get().Result );

        public Either<HttpStatusCode, List<RuleModelLight>> Rules
            => As<HttpStatusCode, List<RuleModelLight>>( DynamicClient.Rules.Get().Result );

        public Either<HttpStatusCode, CountryModelLight> CountryRules( string code )
            => As<HttpStatusCode, CountryModelLight>( DynamicClient.Rules.Resource( code ).Get().Result );
    }

    public partial class HolidayWrapper
    {
        public async Task<Either<HttpStatusCode, List<CountryModel>>> CountriesAsync()
            => As<HttpStatusCode, List<CountryModel>>( await DynamicClient.Countries.Get() );

        public async Task<Either<HttpStatusCode, CountryModel>> CountryAsync( string code )
          => As<HttpStatusCode, CountryModel>( await DynamicClient.Countries.Get( code ) );

        public async Task<Either<HttpStatusCode, List<SpecificDayModel>>> CountryDaysAsync( string code, int year, string rule, string calendar )
            => As<HttpStatusCode, List<SpecificDayModel>>( await DynamicClient.Countries.Resource( code ).Days.Query( new { year, rule, calendar } ).Get() );

        public async Task<Either<HttpStatusCode, List<StateModel>>> StatesAsync( string code )
            => As<HttpStatusCode, List<StateModel>>( await DynamicClient.Countries.Resource( code ).States.Get() );

        public async Task<Either<HttpStatusCode, StateModel>> StateAsync( string code )
            => As<HttpStatusCode, StateModel>( await DynamicClient.States.Resource( code ).Get() );

        public async Task<Either<HttpStatusCode, List<RegionModel>>> RegionsAsync( string code )
            => As<HttpStatusCode, List<RegionModel>>( await DynamicClient.States.Resource( code ).Regions.Get() );

        public async Task<Either<HttpStatusCode, List<SpecificDayModel>>> StateDaysAsync( string code, int year, string rule, string calendar )
            => As<HttpStatusCode, List<SpecificDayModel>>( await DynamicClient.States.Resource( code ).Days.Query( new { year, rule, calendar } ).Get() );

        public async Task<Either<HttpStatusCode, RegionModel>> RegionAsync( string code )
            => As<HttpStatusCode, RegionModel>( await DynamicClient.Regions.Resource( code ).Get() );

        public async Task<Either<HttpStatusCode, List<SpecificDayModel>>> RegionDaysAsync( string code, int year, string rule, string calendar )
            => As<HttpStatusCode, List<SpecificDayModel>>( await DynamicClient.Regions.Resource( code ).Days.Query( new { year, rule, calendar } ).Get() );

        public async Task<Either<HttpStatusCode, List<SpecificDayModel>>> DaysAsync( int year, string ccode, string scode, string rcode, string rule, string calendar )
            => As<HttpStatusCode, List<SpecificDayModel>>( await DynamicClient.Days.Resource( year ).Query( new { ccode, scode, rcode, rule, calendar } ).Get() );

        public async Task<Either<HttpStatusCode, List<LongWeekEndModel>>> LongWeekEndsAsync( int year, string ccode, string scode, string rcode, string rule, string calendar )
            => As<HttpStatusCode, List<LongWeekEndModel>>( await DynamicClient.LongWeekEnds.Resource( year ).Query( new { ccode, scode, rcode, rule, calendar } ).Get() );

        public async Task<Either<HttpStatusCode, List<RuleModelLight>>> RulesAsync()
            => As<HttpStatusCode, List<RuleModelLight>>( await DynamicClient.Rules.Get() );

        public async Task<Either<HttpStatusCode, CountryModelLight>> CountryRulesAsync( string code )
            => As<HttpStatusCode, CountryModelLight>( await DynamicClient.Rules.Resource( code ).Get() );
    }
}
