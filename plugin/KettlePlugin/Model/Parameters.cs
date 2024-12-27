using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KettlePlugin
{
    public class Parameters
    {
        private Dictionary<ParameterType, Parameter> _parameter { get; set; }

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
