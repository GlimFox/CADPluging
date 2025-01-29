using System;
using NUnit.Framework;
using KettlePlugin;

namespace UnitTest.ParametersTest
{
    /// <summary>
    /// Класс Unit тестов для проверки 
    /// корректности работы класса <see cref="Parameter"/>.
    /// </summary>
    [TestFixture]
    public class ParameterTests
    {
        /// <summary>
        /// Позитивный тест геттера MaxValue.
        /// Проверяет работу get у MaxValue.
        /// </summary>
        [Test(Description = "Позитивный тест геттера MaxValue. " +
            "Проверяет работу get у MaxValue.")]
        public void MaxValue_Get_ReturnsCorrectValue()
        {
            var parameter = new Parameter(10, 100);
            Assert.AreEqual(100, parameter.MaxValue);
        }

        /// <summary>
        /// Позитивный тест сеттера MaxValue.
        /// Проверяет работу set у MaxValue.
        /// </summary>
        [Test(Description = "Позитивный тест сеттера MaxValue. " +
            "Проверяет работу set у MaxValue.")]
        public void MaxValue_Set_SetsCorrectValue()
        {
            var parameter = new Parameter(10, 100);
            Assert.AreEqual(100, parameter.MaxValue);
        }

        /// <summary>
        /// Позитивный тест геттера MinValue.
        /// Проверяет работу get у MinValue.
        /// </summary>
        [Test(Description = "Позитивный тест геттера MinValue. " +
            "Проверяет работу get у MinValue.")]
        public void MinValue_Get_ReturnsCorrectValue()
        {
            var parameter = new Parameter(10, 100);

            Assert.AreEqual(10, parameter.MinValue);
        }

        /// <summary>
        /// Позитивный тест сеттера MinValue.
        /// Проверяет работу set у MinValue.
        /// </summary>
        [Test(Description = "Позитивный тест сеттера MinValue. " +
            "Проверяет работу set у MinValue.")]
        public void MinValue_Set_SetsCorrectValue()
        {
            var parameter = new Parameter(10, 100);

            Assert.AreEqual(10, parameter.MinValue);
        }

        /// <summary>
        /// Позитивный тест геттера Value.
        /// Проверяет работу get у Value.
        /// </summary>
        [Test(Description = "Позитивный тест геттера Value. " +
            "Проверяет работу get у Value.")]
        public void Value_Get_ReturnsCorrectValue()
        {
            var parameter = new Parameter(10, 50, 25);

            Assert.AreEqual(25, parameter.Value);
        }

        /// <summary>
        /// Позитивный тест сеттера Value.
        /// Проверяет работу set у Value.
        /// </summary>
        [Test(Description = "Позитивный тест сеттера Value. " +
            "Проверяет работу set у Value.")]
        public void Value_SetWithinMinMax_DoesNotThrowException()
        {
            var parameter = new Parameter(10, 50);

            Assert.DoesNotThrow(() => parameter.Value = 25);
            Assert.AreEqual(25, parameter.Value);
        }

        /// <summary>
        /// Негативный тест Validator.
        /// Проверяет вызов исключения при Value < MinValue.
        /// </summary>
        [Test(Description = "Негативный тест Validator. " +
            "Проверяет вызов исключения при Value < MinValue.")]
        public void Value_SetBelowMinValue_ThrowsArgumentException()
        {
            var parameter = new Parameter(10, 50);

            var ex = Assert.Throws<ArgumentException>
                (() => parameter.Value = 5);
            Assert.That(ex.Message, Is.EqualTo
                ("Ошибка минимального/максимального значения!"));
        }

        /// <summary>
        /// Негативный тест Validator.
        /// Проверяет вызов исключения при Value > MaxValue.
        /// </summary>
        [Test(Description = "Негативный тест Validator. " +
            "Проверяет вызов исключения при Value > MaxValue.")]
        public void Value_SetAboveMaxValue_ThrowsArgumentException()
        {
            var parameter = new Parameter(10, 50);

            var ex = Assert.Throws<ArgumentException>
                (() => parameter.Value = 60);
            Assert.That(ex.Message, Is.EqualTo
                ("Ошибка минимального/максимального значения!"));
        }
    }
}