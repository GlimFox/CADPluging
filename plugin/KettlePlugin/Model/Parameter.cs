using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KettlePlugin
{
    public class Parameter
    {
        private double _minValue;

        private double _maxValue;

        private double _value;

        public double MinValue
        {
            get
            {
                return this._minValue;
            }

            set
            {
                this._minValue = value;
            }
        }

        public double MaxValue
        {
            get
            {
                return this._maxValue;
            }

            set
            {
                this._maxValue = value;
            }
        }

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

        private void Validator()
        {
            if (this.Value < this._minValue || this.Value > this._maxValue)
            {
                throw new ArgumentException("Ошибка минимального/максимального значения!");
            }
        }
    }
}
