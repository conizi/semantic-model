using System;
using Conizi.Model.Core.Tools;
using Conizi.Model.Shared.Entities;
using Conizi.Model.Test.Library.Entities;
using Conizi.Model.Transport.Truck.Groupage.Forwarding;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Conizi.Model.UnitTests.Conversion
{
    public class DeserializerTests
    {
        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void SerializerInvalidModel_AssertJsonSerializationException()
        {
            var m = new InvalidModel();

            var result = Converter.Serialize(m, ignoreValidation: false);

            Assert.True(result.HasValidationErrors);
            Assert.Equal("Invalid URI: The format of the URI could not be determined.", result.ValidationErrors[1]);
        }

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void DeserializerBasicModel_AssertValidDeserialization()
        {
            // Simple test model
            var m = new TestModel
            {
                Receiver = new EdiPartnerIdentification
                {
                    EdiId = "CONIZIVK"
                },
                Sender = new EdiPartnerIdentification
                {
                    EdiId = "FLELOVK",
                },
                TestReceivingPartner = new EdiPartnerIdentification
                {
                    PartnerId = "2323",
                    Name = "Fleetboard Logistics",
                    Street = "Am Alten Bahnhof",
                    HouseNumber = "8",
                    City = "Volkach"
                },
                TestShippingPartner = new EdiPartnerIdentification
                {
                    PartnerId = "1234"
                },
                Network = new EdiNetwork
                {
                    NetworkId = "CL"
                },
                TestFileContent = new EdiFileContent
                {
                    FileName = "MyFuzzyFile.jpeg",
                    ContentType = "image/jpeg",
                    FileReference = new EdiFileReference
                    {
                        AbsoluteUri = "http://imnotexistend.org",
                        UriValidFrom = DateTime.Today,
                        UriValidTo = DateTime.Now.AddDays(5)
                    }
                }
            };

            var result = Converter.Serialize(m, ignoreValidation: false);
            Assert.False(result.HasValidationErrors);

            var dm = Converter.Deserialize<TestModel>(result.ToString());
            Assert.IsType<TestModel>(dm);
        }

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void DeserializerBasicModel_AssertValidDeserializationOfDates()
        {
            const string dateTimeString = "2019-03-11 15:42:18";

            // Simple test model
            var m = new TestModel
            {
                Receiver = new EdiPartnerIdentification
                {
                    EdiId = "CONIZIVK"
                },
                Sender = new EdiPartnerIdentification
                {
                    EdiId = "FLELOVK",
                },
                TestReceivingPartner = new EdiPartnerIdentification
                {
                    PartnerId = "2323",
                    Name = "Fleetboard Logistics",
                    Street = "Am Alten Bahnhof",
                    HouseNumber = "8",
                    City = "Volkach"
                },
                TestShippingPartner = new EdiPartnerIdentification
                {
                    PartnerId = "1234"
                },
                Network = new EdiNetwork
                {
                    NetworkId = "CL"
                },
                TestDateTime = DateTime.Parse(dateTimeString),
                TestDateOnly = DateTime.Parse("2019-04-11")
            };

            var result = Converter.Serialize(m);
            Assert.False(result.HasValidationErrors);

            var dm = Converter.Deserialize<TestModel>(result.ToString());
            Assert.IsType<TestModel>(dm);
            Assert.Equal(DateTime.Parse(dateTimeString), dm.TestDateTime);
        }

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void DeserializerBasicModelUnTyped_AssertValid()
        {
            const string dateTimeString = "2020-03-04 15:42:18";

            // Simple test model
            var m = new TourEvent()
            {
                Receiver = new EdiPartnerIdentification
                {
                    EdiId = "CONIZIVK"
                },
                Sender = new EdiPartnerIdentification
                {
                    EdiId = "FLELOVK",
                },
                TourId = "4711",
                Stop = new EdiStopSpecificEvent
                {
                    EventDateTime = DateTime.Parse(dateTimeString),
                    StopId = "123213213"
                }
            };
               

            var result = Converter.Serialize(m);
            Assert.False(result.HasValidationErrors);

            var iModel = Converter.Deserialize(result.ToString());
            Assert.IsType<TourEvent>(iModel);

            Assert.True(iModel.ModelType == typeof(TourEvent));

        }


        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void DeserializerBasicModel_AssertValidDeserializationWithXProps()
        {
            // Simple test model
            var m = new TestModel
            {
                Receiver = new EdiPartnerIdentification
                {
                    EdiId = "CONIZIVK"
                },
                Sender = new EdiPartnerIdentification
                {
                    EdiId = "FLELOVK",
                },
                TestReceivingPartner = new EdiPartnerIdentification
                {
                    PartnerId = "2323",
                    Name = "Fleetboard Logistics",
                    Street = "Am Alten Bahnhof",
                    HouseNumber = "8",
                    City = "Volkach"
                },
                TestShippingPartner = new EdiPartnerIdentification
                {
                    PartnerId = "1234"
                },
                Network = new EdiNetwork
                {
                    NetworkId = "CL"
                },
                Services = new EdiServices
                {
                    TimeOptions = new EdiTimeOptions
                    {
                        Evening = new EdiEvening
                        {
                            Date = DateTime.Now,
                            TimeUntil = "19:00:00",
                            TimeFrom = "18:00:00",
                        }
                    }
                },
                TestFileContent = new EdiFileContent
                {
                    FileName = "MyFuzzyFile.jpeg",
                    ContentType = "image/jpeg",
                    FileReference = new EdiFileReference
                    {
                        AbsoluteUri = "http://imnotexistend.org",
                        UriValidFrom = DateTime.Today,
                        UriValidTo = DateTime.Now.AddDays(5)
                    }
                }
            };

            m.TestReceivingPartner.AddPatternProperty("x-park-lane", 37);

            m.Receiver.AddPatternProperty("x-conizi-special", "whats up");
            m.Services.TimeOptions.Evening.AddPatternProperty("x-dawn-service", "X");
            var result = Converter.Serialize(m);
            Assert.False(result.HasValidationErrors);

            var dm = Converter.Deserialize<TestModel>(result.ToString());
            var prop1 = dm.Receiver.GetPatternPropertyValue("x-conizi-special");
            Assert.Equal("whats up", prop1.ToString());

            var prop2 = dm.TestReceivingPartner.GetPatternPropertyValue("x-park-lane");
            Assert.IsType<JValue>(prop2);

            var prop3 = dm.Services.TimeOptions.Evening.GetPatternPropertyValue("x-dawn-service");

            Assert.Equal(JTokenType.Integer, ((JValue) prop2).Type);
            Assert.Equal(37, ((JValue) prop2).Value<Int32>());
            Assert.Equal("X", prop3.Value<string>());
        }
    }
}