using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KettlePlugin
{
    /// <summary>
    /// Класс, представляющий набор параметров и операции над ними.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Словарь, содержащий параметры модели, ключ - тип параметра, значение - сам параметр.
        /// </summary>
        private Dictionary<ParameterType, Parameter> _parameter = new Dictionary<ParameterType, Parameter>
        {
            { ParameterType.DiameterBottom, new Parameter (100, 400)},
            { ParameterType.DiameterLid, new Parameter (75, 300)},
            { ParameterType.HeightBase, new Parameter (80, 450)},
            { ParameterType.HeightHandle, new Parameter (70, 150)},
            { ParameterType.Volume, new Parameter (0.63, 56.55)}
        };

        /// <summary>
        /// Геттер и сеттер параметров модели.
        /// </summary>
        public Dictionary<ParameterType, Parameter> AllParameters
        {
            get
            {
                return this._parameter;
            }

            set
            {
                this._parameter = value;
            }
        }

        /// <summary>
        /// Устанавливает параметр в словарь. Если уже существует - обновляется.
        /// </summary>
        /// <param name="parameterType">Тип параметра.</param>
        /// <param name="parameter">Объект параметра.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если параметр не прошел валидацию.</exception>
        public void SetParameter(ParameterType parameterType, Parameter parameter)
        {
            try
            {
                // Инициализация словаря, если он пуст
                if (_parameter == null)
                {
                    _parameter = new Dictionary<ParameterType, Parameter>();
                }

                // Обновление или добавление параметра
                if (_parameter.ContainsKey(parameterType))
                {
                    _parameter[parameterType] = parameter;
                }
                else
                {

                    _parameter.Add(parameterType, parameter);
                }

                // Вызов валидации
                ValidateParameters();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Выполняет валидацию параметров модели.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если параметры не соответствуют ограничениям.</exception>
        private void ValidateParameters()
        {
            string exception = string.Empty;

            // Получаем текущий параметр для валидации
            ParameterType parameterType = this._parameter.ElementAt(0).Key;
            Parameter parameter = this._parameter.ElementAt(0).Value;

            Parameter diameterBottom, diameterLid, height, handleHeight;

            switch (parameterType)
            {
                case ParameterType.DiameterBottom:
                    if (this.AllParameters.TryGetValue(ParameterType.DiameterLid, out diameterLid))
                    {
                        if (parameter.Value < diameterLid.Value)
                        {
                            exception += $"Диаметр дна ({parameter.Value} мм) не может быть меньше диаметра крышки ({diameterLid.Value} мм).\n";
                        }
                    }
                    break;

                case ParameterType.DiameterLid:
                    if (this.AllParameters.TryGetValue(ParameterType.DiameterBottom, out diameterBottom))
                    {
                        if (parameter.Value > diameterBottom.Value)
                        {
                            exception += $"Диаметр крышки ({parameter.Value} мм) не может быть больше диаметра дна ({diameterBottom.Value} мм).\n";
                        }
                    }
                    break;

                case ParameterType.HeightBase:
                    if (this.AllParameters.TryGetValue(ParameterType.HeightHandle, out handleHeight))
                    {
                        if (handleHeight.Value > parameter.Value)
                        {
                            exception += $"Высота ручки ({handleHeight.Value} мм) не может превышать высоту чайника ({parameter.Value} мм).\n";
                        }
                    }
                    break;

                case ParameterType.Volume:
                    if (this.AllParameters.TryGetValue(ParameterType.DiameterBottom, out diameterBottom) &&
                        this.AllParameters.TryGetValue(ParameterType.HeightBase, out height))
                    {
                        double calculatedVolume = Math.PI * Math.Pow(diameterBottom.Value / 2, 2) * height.Value / 1000;
                        if (Math.Abs(parameter.Value - calculatedVolume) > 0.01)
                        {
                            exception += $"Объём ({parameter.Value} л) не соответствует диаметру дна ({diameterBottom.Value} мм) и высоте ({height.Value} мм). Пересчитайте объём.\n";
                        }
                    }
                    break;

                case ParameterType.HeightHandle:
                    if (this.AllParameters.TryGetValue(ParameterType.HeightBase, out height))
                    {
                        if (parameter.Value > height.Value)
                        {
                            exception += $"Высота ручки ({parameter.Value} мм) не может быть больше высоты чайника ({height.Value} мм).\n";
                        }
                    }
                    break;

                default:
                    exception += "Неизвестный параметр для валидации.\n";
                    break;
            }

            if (!string.IsNullOrEmpty(exception))
            {
                throw new ArgumentException(exception);
            }
        }

        /// <summary>
        /// Выполняет расчёты параметров чайника в зависимости от входных данных.
        /// </summary>
        /// <param name="i">Тип расчёта (1 - диаметр дна, 2 - высота, 3 - объём).</param>
        /// <param name="var1">Первое значение (например, объём или диаметр).</param>
        /// <param name="var2">Второе значение (например, высота).</param>
        /// <returns>Результат расчёта.</returns>
        public double Calculations(int i, double var1, double var2)
        {
            double calc = 0;

            // Расчет диаметра дна чайника (bottomDiameter)
            if (i == 1)
            {
                calc = Math.Round(2f * Math.Sqrt(var1 / (Math.PI * var2)) * 1000, 0);
            }

            // Расчет высоты чайника (height)
            if (i == 2)
            {
                calc = Math.Round((var2 / (Math.PI * Math.Pow(var1 / 2, 2))) * 1000000, 0);
            }

            // Расчет объема чайника (volume)
            if (i == 3)
            {
                calc = Math.Round((Math.PI * Math.Pow(var1 / 2, 2) * var2) / 1000000, 2);
            }

            // Возвращаем посчитанное число
            return calc;
        }
    }
}
