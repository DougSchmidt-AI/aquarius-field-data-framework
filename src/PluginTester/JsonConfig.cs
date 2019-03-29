using System;
using System.Collections.Generic;
using System.Globalization;
using FieldDataPluginFramework.Context;
using FieldDataPluginFramework.DataModel;
using FieldDataPluginFramework.DataModel.ChannelMeasurements;
using FieldDataPluginFramework.DataModel.CrossSection;
using FieldDataPluginFramework.DataModel.DischargeActivities;
using FieldDataPluginFramework.DataModel.LevelSurveys;
using FieldDataPluginFramework.DataModel.Meters;
using FieldDataPluginFramework.DataModel.PickLists;
using FieldDataPluginFramework.DataModel.Readings;
using FieldDataPluginFramework.DataModel.Verticals;
using ServiceStack;
using ServiceStack.Text;

namespace PluginTester
{
    public class JsonConfig
    {
        public static void Configure()
        {
            JsConfig.ExcludeTypeInfo = true;
            JsConfig.DateHandler = DateHandler.ISO8601DateTime;
            JsConfig.IncludeNullValues = true;
            JsConfig.IncludeNullValuesInDictionaries = true;

            JsConfig<DateTimeOffset>.SerializeFn = SerializeDateTimeOffset;
            JsConfig<DateTimeOffset?>.SerializeFn = offset => offset.HasValue
                ? SerializeDateTimeOffset(offset.Value)
                : string.Empty;

            JsConfig<DateTimeOffset>.DeSerializeFn = DeserializeDateTimeOffset;
            JsConfig<DateTimeOffset?>.DeSerializeFn = text => !string.IsNullOrEmpty(text)
                ? DeserializeDateTimeOffset(text)
                : (DateTimeOffset?) null;

            ConfigureSpecialParsers();
        }

        private static string SerializeDateTimeOffset(DateTimeOffset item)
        {
            return item.ToString("O");
        }

        private static DateTimeOffset DeserializeDateTimeOffset(string text)
        {
            return DateTimeOffset.ParseExact(text, "O", CultureInfo.InvariantCulture);
        }

        public class JsonParser
        {
            public JsonObject JsonObject { get; }
            public string JsonText { get; }

            public JsonParser(string jsonText)
            {
                JsonText = jsonText;
                JsonObject = JsonObject.Parse(JsonText);
            }

            public bool HasProperty(string propertyName)
            {
                return !string.IsNullOrEmpty(JsonObject[propertyName]);
            }

            public T GetObject<T>(string propertyName) where T : class
            {
                var jsonText = JsonObject
                    .Child(propertyName);

                return jsonText?.FromJson<T>();
            }

            public T Get<T>(string propertyName)
            {
                return JsonObject[propertyName]
                    .FromJson<T>();
            }

            public void AddItems<T>(string propertyName, ICollection<T> collection)
            {
                foreach (var item in GetObject<List<T>>(propertyName))
                {
                    collection.Add(item);
                }
            }
        }

        private static void Configure<T>(Func<JsonParser, T> itemFactory, Action<JsonParser, T> itemAction = null) where T : class
        {
            JsConfig<T>.RawDeserializeFn = jsonText =>
            {
                var parser = new JsonParser(jsonText);

                var item = itemFactory(parser);

                itemAction?.Invoke(parser, item);

                return item;
            };
        }

        private static void ConfigureSpecialParsers()
        {
            Configure(json => new DateTimeInterval(
                json.Get<DateTimeOffset>(nameof(DateTimeInterval.Start)),
                json.Get<DateTimeOffset>(nameof(DateTimeInterval.End))));

            Configure(json => InternalConstructor<LocationInfo>.Invoke(
                json.Get<string>(nameof(LocationInfo.LocationName)),
                json.Get<string>(nameof(LocationInfo.LocationIdentifier)),
                json.Get<long>(nameof(LocationInfo.LocationId)),
                json.Get<Guid>(nameof(LocationInfo.UniqueId)),
                json.Get<TimeSpan>(nameof(LocationInfo.UtcOffset)).TotalHours));

            Configure(json => InternalConstructor<FieldVisitInfo>.Invoke(
                    json.GetObject<LocationInfo>(nameof(FieldVisitInfo.LocationInfo)),
                    json.GetObject<FieldVisitDetails>(nameof(FieldVisitInfo.FieldVisitDetails))),
                (json, item) =>
                {
                    json.AddItems(nameof(item.DischargeActivities), item.DischargeActivities);
                    json.AddItems(nameof(item.ControlConditions), item.ControlConditions);
                    json.AddItems(nameof(item.CrossSectionSurveys), item.CrossSectionSurveys);
                    json.AddItems(nameof(item.LevelSurveys), item.LevelSurveys);
                    json.AddItems(nameof(item.Readings), item.Readings);
                });

            Configure(json => new FieldVisitDetails(
                    json.GetObject<DateTimeInterval>(nameof(FieldVisitDetails.FieldVisitPeriod)))
                {
                    Party = json.Get<string>(nameof(FieldVisitDetails.Party)),
                    Comments = json.Get<string>(nameof(FieldVisitDetails.Comments)),
                    Weather = json.Get<string>(nameof(FieldVisitDetails.Weather)),
                    CollectionAgency = json.Get<string>(nameof(FieldVisitDetails.CollectionAgency)),
                    CompletedVisitActivities = json.GetObject<CompletedVisitActivities>(nameof(FieldVisitDetails.CompletedVisitActivities))
                });

            Configure(json => new Measurement(
                json.Get<double>(nameof(Measurement.Value)),
                json.Get<string>(nameof(Measurement.UnitId))));

            Configure(json => new MeasurementDevice(
                json.Get<string>(nameof(MeasurementDevice.Manufacturer)),
                json.Get<string>(nameof(MeasurementDevice.Model)),
                json.Get<string>(nameof(MeasurementDevice.SerialNumber))));

            Configure(json => new Reading(
                    json.Get<string>(nameof(Reading.ParameterId)),
                    json.GetObject<Measurement>(nameof(Reading.Measurement)))
                {
                    Comments = json.Get<string>(nameof(Reading.Comments)),
                    DateTimeOffset = json.Get<DateTimeOffset?>(nameof(Reading.DateTimeOffset)),
                    GroundWaterMeasurementDetails = json.GetObject<GroundWaterMeasurementDetails>(nameof(Reading.GroundWaterMeasurementDetails)),
                    MeasurementDevice = json.GetObject<MeasurementDevice>(nameof(Reading.MeasurementDevice)),
                    Method = json.Get<string>(nameof(Reading.Method)),
                    Publish = json.Get<bool>(nameof(Reading.Publish)),
                    ReadingQualifier = json.GetObject<ReadingQualifierPickList>(nameof(Reading.ReadingQualifier)),
                    ReadingType = json.Get<ReadingType>(nameof(Reading.ReadingType)),
                    ReferencePointName = json.Get<string>(nameof(Reading.ReferencePointName)),
                    SubLocation = json.Get<string>(nameof(Reading.SubLocation)),
                    Uncertainty = json.Get<double?>(nameof(Reading.Uncertainty)),
                });

            Configure(json => new CrossSectionPoint(
                    json.Get<int>(nameof(CrossSectionPoint.PointOrder)),
                    json.Get<double>(nameof(CrossSectionPoint.Distance)),
                    json.Get<double>(nameof(CrossSectionPoint.Elevation)))
                {
                    Comments = json.Get<string>(nameof(CrossSectionPoint.Comments)),
                    Depth = json.Get<double>(nameof(CrossSectionPoint.Depth))
                });

            Configure(json => new CrossSectionSurvey(
                    json.GetObject<DateTimeInterval>(nameof(CrossSectionSurvey.SurveyPeriod)),
                    json.Get<string>(nameof(CrossSectionSurvey.ChannelName)),
                    json.Get<string>(nameof(CrossSectionSurvey.RelativeLocationName)),
                    json.Get<string>(nameof(CrossSectionSurvey.DistanceUnitId)),
                    json.Get<StartPointType>(nameof(CrossSectionSurvey.StartPoint)))
                {
                    Comments = json.Get<string>(nameof(CrossSectionSurvey.Comments)),
                    Party = json.Get<string>(nameof(CrossSectionSurvey.Party)),
                    StageMeasurement = json.GetObject<Measurement>(nameof(CrossSectionSurvey.StageMeasurement)),
                    CrossSectionPoints = json.Get<List<CrossSectionPoint>>(nameof(CrossSectionSurvey.CrossSectionPoints))
                });

            Configure(json => new LevelSurvey(
                    json.Get<string>(nameof(LevelSurvey.OriginReferencePointName)))
                {
                    Comments = json.Get<string>(nameof(LevelSurvey.Comments)),
                    Method = json.Get<string>(nameof(LevelSurvey.Method)),
                    Party = json.Get<string>(nameof(LevelSurvey.Party)),
                    LevelSurveyMeasurements = json.Get<List<LevelSurveyMeasurement>>(nameof(LevelSurvey.LevelSurveyMeasurements))
                });

            Configure(json => new LevelSurveyMeasurement(
                    json.Get<string>(nameof(LevelSurveyMeasurement.ReferencePointName)),
                    json.Get<DateTimeOffset>(nameof(LevelSurveyMeasurement.MeasurementTime)),
                    json.Get<double>(nameof(LevelSurveyMeasurement.MeasuredElevation)))
                {
                    Comments = json.Get<string>(nameof(LevelSurveyMeasurement.Comments))
                });

            Configure(json => new DischargeActivity(
                    json.GetObject<DateTimeInterval>(nameof(DischargeActivity.MeasurementPeriod)),
                    json.GetObject<Measurement>(nameof(DischargeActivity.Discharge)))
                {
                    Party = json.Get<string>(nameof(DischargeActivity.Party)),
                    MeasurementId = json.Get<string>(nameof(DischargeActivity.MeasurementId)),
                    MeanIndexVelocity = json.GetObject<Measurement>(nameof(DischargeActivity.MeanIndexVelocity)),
                    Comments = json.Get<string>(nameof(DischargeActivity.Comments)),
                    ShowInDataCorrection = json.Get<bool>(nameof(DischargeActivity.ShowInDataCorrection)),
                    ShowInRatingDevelopment = json.Get<bool>(nameof(DischargeActivity.ShowInRatingDevelopment)),
                    PreventAutomaticPublishing = json.Get<bool>(nameof(DischargeActivity.PreventAutomaticPublishing)),
                    AdjustmentType = json.Get<AdjustmentType?>(nameof(DischargeActivity.AdjustmentType)),
                    AdjustmentAmount = json.Get<double?>(nameof(DischargeActivity.AdjustmentAmount)),
                    ReasonForAdjustment = json.Get<ReasonForAdjustmentType?>(nameof(DischargeActivity.ReasonForAdjustment)),
                    ManuallyCalculatedMeanGageHeight = json.GetObject<Measurement>(nameof(DischargeActivity.ManuallyCalculatedMeanGageHeight)),
                    MeanGageHeightDifferenceDuringVisit = json.GetObject<Measurement>(nameof(DischargeActivity.MeanGageHeightDifferenceDuringVisit)),
                    MeanGageHeightDurationHours = json.Get<double?>(nameof(DischargeActivity.MeanGageHeightDurationHours)),
                },
                (json, item) =>
                {
                    json.AddItems(nameof(item.GageHeightMeasurements), item.GageHeightMeasurements);
                    json.AddItems(nameof(item.ChannelMeasurements), item.ChannelMeasurements);
                });

            Configure(json => new GageHeightMeasurement(
                json.GetObject<Measurement>(nameof(GageHeightMeasurement.GageHeight)),
                json.Get<DateTimeOffset>(nameof(GageHeightMeasurement.MeasurementTime)),
                json.Get<bool>(nameof(GageHeightMeasurement.Include))));

            Configure(json => json.HasProperty(nameof(ManualGaugingDischargeSection.VelocityObservationMethod))
                ? (ChannelMeasurementBase) json.JsonText.FromJson<ManualGaugingDischargeSection>()
                : json.JsonText.FromJson<AdcpDischargeSection>());

            Configure(json => json.HasProperty(nameof(IceCoveredData.WaterSurfaceToBottomOfIce))
                ? (MeasurementConditionData)json.JsonText.FromJson<IceCoveredData>()
                : json.JsonText.FromJson<OpenWaterData>());

            Configure(json => new MeterCalibration
                {
                    SerialNumber = json.Get<string>(nameof(MeterCalibration.SerialNumber)),
                    Manufacturer = json.Get<string>(nameof(MeterCalibration.Manufacturer)),
                    Model = json.Get<string>(nameof(MeterCalibration.Model)),
                    MeterType = json.Get<MeterType>(nameof(MeterCalibration.MeterType)),
                    Configuration = json.Get<string>(nameof(MeterCalibration.Configuration)),
                    FirmwareVersion = json.Get<string>(nameof(MeterCalibration.FirmwareVersion)),
                    SoftwareVersion = json.Get<string>(nameof(MeterCalibration.SoftwareVersion))
                },
                (json, item) => json.AddItems(nameof(item.Equations), item.Equations));

            Configure(json => new VelocityObservation
                {
                    MeterCalibration = json.GetObject<MeterCalibration>(nameof(VelocityObservation.MeterCalibration)),
                    VelocityObservationMethod = json.Get<PointVelocityObservationType?>(nameof(VelocityObservation.VelocityObservationMethod)),
                    DeploymentMethod = json.Get<DeploymentMethodType?>(nameof(VelocityObservation.DeploymentMethod)),
                    MeanVelocity = json.Get<double>(nameof(VelocityObservation.MeanVelocity))
                },
                (json, item) => json.AddItems(nameof(item.Observations), item.Observations));

            Configure(json => new ManualGaugingDischargeSection(
                    json.GetObject<DateTimeInterval>(nameof(ManualGaugingDischargeSection.MeasurementPeriod)),
                    json.Get<string>(nameof(ManualGaugingDischargeSection.ChannelName)),
                    json.GetObject<Measurement>(nameof(ManualGaugingDischargeSection.Discharge)),
                    json.Get<string>(nameof(ManualGaugingDischargeSection.DistanceUnitId)),
                    json.Get<string>(nameof(ManualGaugingDischargeSection.AreaUnitId)),
                    json.Get<string>(nameof(ManualGaugingDischargeSection.VelocityUnitId))),
                (json, item) =>
                {
                    item.Comments = json.Get<string>(nameof(item.Comments));
                    item.Party = json.Get<string>(nameof(item.Party));

                    item.WidthValue = json.GetObject<Measurement>(nameof(item.Width))?.Value;
                    item.AreaValue = json.GetObject<Measurement>(nameof(item.Area))?.Value;
                    item.VelocityAverageValue = json.GetObject<Measurement>(nameof(item.VelocityAverage))?.Value;

                    item.DischargeMethod = json.Get<DischargeMethodType>(nameof(item.DischargeMethod));
                    item.StartPoint = json.Get<StartPointType>(nameof(item.StartPoint));
                    item.VelocityObservationMethod = json.Get<PointVelocityObservationType>(nameof(item.VelocityObservationMethod));
                    item.MeterSuspension = json.Get<MeterSuspensionType>(nameof(item.MeterSuspension));
                    item.DeploymentMethod = json.Get<DeploymentMethodType>(nameof(item.DeploymentMethod));

                    json.AddItems(nameof(item.Verticals), item.Verticals);
                });

            Configure(json => new AdcpDischargeSection(
                    json.GetObject<DateTimeInterval>(nameof(AdcpDischargeSection.MeasurementPeriod)),
                    json.Get<string>(nameof(AdcpDischargeSection.ChannelName)),
                    json.GetObject<Measurement>(nameof(AdcpDischargeSection.Discharge)),
                    json.Get<string>(nameof(AdcpDischargeSection.AdcpDeviceType)),
                    json.Get<string>(nameof(AdcpDischargeSection.DistanceUnitId)),
                    json.Get<string>(nameof(AdcpDischargeSection.AreaUnitId)),
                    json.Get<string>(nameof(AdcpDischargeSection.VelocityUnitId))),
                (json, item) =>
                {
                    item.Comments = json.Get<string>(nameof(item.Comments));
                    item.Party = json.Get<string>(nameof(item.Party));

                    item.WidthValue = json.GetObject<Measurement>(nameof(item.Width))?.Value;
                    item.AreaValue = json.GetObject<Measurement>(nameof(item.Area))?.Value;
                    item.VelocityAverageValue = json.GetObject<Measurement>(nameof(item.VelocityAverage))?.Value;

                    item.NumberOfTransects = json.Get<int?>(nameof(item.NumberOfTransects));
                    item.PercentOfDischargeMeasured = json.Get<double?>(nameof(item.PercentOfDischargeMeasured));
                    item.MagneticVariation = json.Get<double?>(nameof(item.MagneticVariation));
                    item.DischargeCoefficientVariation = json.Get<double?>(nameof(item.DischargeCoefficientVariation));
                    item.TransducerDepth = json.Get<double?>(nameof(item.TransducerDepth));
                    item.TopEstimateExponent = json.Get<double?>(nameof(item.TopEstimateExponent));
                    item.TopEstimateMethod = json.GetObject<TopEstimateMethodPickList>(nameof(item.TopEstimateMethod));
                    item.BottomEstimateExponent = json.Get<double?>(nameof(item.BottomEstimateExponent));
                    item.BottomEstimateMethod = json.GetObject<BottomEstimateMethodPickList>(nameof(item.BottomEstimateMethod));
                    item.MeasurementDevice = json.Get<MeasurementDevice>(nameof(item.MeasurementDevice));
                    item.NavigationMethod = json.GetObject<NavigationMethodPickList>(nameof(item.NavigationMethod));
                    item.FirmwareVersion = json.Get<string>(nameof(item.FirmwareVersion));
                    item.SoftwareVersion = json.Get<string>(nameof(item.SoftwareVersion));
                    item.DepthReference = json.Get<DepthReferenceType>(nameof(item.DepthReference));
                    item.DeploymentMethod = json.Get<AdcpDeploymentMethodType>(nameof(item.DeploymentMethod));
                    item.MeterSuspension = json.Get<AdcpMeterSuspensionType>(nameof(item.MeterSuspension));
                });

            Configure(json => new BottomEstimateMethodPickList(json.Get<string>(nameof(PickList.IdOrDisplayName))));
            Configure(json => new ControlCodePickList(json.Get<string>(nameof(PickList.IdOrDisplayName))));
            Configure(json => new NavigationMethodPickList(json.Get<string>(nameof(PickList.IdOrDisplayName))));
            Configure(json => new ReadingQualifierPickList(json.Get<string>(nameof(PickList.IdOrDisplayName))));
            Configure(json => new TopEstimateMethodPickList(json.Get<string>(nameof(PickList.IdOrDisplayName))));
            Configure(json => new ControlConditionPickList(json.Get<string>(nameof(PickList.IdOrDisplayName))));
        }
    }
}
