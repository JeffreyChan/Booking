﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Extensions;
using Xunit;
using System.Web.Mvc;
using Ploeh.AutoFixture.Xunit;
using Ploeh.Samples.Booking.DomainModel;
using Moq;

namespace Ploeh.Samples.Booking.WebModel.UnitTest
{
    public class DisabledDatesControllerTests
    {
        [Theory, AutoWebData]
        public void SutIsController(DisabledDatesController sut)
        {
            Assert.IsAssignableFrom<IController>(sut);
        }

        [Theory, AutoWebData]
        public void GetReturnsCorrectDataType(DisabledDatesController sut,
            int year,
            int month)
        {
            JsonResult actual = sut.Get(year, month);
            Assert.IsAssignableFrom<string[]>(actual.Data);
        }

        [Theory, AutoWebData]
        public void GetReturnsCorrectJsonBehavior(DisabledDatesController sut,
            int year,
            int month)
        {
            var actual = sut.Get(year, month);
            Assert.Equal(JsonRequestBehavior.AllowGet, actual.JsonRequestBehavior);
        }

        [Theory, AutoWebData]
        public void GetReturnsCorrectModel(
            [Frozen]Mock<IReader<Month, IEnumerable<string>>> readerStub,
            string[] expected,
            DisabledDatesController sut,
            int year,
            int month)
        {
            readerStub
                .Setup(r => r.Query(It.Is<Month>(m => m.Year == year && m.MonthNumber == month)))
                .Returns(expected);
            var actual = sut.Get(year, month);
            Assert.Equal(expected, actual.Data);
        }
    }
}
