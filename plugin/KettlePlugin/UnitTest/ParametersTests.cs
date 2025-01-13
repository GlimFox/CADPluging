using KettlePlugin;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTest.ParametersTest
{
    /// <summary>
    /// Класс Unit тестов для проверки корректности работы класса <see cref="Parameters"/>.
    /// </summary>
    [TestFixture]
    public class ParametersTests
    {
        /// <summary>
        /// Позитивный тест геттера AllParameters.
        /// Проверяет работу get у AllParameters.
        /// </summary>
        [Test(Description = "Позитивный тест геттера AllParameters. Проверяет работу get у AllParameters.")]
        public void AllParameters_Get_ReturnsCorrectDictionary()
        {
            var parameters = new Parameters
            {
                AllParameters = new Dictionary<ParameterType, Parameter>
                {
                    { ParameterType.DiameterBottom, new Parameter (100, 400, 150) }
                }
            };
            Assert.IsNotNull(parameters.AllParameters);
            Assert.AreEqual(1, parameters.AllParameters.Count);
        }

        /// <summary>
        /// Позитивный тест сеттера AllParameters.
        /// Проверяет работу set у AllParameters.
        /// </summary>
        [Test(Description = "Позитивный тест сеттера AllParameters. Проверяет работу set у AllParameters.")]
        public void AllParameters_Set_SetsCorrectDictionary()
        {
            var parameters = new Parameters();
            var newParameters = new Dictionary<ParameterType, Parameter>
            {
                { ParameterType.DiameterBottom, new Parameter (100, 400, 150) }
            };

            parameters.AllParameters = newParameters;

            Assert.AreEqual(newParameters, parameters.AllParameters);
        }

        /// <summary>
        /// Позитивный тест метода SetParameter.
        /// Проверяет работу set для _parameter.
        /// </summary>
        [Test(Description = "Позитивный тест метода SetParameter. Проверяет работу set для _parameter.")]
        public void SetParameter_ValidParameters_SuccessfullyUpdatesParameter()
        {
            var parameters = new Parameters
            {
                AllParameters = new Dictionary<ParameterType, Parameter>
                {
                    { ParameterType.DiameterBottom, new Parameter(100, 400, 150) }
                }
            };
            var newParameter = new Parameter (100, 400, 200);

            parameters.SetParameter(ParameterType.DiameterBottom, newParameter);

            Assert.AreEqual(200, parameters.AllParameters[ParameterType.DiameterBottom].Value);
        }

        /// <summary>
        /// Негативный тест ValidateParameters.
        /// Проверяет вызов исключения при некорректных зависимостях.
        /// </summary>
        [Test(Description = "Негативный тест ValidateParameters. Проверяет вызов исключения при некорректных зависимостях.")]
        public void ValidateParameters_InvalidDependentValues_ThrowsArgumentException()
        {
            var parameters = new Parameters
            {
                AllParameters = new Dictionary<ParameterType, Parameter>
                {
                    { ParameterType.DiameterBottom, new Parameter (100, 400, 150) },
                    { ParameterType.DiameterLid, new Parameter (75, 300, 200 ) }
                }
            };

            var validateMethod = typeof(Parameters).GetMethod("ValidateParameters",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Assert.IsNotNull(validateMethod);

            var ex = Assert.Throws<TargetInvocationException>(() =>
                validateMethod.Invoke(parameters, null));

            Assert.That(ex.InnerException.Message, Does.Contain("Диаметр дна"));
        }
        /// <summary>
        /// Проверяет корректность расчета диаметра дна.
        /// </summary>
        [Test(Description = "Проверяет корректность расчета диаметра дна.")]
        public void Calculations_BottomDiameter_ReturnsCorrectValue()
        {
            var parameters = new Parameters();
            double volume = 5.0;
            double height = 200.0;

            var result = parameters.Calculations(1, volume, height);

            Assert.That(result, Is.GreaterThan(0));
        }

        /// <summary>
        /// Проверяет корректность расчета высоты.
        /// </summary>
        [Test(Description = "Проверяет корректность расчета высоты.")]
        public void Calculations_Height_ReturnsCorrectValue()
        {
            var parameters = new Parameters();
            double bottomDiameter = 150.0;
            double volume = 5.0;

            var result = parameters.Calculations(2, bottomDiameter, volume);

            Assert.That(result, Is.GreaterThan(0));
        }

        /// <summary>
        /// Проверяет корректность расчета объема.
        /// </summary>
        [Test(Description = "Проверяет корректность расчета объема.")]
        public void Calculations_Volume_ReturnsCorrectValue()
        {
            var parameters = new Parameters();
            double bottomDiameter = 150.0;
            double height = 200.0;

            var result = parameters.Calculations(3, bottomDiameter, height);

            Assert.That(result, Is.GreaterThan(0));
        }
    }
}
