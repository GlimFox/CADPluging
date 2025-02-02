﻿using System;

namespace KettlePlugin
{
    /// <summary>
    /// Класс, представляющий параметр с 
    /// минимальным, максимальным и текущим значением.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Минимально допустимое значение параметра.
        /// </summary>
        private double _minValue;

        /// <summary>
        /// Максимально допустимое значение параметра.
        /// </summary>
        private double _maxValue;

        /// <summary>
        /// Текущее значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Получает или задает минимально допустимое значение параметра.
        /// </summary>
        public double MinValue
        {
            get => _minValue;
            private set
            {
                _minValue = value;
            }
        }

        /// <summary>
        /// Получает или задает максимально допустимое значение параметра.
        /// </summary>
        public double MaxValue
        {
            get => _maxValue;
            private set
            {
                _maxValue = value;
            }
        }

        /// <summary>
        /// Получает или задает текущее значение параметра.
        /// При установке значения проверяется соответствие диапазону.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если 
        /// значение выходит за пределы допустимого диапазона.</exception>
        public double Value
        {
            get
            {
                return this._value;
            }

            set
            {
                try
                {
                    this._value = value;
                    this.Validator();
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }
        }

        /// <summary>
        /// Конструктор параметра.
        /// Только для минимального и максимального значений.
        /// </summary>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        public Parameter(double minValue, double maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// Конструктор параметра.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="value"></param>
        public Parameter(double minValue, double maxValue, double value)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Value = value;
        }

        /// <summary>
        /// Проверяет текущее значение на соответствие заданным 
        /// минимальному и максимальному значениям.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если 
        /// значение выходит за пределы допустимого диапазона.</exception>
        private void Validator()
        {
            if (this.Value < this._minValue || this.Value > this._maxValue)
            {
                throw new ArgumentException
                    ("Ошибка минимального/максимального значения!");
            }
        }
    }
}
