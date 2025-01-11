using KettlePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KettlePlugin
{
    /// <summary>
    /// Класс, представляющий параметр с минимальным, максимальным и текущим значением.
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
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
            }
        }

        /// <summary>
        /// Получает или задает максимально допустимое значение параметра.
        /// </summary>
        public double MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }

        /// <summary>
        /// Получает или задает текущее значение параметра.
        /// При установке значения выполняется проверка на соответствие диапазону.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если значение выходит за пределы допустимого диапазона.</exception>
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
        /// Проверяет текущее значение на соответствие заданным минимальному и максимальному значениям.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если значение выходит за пределы допустимого диапазона.</exception>
        private void Validator()
        {
            if (this.Value < this._minValue || this.Value > this._maxValue)
            {
                throw new ArgumentException("Ошибка минимального/максимального значения!");
            }
        }
    }
}
