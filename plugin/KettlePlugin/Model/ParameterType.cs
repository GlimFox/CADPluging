using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KettlePlugin
{
    /// <summary>
    /// Перечисление, представляющее типы параметров модели.
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// Диаметр дна модели.
        /// </summary>
        DiameterBottom,

        /// <summary>
        /// Диаметр крышки модели.
        /// </summary>
        DiameterLid,

        /// <summary>
        /// Высота ручки модели.
        /// </summary>
        HeightHandle,

        /// <summary>
        /// Высота основания модели.
        /// </summary>
        HeightBase,

        /// <summary>
        /// Объём модели.
        /// </summary>
        Volume
    }
}
